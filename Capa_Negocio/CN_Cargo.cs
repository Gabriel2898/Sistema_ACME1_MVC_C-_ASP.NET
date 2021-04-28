using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CN_Cargo
    {
        private CD_Cargo objCargo;
        public Boolean AgregarCargo(string nombre)
        {
            try
            {
                objCargo = new CD_Cargo();
                objCargo.AgregarCargo(nombre);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public Boolean EliminarCargo(int id)
        {
            try
            {
                objCargo = new CD_Cargo();
                objCargo.EliminarCargo(id);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public DataTable MostrarDepartamento()
        {
            objCargo = new CD_Cargo();
            DataTable dtbl = new DataTable();
            dtbl = objCargo.MostrarCargo();
            return dtbl;
        }

        public DataTable BuscarCargo(int id)
        {
            DataTable tabla = new DataTable();
            tabla = objCargo.BuscarCargo(id);
            return tabla;
        }

        public Boolean ActualizarCargo(int id, string nombre)
        {
            try
            {
                objCargo = new CD_Cargo();
                objCargo.ActualizarCargo(id, nombre);
                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
