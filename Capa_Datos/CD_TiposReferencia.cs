using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_TiposReferencia
    {
        private CD_Conexion con = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public void AgregarTipoReferencia(string nombre)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_agregarTipoReferencia";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@tipr_nombre", nombre);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void EliminarTipoReferencia(int id)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_eliminarTipoReferencia";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@tipr_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarTipoReferencia()
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_mostrarTipoReferencia";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarTipoReferencia(int id)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarTipoReferencia", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@tipr_id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public void ActualizarTipoReferencia(int id, string nombre)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_editarTipoReferencia";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@tipr_id", id);
            comando.Parameters.AddWithValue("@tipr_nombre", nombre);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }
    }
}
