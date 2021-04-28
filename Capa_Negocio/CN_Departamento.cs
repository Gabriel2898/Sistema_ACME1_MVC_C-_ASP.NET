using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class CN_Departamento
    {
        private CD_Departamento objDepartamento;
        public Boolean AgregarDepartamento(string nombre, int idEmpresa)
        {
            try
            {
                objDepartamento = new CD_Departamento();
                objDepartamento.AgregarDepartamento(nombre, idEmpresa);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public Boolean EliminarDepartamento(int id)
        {
            try
            {
                objDepartamento = new CD_Departamento();
                objDepartamento.EliminarDepartamento(id);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public DataTable MostrarDepartamento()
        {
            objDepartamento = new CD_Departamento();
            DataTable dtbl = new DataTable();
            dtbl = objDepartamento.MostrarDepartamento();
            return dtbl;
        }

        public DataTable BuscarDepartamento(int id)
        {
            DataTable tabla = new DataTable();
            tabla = objDepartamento.BuscarDepartamento(id);
            return tabla;
        }

        public Boolean ActualizarDepartamento(int id, string nombre, int idEmpresa)
        {
            try
            {
                objDepartamento = new CD_Departamento();
                objDepartamento.ActualizarDepartamento(id, nombre, idEmpresa);
                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
