using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Negocio;
namespace Capa_Presentacion
{
    public partial class FrmTipoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarTipoUsuario();
            btnBorrar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private CN_TipoUsuario objTipoUsuario = new CN_TipoUsuario();
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (objTipoUsuario.AgregarTipoUsuario(txtTipo.Text))
            {
                Limpiar();
                lblMensaje.Text = "Guardado con éxito";
                MostrarTipoUsuario();
            }
            else
            {
                lblMensaje.Text = "Sucedio un error no se pudo guardar!!";
            }


        }
        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Frm_Administrador.aspx");
        }
        private void MostrarTipoUsuario()
        {
            GrvTipoUsuario.DataSource = objTipoUsuario.MostrarTipoUsuario();
            GrvTipoUsuario.DataBind();
        }

        protected void LinkVer_Click(object sender, EventArgs e)
        {
            int tipoID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DataTable dtbl = new DataTable();

            dtbl = objTipoUsuario.BuscarTipoUsuario(tipoID);

            hfTipoUserId.Value = tipoID.ToString();
            txtTipo.Text = dtbl.Rows[0]["tipu_nombre"].ToString();
            btnGuardar.Enabled = false;
            btnBorrar.Enabled = true;
            btnActualizar.Enabled = true;

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            int id = hfTipoUserId.Value == "" ? 0 : Convert.ToInt32(hfTipoUserId.Value);

            if (objTipoUsuario.ActualizarTipoUsuario(id, txtTipo.Text) == true)
            {
                Limpiar();
                lblMensaje.Text = "Actualizado con éxito";
                MostrarTipoUsuario();
            }
            else
            {
                lblMensaje.Text = "Sucedio un error no se pudo Actualizar!!";
            }


        }
        private void Limpiar()
        {
            hfTipoUserId.Value = "";
            txtTipo.Text = "";
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
            int id = hfTipoUserId.Value == "" ? 0 : Convert.ToInt32(hfTipoUserId.Value);
            if (objTipoUsuario.EliminarTipoUsuario(id) == true)
            {
                Limpiar();
                lblMensaje.Text = "Eliminado con exito";
                MostrarTipoUsuario();
            }
            else
            {
                lblMensaje.Text = "Error!! Si el rol esta asociado a un usuario no se puede eliminar";

            }
        }

    }
}