using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Capacitacion
    {
        private CD_Conexion con = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public void AgregarCapacitacion(string descripcion, string ced)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_agregarCapacitacion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cap_descripcion", descripcion);
            comando.Parameters.AddWithValue("@per_cedula", ced);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void EliminarCapacitacion(int id)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_eliminarCapacitacion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cap_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarCapacitacion()
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_mostrarCapacitacion";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarCapacitacion(int id)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarCapacitacion", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@cap_id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public void ActualizarCapacitacion(int id, string descripcion, string ced)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_editarCapacitacion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cap_id", id);
            comando.Parameters.AddWithValue("@cap_descripcion", descripcion);
            comando.Parameters.AddWithValue("@per_cedula", ced);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }
    }
}
