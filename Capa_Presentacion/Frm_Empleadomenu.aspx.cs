using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Negocio;


namespace Capa_Presentacion
{
    public partial class FrmEmpleadoMenu : System.Web.UI.Page
    {
        private CN_EmpleadoMenu objEmpleado = new CN_EmpleadoMenu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sesion"] == null)
            {
                Response.Redirect("FrmPermisos.aspx");
            }
            else
            {
                string cedula = Convert.ToString(Request.QueryString["CC"]);
                MostrarDatos(cedula);
                MostrarDatosCap(cedula);
                MostrarDatosRef(cedula);
                MostrarDatosFam(cedula);
                MostrarDatosUsu(cedula);
                MostrarColspanDGW();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        private void MostrarColspanDGW()
        {
            GrvEmpleado.HeaderRow.Cells[0].ColumnSpan = 2;
            GrvEmpleado.HeaderRow.Cells[0 + 1].Visible = false;

            GrvEmpleado.HeaderRow.Cells[2].ColumnSpan = 2;
            GrvEmpleado.HeaderRow.Cells[2 + 1].Visible = false;
        }
        private void MostrarDatos(string id)
        {
            try
            {
                GrvEmpleado.DataSource = objEmpleado.BuscarEmpleado(id);
                GrvEmpleado.DataBind();
            }
            catch (Exception) { }

        }

        private void MostrarDatosCap(string id)
        {
            try
            {
                GrvCapacitacion.DataSource = objEmpleado.BuscarEmpleadoCap(id);
                GrvCapacitacion.DataBind();
            }
            catch (Exception) { }

        }

        private void MostrarDatosRef(string id)
        {
            try
            {
                GrvReferencia.DataSource = objEmpleado.BuscarEmpleadoRef(id);
                GrvReferencia.DataBind();

            }
            catch (Exception) { }

        }

        private void MostrarDatosFam(string id)
        {
            try
            {
                grvFamilia.DataSource = objEmpleado.BuscarEmpleadoFam(id);
                grvFamilia.DataBind();
            }
            catch (Exception) { }

        }

        private void MostrarDatosUsu(string id)
        {
            try
            {
                GrvUsuario.DataSource = objEmpleado.BuscarEmpleadoUsu(id);
                GrvUsuario.DataBind();
            }
            catch (Exception) { }

        }

    }
}