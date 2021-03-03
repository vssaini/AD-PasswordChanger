namespace PasswordChanger
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResetADDetails = new System.Windows.Forms.Button();
            this.btnSaveADDetails = new System.Windows.Forms.Button();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.txtAdminPass = new System.Windows.Forms.TextBox();
            this.txtAdminUser = new System.Windows.Forms.TextBox();
            this.lblAdminPass = new System.Windows.Forms.Label();
            this.lblAdminUser = new System.Windows.Forms.Label();
            this.gbPolicyDetails = new System.Windows.Forms.GroupBox();
            this.btnShowPolicyDetails = new System.Windows.Forms.Button();
            this.txtPolicyDetails = new System.Windows.Forms.RichTextBox();
            this.gbChangePass = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnResetPassDetails = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.txtSamAccountName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.gbPolicyDetails.SuspendLayout();
            this.gbChangePass.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResetADDetails);
            this.groupBox1.Controls.Add(this.btnSaveADDetails);
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.lblDomain);
            this.groupBox1.Controls.Add(this.txtAdminPass);
            this.groupBox1.Controls.Add(this.txtAdminUser);
            this.groupBox1.Controls.Add(this.lblAdminPass);
            this.groupBox1.Controls.Add(this.lblAdminUser);
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(357, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AD Settings";
            // 
            // btnResetADDetails
            // 
            this.btnResetADDetails.Location = new System.Drawing.Point(276, 147);
            this.btnResetADDetails.Name = "btnResetADDetails";
            this.btnResetADDetails.Size = new System.Drawing.Size(75, 23);
            this.btnResetADDetails.TabIndex = 5;
            this.btnResetADDetails.Text = "&Reset";
            this.btnResetADDetails.UseVisualStyleBackColor = true;
            this.btnResetADDetails.Click += new System.EventHandler(this.btnResetADDetails_Click);
            // 
            // btnSaveADDetails
            // 
            this.btnSaveADDetails.Location = new System.Drawing.Point(195, 147);
            this.btnSaveADDetails.Name = "btnSaveADDetails";
            this.btnSaveADDetails.Size = new System.Drawing.Size(75, 23);
            this.btnSaveADDetails.TabIndex = 4;
            this.btnSaveADDetails.Text = "&Save";
            this.btnSaveADDetails.UseVisualStyleBackColor = true;
            this.btnSaveADDetails.Click += new System.EventHandler(this.btnSaveADDetails_Click);
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(101, 26);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(228, 24);
            this.txtDomain.TabIndex = 1;
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(16, 34);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(56, 17);
            this.lblDomain.TabIndex = 8;
            this.lblDomain.Text = "Domain:";
            // 
            // txtAdminPass
            // 
            this.txtAdminPass.Location = new System.Drawing.Point(100, 103);
            this.txtAdminPass.Name = "txtAdminPass";
            this.txtAdminPass.Size = new System.Drawing.Size(229, 24);
            this.txtAdminPass.TabIndex = 3;
            // 
            // txtAdminUser
            // 
            this.txtAdminUser.Location = new System.Drawing.Point(100, 65);
            this.txtAdminUser.Name = "txtAdminUser";
            this.txtAdminUser.Size = new System.Drawing.Size(229, 24);
            this.txtAdminUser.TabIndex = 2;
            // 
            // lblAdminPass
            // 
            this.lblAdminPass.AutoSize = true;
            this.lblAdminPass.Location = new System.Drawing.Point(16, 111);
            this.lblAdminPass.Name = "lblAdminPass";
            this.lblAdminPass.Size = new System.Drawing.Size(78, 17);
            this.lblAdminPass.TabIndex = 1;
            this.lblAdminPass.Text = "Admin Pass:";
            // 
            // lblAdminUser
            // 
            this.lblAdminUser.AutoSize = true;
            this.lblAdminUser.Location = new System.Drawing.Point(15, 73);
            this.lblAdminUser.Name = "lblAdminUser";
            this.lblAdminUser.Size = new System.Drawing.Size(79, 17);
            this.lblAdminUser.TabIndex = 0;
            this.lblAdminUser.Text = "Admin User:";
            // 
            // gbPolicyDetails
            // 
            this.gbPolicyDetails.Controls.Add(this.btnShowPolicyDetails);
            this.gbPolicyDetails.Controls.Add(this.txtPolicyDetails);
            this.gbPolicyDetails.Location = new System.Drawing.Point(397, 16);
            this.gbPolicyDetails.Name = "gbPolicyDetails";
            this.gbPolicyDetails.Size = new System.Drawing.Size(415, 341);
            this.gbPolicyDetails.TabIndex = 1;
            this.gbPolicyDetails.TabStop = false;
            this.gbPolicyDetails.Text = "AD Policy Details";
            // 
            // btnShowPolicyDetails
            // 
            this.btnShowPolicyDetails.Location = new System.Drawing.Point(323, 23);
            this.btnShowPolicyDetails.Name = "btnShowPolicyDetails";
            this.btnShowPolicyDetails.Size = new System.Drawing.Size(75, 23);
            this.btnShowPolicyDetails.TabIndex = 11;
            this.btnShowPolicyDetails.Text = "Show";
            this.btnShowPolicyDetails.UseVisualStyleBackColor = true;
            this.btnShowPolicyDetails.Click += new System.EventHandler(this.btnShowPolicyDetails_Click);
            // 
            // txtPolicyDetails
            // 
            this.txtPolicyDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPolicyDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPolicyDetails.Enabled = false;
            this.txtPolicyDetails.Location = new System.Drawing.Point(17, 57);
            this.txtPolicyDetails.Name = "txtPolicyDetails";
            this.txtPolicyDetails.Size = new System.Drawing.Size(381, 264);
            this.txtPolicyDetails.TabIndex = 10;
            this.txtPolicyDetails.Text = "";
            // 
            // gbChangePass
            // 
            this.gbChangePass.Controls.Add(this.txtPassword);
            this.gbChangePass.Controls.Add(this.btnResetPassDetails);
            this.gbChangePass.Controls.Add(this.btnChangePass);
            this.gbChangePass.Controls.Add(this.txtSamAccountName);
            this.gbChangePass.Controls.Add(this.lblPassword);
            this.gbChangePass.Controls.Add(this.lblUser);
            this.gbChangePass.Location = new System.Drawing.Point(14, 213);
            this.gbChangePass.Name = "gbChangePass";
            this.gbChangePass.Size = new System.Drawing.Size(357, 144);
            this.gbChangePass.TabIndex = 2;
            this.gbChangePass.TabStop = false;
            this.gbChangePass.Text = "Change Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(139, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(190, 24);
            this.txtPassword.TabIndex = 7;
            // 
            // btnResetPassDetails
            // 
            this.btnResetPassDetails.Location = new System.Drawing.Point(276, 112);
            this.btnResetPassDetails.Name = "btnResetPassDetails";
            this.btnResetPassDetails.Size = new System.Drawing.Size(75, 23);
            this.btnResetPassDetails.TabIndex = 9;
            this.btnResetPassDetails.Text = "Reset";
            this.btnResetPassDetails.UseVisualStyleBackColor = true;
            this.btnResetPassDetails.Click += new System.EventHandler(this.btnResetPassDetails_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(195, 112);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(75, 23);
            this.btnChangePass.TabIndex = 8;
            this.btnChangePass.Text = "Change";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // txtSamAccountName
            // 
            this.txtSamAccountName.Location = new System.Drawing.Point(139, 33);
            this.txtSamAccountName.Name = "txtSamAccountName";
            this.txtSamAccountName.Size = new System.Drawing.Size(190, 24);
            this.txtSamAccountName.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 76);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 17);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(16, 41);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(117, 17);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "SamAccountName:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(17, 17);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(833, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(26, 17);
            this.lblStatus.Text = "Idle";
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnChangePass;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 401);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbChangePass);
            this.Controls.Add(this.gbPolicyDetails);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.267326F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Changer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPolicyDetails.ResumeLayout(false);
            this.gbChangePass.ResumeLayout(false);
            this.gbChangePass.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResetADDetails;
        private System.Windows.Forms.Button btnSaveADDetails;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.TextBox txtAdminPass;
        private System.Windows.Forms.TextBox txtAdminUser;
        private System.Windows.Forms.Label lblAdminPass;
        private System.Windows.Forms.Label lblAdminUser;
        private System.Windows.Forms.GroupBox gbPolicyDetails;
        private System.Windows.Forms.RichTextBox txtPolicyDetails;
        private System.Windows.Forms.GroupBox gbChangePass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnResetPassDetails;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.TextBox txtSamAccountName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnShowPolicyDetails;
    }
}

