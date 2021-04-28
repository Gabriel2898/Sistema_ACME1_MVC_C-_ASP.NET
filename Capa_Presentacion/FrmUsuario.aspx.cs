using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Datos;
using Capa_Negocio;
namespace Capa_Presentacion
{
    public partial class FrmUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CD_Login clsLogin = new CD_Login();
                DataSet dsConsulta = clsLogin.dsConsultarTipoUsuario();

                clsLogin.cargarControl(ref ddlTipo,
                     dsConsulta,
                     "tipu_id",
                     "tipu_nombre",
                     "Seleccione");
            }
            MostrarUsuario();
            btnBorrar.Enabled = false;
            btnActualizar.Enabled = false;

        }



        private CN_Usuario objUsuario = new CN_Usuario();
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (objUsuario.AgregarUsuario(txtCedula.Text,txtUsuario.Text,txtClave.Text,int.Parse(ddlTipo.SelectedValue)))
            {
                Limpiar();
                lblMensaje.Text = "Guardado con éxito";
                MostrarUsuario();
            }
            else
            {
                lblMensaje.Text = "Error, Primero Agregar Un Empleado!!";
            }


        }
        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Frm_Administrador.aspx");
        }
        private void MostrarUsuario()
        {
            GrvUsuario.DataSource = objUsuario.MostrarUsuario();
            GrvUsuario.DataBind();
        }

        protected void LinkVer_Click(object sender, EventArgs e)
        {
            string usuarioID = Convert.ToString((sender as LinkButton).CommandArgument);
            DataTable dtbl = new DataTable();

            dtbl = objUsuario.BuscarUsuario(usuarioID);

            txtCedula.Text = dtbl.Rows[0]["per_cedula"].ToString();
            txtUsuario.Text= dtbl.Rows[0]["usu_usuario"].ToString();
            txtClave.Text = dtbl.Rows[0]["usu_clave"].ToString();
            ddlTipo.SelectedValue= dtbl.Rows[0]["tipu_id"].ToString();
            btnGuardar.Enabled = false;
            btnBorrar.Enabled = true;
            btnActualizar.Enabled = true;

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {

            if (objUsuario.ActualizarUsuario(txtCedula.Text, txtUsuario.Text, txtClave.Text, int.Parse(ddlTipo.SelectedValue)) == true)
            {
                Limpiar();
                lblMensaje.Text = "Actualizado con éxito";
                MostrarUsuario();
            }
            else
            {
                lblMensaje.Text = "Sucedio un error no se pudo Actualizar!!";
            }


        }
        private void Limpiar()
        {
            txtCedula.Text =txtUsuario.Text=txtClave.Text= "";
            ddlTipo.SelectedValue=null;
            lblMensaje.Text = "";
            btnBorrar.Enabled = false;
            btnActualizar.Enabled = false;
            btnGuardar.Enabled = true;
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (objUsuario.EliminarUsuario(txtCedula.Text) == true)
            {
                Limpiar();
                lblMensaje.Text = "Eliminado con exito";
                MostrarUsuario();
            }
            else
            {
                lblMensaje.Text = "El cargo esta asociado a un empleado no puede eliminarlo";

            }
        }
    }
}