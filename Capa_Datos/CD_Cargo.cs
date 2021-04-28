using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Cargo
    {
        private CD_Conexion con = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public void AgregarCargo(string nombre)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_agregarCargo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@carg_nombre", nombre);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void EliminarCargo(int id)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_eliminarCargo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@carg_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarCargo()
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_mostrarCargo";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarCargo(int id)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarCargo", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@carg_id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public void ActualizarCargo(int id, string nombre)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_editarCargo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@carg_id", id);
            comando.Parameters.AddWithValue("@carg_nombre", nombre);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }
    }
}
