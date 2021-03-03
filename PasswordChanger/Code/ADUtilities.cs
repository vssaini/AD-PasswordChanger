using System;
using System.DirectoryServices;
using System.Text;
using System.Text.RegularExpressions;
using PasswordChanger.Properties;

namespace PasswordChanger.Code
{
    /// <summary>
    /// Provide different methods for performing tasks with active directory.
    /// </summary>
    class ADUtilities
    {
        /// <summary>
        /// The LDAP path root
        /// </summary>
        private const string LDAPPathRoot = "LDAP://";

        private static AccountPolicy _policy;
        public static DirectoryEntry DirEntry { get; set; }

        /// <summary>
        /// Get AD policy and show it to end user.
        /// </summary>
        public static string GetADPolicyDetails()
        {
            // Retrieve AD policy and set values in the textbox
            _policy = GetAccountPolicy(Settings.Default.Domain, Settings.Default.AdminUser,
                Settings.Default.AdminPass);

            var maxPwdAge = _policy.MaximumPasswordAge != null
                ? string.Format("{0} days", ((TimeSpan)_policy.MaximumPasswordAge).Days)
                : "Not Defined";
            var minPwdAge = _policy.MinimumPasswordAge != null
                ? string.Format("{0} days", ((TimeSpan)_policy.MinimumPasswordAge).Days)
                : "Not Defined";
            var minPwdLength = _policy.MinimumPasswordLength != null
                ? string.Format("{0} characters", _policy.MinimumPasswordLength.Value) : "Not Defined";
            var lockoutDuration = _policy.LockoutDuration != null ? string.Format("{0} days", ((TimeSpan)_policy.LockoutDuration).Days) : "Not Defined";
            var lockoutObsWindow = _policy.LockoutObservationWindow != null ? string.Format("{0} days", ((TimeSpan)_policy.LockoutObservationWindow).Days) : "Not Defined";
            var lockoutThreshold = _policy.LockoutThreshold != null ? _policy.LockoutThreshold.Value.ToString() : "Not Defined";
            var pwdHistoryLength = _policy.PasswordHistoryLength != null ? _policy.PasswordHistoryLength.Value.ToString() : "Not Defined";
            var pwdComplex = _policy.PasswordProperties.HasValue &&
                             _policy.PasswordProperties.Value.Equals(PasswordPolicy.DomainPasswordComplex)
                ? "Enabled"
                : "Disabled";


            var builder = new StringBuilder();
            builder.AppendFormat("Maximum password age: {0}", maxPwdAge).AppendLine();
            builder.AppendFormat("Minimum password age: {0}", minPwdAge).AppendLine();
            builder.AppendFormat("Minimum password length: {0}", minPwdLength).AppendLine();
            builder.AppendFormat("Lockout duration: {0}", lockoutDuration).AppendLine();
            builder.AppendFormat("Lockout observation window: {0}", lockoutObsWindow).AppendLine();
            builder.AppendFormat("Lockout threshold: {0}", lockoutThreshold).AppendLine();
            builder.AppendFormat("Password history length: {0}", pwdHistoryLength).AppendLine();
            builder.AppendFormat("Password must meet complexity requirements: {0}", pwdComplex);

            return builder.ToString();
        }

        /// <summary>
        /// Validates the password against the domain's password policy
        /// </summary>
        /// <param name="password">The password to validate</param>
        /// <param name="samAccountName">The user's sAMAccountName</param>
        /// <param name="displayName">The user's display name</param>
        /// <returns>A boolean indicating whether the password is valid</returns>
        public static bool ValidatePassword(string password, string samAccountName, string displayName)
        {
            if (_policy == null)
                _policy = GetAccountPolicy(Settings.Default.Domain, Settings.Default.AdminUser,
               Settings.Default.AdminPass);

            var minPassLength = _policy.MinimumPasswordLength;
            // Validate the password length
            if (minPassLength > 0)
            {
                if (string.IsNullOrEmpty(password))
                    return false;

                if (password.Length < minPassLength)
                    return false;
            }

            // Validate complexity requirements
            // The requirements are detailed here: http://technet.microsoft.com/en-us/library/cc786468%28WS.10%29.aspx
            if (_policy.PasswordProperties.HasValue && _policy.PasswordProperties.Value.Equals(PasswordPolicy.DomainPasswordComplex))
            {
                // If the password is empty, return false
                if (string.IsNullOrEmpty(password))
                    return false;

                // If the password contains the sAMAccountName, return false
                if (!string.IsNullOrEmpty(samAccountName) && password.ToUpper().Contains(samAccountName.ToUpper()))
                    return false;

                // If the password contains any part of the display name, return false
                if (!string.IsNullOrEmpty(displayName))
                {
                    var displayNameParts = displayName.Split(new[] { ',', '.', '-', '‐', '_', ' ', '#', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    var upperPassword = password.ToUpper();

                    foreach (var part in displayNameParts)
                    {
                        var trimmedPart = part.Trim();

                        // The part must be more than 3 characters long
                        if (trimmedPart.Length >= 3 && upperPassword.Contains(trimmedPart.ToUpper()))
                            return false;
                    }
                }

                // Validate the password against the following regex patterns
                var patterns = new[] 
                { 
                    @"\p{Lu}", // Uppercase characters of European languages (A through Z, with diacritic marks, Greek and Cyrillic characters)
                    @"\p{Ll}", // Lowercase characters of European languages (a through z, sharp-s, with diacritic marks, Greek and Cyrillic characters)
                    @"[0-9]", // Base 10 digits (0 through 9)
                    @"[~!@#$%^&*_\-+=`|\\(){}\[\]:;""'<>,\.?/]", // Nonalphanumeric characters: ~!@#$%^&*_-+=`|\(){}[]:;"'<>,.?/
                    @"\p{Lo}" // Any Unicode character that is categorized as an alphabetic character but is not uppercase or lowercase. This includes Unicode characters from Asian languages.
                };

                // Note: Regex Unicode Categories explained here: http://msdn.microsoft.com/en-us/library/20bw873z.aspx#SupportedUnicodeGeneralCategories

                // The password should satisfy at least 3 of the above patterns
                var matchedGroups = 0;

                // Test the expressions
                foreach (var pattern in patterns)
                {
                    if (Regex.IsMatch(password, pattern))
                        matchedGroups++;
                }

                // If the password didn't satisfy at least 3 patterns, return false
                if (matchedGroups < 3)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Resets the user password
        /// </summary>
        /// <param name="userEntry">The DirectoryEntry object wiht SamAccount details.</param>
        /// <param name="sAMAccountName">The user sAMAccountName</param>
        /// <param name="newPassword">The new password</param>
        /// <param name="askToChangePassword">Ask to change password at next login</param>
        /// <param name="unlockAccount">Unlock user account</param>
        public static void ResetUserPassword(DirectoryEntry userEntry, string sAMAccountName, string newPassword, bool askToChangePassword, bool unlockAccount)
        {
            // Set the user password
            userEntry.Invoke("SetPassword", newPassword);

            // Set "Ask to change password at next login"
            if (askToChangePassword)
                userEntry.Properties["pwdLastSet"].Value = 0;

            // Unlock account if required
            if (unlockAccount)
                userEntry.Properties["lockoutTime"].Value = 0;

            // Commit changes
            userEntry.CommitChanges();
        }

        /// <summary>
        /// Get displayName of user as per SamAccountName.
        /// </summary>
        public static string GetDisplayName(string samAccountName, out DirectoryEntry dirEntry)
        {
            var displayName = string.Empty;

            // Create a directory searcher to retrieve the password policy
            using (var ds = new DirectorySearcher(DirEntry))
            {
                ds.Filter = string.Format("(SAMAccountName={0})", samAccountName);
                ds.PropertiesToLoad.Add("displayName");

                var result = ds.FindOne();

                if (result != null)
                {
                    dirEntry = result.GetDirectoryEntry();
                    displayName = Convert.ToString(result.Properties["displayName"][0]);
                }
                else
                {
                    dirEntry = null;
                }
            }

            return displayName;
        }

        /// <summary>
        ///     Gets the account policy for the domain
        /// </summary>
        /// <param name="domainName">The domain name</param>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns>The domain account policy</returns>
        public static AccountPolicy GetAccountPolicy(string domainName, string username, string password)
        {
            // Init return value
            var policy = new AccountPolicy();

            // Format the path for the root entry
            var rootPath = string.Format("{0}{1}", LDAPPathRoot, GetDomainDnFromName(domainName));

            // Get root directory entry
            DirEntry = new DirectoryEntry(rootPath, username, password);

            // Create a directory searcher to retrieve the password policy
            using (var ds = new DirectorySearcher(DirEntry))
            {
                ds.Filter = "(objectClass=domainDNS)";
                ds.PropertiesToLoad.AddRange(new[]
                    {
                        "maxPwdAge", "minPwdAge", "minPwdLength", "pwdProperties", "pwdHistoryLength", "lockoutDuration",
                        "lockOutObservationWindow", "lockoutThreshold"
                    });
                ds.SearchScope = SearchScope.Base;

                // Find the domain dns
                var result = ds.FindOne();

                // Check for maximum password age
                if (result.Properties.Contains("maxPwdAge"))
                {
                    // Get the maximum password age in ticks
                    var ticks = Math.Abs((long)result.Properties["maxPwdAge"][0]);

                    // If not 0 (set), set the policy property
                    if (ticks != 0)
                        policy.MaximumPasswordAge = TimeSpan.FromTicks(ticks);
                }

                // Check for minimum password age
                if (result.Properties.Contains("minPwdAge"))
                {
                    // Get the minimum password age in ticks
                    var ticks = Math.Abs((long)result.Properties["minPwdAge"][0]);

                    // If not 0 (set), set the policy property
                    if (ticks != 0)
                        policy.MinimumPasswordAge = TimeSpan.FromTicks(ticks);
                }

                // Check for minimum password age
                if (result.Properties.Contains("minPwdLength"))
                {
                    policy.MinimumPasswordLength = (int)result.Properties["minPwdLength"][0];
                }

                // Check for password history length
                if (result.Properties.Contains("pwdHistoryLength"))
                {
                    policy.PasswordHistoryLength = (int)result.Properties["pwdHistoryLength"][0];
                }

                // Check for password properties flags
                if (result.Properties.Contains("pwdProperties"))
                {
                    // Cast password properties into an enum (flags)
                    policy.PasswordProperties = (PasswordPolicy)result.Properties["pwdProperties"][0];
                }

                // Check for lockout duration
                if (result.Properties.Contains("lockoutDuration"))
                {
                    var ticks = Math.Abs((long)result.Properties["lockoutDuration"][0]);

                    // If not 0 (set), set the policy property
                    if (ticks != 0)
                        policy.LockoutDuration = new TimeSpan(ticks);
                }

                // Check for lockout threshold
                if (result.Properties.Contains("lockoutThreshold"))
                {
                    policy.LockoutThreshold = (int)result.Properties["lockoutThreshold"][0];
                }

                // Check for lockout observation window
                if (result.Properties.Contains("lockOutObservationWindow"))
                {
                    var ticks = Math.Abs((long)result.Properties["lockOutObservationWindow"][0]);

                    // If not 0 (set), set the policy property
                    if (ticks != 0)
                        policy.LockoutObservationWindow = new TimeSpan(ticks);
                }
            }

            return policy;
        }

        /// <summary>
        ///     Returns the domain's DN (distinguishedName) from its name
        /// </summary>
        /// <param name="domainName">The domain name</param>
        /// <returns>The domain's DN (distinguishedName) from its name</returns>
        private static string GetDomainDnFromName(string domainName)
        {
            // Create string builder
            var sbPath = new StringBuilder();

            // Split domain name by dots
            var dCs = domainName.Trim().Split('.');

            // Add domain components
            foreach (var t in dCs)
                sbPath.AppendFormat("DC={0},", t);

            // Remove last "," character and return path
            return sbPath.ToString().TrimEnd(',');
        }

    }
}
