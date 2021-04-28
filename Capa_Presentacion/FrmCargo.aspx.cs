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
    public partial class FrmCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarCargo();
            btnBorrar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private CN_Cargo objCargo = new CN_Cargo();
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (objCargo.AgregarCargo(txtCargo.Text))
            {
                Limpiar();
                lblMensaje.Text = "Guardado con éxito";
                MostrarCargo();
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
        private void MostrarCargo()
        {
            GrvCargo.DataSource = objCargo.MostrarDepartamento();
            GrvCargo.DataBind();
        }

        protected void LinkVer_Click(object sender, EventArgs e)
        {
            int departamentoID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DataTable dtbl = new DataTable();

            dtbl = objCargo.BuscarCargo(departamentoID);

            hfCargoId.Value = departamentoID.ToString();
            txtCargo.Text = dtbl.Rows[0]["carg_nombre"].ToString();
            btnGuardar.Enabled = false;
            btnBorrar.Enabled = true;
            btnActualizar.Enabled = true;

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            int id = hfCargoId.Value == "" ? 0 : Convert.ToInt32(hfCargoId.Value);

            if (objCargo.ActualizarCargo(id, txtCargo.Text) == true)
            {
                Limpiar();
                lblMensaje.Text = "Actualizado con éxito";
                MostrarCargo();
            }
            else
            {
                lblMensaje.Text = "Sucedio un error no se pudo Actualizar!!";
            }


        }
        private void Limpiar()
        {
            hfCargoId.Value = "";
            txtCargo.Text = "";
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
            int id = hfCargoId.Value == "" ? 0 : Convert.ToInt32(hfCargoId.Value);
            if (objCargo.EliminarCargo(id) == true)
            {
                Limpiar();
                lblMensaje.Text = "Eliminado con exito";
                MostrarCargo();
            }
            else
            {
                lblMensaje.Text = "El cargo esta asociado a un empleado no puede eliminarlo";
                
            }
        }
    }
}