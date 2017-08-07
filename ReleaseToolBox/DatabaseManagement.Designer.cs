namespace ReleaseToolBox
{
    partial class frmDatabaseManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabaseManagement));
            this.lblDBName = new System.Windows.Forms.Label();
            this.cbxDatabase = new System.Windows.Forms.ComboBox();
            this.btnRestoreDefault = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnDBconfiguration = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblWindowUser = new System.Windows.Forms.Label();
            this.txtDomainUser = new System.Windows.Forms.TextBox();
            this.cbxBackupFile = new System.Windows.Forms.ComboBox();
            this.lblBackupFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(24, 34);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(53, 13);
            this.lblDBName.TabIndex = 0;
            this.lblDBName.Text = "Database";
            // 
            // cbxDatabase
            // 
            this.cbxDatabase.FormattingEnabled = true;
            this.cbxDatabase.Location = new System.Drawing.Point(97, 26);
            this.cbxDatabase.Name = "cbxDatabase";
            this.cbxDatabase.Size = new System.Drawing.Size(183, 21);
            this.cbxDatabase.TabIndex = 1;
            // 
            // btnRestoreDefault
            // 
            this.btnRestoreDefault.Location = new System.Drawing.Point(27, 166);
            this.btnRestoreDefault.Name = "btnRestoreDefault";
            this.btnRestoreDefault.Size = new System.Drawing.Size(103, 34);
            this.btnRestoreDefault.TabIndex = 2;
            this.btnRestoreDefault.Text = "Restore DB";
            this.btnRestoreDefault.UseVisualStyleBackColor = true;
            this.btnRestoreDefault.Click += new System.EventHandler(this.btnRestoreDefault_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(167, 166);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(102, 34);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnDBconfiguration
            // 
            this.btnDBconfiguration.Location = new System.Drawing.Point(27, 216);
            this.btnDBconfiguration.Name = "btnDBconfiguration";
            this.btnDBconfiguration.Size = new System.Drawing.Size(103, 32);
            this.btnDBconfiguration.TabIndex = 4;
            this.btnDBconfiguration.Text = "Configuration";
            this.btnDBconfiguration.UseVisualStyleBackColor = true;
            this.btnDBconfiguration.Click += new System.EventHandler(this.btnDBconfiguration_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(167, 216);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblWindowUser
            // 
            this.lblWindowUser.AutoSize = true;
            this.lblWindowUser.Location = new System.Drawing.Point(24, 110);
            this.lblWindowUser.Name = "lblWindowUser";
            this.lblWindowUser.Size = new System.Drawing.Size(68, 13);
            this.lblWindowUser.TabIndex = 6;
            this.lblWindowUser.Text = "Domain User";
            // 
            // txtDomainUser
            // 
            this.txtDomainUser.Location = new System.Drawing.Point(97, 103);
            this.txtDomainUser.Name = "txtDomainUser";
            this.txtDomainUser.Size = new System.Drawing.Size(121, 20);
            this.txtDomainUser.TabIndex = 7;
            // 
            // cbxBackupFile
            // 
            this.cbxBackupFile.FormattingEnabled = true;
            this.cbxBackupFile.Location = new System.Drawing.Point(97, 64);
            this.cbxBackupFile.Name = "cbxBackupFile";
            this.cbxBackupFile.Size = new System.Drawing.Size(183, 21);
            this.cbxBackupFile.TabIndex = 8;
            this.cbxBackupFile.DropDown += new System.EventHandler(this.cbxBackupFile_DropDown);
            this.cbxBackupFile.SelectedIndexChanged += new System.EventHandler(this.cbxBackupFile_SelectedIndexChanged);
            // 
            // lblBackupFile
            // 
            this.lblBackupFile.AutoSize = true;
            this.lblBackupFile.Location = new System.Drawing.Point(25, 71);
            this.lblBackupFile.Name = "lblBackupFile";
            this.lblBackupFile.Size = new System.Drawing.Size(63, 13);
            this.lblBackupFile.TabIndex = 9;
            this.lblBackupFile.Text = "Backup File";
            // 
            // frmDatabaseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 288);
            this.Controls.Add(this.lblBackupFile);
            this.Controls.Add(this.cbxBackupFile);
            this.Controls.Add(this.txtDomainUser);
            this.Controls.Add(this.lblWindowUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDBconfiguration);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnRestoreDefault);
            this.Controls.Add(this.cbxDatabase);
            this.Controls.Add(this.lblDBName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDatabaseManagement";
            this.Text = "Database Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.ComboBox cbxDatabase;
        private System.Windows.Forms.Button btnRestoreDefault;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnDBconfiguration;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblWindowUser;
        private System.Windows.Forms.TextBox txtDomainUser;
        private System.Windows.Forms.ComboBox cbxBackupFile;
        private System.Windows.Forms.Label lblBackupFile;
    }
}