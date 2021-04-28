using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class CN_TipoUsuario
    {
        private CN_TipoUsuario objTipoUsuarios;
        public Boolean AgregarTipoUsuario(string nombre)
        {
            try
            {
                objTipoUsuarios = new CN_TipoUsuario();
                objTipoUsuarios.AgregarTipoUsuario(nombre);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public Boolean EliminarTipoUsuario(int id)
        {
            try
            {
                objTipoUsuarios = new CN_TipoUsuario();
                objTipoUsuarios.EliminarTipoUsuario(id);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public DataTable MostrarTipoUsuario()
        {
            objTipoUsuarios = new CN_TipoUsuario();
            DataTable dtbl = new DataTable();
            dtbl = objTipoUsuarios.MostrarTipoUsuario();
            return dtbl;
        }

        public DataTable BuscarTipoUsuario(int id)
        {
            DataTable tabla = new DataTable();
            tabla = objTipoUsuarios.BuscarTipoUsuario(id);
            return tabla;
        }

        public Boolean ActualizarTipoUsuario(int id, string nombre)
        {
            try
            {
                objTipoUsuarios = new CN_TipoUsuario();
                objTipoUsuarios.ActualizarTipoUsuario(id, nombre);
                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
