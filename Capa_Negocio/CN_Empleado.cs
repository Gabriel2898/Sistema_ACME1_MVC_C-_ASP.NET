using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class CN_Empleado
    {
        private CD_Empleado objEmpleado;
        public Boolean AgregarEmpleado(string ced, string n1, string n2, string a1, string a2, string dir, string tel, string mail, int idDep, int idCargo)
        {
            try
            {
                objEmpleado = new CD_Empleado();
                objEmpleado.AgregarEmpleado(ced, n1, n2, a1, a2, dir, tel, mail, idDep, idCargo);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public Boolean EliminarEmpleado(string cedula)
        {
            try
            {
                objEmpleado = new CD_Empleado();
                objEmpleado.EliminarEmpleado(cedula);
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public DataTable MostrarEmpleado()
        {
            objEmpleado = new CD_Empleado();
            DataTable dtbl = new DataTable();
            dtbl = objEmpleado.MostrarEmpleado();
            return dtbl;
        }

        public DataTable BuscarEmpleado(string cedula)
        {
            DataTable tabla = new DataTable();
            tabla = objEmpleado.BuscarEmpleado(cedula);
            return tabla;
        }

        public Boolean ActualizarEmpleado(string ced, string n1, string n2, string a1, string a2, string dir, string tel, string mail, int idDep, int idCargo)
        {
            try
            {
                objEmpleado = new CD_Empleado();
                objEmpleado.ActualizarEmpleado(ced, n1, n2, a1, a2, dir, tel, mail, idDep, idCargo);
                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
