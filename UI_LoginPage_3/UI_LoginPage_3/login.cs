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


namespace UI_LoginPage_3
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
          


            ClassNLogin objLog = new ClassNLogin();
            OdbcDataReader loguear;
            objLog.Usuario = "mario";
            objLog.Password = "ch";
            loguear = objLog.IniciarSesion();
            if (loguear.Read() == true)
            {
                MessageBox.Show("todo correcto");
            }
            else
                MessageBox.Show("error...!!");
        }
    }
}
