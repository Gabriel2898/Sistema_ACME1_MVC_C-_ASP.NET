using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class CN_Empresa
    {
        private CD_Empresa objEmpresa;
        public Boolean AgregarEmpresa(string ruc, string nombre, string telefono, string direccion)
        {
            try
            {
                objEmpresa = new CD_Empresa();
                objEmpresa.AgregarEmpresa(ruc, nombre, telefono, direccion);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public Boolean EliminarEmpresa(int id)
        {
            try
            {
                objEmpresa = new CD_Empresa();
                objEmpresa.EliminarEmpresa(id);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public DataTable MostrarEmpresa()
        {
            objEmpresa = new CD_Empresa();
            DataTable dtbl = new DataTable();
            dtbl = objEmpresa.MostrarEmpresa();
            return dtbl;
        }

        public DataTable BuscarEmpresa(int id)
        {
            DataTable tabla = new DataTable();
            tabla = objEmpresa.BuscarEmpresa(id);
            return tabla;
        }

        public Boolean ActualizarEmpresa(int id, string ruc, string nombre, string telefono, string direccion)
        {
            try
            {
                objEmpresa = new CD_Empresa();
                objEmpresa.ActualizarEmpresa(id, ruc, nombre, telefono, direccion);
                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
