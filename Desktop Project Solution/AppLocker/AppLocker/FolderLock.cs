using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using AesEncDec;

namespace AppLocker
{
    public partial class FolderLock : Form
    {

        public string path;
       

        public FolderLock()
        {
            InitializeComponent();
       

        }

        private void FolderLock_Load(object sender, EventArgs e)
        {
            string dir = "FolderLockData";
            if (File.Exists("data\\" + dir + "\\data.ls"))
            {
                checkBox1.Visible = true;

            }
            else
            {
                checkBox1.Visible = false;
            }
        }  
        
        private void button3_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog folbd = new FolderBrowserDialog();
            if (folbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = folbd.SelectedPath;
                textBox1.Text = path;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SetAccess();
        }
        public void SetAccess()
        {


            if (path != null)
            {
                DirectoryInfo myDirectoryInfo = new DirectoryInfo(path);

                string dir = "FolderLockData";
                Directory.CreateDirectory("data\\" + dir);
                var streamw = new StreamWriter("data\\" + dir + "\\data.ls");
                string dc = AesCrypt.Encrypt(textBox1.Text);
                streamw.WriteLine(dc);
                streamw.Close();



                var sid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
                DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
                myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(sid, FileSystemRights.Read, AccessControlType.Deny));
                var everyid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                var usersid = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);

                var accsid = new SecurityIdentifier(WellKnownSidType.BuiltinAccountOperatorsSid, null);
                var adnissid = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);

                myDirectorySecurity.RemoveAccessRuleAll(new FileSystemAccessRule(everyid, FileSystemRights.Read, AccessControlType.Allow));
                myDirectorySecurity.RemoveAccessRuleAll(new FileSystemAccessRule(usersid, FileSystemRights.Read, AccessControlType.Allow));

                myDirectorySecurity.RemoveAccessRuleAll(new FileSystemAccessRule(accsid, FileSystemRights.Read, AccessControlType.Allow));
                myDirectorySecurity.RemoveAccessRuleAll(new FileSystemAccessRule(adnissid, FileSystemRights.Read, AccessControlType.Allow));
                myDirectoryInfo.SetAccessControl(myDirectorySecurity);
                MessageBox.Show("Folder has been Locked!", "Congratulations!", MessageBoxButtons.OK);
                myDirectoryInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                checkBox1.Visible = true;
            }

            else
            {
                MessageBox.Show("Select Path First");

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            removeAccess();
        }

        public void removeAccess()
        {

            if (path != null)
            {

                DirectoryInfo myDirectoryInfo = new DirectoryInfo(path);

                var sid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);


                DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
                myDirectorySecurity.RemoveAccessRuleAll(new FileSystemAccessRule(sid, FileSystemRights.Read, AccessControlType.Deny));

                myDirectoryInfo.SetAccessControl(myDirectorySecurity);
                MessageBox.Show("Folder has been Unlocked!", "Congratulations!", MessageBoxButtons.OK);

                string dir = "FolderLockData";
                Directory.CreateDirectory("data\\" + dir);
                var streamw = new StreamWriter("data\\" + dir + "\\data.ls");
                streamw.Flush();
                streamw.Close();
                checkBox1.Visible = false;
                myDirectoryInfo.Attributes = FileAttributes.Directory | FileAttributes.Normal;
                File.Delete("data\\" + dir + "\\data.ls");

            }
            else
            {
                MessageBox.Show("Select Path First");

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string dir = "FolderLockData";

                if (File.Exists("data\\" + dir + "\\data.ls"))
                {
                    var streamr = new StreamReader("data\\" + dir + "\\data.ls");
                    string encsavedpath = streamr.ReadLine();
                    string decsavedpath = AesCrypt.Decrypt(encsavedpath);
                    checkBox1.Text = decsavedpath;
                    path = checkBox1.Text;
                    streamr.Close();

                    if (path != null)
                    {
                        textBox1.Text = path;
                        button2.Select();

                    }
                }
                else
                {
                    MessageBox.Show("Path Information is Missing");


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            


        }

        private void FolderLock_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main form = new Main();
            form.Show();
        }
    }
}
