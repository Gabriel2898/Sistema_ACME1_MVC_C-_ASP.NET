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
    public partial class FrmDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mostrarCombo();
            }
            MostrarDepartamento();
            btnBorrar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void mostrarCombo()
        {
            CD_Departamento clsDepartamento = new CD_Departamento();
            DataSet dsConsulta = clsDepartamento.dsConsultarEmpresa();

            clsDepartamento.cargarControl(ref ddlEmpresa,
                 dsConsulta,
                 "empr_id",
                 "empr_nombre",
                 "Seleccione");
        }
        private CN_Departamento objDepartamento = new CN_Departamento();
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (objDepartamento.AgregarDepartamento( txtDepartamento.Text, int.Parse(ddlEmpresa.SelectedValue)))
            {
                Limpiar();
                lblMensaje.Text = "Guardado con éxito";
                MostrarDepartamento();
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
        private void MostrarDepartamento()
        {
            GrvDepartamento.DataSource = objDepartamento.MostrarDepartamento();
            GrvDepartamento.DataBind();
        }

        protected void LinkVer_Click(object sender, EventArgs e)
        {
            int departamentoID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DataTable dtbl = new DataTable();

            dtbl = objDepartamento.BuscarDepartamento(departamentoID);

            hfDepartamentoId.Value = departamentoID.ToString();
            txtDepartamento.Text = dtbl.Rows[0]["dep_nombre"].ToString();
            ddlEmpresa.SelectedValue = dtbl.Rows[0]["empr_id"].ToString();
            btnGuardar.Enabled = false;
            btnBorrar.Enabled = true;
            btnActualizar.Enabled = true;

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            int id = hfDepartamentoId.Value == "" ? 0 : Convert.ToInt32(hfDepartamentoId.Value);

            if (objDepartamento.ActualizarDepartamento(id, txtDepartamento.Text, int.Parse(ddlEmpresa.SelectedValue)) == true)
            {
                Limpiar();
                lblMensaje.Text = "Actualizado con éxito";
                MostrarDepartamento();
            }
            else
            {
                lblMensaje.Text = "Sucedio un error no se pudo Actualizar!!";
            }


        }
        private void Limpiar()
        {
            hfDepartamentoId.Value = "";
            txtDepartamento.Text = "";
            lblMensaje.Text = "";
            ddlEmpresa.SelectedValue=null;
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
            int id = hfDepartamentoId.Value == "" ? 0 : Convert.ToInt32(hfDepartamentoId.Value);
            if (objDepartamento.EliminarDepartamento(id) == true)
            {
                Limpiar();
                lblMensaje.Text = "Eliminado con exito";
                MostrarDepartamento();
            }
            else
            {
                lblMensaje.Text = "No se puede eliminar el departamento esta asociado a una empresa";
            }
        }
    }
}