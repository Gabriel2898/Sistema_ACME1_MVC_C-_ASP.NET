using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class CN_Login
    {
        private String _User, _Pass, _Tipo;
        public String Usuario
        {
            set
            {
                if (value == "")
                {
                    _User = "Ingrese el usuario";
                }
                else
                {
                    _User = value;
                }
            }
            get { return _User; }
        }
        public String Clave
        {
            set
            {
                if (value == "")
                {
                    _Pass = "Ingrese la clave";
                }
                else
                {
                    _Pass = value;
                }
            }
            get { return _Pass; }
        }

        public String Tipo
        {
            set
            {
                if (value == "Seleccione")
                {
                    _Tipo = "Escoga el tipo de usuario";
                }
                else
                {
                    _Tipo = value;
                }
            }
            get { return _Tipo; }
        }

        public CN_Login() { }

        private CD_Login objLogin = new CD_Login();
        public SqlDataReader iniciarSesion()
        {
            SqlDataReader iniciar;
            iniciar = objLogin.Autenticar_Usuario(Usuario, Clave, Tipo);
            return iniciar;
        }
    }
}
