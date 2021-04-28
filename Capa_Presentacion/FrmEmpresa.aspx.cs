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
    public partial class FrmEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarEmpresa();
            btnBorrar.Enabled = false;
            btnActualizar.Enabled = false;
        }


        private CN_Empresa objEmpresa = new CN_Empresa();
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            
            if (objEmpresa.AgregarEmpresa(txtRuc.Text,txtNombre.Text,txtTelefono.Text,txtDireccion.Text))
            {
                Limpiar();
                lblMensaje.Text = "Guardado con exito";
                MostrarEmpresa();
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
        private void MostrarEmpresa()
        {
            GrvEmpresa.DataSource = objEmpresa.MostrarEmpresa();
            GrvEmpresa.DataBind();
        }

        protected void LinkVer_Click(object sender, EventArgs e)
        {
            int empresaID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DataTable dtbl = new DataTable();

            dtbl = objEmpresa.BuscarEmpresa(empresaID);

            hfEmpresaId.Value = empresaID.ToString();
            txtRuc.Text = dtbl.Rows[0]["empr_ruc"].ToString();
            txtNombre.Text = dtbl.Rows[0]["empr_nombre"].ToString();
            txtTelefono.Text = dtbl.Rows[0]["empr_telefono"].ToString();
            txtDireccion.Text = dtbl.Rows[0]["empr_direccion"].ToString();
            btnGuardar.Enabled = false;
            btnBorrar.Enabled = true;
            btnActualizar.Enabled = true;

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            int id = hfEmpresaId.Value == "" ? 0 : Convert.ToInt32(hfEmpresaId.Value);
            
            if (objEmpresa.ActualizarEmpresa(id,txtRuc.Text,txtNombre.Text,txtTelefono.Text,txtDireccion.Text) == true)
            {
                Limpiar();
                lblMensaje.Text = "Actualizado con exito";
                MostrarEmpresa();
            }
            else
            {
                lblMensaje.Text = "Sucedio un error no se pudo Actualizar!!";
            }


        }
        private void Limpiar()
        {
            hfEmpresaId.Value = "";
            txtRuc.Text = txtNombre.Text = txtTelefono.Text = txtDireccion.Text = "";
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
            int id = hfEmpresaId.Value == "" ? 0 : Convert.ToInt32(hfEmpresaId.Value);
            if (objEmpresa.EliminarEmpresa(id) == true)
            {
                Limpiar();
                lblMensaje.Text = "Eliminado con exito";
                MostrarEmpresa();
            }
            else
            {
                lblMensaje.Text = "Sucedio un error no se pudo Eliminar!!";
            }
        }
    }
}