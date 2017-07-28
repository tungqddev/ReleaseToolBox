namespace ReleaseToolBox
{
    partial class frmTextEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTextEdit));
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rchtxtTextContent = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(267, 211);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(87, 23);
            this.btnSaveAndClose.TabIndex = 0;
            this.btnSaveAndClose.Text = "Save && Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(372, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rchtxtTextContent
            // 
            this.rchtxtTextContent.Location = new System.Drawing.Point(12, 12);
            this.rchtxtTextContent.Name = "rchtxtTextContent";
            this.rchtxtTextContent.Size = new System.Drawing.Size(452, 168);
            this.rchtxtTextContent.TabIndex = 2;
            this.rchtxtTextContent.Text = "";
            // 
            // frmTextEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 262);
            this.Controls.Add(this.rchtxtTextContent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTextEdit";
            this.Text = "Text Edit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox rchtxtTextContent;
    }
}