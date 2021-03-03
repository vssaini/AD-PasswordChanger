using System;
using System.DirectoryServices;
using System.Windows.Forms;
using PasswordChanger.Code;
using PasswordChanger.Properties;

namespace PasswordChanger
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

#if DEBUG
            txtSamAccountName.Text = "vssaini";
            txtPassword.Text = "danav12";
#endif
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            txtDomain.Text = Settings.Default.Domain;
            txtAdminUser.Text = Settings.Default.AdminUser;
            txtAdminPass.Text = Settings.Default.AdminPass;

        }

        private void btnResetADDetails_Click(object sender, EventArgs e)
        {
            txtDomain.Text = txtAdminUser.Text = txtPassword.Text = string.Empty;
        }

        private void btnResetPassDetails_Click(object sender, EventArgs e)
        {
            txtSamAccountName.Text = txtPassword.Text = string.Empty;
        }

        private void btnSaveADDetails_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDomain.Text) && string.IsNullOrEmpty(txtAdminUser.Text) &&
                string.IsNullOrEmpty(txtPassword.Text))
            {
                lblStatus.Text = "Some of the fields are still blank.";
                return;
            }

            Settings.Default.Domain = txtDomain.Text;
            Settings.Default.AdminUser = txtAdminUser.Text;
            Settings.Default.AdminPass = txtAdminPass.Text;

            Settings.Default.Save();
            lblStatus.Text = "AD details saved successfully!";
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            var samAccount = txtSamAccountName.Text;
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(samAccount) && string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "SamAccountName or Password field is empty.";
                return;
            }

            if (!string.IsNullOrEmpty(txtDomain.Text) && !string.IsNullOrEmpty(txtAdminUser.Text) &&
                !string.IsNullOrEmpty(txtAdminPass.Text))
            {
                DirectoryEntry userEntry;
                var displayName = ADUtilities.GetDisplayName(samAccount,out userEntry);

                if (!string.IsNullOrEmpty(displayName))
                {
                    if (ADUtilities.ValidatePassword(password, samAccount, displayName))
                    {
                        lblStatus.Text = "Password is fine as per AD policy. Changing it...";

                        // Change password
                        if (userEntry != null)
                        {
                            ADUtilities.ResetUserPassword(userEntry, samAccount, password, false, false);
                            lblStatus.Text = string.Format("Password was reset for user '{0}' successfully!",displayName);
                            userEntry.Dispose();
                        }
                    }
                    else
                    {
                        lblStatus.Text = "Password failed for complexity rule.";
                    }
                }
            }
               
        }

        private void btnShowPolicyDetails_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDomain.Text) && !string.IsNullOrEmpty(txtAdminUser.Text) &&
               !string.IsNullOrEmpty(txtAdminPass.Text))
                txtPolicyDetails.Text = ADUtilities.GetADPolicyDetails();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ADUtilities.DirEntry!=null)
                ADUtilities.DirEntry.Dispose();
        }
    }
}
