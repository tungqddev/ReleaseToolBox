namespace ReleaseToolBox
{
    partial class ReleaseTool
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReleaseTool));
            this.btnTagsCopy = new System.Windows.Forms.Button();
            this.btnComparePre = new System.Windows.Forms.Button();
            this.btnCompareGit = new System.Windows.Forms.Button();
            this.rchtxtMessage = new System.Windows.Forms.RichTextBox();
            this.txtFunctionID = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuTripConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTripAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSVNupdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkSVNUsing = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTagsCopy
            // 
            this.btnTagsCopy.Location = new System.Drawing.Point(26, 123);
            this.btnTagsCopy.Name = "btnTagsCopy";
            this.btnTagsCopy.Size = new System.Drawing.Size(151, 23);
            this.btnTagsCopy.TabIndex = 5;
            this.btnTagsCopy.Text = "Tags copy and Commit";
            this.btnTagsCopy.UseVisualStyleBackColor = true;
            this.btnTagsCopy.Click += new System.EventHandler(this.btnTagsCopy_Click);
            // 
            // btnComparePre
            // 
            this.btnComparePre.Location = new System.Drawing.Point(26, 172);
            this.btnComparePre.Name = "btnComparePre";
            this.btnComparePre.Size = new System.Drawing.Size(151, 23);
            this.btnComparePre.TabIndex = 6;
            this.btnComparePre.Text = "Compare with Previous Tag";
            this.btnComparePre.UseVisualStyleBackColor = true;
            // 
            // btnCompareGit
            // 
            this.btnCompareGit.Location = new System.Drawing.Point(26, 219);
            this.btnCompareGit.Name = "btnCompareGit";
            this.btnCompareGit.Size = new System.Drawing.Size(151, 23);
            this.btnCompareGit.TabIndex = 7;
            this.btnCompareGit.Text = "Compare with Git";
            this.btnCompareGit.UseVisualStyleBackColor = true;
            // 
            // rchtxtMessage
            // 
            this.rchtxtMessage.Location = new System.Drawing.Point(222, 79);
            this.rchtxtMessage.Name = "rchtxtMessage";
            this.rchtxtMessage.Size = new System.Drawing.Size(367, 163);
            this.rchtxtMessage.TabIndex = 3;
            this.rchtxtMessage.Text = "";
            // 
            // txtFunctionID
            // 
            this.txtFunctionID.Location = new System.Drawing.Point(439, 41);
            this.txtFunctionID.Name = "txtFunctionID";
            this.txtFunctionID.Size = new System.Drawing.Size(100, 20);
            this.txtFunctionID.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTripConfiguration,
            this.databaseToolStripMenuItem,
            this.menuTripHelp,
            this.menuTripAbout,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(601, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuTripConfiguration
            // 
            this.menuTripConfiguration.Name = "menuTripConfiguration";
            this.menuTripConfiguration.Size = new System.Drawing.Size(93, 20);
            this.menuTripConfiguration.Text = "&Configuration";
            this.menuTripConfiguration.Click += new System.EventHandler(this.menuTripConfiguration_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "&Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // menuTripHelp
            // 
            this.menuTripHelp.Name = "menuTripHelp";
            this.menuTripHelp.Size = new System.Drawing.Size(44, 20);
            this.menuTripHelp.Text = "&Help";
            this.menuTripHelp.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // menuTripAbout
            // 
            this.menuTripAbout.Name = "menuTripAbout";
            this.menuTripAbout.Size = new System.Drawing.Size(52, 20);
            this.menuTripAbout.Text = "&About";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnSVNupdate
            // 
            this.btnSVNupdate.Location = new System.Drawing.Point(26, 79);
            this.btnSVNupdate.Name = "btnSVNupdate";
            this.btnSVNupdate.Size = new System.Drawing.Size(151, 23);
            this.btnSVNupdate.TabIndex = 4;
            this.btnSVNupdate.Text = "Tags SVN Update";
            this.btnSVNupdate.UseVisualStyleBackColor = true;
            this.btnSVNupdate.Click += new System.EventHandler(this.btnSVNupdate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(562, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkSVNUsing
            // 
            this.chkSVNUsing.AutoSize = true;
            this.chkSVNUsing.Location = new System.Drawing.Point(222, 43);
            this.chkSVNUsing.Name = "chkSVNUsing";
            this.chkSVNUsing.Size = new System.Drawing.Size(120, 17);
            this.chkSVNUsing.TabIndex = 8;
            this.chkSVNUsing.Text = "Use SVN Command";
            this.chkSVNUsing.UseVisualStyleBackColor = true;
            this.chkSVNUsing.CheckedChanged += new System.EventHandler(this.chkSVNUsing_CheckedChanged);
            // 
            // ReleaseTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 362);
            this.Controls.Add(this.chkSVNUsing);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSVNupdate);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtFunctionID);
            this.Controls.Add(this.rchtxtMessage);
            this.Controls.Add(this.btnCompareGit);
            this.Controls.Add(this.btnComparePre);
            this.Controls.Add(this.btnTagsCopy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReleaseTool";
            this.Text = "Release ";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTagsCopy;
        private System.Windows.Forms.Button btnComparePre;
        private System.Windows.Forms.Button btnCompareGit;
        private System.Windows.Forms.RichTextBox rchtxtMessage;
        private System.Windows.Forms.TextBox txtFunctionID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuTripConfiguration;
        private System.Windows.Forms.ToolStripMenuItem menuTripHelp;
        private System.Windows.Forms.ToolStripMenuItem menuTripAbout;
        private System.Windows.Forms.Button btnSVNupdate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkSVNUsing;
    }
}

