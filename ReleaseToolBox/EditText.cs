using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReleaseToolBox
{
    public partial class frmTextEdit : Form
    {
        public frmTextEdit()
        {
            InitializeComponent();
        }
        public string RichTextBoxValue
        {
            get { return rchtxtTextContent.Text; }
            set { rchtxtTextContent.Text = value; }
        }

        public string pathToSave;
        public string _pathToSave
        {
            get { return this.pathToSave; }
            set { this.pathToSave = value; }
        }


        public bool closedFlag;

        public bool _closedFlag
        {
            get { return this.closedFlag; }
            set { this.closedFlag = value; }
        }

        /// <summary>
        /// save content from textbox to specify file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            File.WriteAllText(this.pathToSave, rchtxtTextContent.Text);
            closedFlag = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closedFlag = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
