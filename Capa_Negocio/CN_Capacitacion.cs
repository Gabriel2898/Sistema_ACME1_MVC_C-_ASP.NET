using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CN_Capacitacion
    {
        private CD_Capacitacion objCapacitacion;
        public Boolean AgregarCapacitacion(string descripcion, string ced)
        {
            try
            {
                objCapacitacion = new CD_Capacitacion();
                objCapacitacion.AgregarCapacitacion(descripcion, ced);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public Boolean EliminarCapacitacion(int id)
        {
            try
            {
                objCapacitacion = new CD_Capacitacion();
                objCapacitacion.EliminarCapacitacion(id);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public DataTable MostrarCapacitacion()
        {
            objCapacitacion = new CD_Capacitacion();
            DataTable dtbl = new DataTable();
            dtbl = objCapacitacion.MostrarCapacitacion();
            return dtbl;
        }

        public DataTable BuscarCapacitacion(int id)
        {
            DataTable tabla = new DataTable();
            tabla = objCapacitacion.BuscarCapacitacion(id);
            return tabla;
        }

        public Boolean ActualizarCapacitacion(int id, string descripcion, string ced)
        {
            try
            {
                objCapacitacion = new CD_Capacitacion();
                objCapacitacion.ActualizarCapacitacion(id, descripcion, ced);
                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
