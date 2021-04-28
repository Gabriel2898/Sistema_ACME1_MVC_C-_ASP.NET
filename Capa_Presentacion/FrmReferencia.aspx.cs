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
    public partial class FrmReferencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mostrarCombo();
            }
            MostrarReferencia();
            btnBorrar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void mostrarCombo()
        {
            CD_Referencia clsReferencia = new CD_Referencia();
            DataSet dsConsulta = clsReferencia.dsConsultarReferencia();

            clsReferencia.cargarControl(ref ddlTipo,
                 dsConsulta,
                 "tipr_id",
                 "tipr_nombre",
                 "Seleccione");
        }
        private CN_Referencia objReferencia = new CN_Referencia();
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (objReferencia.AgregarReferencia(txtReferencia.Text, int.Parse(ddlTipo.SelectedValue),txtCedula.Text))
            {
                Limpiar();
                lblMensaje.Text = "Guardado con éxito";
                MostrarReferencia();
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
        protected void btnTipos_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmTiposReferencia.aspx");
        }
        private void MostrarReferencia()
        {
            GrvReferencia.DataSource = objReferencia.MostrarReferencia();
            GrvReferencia.DataBind();
        }

        protected void LinkVer_Click(object sender, EventArgs e)
        {
            int refID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DataTable dtbl = new DataTable();

            dtbl = objReferencia.BuscarReferencia(refID);

            hfReferenciaId.Value = refID.ToString();
            txtReferencia.Text = dtbl.Rows[0]["ref_descripcion"].ToString();
            ddlTipo.SelectedValue = dtbl.Rows[0]["tipr_id"].ToString();
            txtCedula.Text= dtbl.Rows[0]["per_cedula"].ToString();
            btnGuardar.Enabled = false;
            btnBorrar.Enabled = true;
            btnActualizar.Enabled = true;

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            int id = hfReferenciaId.Value == "" ? 0 : Convert.ToInt32(hfReferenciaId.Value);

            if (objReferencia.ActualizarReferencia(id, txtReferencia.Text, 
                int.Parse(ddlTipo.SelectedValue),txtCedula.Text) == true)
            {
                Limpiar();
                lblMensaje.Text = "Actualizado con éxito";
                MostrarReferencia();
            }
            else
            {
                lblMensaje.Text = "Error.Verifique que los datos sean correctos!!";
            }


        }
        private void Limpiar()
        {
            hfReferenciaId.Value = "";
            txtReferencia.Text = "";
            lblMensaje.Text = "";
            txtCedula.Text = "";
            ddlTipo.SelectedValue = null;
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
            int id = hfReferenciaId.Value == "" ? 0 : Convert.ToInt32(hfReferenciaId.Value);
            if (objReferencia.EliminarReferencia(id) == true)
            {
                Limpiar();
                lblMensaje.Text = "Eliminado con exito";
                MostrarReferencia();
            }
            else
            {
                lblMensaje.Text = "No se puedo eliminar la referencia. Error!!";
            }
        }
    }
}