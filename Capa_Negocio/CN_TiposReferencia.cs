using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    class CN_TiposReferencia
    {
        private CD_TiposReferencia objTipoReferencia;
        public Boolean AgregarTipoReferencia(string nombre)
        {
            try
            {
                objTipoReferencia = new CD_TiposReferencia();
                objTipoReferencia.AgregarTipoReferencia(nombre);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public Boolean EliminarTipoReferencia(int id)
        {
            try
            {
                objTipoReferencia = new CD_TiposReferencia();
                objTipoReferencia.EliminarTipoReferencia(id);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public DataTable MostrarTipoReferencia()
        {
            objTipoReferencia = new CD_TiposReferencia();
            DataTable dtbl = new DataTable();
            dtbl = objTipoReferencia.MostrarTipoReferencia();
            return dtbl;
        }

        public DataTable BuscarTipoReferencia(int id)
        {
            DataTable tabla = new DataTable();
            tabla = objTipoReferencia.BuscarTipoReferencia(id);
            return tabla;
        }

        public Boolean ActualizarTipoReferencia(int id, string nombre)
        {
            try
            {
                objTipoReferencia = new CD_TiposReferencia();
                objTipoReferencia.ActualizarTipoReferencia(id, nombre);
                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
