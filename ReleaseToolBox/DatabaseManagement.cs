using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Mail;

namespace ReleaseToolBox
{
    public partial class frmDatabaseManagement : Form
    {
        public frmDatabaseManagement()
        {
            InitializeComponent();
            connectDatabase("", "", "");
            txtDomainUser.Text = Environment.UserName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to close!", "Exit confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                mailSending("Quach.Dai.Tung@usol-v.com.vn", "Quach.Dai.Tung@usol-v.com.vn", "test mail");
            }
            else
            {
                return;
            }
        }

        private void btnDBconfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                this.editDataInfo(@"master.data");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void connectDatabase(string dbName, string dbUser, string dbPassword)
        {
            Global global = new Global();
            string connetionString = "";
            SqlConnection cnn;
            connetionString = "Data Source=" + global._severName + ";Initial Catalog=master;User ID=" + global._dbUser + ";Password=" + global._dbPassword;
            //connetionString = "Data Source=" + "10.128.9.215" + ";Initial Catalog=master;User ID=" + "sa" + ";Password=" + "It123!@#";
            cnn = new SqlConnection(connetionString);
            SqlCommand cmdGetDataBaseList = new SqlCommand();
            SqlDataReader reader;
            DataTable tblMyDatabaseList = new DataTable();
            try
            {
                cnn.Open();
                cmdGetDataBaseList.CommandText = "select * from master.sys.databases";
                cmdGetDataBaseList.CommandType = CommandType.Text;
                cmdGetDataBaseList.Connection = cnn;
                reader = cmdGetDataBaseList.ExecuteReader();
                tblMyDatabaseList.Load(reader);
                foreach (DataRow row in tblMyDatabaseList.Rows)
                {
                    cbxDatabase.Items.Add(row["name"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + Environment.NewLine + ex.ToString());
            }
            cnn.Close();
        }

        private void btnRestoreDefault_Click(object sender, EventArgs e)
        {
            Global global = new Global();
            string dbinfo = System.IO.File.ReadAllText(@"master.data");
            if (cbxDatabase.Text == string.Empty)
            {
                MessageBox.Show("Please choose or type your database name !!!");
                return;
            }
            Regex regexUserdb = new Regex("..+" + cbxDatabase.Text + "+.*");
            Match matchUserinfo = regexUserdb.Match(dbinfo);
            string userInfo = "";

            if (matchUserinfo.Success)
            {
                userInfo = matchUserinfo.Value.Replace(Environment.NewLine, "");
            }
            else
            {
                MessageBox.Show("Can't find your database information. Please check your configuration !!!");
                return;
            }

            string userInfoDomainUser = userInfo.Substring(0, userInfo.IndexOf(","));

            if (userInfoDomainUser.Trim() != txtDomainUser.Text.Trim())
            {
                DialogResult dialogResult = MessageBox.Show("Warning!!!! It isn't " + txtDomainUser.Text + " database. You still want to restore! ", "WARNING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string dataPath = userInfo.Substring(userInfo.LastIndexOf(",") + 1, userInfo.Length - userInfo.LastIndexOf(",") - 1);
                        queryExecute(restoreQueryCreate(cbxDatabase.Text, global._dbPath, dataPath.Trim()));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }
                    MessageBox.Show("Restore database sucessfully!!!");
                }
                else
                {
                    return;
                }
            }

            else
            {
                try
                {
                    string dataPath = userInfo.Substring(userInfo.LastIndexOf(",") + 1, userInfo.Length - userInfo.LastIndexOf(",") - 1);
                    queryExecute(restoreQueryCreate(cbxDatabase.Text, global._dbPath, dataPath.Trim()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                MessageBox.Show("Restore database sucessfully!!!");
            }

        }

        private void queryExecute(string query)
        {
            string connetionString = null;
            Global global = new Global();
            SqlConnection cnn;
            connetionString = "Data Source=" + global._severName + ";Initial Catalog=master;User ID=" + global._dbUser + ";Password=" + global._dbPassword;
            cnn = new SqlConnection(connetionString);
            SqlCommand cmdGetDataBaseList = new SqlCommand();
            DataTable tblMyDatabaseList = new DataTable();
            try
            {
                cnn.Open();
                cmdGetDataBaseList.CommandText = query;
                cmdGetDataBaseList.CommandType = CommandType.Text;
                cmdGetDataBaseList.Connection = cnn;
                cmdGetDataBaseList.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            cnn.Close();
        }

        private string restoreQueryCreate(string databaseName, string databaseLocation, string desFolder)
        {
            string restoreQuery = @"IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'" + cbxDatabase.Text + @"') BEGIN ALTER DATABASE " + cbxDatabase.Text + @" SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE " + cbxDatabase.Text + @" END 

DECLARE @Table TABLE (LogicalName varchar(128),[PhysicalName] varchar(128), [Type] varchar, [FileGroupName] varchar(128), [Size] varchar(128), 
            [MaxSize] varchar(128), [FileId]varchar(128), [CreateLSN]varchar(128), [DropLSN]varchar(128), [UniqueId]varchar(128), [ReadOnlyLSN]varchar(128), [ReadWriteLSN]varchar(128), 
            [BackupSizeInBytes]varchar(128), [SourceBlockSize]varchar(128), [FileGroupId]varchar(128), [LogGroupGUID]varchar(128), [DifferentialBaseLSN]varchar(128), [DifferentialBaseGUID]varchar(128), [IsReadOnly]varchar(128), [IsPresent]varchar(128), [TDEThumbprint]varchar(128)
                )
                DECLARE @Path varchar(1000)='" + databaseLocation + @"'
                DECLARE @LogicalNameData varchar(128),@LogicalNameLog varchar(128)
                INSERT INTO @table
                EXEC('
                RESTORE FILELISTONLY 
                   FROM DISK=''' +@Path+ '''
                   ')
                
                   SET @LogicalNameData=(SELECT LogicalName FROM @Table WHERE Type='D')
                   SET @LogicalNameLog=(SELECT LogicalName FROM @Table WHERE Type='L')
                
                RESTORE LABELONLY FROM DISK = '" + databaseLocation + @"';
                
                RESTORE FILELISTONLY FROM DISK = '" + databaseLocation + @"' 
                declare @bak_addr nvarchar(1000);
                declare @data_addr nvarchar (1000);
                declare @log_addr nvarchar(1000);
                set @bak_addr = '" + databaseLocation + @"'
                set @data_addr = '" + desFolder + @"\'+@LogicalNameData+'.mdf'
                set @log_addr = '" + desFolder + @"\'+@LogicalNameData+'.ldf'
                RESTORE DATABASE " + databaseName + @"
                FROM DISK = @bak_addr
                with file =1,
                MOVE @LogicalNameData to  @data_addr,
                MOVE @LogicalNameLog TO @log_addr,
                NOUNLOAD,STATS = 10
                ";

            return restoreQuery;
        }

        private void editDataInfo(string filePath)
        {
            frmTextEdit editForm = new frmTextEdit();
            editForm.Activate();
            editForm.Show();
            editForm.RichTextBoxValue = File.ReadAllText(filePath);
            editForm.pathToSave = filePath.ToString();
        }

        private void mailSending(string fromEmail, string toEmail, string contents)
        {
            MailMessage mail = new MailMessage(fromEmail, toEmail);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("tquach1", "QDT12345!");
            client.Host = "10.128.2.51";
            mail.Subject = "DATABASE RESTORE NOTIFICATION";
            mail.Body = contents;
            client.Send(mail);
        }

    }
}
