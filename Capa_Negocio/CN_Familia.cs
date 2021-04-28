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
    public class CN_Familia
    {
        private CD_Familia objFamilia;
        public Boolean AgregarCargaFamiliar(string cedulaPariente, string nombre, string apellido,
            string parentesco, int edad, string cedulaEmpleado)
        {
            try
            {
                objFamilia = new CD_Familia();

                objFamilia.AgregarCargaFamiliar(cedulaPariente, nombre, apellido, parentesco,
                    edad, cedulaEmpleado);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public Boolean EliminarCargaFamiliar(int id)
        {
            try
            {
                objFamilia = new CD_Familia();
                objFamilia.EliminarCargaFamiliar(id);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public DataTable MostrarCargaFamiliar()
        {
            objFamilia = new CD_Familia();
            DataTable dtbl = new DataTable();
            dtbl = objFamilia.MostrarCargaFamiliar();
            return dtbl;
        }

        public DataTable BuscarCargaFamiliar(int id)
        {
            DataTable tabla = new DataTable();
            tabla = objFamilia.BuscarCargaFamiliar(id);
            return tabla;
        }

        public Boolean ActualizarCargaFamiliar(int id, string cedulaPariente, string nombre, string apellido,
            string parentesco, int edad, string cedulaEmpleado)
        {
            try
            {
                objFamilia = new CD_Familia();
                objFamilia.ActualizarCargaFamiliar(id, cedulaPariente, nombre, apellido, parentesco,
                    edad, cedulaEmpleado);
                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
