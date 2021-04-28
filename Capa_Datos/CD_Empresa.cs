using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Empresa
    {
        private CD_Conexion con = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public void AgregarEmpresa(string ruc, string nombre, string telefono, string direccion)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_agregarEmpresa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@empr_ruc", ruc);
            comando.Parameters.AddWithValue("@empr_nombre", nombre);
            comando.Parameters.AddWithValue("@empr_telefono", telefono);
            comando.Parameters.AddWithValue("@empr_direccion", direccion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void EliminarEmpresa(int id)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_eliminarEmpresa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@empr_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarEmpresa()
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_mostrarEmpresa";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarEmpresa(int id)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarEmpresa", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@empr_id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public void ActualizarEmpresa(int id, string ruc, string nombre, string telefono, string direccion)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_editarEmpresa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@empr_id", id);
            comando.Parameters.AddWithValue("@empr_ruc", ruc);
            comando.Parameters.AddWithValue("@empr_nombre", nombre);
            comando.Parameters.AddWithValue("@empr_telefono", telefono);
            comando.Parameters.AddWithValue("@empr_direccion", direccion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }
    }
}
