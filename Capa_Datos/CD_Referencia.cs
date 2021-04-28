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
    public class CD_Referencia
    {
        private CD_Conexion con = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public void AgregarReferencia(string nombre, int idTipr, string ced)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_agregarReferencia";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ref_descripcion", nombre);
            comando.Parameters.AddWithValue("@tipr_id", idTipr);
            comando.Parameters.AddWithValue("@per_cedula", ced);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void EliminarReferencia(int id)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_eliminarReferencia";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ref_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarReferencia()
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_mostrarReferencia";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarReferencia(int id)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarReferencia", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ref_id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public void ActualizarReferencia(int id, string nombre, int idTipr, string ced)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_editarReferencia";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ref_id", id);
            comando.Parameters.AddWithValue("@ref_descripcion", nombre);
            comando.Parameters.AddWithValue("@tipr_id", idTipr);
            comando.Parameters.AddWithValue("@per_cedula", ced);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        SqlDataAdapter sqlAdapter = null;
        public DataSet dsConsultarReferencia()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                string stSentencia = "select * from tbl_tiporeferencia";

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
