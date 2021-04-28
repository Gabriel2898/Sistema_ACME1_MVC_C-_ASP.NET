using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;


namespace Capa_Negocio
{
    public class CN_Referencia
    {
        private CD_Referencia objReferencia;
        public Boolean AgregarReferencia(string nombre, int idTipr, string ced)
        {
            try
            {
                objReferencia = new CD_Referencia();
                objReferencia.AgregarReferencia(nombre, idTipr, ced);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public Boolean EliminarReferencia(int id)
        {
            try
            {
                objReferencia = new CD_Referencia();
                objReferencia.EliminarReferencia(id);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public DataTable MostrarReferencia()
        {
            objReferencia = new CD_Referencia();
            DataTable dtbl = new DataTable();
            dtbl = objReferencia.MostrarReferencia();
            return dtbl;
        }

        public DataTable BuscarReferencia(int id)
        {
            DataTable tabla = new DataTable();
            tabla = objReferencia.BuscarReferencia(id);
            return tabla;
        }

        public Boolean ActualizarReferencia(int id, string nombre, int idTipr, string ced)
        {
            try
            {
                objReferencia = new CD_Referencia();
                objReferencia.ActualizarReferencia(id, nombre, idTipr, ced);
                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
