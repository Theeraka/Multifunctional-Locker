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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Password is Empty");
                    textBox1.Clear();


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
                        Code form = new Code();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Password Not Set!");
                        textBox1.Clear();
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Password is Incorrect!");
                textBox1.Clear();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Password is Empty");
                        textBox1.Clear();


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
                            Code form = new Code();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Password Not Set!");
                            textBox1.Clear();
                        }
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Password is Incorrect!");
                    textBox1.Clear();
                }


            }
        }
    }
}
