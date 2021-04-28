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
    public class CD_Login
    {

        private CD_Conexion con = new CD_Conexion();
        SqlDataReader leer;
        public SqlDataReader Autenticar_Usuario(string usuario, string clave, string tipo)
        {
            SqlCommand cmd = new SqlCommand("sp_validarUsuario", con.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usu_usuario", usuario);
            cmd.Parameters.AddWithValue("@usu_clave", clave);
            cmd.Parameters.AddWithValue("@usu_tipo", tipo);
            leer = cmd.ExecuteReader();
            return leer;
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
