using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace ReleaseToolBox
{
    public partial class ReleaseTool : Form
    {

        public ReleaseTool()
        {
            InitializeComponent();
            
            btnCompareGit.Enabled = false;
            btnComparePre.Enabled = false;
            btnSVNupdate.Enabled = false;
            btnTagsCopy.Text = "Tags copy";
            Global global = new Global();

            if (!Directory.Exists(global._branchesPath))
            {
                MessageBox.Show("Branches folder path doesn't exits. Please check [Configuration]");
            }

            else if (!Directory.Exists(global._tagsPath))
            {
                MessageBox.Show("Tags folder path doesn't exits. Please check [Configuration]");
            }

        }

        private void menuTripConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                this.editText(@"data.config");
            }
            catch (Exception ex)
            {
                rchtxtMessage.Text = ex.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            {
                if(txtFunctionID.Text == string.Empty)
                {
                    MessageBox.Show("Please input your screen ID!!!");
                    return;
                }              
                if (File.Exists(@".\FileList\" + txtFunctionID.Text + ".txt"))
                {
                    rchtxtMessage.Text = System.IO.File.ReadAllText(@".\FileList\" + txtFunctionID.Text + ".txt");
                }
                else
                {
                    MessageBox.Show("Can't find your function information. Please input by yourself!!!");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This app will be closed !!!!", "Exit confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        public void commit_svn(string commit_path)
        {

            string requestUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string addFileArgument;
            string commitArgument;
            string processing_output;

            addFileArgument = " add ";
            addFileArgument += "\"";
            addFileArgument += commit_path;
            addFileArgument += "\"";
            addFileArgument += " --force";

            commitArgument = " commit -m \"update by ";
            commitArgument += requestUser + " \" ";
            commitArgument += "\"";
            commitArgument += commit_path;
            commitArgument += "\"";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "svn.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.StartInfo.Arguments = addFileArgument;
            process.Start();
            StreamReader reader = process.StandardOutput;
            while ((processing_output = process.StandardOutput.ReadLine()) != null)
            {
                rchtxtMessage.Text += processing_output + Environment.NewLine;
            }
            process.WaitForExit();

            process.StartInfo.Arguments = commitArgument;
            process.Start();
            while ((processing_output = process.StandardOutput.ReadLine()) != null)
            {
                rchtxtMessage.Text += processing_output + Environment.NewLine;
            }
            process.WaitForExit();
        }

        public void SVNUpdating(string svn_path)
        {
            string str_cmd_text;
            string processing_output;
            str_cmd_text = " update ";
            str_cmd_text += "\"";
            str_cmd_text += svn_path;
            str_cmd_text += "\"";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "svn.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.Arguments = str_cmd_text;
            process.Start();
            StreamReader reader = process.StandardOutput;
            while ((processing_output = process.StandardOutput.ReadLine()) != null)
            {
                rchtxtMessage.Text += processing_output + Environment.NewLine;
            }
            process.WaitForExit();
        }

        private void btnTagsCopy_Click(object sender, EventArgs e)
        {
            string listFileContent = "";
            string lastestTagID = "";
            bool fileNotExist = false;
            List<string> copyList = new List<string>();
            Global global = new Global();
            if (!Directory.Exists(global._branchesPath))
            {
                MessageBox.Show("Branches folder path doesn't exits. Please check [Configuration]");
                return;
            }

            else if (!Directory.Exists(global._tagsPath))
            {
                MessageBox.Show("Tags folder path doesn't exits. Please check [Configuration]");
                return;
            }

            // copy all file from branches to tags folder
            copyList = fileSplit(rchtxtMessage.Text.ToString(), Environment.NewLine.ToCharArray());
            for (int i = 0; i < copyList.Count; i++)
            {
                string copyFile = string.Empty;
                copyFile = copyList[i];
                if (copyList[i].Length <= 2)
                {
                    copyList.RemoveAt(i);
                }
            }

            rchtxtMessage.Text = string.Empty;
            foreach (string deployFileName in copyList)
            {
                if (!File.Exists(global._branchesPath + "\\" + deployFileName))
                {
                    fileNotExist = true;
                    rchtxtMessage.AppendText("\\");
                    rchtxtMessage.AppendText(deployFileName);
                    int selectionStart = rchtxtMessage.Text.Length;
                    rchtxtMessage.AppendText(" Doesn't exist. Please check !");
                    rchtxtMessage.AppendText(Environment.NewLine);
                    rchtxtMessage.Select(selectionStart, selectionStart + 31);
                    rchtxtMessage.SelectionColor = Color.Red;
                }
            }
            if (fileNotExist)
                return;

            if (Directory.Exists(global._tagsPath + "\\" + txtFunctionID.Text))
            {
                //List<String> tagIDFolderList = new List<String>;
                if (chkSVNUsing.Checked)
                {
                    SVNUpdating(global._tagsPath + "\\" + txtFunctionID.Text);
                }

                listFileContent = System.IO.File.ReadAllText(@"FileList\" + txtFunctionID.Text + ".txt");
                var sorted = Directory.GetDirectories(global._tagsPath + "\\" + txtFunctionID.Text).OrderBy(d => d).ToList();
                lastestTagID = sorted[sorted.Count - 1].ToString().Substring(sorted[sorted.Count - 1].ToString().LastIndexOf("\\") + 1, 4);
                Directory.CreateDirectory(global._tagsPath + "\\" + txtFunctionID.Text + "\\" + (((10000 + Convert.ToDecimal(lastestTagID) + 1)).ToString()).Substring(1, 4));

            }
            else
            {
                if (chkSVNUsing.Checked)
                {
                    SVNUpdating(global._tagsPath);
                }
                DialogResult dialogResult = MessageBox.Show("Create folder " + txtFunctionID.Text, "Folder create", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Directory.CreateDirectory(global._tagsPath + "\\" + txtFunctionID.Text + "\\0001");
                    lastestTagID = "0000";
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            // MessageBox.Show(copyList.ToString());

            foreach (string singleFile in copyList)
            {
                if (!Directory.Exists(global._tagsPath + "\\" + txtFunctionID.Text.ToString() + "\\" + (((10000 + Convert.ToDecimal(lastestTagID) + 1)).ToString()).Substring(1, 4) + "\\" + singleFile.Substring(0, singleFile.LastIndexOf("\\"))))
                {
                    Directory.CreateDirectory(global._tagsPath + "\\" + txtFunctionID.Text + "\\" + (((10000 + Convert.ToDecimal(lastestTagID) + 1)).ToString()).Substring(1, 4) + "\\" + singleFile.Substring(0, singleFile.LastIndexOf("\\")));
                }
                try
                {
                    File.Copy(global._branchesPath + "\\" + singleFile, global._tagsPath + "\\" + txtFunctionID.Text + "\\" + (((10000 + Convert.ToDecimal(lastestTagID) + 1)).ToString()).Substring(1, 4) + "\\" + singleFile, true);
                    rchtxtMessage.AppendText(singleFile);
                    int selectionStart = rchtxtMessage.Text.Length;
                    rchtxtMessage.AppendText(" copy success");
                    rchtxtMessage.AppendText(Environment.NewLine);
                    rchtxtMessage.Select(selectionStart, selectionStart + 14);
                    rchtxtMessage.SelectionColor = Color.Green;
                }
                catch (Exception ex)
                {
                    rchtxtMessage.Text = ex.ToString();
                }
            }

            if (chkSVNUsing.Checked)
            {
                commit_svn(global._tagsPath + "\\" + txtFunctionID.Text);
            }

        }

        private void btnSVNupdate_Click(object sender, EventArgs e)
        {
            Global global = new Global();
            try
            {
                if (chkSVNUsing.Checked)
                {
                    SVNUpdating(global._tagsPath);
                }
                else
                {
                    MessageBox.Show("Please check [SVN Using] if you want to use!");
                }
            }
            catch (Exception ex)
            {
                rchtxtMessage.Text = ex.ToString();
            }

        }

        private void editText(string filePath)
        {
            frmTextEdit editForm = new frmTextEdit();
            editForm.Activate();
            editForm.RichTextBoxValue = File.ReadAllText(filePath);
            editForm.pathToSave = filePath.ToString();
            Global global = new Global();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(global._branchesPath))
                {
                    MessageBox.Show("Branches folder path doesn't exits. Please check [Configuration]");
                }

                else if (!Directory.Exists(global._tagsPath))
                {
                    MessageBox.Show("Tags folder path doesn't exits. Please check [Configuration]");
                }

            }
        }

        /// <summary>
        /// Split file from string with delimiter characters
        /// </summary>
        /// <param name="textContent"></param>
        /// <param name="delimiterChars"></param>
        /// <returns></returns>
        public List<string> fileSplit(string textContent, char[] delimiterChars)
        {
            List<string> splitedList = new List<String>();
            //char[] delimiterChars = { '\r', ',', '.', ':', '\t' };
            textContent = Regex.Replace(textContent, @"\r\n\r\n", @"\r\n");
            splitedList = textContent.Split(delimiterChars).ToList();
            // Keep the console window open in debug mode.
            for (int i = 0; i < splitedList.Count(); i++)
            {
                splitedList[i] = splitedList[i].Trim();
                if (splitedList[i].Length < 3)
                {
                    splitedList.RemoveAt(i);
                }
            }
            return splitedList;
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatabaseManagement formDatabaseManagement = new frmDatabaseManagement();
            formDatabaseManagement.Show();
            formDatabaseManagement.Activate();
        }

        private void chkSVNUsing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSVNUsing.Checked)
            {
                btnSVNupdate.Enabled = true;
                btnTagsCopy.Text = "Tags copy and Commit";
            }
            else
            {
                {
                    btnSVNupdate.Enabled = false;
                    btnTagsCopy.Text = "Tags copy";
                }
            }
        }
    }
}
