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
    public partial class FrmCargaFamiliar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarCargaFamiliar();
            btnBorrar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private CN_Familia objFamilia = new CN_Familia();
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (objFamilia.AgregarCargaFamiliar(txtCedulaPariente.Text,txtNombre.Text,
                txtApellido.Text,txtParentesco.Text,int.Parse(txtEdad.Text),
                txtCedulaEmpleado.Text))
            {
                Limpiar();
                lblMensaje.Text = "Guardado con éxito";
                MostrarCargaFamiliar();
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
        private void MostrarCargaFamiliar()
        {
            GrvCargaFamiliar.DataSource = objFamilia.MostrarCargaFamiliar();
            GrvCargaFamiliar.DataBind();
        }

        protected void LinkVer_Click(object sender, EventArgs e)
        {
            int cargfID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DataTable dtbl = new DataTable();

            dtbl = objFamilia.BuscarCargaFamiliar(cargfID);

            hfFamiliarId.Value = cargfID.ToString();
            txtCedulaPariente.Text = dtbl.Rows[0]["carf_cedula"].ToString();
            txtNombre.Text = dtbl.Rows[0]["carf_nombre"].ToString();
            txtApellido.Text = dtbl.Rows[0]["carf_apellido"].ToString();
            txtParentesco.Text = dtbl.Rows[0]["carf_parentesco"].ToString();
            txtEdad.Text = dtbl.Rows[0]["carf_edad"].ToString();
            txtCedulaEmpleado.Text = dtbl.Rows[0]["per_cedula"].ToString();
            btnGuardar.Enabled = false;
            btnBorrar.Enabled = true;
            btnActualizar.Enabled = true;

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            int id = hfFamiliarId.Value == "" ? 0 : Convert.ToInt32(hfFamiliarId.Value);

            if (objFamilia.ActualizarCargaFamiliar(id, txtCedulaPariente.Text, txtNombre.Text,
                txtApellido.Text, txtParentesco.Text, int.Parse(txtEdad.Text),
                txtCedulaEmpleado.Text) == true)
            {
                Limpiar();
                lblMensaje.Text = "Actualizado con éxito";
                MostrarCargaFamiliar();
            }
            else
            {
                lblMensaje.Text = "Sucedio un error no se pudo Actualizar!!";
            }


        }
        private void Limpiar()
        {
            hfFamiliarId.Value = "";
            txtCedulaEmpleado.Text = txtNombre.Text=txtApellido.Text=txtEdad.Text=txtParentesco.Text=
                txtCedulaPariente.Text="";
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
            int id = hfFamiliarId.Value == "" ? 0 : Convert.ToInt32(hfFamiliarId.Value);
            if (objFamilia.EliminarCargaFamiliar(id) == true)
            {
                Limpiar();
                lblMensaje.Text = "Eliminado con exito";
                MostrarCargaFamiliar();
            }
            else
            {
                lblMensaje.Text = "Error!! No se pudo consulte con administración";

            }
        }
    }
}