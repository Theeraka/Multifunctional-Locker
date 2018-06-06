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
    public partial class Code : Form
    {
        public Code()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
                string dir = "UserCode";
                var streamr = new StreamReader("data\\" + dir + "\\data.ls");

                string Code1 = streamr.ReadLine();
                string Code2 = streamr.ReadLine();
                string Code3 = streamr.ReadLine();
                string Code4 = streamr.ReadLine();
                string Code5 = streamr.ReadLine();
                string Code6 = streamr.ReadLine();
                string Code7 = streamr.ReadLine();
                string Code8 = streamr.ReadLine();
                string Code9 = streamr.ReadLine();
                string Code10 = streamr.ReadLine();
                string Code11 = streamr.ReadLine();
                string Code12 = streamr.ReadLine();

                streamr.Close();

                string decCode1 = AesCrypt.Decrypt(Code1);
                string decCode2 = AesCrypt.Decrypt(Code2);
                string decCode3 = AesCrypt.Decrypt(Code3);
                string decCode4 = AesCrypt.Decrypt(Code4);
                string decCode5 = AesCrypt.Decrypt(Code5);
                string decCode6 = AesCrypt.Decrypt(Code6);
                string decCode7 = AesCrypt.Decrypt(Code7);
                string decCode8 = AesCrypt.Decrypt(Code8);
                string decCode9 = AesCrypt.Decrypt(Code9);
                string decCode10 = AesCrypt.Decrypt(Code10);
                string decCode11 = AesCrypt.Decrypt(Code11);
                string decCode12 = AesCrypt.Decrypt(Code12);

                int code_Hour1 = 6;
                int code_Hour2 = 7;
                int code_Hour3 = 8;
                int code_Hour4 = 9;
                int code_Hour5 = 10;
                int code_Hour6 = 11;
                int code_Hour7 = 12;
                int code_Hour8 = 13;
                int code_Hour9 = 14;
                int code_Hour10 = 15;
                int code_Hour11 = 16;
                int code_Hour12 = 17;


                try
                {
                    if (DateTime.Now.Hour == code_Hour1)//Time 6 hour
                    {

                        if (decCode1 == textBox1.Text)
                        {
                            Main form = new Main();
                            form.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        if (DateTime.Now.Hour == code_Hour2)//Time 7 hour
                        {

                            if (decCode2 == textBox1.Text)
                            {
                                Main form = new Main();
                                form.Show();
                                this.Hide();
                            }

                        }
                        else
                        {
                            if (DateTime.Now.Hour == code_Hour3)//Time 8 hour
                            {

                                if (decCode3 == textBox1.Text)
                                {
                                    Main form = new Main();
                                    form.Show();
                                    this.Hide();
                                }

                            }
                            else
                            {
                                if (DateTime.Now.Hour == code_Hour4)//Time 9 hour
                                {

                                    if (decCode4 == textBox1.Text)
                                    {
                                        Main form = new Main();
                                        form.Show();
                                        this.Hide();
                                    }

                                }
                                else
                                {
                                    if (DateTime.Now.Hour == code_Hour5)//Time 10 hour
                                    {

                                        if (decCode5 == textBox1.Text)
                                        {
                                            Main form = new Main();
                                            form.Show();
                                            this.Hide();
                                        }

                                    }
                                    else
                                    {
                                        if (DateTime.Now.Hour == code_Hour6)//Time 11 hour
                                        {

                                            if (decCode6 == textBox1.Text)
                                            {
                                                Main form = new Main();
                                                form.Show();
                                                this.Hide();
                                            }

                                        }
                                        else
                                        {
                                            if (DateTime.Now.Hour == code_Hour7)//Time 12 hour
                                            {

                                                if (decCode7 == textBox1.Text)
                                                {
                                                    Main form = new Main();
                                                    form.Show();
                                                    this.Hide();
                                                }

                                            }
                                            else
                                            {
                                                if (DateTime.Now.Hour == code_Hour8)//Time 13 hour
                                                {

                                                    if (decCode8 == textBox1.Text)
                                                    {
                                                        Main form = new Main();
                                                        form.Show();
                                                        this.Hide();
                                                    }

                                                }
                                                else
                                                {
                                                    if (DateTime.Now.Hour == code_Hour9)//Time 14 hour
                                                    {

                                                        if (decCode9 == textBox1.Text)
                                                        {
                                                            Main form = new Main();
                                                            form.Show();
                                                            this.Hide();
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (DateTime.Now.Hour == code_Hour10)//Time 15 hour
                                                        {

                                                            if (decCode10 == textBox1.Text)
                                                            {
                                                                Main form = new Main();
                                                                form.Show();
                                                                this.Hide();
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (DateTime.Now.Hour == code_Hour11)//Time 16 hour
                                                            {

                                                                if (decCode11 == textBox1.Text)
                                                                {
                                                                    Main form = new Main();
                                                                    form.Show();
                                                                    this.Hide();
                                                                }

                                                            }
                                                            else
                                                            {
                                                                if (DateTime.Now.Hour == code_Hour12)//Time 17 hour
                                                                {

                                                                    if (decCode12 == textBox1.Text)
                                                                    {
                                                                        Main form = new Main();
                                                                        form.Show();
                                                                        this.Hide();
                                                                    }

                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Incorrect Code!");
                                                                    textBox1.Clear();

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                        }

                                    }
                                }
                            }

                        }
                    }

                }

                catch (Exception)
                {
                    MessageBox.Show("Incorrect Code!ByTime");
                    //throw ex;
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = "UserCode";
                Directory.CreateDirectory("data\\" + dir);

                var streamw = new StreamWriter("data\\" + dir + "\\data.ls");


                string Code1 = AesCrypt.Encrypt(textBox2.Text);
                string Code2 = AesCrypt.Encrypt(textBox3.Text);
                string Code3 = AesCrypt.Encrypt(textBox4.Text);
                string Code4 = AesCrypt.Encrypt(textBox5.Text);
                string Code5 = AesCrypt.Encrypt(textBox6.Text);
                string Code6 = AesCrypt.Encrypt(textBox7.Text);
                string Code7 = AesCrypt.Encrypt(textBox8.Text);
                string Code8 = AesCrypt.Encrypt(textBox9.Text);
                string Code9 = AesCrypt.Encrypt(textBox10.Text);
                string Code10 = AesCrypt.Encrypt(textBox11.Text);
                string Code11 = AesCrypt.Encrypt(textBox12.Text);
                string Code12 = AesCrypt.Encrypt(textBox13.Text);
                streamw.WriteLine(Code1);
                streamw.WriteLine(Code2);
                streamw.WriteLine(Code3);
                streamw.WriteLine(Code4);
                streamw.WriteLine(Code5);
                streamw.WriteLine(Code6);
                streamw.WriteLine(Code7);
                streamw.WriteLine(Code8);
                streamw.WriteLine(Code9);
                streamw.WriteLine(Code10);
                streamw.WriteLine(Code11);
                streamw.WriteLine(Code12);
                streamw.Close();

                MessageBox.Show("Code Successfully Added.");
            }
            catch (Exception)
            {

                throw;
            }
                
                
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string dir = "UserCode";
                var streamr = new StreamReader("data\\" + dir + "\\data.ls");

                string Code1 = streamr.ReadLine();
                string Code2 = streamr.ReadLine();
                string Code3 = streamr.ReadLine();
                string Code4 = streamr.ReadLine();
                string Code5 = streamr.ReadLine();
                string Code6 = streamr.ReadLine();
                string Code7 = streamr.ReadLine();
                string Code8 = streamr.ReadLine();
                string Code9 = streamr.ReadLine();
                string Code10 = streamr.ReadLine();
                string Code11 = streamr.ReadLine();
                string Code12 = streamr.ReadLine();
                                
                streamr.Close();

                string decCode1 = AesCrypt.Decrypt(Code1);
                string decCode2 = AesCrypt.Decrypt(Code2);
                string decCode3 = AesCrypt.Decrypt(Code3);
                string decCode4 = AesCrypt.Decrypt(Code4);
                string decCode5 = AesCrypt.Decrypt(Code5);
                string decCode6 = AesCrypt.Decrypt(Code6);
                string decCode7 = AesCrypt.Decrypt(Code7);
                string decCode8 = AesCrypt.Decrypt(Code8);
                string decCode9 = AesCrypt.Decrypt(Code9);
                string decCode10 = AesCrypt.Decrypt(Code10);
                string decCode11 = AesCrypt.Decrypt(Code11);
                string decCode12 = AesCrypt.Decrypt(Code12);
                
                int code_Hour1 = 6;
                int code_Hour2 = 7;
                int code_Hour3 = 8;
                int code_Hour4 = 9;
                int code_Hour5 = 10;
                int code_Hour6 = 11;
                int code_Hour7 = 12;
                int code_Hour8 = 13;
                int code_Hour9 = 14;
                int code_Hour10 = 15;
                int code_Hour11 = 16;
                int code_Hour12 = 17;
                

                try
                {
                    if (DateTime.Now.Hour == code_Hour1)//Time 6 hour
                    {

                        if (decCode1 == textBox1.Text)
                        {
                            Main form = new Main();
                            form.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        if (DateTime.Now.Hour == code_Hour2)//Time 7 hour
                        {

                            if (decCode2 == textBox1.Text)
                            {
                                Main form = new Main();
                                form.Show();
                                this.Hide();
                            }

                        }
                        else
                        {
                            if (DateTime.Now.Hour == code_Hour3)//Time 8 hour
                            {

                                if (decCode3 == textBox1.Text)
                                {
                                    Main form = new Main();
                                    form.Show();
                                    this.Hide();
                                }

                            }
                            else
                            {
                                if (DateTime.Now.Hour == code_Hour4)//Time 9 hour
                                {

                                    if (decCode4 == textBox1.Text)
                                    {
                                        Main form = new Main();
                                        form.Show();
                                        this.Hide();
                                    }

                                }
                                else
                                {
                                    if (DateTime.Now.Hour == code_Hour5)//Time 10 hour
                                    {

                                        if (decCode5 == textBox1.Text)
                                        {
                                            Main form = new Main();
                                            form.Show();
                                            this.Hide();
                                        }

                                    }
                                    else
                                    {
                                        if (DateTime.Now.Hour == code_Hour6)//Time 11 hour
                                        {

                                            if (decCode6 == textBox1.Text)
                                            {
                                                Main form = new Main();
                                                form.Show();
                                                this.Hide();
                                            }

                                        }
                                        else
                                        {
                                            if (DateTime.Now.Hour == code_Hour7)//Time 12 hour
                                            {

                                                if (decCode7 == textBox1.Text)
                                                {
                                                    Main form = new Main();
                                                    form.Show();
                                                    this.Hide();
                                                }

                                            }
                                            else
                                            {
                                                if (DateTime.Now.Hour == code_Hour8)//Time 13 hour
                                                {

                                                    if (decCode8 == textBox1.Text)
                                                    {
                                                        Main form = new Main();
                                                        form.Show();
                                                        this.Hide();
                                                    }

                                                }
                                                else
                                                {
                                                    if (DateTime.Now.Hour == code_Hour9)//Time 14 hour
                                                    {

                                                        if (decCode9 == textBox1.Text)
                                                        {
                                                            Main form = new Main();
                                                            form.Show();
                                                            this.Hide();
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (DateTime.Now.Hour == code_Hour10)//Time 15 hour
                                                        {

                                                            if (decCode10 == textBox1.Text)
                                                            {
                                                                Main form = new Main();
                                                                form.Show();
                                                                this.Hide();
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (DateTime.Now.Hour == code_Hour11)//Time 16 hour
                                                            {

                                                                if (decCode11 == textBox1.Text)
                                                                {
                                                                    Main form = new Main();
                                                                    form.Show();
                                                                    this.Hide();
                                                                }

                                                            }
                                                            else
                                                            {
                                                                if (DateTime.Now.Hour == code_Hour12)//Time 17 hour
                                                                {

                                                                    if (decCode12 == textBox1.Text)
                                                                    {
                                                                        Main form = new Main();
                                                                        form.Show();
                                                                        this.Hide();
                                                                    }

                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Incorrect Code!");
                                                                    textBox1.Clear();

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                        }

                                    }
                                }
                            }

                        }
                    }

                }

                catch (Exception)
                {
                    MessageBox.Show("Incorrect Code!ByTime");
                    //throw ex;
                }
            }
                
        }

        private void Code_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Code_Load(object sender, EventArgs e)
        {
            
        }
    }
}
