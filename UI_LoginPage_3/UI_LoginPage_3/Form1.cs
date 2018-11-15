using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocio;
using System.Data.Odbc;
using Npgsql;

namespace UI_LoginPage_3
{
    public partial class Form1 : Form
    {
        /*Thanks for Downloading this File.I like this can be useful,
        and can be the best reference for learning again. So if you are ready,
        subscribe now to get new videos and much project free.
        //
        //By: Padli Nurohman
        //YouTube: https://www.youtube.com/c/padlinurohman
        //Blog: http://www.theasdos.com
        */

        //Create instance object
        Timer timer1 = new Timer();
        Timer timer2 = new Timer();
        Label logreg = new Label();

        public Form1()
        {
            InitializeComponent();

            this.Size = new Size (320, 480);
            pictureBox2.Image = Properties.Resources._lock;
            pictureBox2.Enabled = false;
        }

        /// <summary>
        /// Form Load
        /// </summary>
        private void Form1Load(object sender, EventArgs e)
        {
            //Set properties
            timer1.Tick += new EventHandler(timer1_go);
            timer2.Tick += new EventHandler(timer2_go);
            timer1.Interval = 10;
            timer2.Interval = 5;
            timer1.Start();
        }

        /// <summary>
        /// Definition for timer function
        /// </summary>
        void timer1_go(object sender, EventArgs e)
        {
            Logoposition();
        }
        //
        void timer2_go(object sender, EventArgs e)
        {
            if (logreg.Text == "Register")
            {
                reg();
            }
            else if (logreg.Text == "Login")
            {
                log();
            }
        }

        /// <summary>
        /// Create animation
        /// </summary>
        int go = 1;
        #region
        //logo postion
        void Logoposition()
        {
            if(panel1.Left == 0)
            {
                pictureBox1.Top += go;
                if(pictureBox1.Top > 50)
                {
                    timer1.Stop();
                }
            }
            if(panel2.Left == 0)
            {
                pictureBox1.Top -= go;
                if(pictureBox1.Top < 34)
                {
                    timer1.Stop();
                }
            }
        }

        //line animation
        void line()
        {
            if (panel1.Left == 0)
            {
                bunifuSeparator2.LineThickness = 2;
                bunifuSeparator2.LineColor = Color.FromArgb(0, 173, 239);
                bunifuSeparator1.LineThickness = 1;
                bunifuSeparator1.LineColor = Color.Silver;
            }
            if (panel2.Left == 0)
            {
                bunifuSeparator2.LineThickness = 1;
                bunifuSeparator2.LineColor = Color.Silver;
                bunifuSeparator1.LineThickness = 2;
                bunifuSeparator1.LineColor = Color.FromArgb(0, 173, 239);
            }
        }

        //slide panel
        int move_speed = 20;
        void reg()
        {
            if (panel2.Left > 0)
            {
                timer1.Start();
                line();

                panel1.Left -= move_speed;
                panel2.Left -= move_speed;
                if (panel2.Left == 0)
                {
                    timer2.Stop();
                }
            }
        }
        void log()
        {
            if (panel1.Left < 0)
            {
                timer1.Start();
                line();

                panel2.Left += move_speed;
                panel1.Left += move_speed;
                if (panel1.Left == 0)
                {
                    timer2.Stop();
                }
            }
        }

        //image of key
        void unlock()
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
                pictureBox2.Image = Properties.Resources.show;
            }
            else
            {
                textBox2.PasswordChar = '*';
                pictureBox2.Image = Properties.Resources._lock;
            }
        }
        #endregion
        
        /// <summary>
        /// Event of TextBox
        /// </summary>
        void Enter1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = string.Empty;
            }
        }
        void Leave1(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "Username";
            }
        }
        void Enter2(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.PasswordChar = '*';
                pictureBox2.Enabled = true;
                textBox2.Text = string.Empty;
            }
        }
        void Leave2(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.PasswordChar = '\0';
                pictureBox2.Enabled = false;
                textBox2.Text = "Password";
            }
        }
        void Enter3(object sender, EventArgs e)
        {
            if (textBox3.Text == "Full Name")
            {
                textBox3.Text = string.Empty;
            }
        }
        void Leave3(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                textBox3.Text = "Full Name";
            }
        }
        void Enter4(object sender, EventArgs e)
        {
            if (textBox4.Text == "Username")
            {
                textBox4.Text = string.Empty;
            }
        }
        void Leave4(object sender, EventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                textBox4.Text = "Username";
            }
        }
        void Enter5(object sender, EventArgs e)
        {
            if (textBox5.Text == "Email")
            {
                textBox5.Text = string.Empty;
            }
        }
        void Leave5(object sender, EventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                textBox5.Text = "Email";
            }
        }
        void Enter6(object sender, EventArgs e)
        {
            if (textBox6.Text == "Password")
            {
                textBox6.PasswordChar = '*';
                textBox6.Text = string.Empty;
            }
        }
        void Leave6(object sender, EventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                textBox6.PasswordChar = '\0';
                textBox6.Text = "Password";
            }
        }

        /// <summary>
        /// Event of label Register&ogin
        /// </summary>
        private void Register(object sender, EventArgs e)
        {
            Label lr = (Label)sender;

            logreg = lr; 
            timer2.Start(); 
        }

        //Event of image
        private void lockun(object sender, EventArgs e)
        {
            unlock();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            ClassNLogin objLog = new ClassNLogin();
            NpgsqlDataReader loguear;
            objLog.Usuario = textBox1.Text;
            objLog.Password = textBox2.Text;
            loguear = objLog.IniciarSesion();
            string dato="";
            while (loguear.Read())
            {
                dato =""+ loguear[0];
            }     

            if (dato== "1")
            {
                
                    
                MessageBox.Show("todo correcto");
            }
            else
                MessageBox.Show("error...!!");




        }

        
    }
}
