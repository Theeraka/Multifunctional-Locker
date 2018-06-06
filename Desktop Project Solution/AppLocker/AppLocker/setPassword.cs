using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AesEncDec;
using System.IO;

namespace AppLocker
{
    public partial class setPassword : Form
    {

        public setPassword()
        {
            InitializeComponent();
        }

        private void setPassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Pass_textBox.Text == "")
            {
                MessageBox.Show("Password is Empty");


            }
            else
            {
                string dir = "Userdata";
                var streamr = new StreamReader("data\\" + dir + "\\data.ls");


                string encpass = streamr.ReadLine();
                streamr.Close();


                string decpass = AesCrypt.Decrypt(encpass);

                if (decpass == textBox1.Text)
                {
                    if (Pass_textBox.Text.Length < 4)
                    {
                        MessageBox.Show("Password is Invaled or too short!");
                    }
                    else
                    {
                        string dir1 = "Userdata";
                        Directory.CreateDirectory("data\\" + dir1);

                        var streamw = new StreamWriter("data\\" + dir1 + "\\data.ls");

                        string w_encpass = AesCrypt.Encrypt(Pass_textBox.Text);

                        streamw.WriteLine(w_encpass);
                        streamw.Close();

                        MessageBox.Show("Password Successfully Changed.");
                        Pass_textBox.Clear();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Password Not Matched!");
                    textBox1.Clear();
                }

                
            }
        }

        private void setPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main form = new Main();
            form.Show();
        }
    }
}
