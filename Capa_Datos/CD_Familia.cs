using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Familia
    {
        private CD_Conexion con = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public void AgregarCargaFamiliar(string cedulaPariente, string nombre, string apellido,
            string parentesco, int edad, string cedulaEmpleado)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_agregarFamilia";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@carf_cedula", cedulaPariente);
            comando.Parameters.AddWithValue("@carf_nombre", nombre);
            comando.Parameters.AddWithValue("@carf_apellido", apellido);
            comando.Parameters.AddWithValue("@carf_parentesco", parentesco);
            comando.Parameters.AddWithValue("@carf_edad", edad);
            comando.Parameters.AddWithValue("@per_cedula", cedulaEmpleado);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void EliminarCargaFamiliar(int id)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_eliminarFamilia";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@carf_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarCargaFamiliar()
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_mostrarFamilia";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarCargaFamiliar(int id)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarFamilia", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@carf_id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public void ActualizarCargaFamiliar(int id, string cedulaPariente, string nombre, string apellido,
            string parentesco, int edad, string cedulaEmpleado)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_editarFamilia";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@carf_id", id);
            comando.Parameters.AddWithValue("@carf_cedula", cedulaPariente);
            comando.Parameters.AddWithValue("@carf_nombre", nombre);
            comando.Parameters.AddWithValue("@carf_apellido", apellido);
            comando.Parameters.AddWithValue("@carf_parentesco", parentesco);
            comando.Parameters.AddWithValue("@carf_edad", edad);
            comando.Parameters.AddWithValue("@per_cedula", cedulaEmpleado);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }
    }
}
