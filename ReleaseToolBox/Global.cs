using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReleaseToolBox
{
    class Global
    {
        public Global()
        {
            getPathConfiguration();
        }
        private string branchesPath;

        public string _branchesPath
        {
            get { return branchesPath; }
            set { branchesPath = value; }
        }

        private string tagsPath;

        public string _tagsPath
        {
            get { return tagsPath; }
            set { tagsPath = value; }
        }


        private string gitPath;
        public string _gitPath
        {
            get { return gitPath; }
            set { gitPath = value; }
        }

        private string severName;
        public string _severName
        {
            get { return severName; }
            set { severName = value; }
        }

        private string dbUser;
        public string _dbUser
        {
            get { return dbUser; }
            set { dbUser = value; }
        }

        private string dbPassword;
        public string _dbPassword
        {
            get { return dbPassword; }
            set { dbPassword = value; }
        }

        private string dbPath;
        public string _dbPath
        {
            get { return dbPath; }
            set { dbPath = value; }
        }

        private string backupDBPath;
        public string _backupDBPath
        {
            get { return backupDBPath; }
            set { backupDBPath = value; }
        }


        protected void getPathConfiguration()
        {
            string configurationFileContent;
            try
            {
                configurationFileContent = System.IO.File.ReadAllText(@"data.config");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            Regex regexbranchesPath = new Regex(@"(?m)(?<=\bBranches folder]:)[^\r\n]+");
            Regex regextagsPath = new Regex(@"(?m)(?<=\bTag folder]:)[^\r\n]+");
            Regex regexgitPath = new Regex(@"(?m)(?<=\bGit folder]:)[^\r\n]+");
            Regex regexServerName = new Regex(@"(?m)(?<=\bServer Name]:)[^\r\n]+");
            Regex regexDBUser = new Regex(@"(?m)(?<=\bDB User]:)[^\r\n]+");
            Regex regexDBPass = new Regex(@"(?m)(?<=\bDB Password]:)[^\r\n]+");
            Regex regexDefaultDBpath = new Regex(@"(?m)(?<=\bDefault DB Path]:)[^\r\n]+");
            Regex regexbackupDBPath = new Regex(@"(?m)(?<=\bBackup Path]:)[^\r\n]+");

            Match matchBranchesPath = regexbranchesPath.Match(configurationFileContent);
            if (matchBranchesPath.Success)
            {
                branchesPath = matchBranchesPath.Value.Replace(Environment.NewLine, "");
            }

            Match matchTagsPath = regextagsPath.Match(configurationFileContent);
            if (matchTagsPath.Success)
            {
                tagsPath = matchTagsPath.Value.Replace(Environment.NewLine, "");
            }

            Match matchGitPath = regexgitPath.Match(configurationFileContent);
            if (matchGitPath.Success)
            {
                gitPath = matchGitPath.Value.Replace(Environment.NewLine, "");
            }

            Match matcheServerName = regexServerName.Match(configurationFileContent);
            if (matcheServerName.Success)
            {
                severName = matcheServerName.Value.Replace(Environment.NewLine, "");
            }

            Match matchDBUser = regexDBUser.Match(configurationFileContent);
            if (matchDBUser.Success)
            {
                dbUser = matchDBUser.Value.Replace(Environment.NewLine, "");
            }

            Match matchDBPass = regexDBPass.Match(configurationFileContent);
            if (matchDBPass.Success)
            {
                dbPassword = matchDBPass.Value.Replace(Environment.NewLine, "");
            }

            Match matchDefaultDBpath = regexDefaultDBpath.Match(configurationFileContent);
            if (matchDefaultDBpath.Success)
            {
                dbPath = matchDefaultDBpath.Value.Replace(Environment.NewLine, "");
            }

            Match matchbackupDBPath = regexbackupDBPath.Match(configurationFileContent);
            if (matchDefaultDBpath.Success)
            {
                backupDBPath = matchbackupDBPath.Value.Replace(Environment.NewLine, "");
            }

        }
    }

}
