using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class CN_EmpleadoMenu
    {
        private CD_EmpleadoMenu objEmpleados = new CD_EmpleadoMenu();
        public DataTable BuscarEmpleado(string cedula)
        {
            DataTable tabla = new DataTable();
            tabla = objEmpleados.BuscarEmpleado(cedula);
            return tabla;
        }

        public DataTable BuscarEmpleadoCap(string cedula)
        {
            DataTable tabla = new DataTable();
            tabla = objEmpleados.BuscarEmpleadoCap(cedula);
            return tabla;
        }

        public DataTable BuscarEmpleadoRef(string cedula)
        {
            DataTable tabla = new DataTable();
            tabla = objEmpleados.BuscarEmpleadoRef(cedula);
            return tabla;
        }

        public DataTable BuscarEmpleadoFam(string cedula)
        {
            DataTable tabla = new DataTable();
            tabla = objEmpleados.BuscarEmpleadoFam(cedula);
            return tabla;
        }

        public DataTable BuscarEmpleadoUsu(string cedula)
        {
            DataTable tabla = new DataTable();
            tabla = objEmpleados.BuscarEmpleadoUsu(cedula);
            return tabla;
        }
    }
}
