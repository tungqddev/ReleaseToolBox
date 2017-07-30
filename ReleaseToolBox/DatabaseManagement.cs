using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ReleaseToolBox
{
    public partial class frmDatabaseManagement : Form
    {
        public frmDatabaseManagement()
        {
            InitializeComponent();
            connectDatabase("","","");
            txtDomainUser.Text = Environment.UserName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to close!", "Exit confirmation", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void btnDBconfiguration_Click(object sender, EventArgs e)
        {
            frmTextEdit dbConfiguartion = new frmTextEdit();
            dbConfiguartion.Activate();
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

        }

        private void queryExecute(string datanbaseName, string query)
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
    }
}
