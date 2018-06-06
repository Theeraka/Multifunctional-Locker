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
    public partial class FileLock : Form
    {
        public string path;

        public FileLock()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Browse";
            open.Filter = "Text Files (*.txt)|*.txt|JPEG Files (*.jpg)|*.jpg|Doc Files (*.docx)|*.docx|Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";

            if (open.ShowDialog() == DialogResult.OK)
            {
                textBoxSelect_Path.Text = open.FileName;
                
                path = textBoxSelect_Path.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SetAccess();
        }

        
        public void SetAccess()
        {
            try
            {
                if (path != null)
                {
                    DirectoryInfo myDirectoryInfo = new DirectoryInfo(path);

                    string dir = "FileLockData";
                    Directory.CreateDirectory("data\\" + dir);
                    var streamw = new StreamWriter("data\\" + dir + "\\data.ls");

                    string dc = AesCrypt.Encrypt(textBoxSelect_Path.Text);
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

                    MessageBox.Show("File has been Locked!", "Congratulations!", MessageBoxButtons.OK);

                    checkBox1.Visible = true;

                }

                else
                {
                    MessageBox.Show("Select Path First");

                }
            }
            catch (Exception ex )
            {

                throw ex;
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          removeAccess();

        }
        

        public void removeAccess()
        {
            try
            {
                
                if (path != null)
                {
                    DirectoryInfo myDirectoryInfo = new DirectoryInfo(path);

                    var sid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);


                    DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
                    myDirectorySecurity.RemoveAccessRuleAll(new FileSystemAccessRule(sid, FileSystemRights.Read, AccessControlType.Deny));

                    myDirectoryInfo.SetAccessControl(myDirectorySecurity);
                    MessageBox.Show("File has been Unlocked!", "Congratulations!", MessageBoxButtons.OK);

                    string dir = "FileLockData";
                    Directory.CreateDirectory("data\\" + dir);
                    var streamw = new StreamWriter("data\\" + dir + "\\data.ls");
                    streamw.Flush();
                    streamw.Close();
                    checkBox1.Visible = false;
                    File.Delete("data\\" + dir + "\\data.ls");

                }
                else
                {
                    MessageBox.Show("Select Path First");

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                
                string dir = "FileLockData";
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

                        textBoxSelect_Path.Text = path;
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

        private void FileLock_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main form = new Main();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string FileName1 = path;
            AddEncryption(FileName1);
            
        }
        public void AddEncryption(string FileName1)
        {

            try
            {
                
                
                if (path != null)
                    {
                    string dir = "FileEncryptData";
                    Directory.CreateDirectory("data\\" + dir);
                    var streamw = new StreamWriter("data\\" + dir + "\\data.ls");

                    string dc = AesCrypt.Encrypt(textBoxSelect_Path.Text);
                    streamw.WriteLine(dc);
                    streamw.Close();
                    try
                    {
                        File.Encrypt(FileName1);
                        MessageBox.Show("File has been Encrypted!", "Congratulations!", MessageBoxButtons.OK);
                        checkBox2.Visible = true;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    
                    }
                    else
                    {
                        MessageBox.Show("Select Path First");
                    }
                
            }
            catch (Exception ex)
            {

                throw ex;
                
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string FileName2 = path;
            RemoveEncryption(FileName2);
        }
        public void RemoveEncryption(string FileName2)
        {
            try
            {   
                    if (path != null)
                    {
                        File.Decrypt(FileName2);
                        MessageBox.Show("File has been Decrypted!", "Congratulations!", MessageBoxButtons.OK);
                        

                    string dir = "FileEncryptData";
                    Directory.CreateDirectory("data\\" + dir);
                    var streamw = new StreamWriter("data\\" + dir + "\\data.ls");
                    streamw.Flush();
                    streamw.Close();
                    checkBox2.Visible = false;
                    File.Delete("data\\" + dir + "\\data.ls");
                    }
                    else
                    {
                        MessageBox.Show("Select Path First");

                    }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private void FileLock_Load(object sender, EventArgs e)
        {
            try
            {
                    string dir = "FileLockData";
                    if (File.Exists("data\\" + dir + "\\data.ls"))
                    {
                    checkBox1.Visible = true;
                
                    }
                    else
                    {
                    checkBox1.Visible = false;
                    }
                    string dir1 = "FileEncryptData";
                    if (File.Exists("data\\" + dir1 + "\\data.ls"))
                    {
                    checkBox2.Visible = true;

                    }
                    else
                    {
                    checkBox2.Visible = false;
                    }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string dir = "FileEncryptData";
                if (File.Exists("data\\" + dir + "\\data.ls"))
                {
                    var streamr = new StreamReader("data\\" + dir + "\\data.ls");
                    string encsavedpath = streamr.ReadLine();
                    string decsavedpath = AesCrypt.Decrypt(encsavedpath);
                    checkBox2.Text = decsavedpath;
                    path = checkBox2.Text;
                    streamr.Close();


                    if (path != null)
                    {
                        textBoxSelect_Path.Text = path;
                        button5.Select();
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
    }
}
