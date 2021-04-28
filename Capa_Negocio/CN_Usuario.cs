using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class CN_Usuario
    {
        private CD_Usuario objUsuario;
        public Boolean AgregarUsuario(string cedula, string usuario, string clave, int tipo)
        {
            try
            {
                objUsuario = new CD_Usuario();
                objUsuario.AgregarUsuario(cedula, usuario, clave, tipo);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public Boolean EliminarUsuario(string cedula)
        {
            try
            {
                objUsuario = new CD_Usuario();
                objUsuario.EliminarUsuario(cedula);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public DataTable MostrarUsuario()
        {
            objUsuario = new CD_Usuario();
            DataTable dtbl = new DataTable();
            dtbl = objUsuario.MostrarUsuario();
            return dtbl;
        }

        public DataTable BuscarUsuario(string cedula)
        {
            DataTable tabla = new DataTable();
            tabla = objUsuario.BuscarUsuario(cedula);
            return tabla;
        }

        public Boolean ActualizarUsuario(string cedula, string usuario, string clave, int tipo)
        {
            try
            {
                objUsuario = new CD_Usuario();
                objUsuario.ActualizarUsuario(cedula, usuario, clave, tipo);
                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
