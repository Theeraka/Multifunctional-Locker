using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppLocker
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
            
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setPassword f = new setPassword();
            f.Show();
            this.Hide();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppLock form = new AppLock();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderLock form = new FolderLock();
            form.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileLock form = new FileLock();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
