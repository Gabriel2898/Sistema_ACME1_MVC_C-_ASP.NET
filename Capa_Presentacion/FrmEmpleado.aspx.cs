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
    public partial class FrmEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!this.IsPostBack)
            {
                MostrarComboDepartamento();
                MostrarComboCargo();
            }
            MostrarEmpleado();
            btnBorrar.Enabled = false;
            btnActualizar.Enabled = false;
            MostrarColspanDGW();
        }

        private void MostrarColspanDGW()
        {
            GrvEmpleado.HeaderRow.Cells[0].ColumnSpan = 2;
            GrvEmpleado.HeaderRow.Cells[0 + 1].Visible = false;

            GrvEmpleado.HeaderRow.Cells[2].ColumnSpan = 2;
            GrvEmpleado.HeaderRow.Cells[2 + 1].Visible = false;
        }


        private void MostrarComboCargo()
        {
            CD_Empleado clsEmpleado = new CD_Empleado();
            DataSet dsConsulta = clsEmpleado.dsConsultarCargo();

            clsEmpleado.cargarControlCargo(ref ddlCargo,
                 dsConsulta,
                 "carg_id",
                 "carg_nombre",
                 "Seleccione");
        }
        private void MostrarComboDepartamento()
        {
            CD_Empleado clsEmpleado2 = new CD_Empleado();
            DataSet dsConsulta2 = clsEmpleado2.dsConsultarDepartamento();

            clsEmpleado2.cargarControlDepartamento(ref ddlDepartamento,
                 dsConsulta2,
                 "dep_id",
                 "dep_nombre",
                 "Seleccione");
        }
        private CN_Empleado objEmpleado = new CN_Empleado();
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (objEmpleado.AgregarEmpleado(txtCedula.Text,txtNombre1.Text,txtNombre2.Text,txtApellido1.Text,
                txtApellido2.Text,txtDireccion.Text,txtTelefono.Text,txtCorreo.Text,int.Parse(ddlDepartamento.SelectedValue), int.Parse(ddlCargo.SelectedValue)))
            {
                Limpiar();
                lblMensaje.Text = "Guardado con éxito";
                MostrarEmpleado();
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
        private void MostrarEmpleado()
        {
            GrvEmpleado.DataSource = objEmpleado.MostrarEmpleado();
            GrvEmpleado.DataBind();
        }


        protected void LinkVer_Click(object sender, EventArgs e)
        {
            string empleadoID = Convert.ToString((sender as LinkButton).CommandArgument);
            DataTable dtbl = new DataTable();

            dtbl = objEmpleado.BuscarEmpleado(empleadoID);
            
            txtCedula.Text = dtbl.Rows[0]["per_cedula"].ToString();
            txtNombre1.Text= dtbl.Rows[0]["per_primerNombre"].ToString();
            txtNombre2.Text = dtbl.Rows[0]["per_segundoNombre"].ToString();
            txtApellido1.Text = dtbl.Rows[0]["per_primerApellido"].ToString();
            txtApellido2.Text = dtbl.Rows[0]["per_segundoApellido"].ToString();
            txtDireccion.Text = dtbl.Rows[0]["per_direccion"].ToString();
            txtTelefono.Text = dtbl.Rows[0]["per_telefono"].ToString();
            txtCorreo.Text = dtbl.Rows[0]["per_correo"].ToString();
            
            ddlCargo.SelectedValue = dtbl.Rows[0]["carg_id"].ToString();
            ddlDepartamento.SelectedValue = dtbl.Rows[0]["dep_id"].ToString();
            btnGuardar.Enabled = false;
            btnBorrar.Enabled = true;
            btnActualizar.Enabled = true;

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            

            if (objEmpleado.ActualizarEmpleado(txtCedula.Text, txtNombre1.Text, txtNombre2.Text, txtApellido1.Text,
                txtApellido2.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text,
                int.Parse(ddlDepartamento.SelectedValue), int.Parse(ddlCargo.SelectedValue)) == true)
            {
                Limpiar();
                lblMensaje.Text = "Actualizado con éxito";
                MostrarEmpleado();
            }
            else
            {
                lblMensaje.Text = "Sucedio un error no se pudo Actualizar!!";
            }


        }
        private void Limpiar()
        {
            txtCedula.Text =txtNombre1.Text=txtNombre2.Text=txtApellido1.Text=txtApellido2.Text=txtCorreo.Text=txtTelefono.Text=txtDireccion.Text= "";
            lblMensaje.Text = "";
            txtCedula.ReadOnly = true;
            ddlCargo.SelectedValue = null;
            ddlDepartamento.SelectedValue = null;
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

            if (objEmpleado.EliminarEmpleado(txtCedula.Text) == true)
            {
                Limpiar();
                lblMensaje.Text = "Eliminado con exito";
                MostrarEmpleado();
            }
            else
            {
                lblMensaje.Text = "No se puede eliminar el departamento esta asociado a una empresa";
            }
        }
    }
}