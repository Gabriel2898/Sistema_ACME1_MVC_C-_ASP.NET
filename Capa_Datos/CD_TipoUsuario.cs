using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_TipoUsuario
    {
        private CD_Conexion con = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public void AgregarTipoUsuario(string nombre)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_agregarTipoUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@tipu_nombre", nombre);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void EliminarTipoUsuario(int id)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_eliminarTipoUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@tipu_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarTipoUsuario()
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_mostrarTipoUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarTipoUsuario(int id)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarTipoUsuario", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@tipu_id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public void ActualizarTipoUsuario(int id, string nombre)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_editarTipoUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@tipu_id", id);
            comando.Parameters.AddWithValue("@tipu_nombre", nombre);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }
    }
}
