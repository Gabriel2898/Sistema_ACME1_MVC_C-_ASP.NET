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
    public class CD_Departamento
    {
        private CD_Conexion con = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public void AgregarDepartamento(string nombre, int idEmpresa)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_agregarDepartamento";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dep_nombre", nombre);
            comando.Parameters.AddWithValue("@empr_id", idEmpresa);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void EliminarDepartamento(int id)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_eliminarDepartamento";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dep_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarDepartamento()
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_mostrarDepartamento";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarDepartamento(int id)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarDepartamento", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@dep_id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public void ActualizarDepartamento(int id, string nombre, int idEmpresa)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_editarDepartamento";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dep_id", id);
            comando.Parameters.AddWithValue("@dep_nombre", nombre);
            comando.Parameters.AddWithValue("@empr_id", idEmpresa);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataAdapter sqlAdapter = null;
        public DataSet dsConsultarEmpresa()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                string stSentencia = "select * from tbl_empresa";

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
