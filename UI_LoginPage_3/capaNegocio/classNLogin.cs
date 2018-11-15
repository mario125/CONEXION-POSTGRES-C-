using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using capaData;
using System.Data.Odbc;
using System.Data;
using Npgsql;
namespace capaNegocio
{
    public class ClassNLogin
    {
        private classLogin objData = new classLogin();
        private string _usuario;
        private string _password;

        public string Usuario
        {
            set { _usuario = value; }
            get { return _usuario; }
        }
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        // constructor
        public ClassNLogin() { }
        public NpgsqlDataReader IniciarSesion()
        {
            NpgsqlDataReader loguin;
            loguin = objData.iniciarSesion(Usuario,Password);
            return loguin;
        }


    }
}
