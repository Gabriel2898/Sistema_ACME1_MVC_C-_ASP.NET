using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_EmpleadoMenu
    {
        private CD_Conexion con = new CD_Conexion();

        public DataTable BuscarEmpleado(string cedula)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarEmpleado", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@per_cedula", cedula);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public DataTable BuscarEmpleadoCap(string cedula)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarEmpleadoCap", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@per_cedula", cedula);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public DataTable BuscarEmpleadoRef(string cedula)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarEmpleadoRef", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@per_cedula", cedula);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public DataTable BuscarEmpleadoFam(string cedula)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarEmpleadoFam", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@per_cedula", cedula);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public DataTable BuscarEmpleadoUsu(string cedula)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarEmpleadoUsu", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@per_cedula", cedula);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }
    }
}
