using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Capa_Datos
{
    public class CD_Usuario
    {
        private CD_Conexion con = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public void AgregarUsuario(string cedula, string usuario, string clave, int tipo)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_agregarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usu_cedula", cedula);
            comando.Parameters.AddWithValue("@usu_usuario", usuario);
            comando.Parameters.AddWithValue("@usu_clave", clave);
            comando.Parameters.AddWithValue("@tip_usuario", tipo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void EliminarUsuario(string id)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_eliminarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usu_cedula", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarUsuario()
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_mostrarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarUsuario(string id)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarUsuario", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@per_cedula", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public void ActualizarUsuario(string cedula, string usuario, string clave, int tipo)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_editarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usu_cedula", cedula);
            comando.Parameters.AddWithValue("@usu_usuario", usuario);
            comando.Parameters.AddWithValue("@usu_clave", clave);
            comando.Parameters.AddWithValue("@tip_usuario", tipo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataAdapter sqlAdapter = null;
        public DataSet dsConsultarTipoUsuario()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                string stSentencia = "SELECT * FROM tbl_tipousuario";

                sqlAdapter = new SqlDataAdapter(stSentencia, con.AbrirConexion());
                sqlAdapter.Fill(dsConsulta);

                return dsConsulta;
            }
            catch (Exception ex) { throw ex; }
        }

        public void cargarControl(ref DropDownList ddlControl,
            DataSet dsConsulta,
            string stValor,
            string stTexto,
            string stTextoEncabezado)
        {
            try
            {
                ddlControl.DataSource = dsConsulta;
                ddlControl.DataValueField = stValor;
                ddlControl.DataTextField = stTexto;
                ddlControl.DataBind();

                ddlControl.Items.Insert(0, new ListItem(stTextoEncabezado));
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
