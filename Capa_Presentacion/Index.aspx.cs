using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Capa_Negocio;
using Capa_Datos;
using System.Data;
using System.Text.RegularExpressions;

namespace Capa_Presentacion
{
    public partial class Index : System.Web.UI.Page
    {
        public CN_Login objLogin = new CN_Login();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CD_Login clsLogin = new CD_Login();
                DataSet dsConsulta = clsLogin.dsConsultarTipoUsuario();

                clsLogin.cargarControl(ref dwlTipo,
                     dsConsulta,
                     "tipu_id",
                     "tipu_nombre",
                     "Seleccione");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = txtContraseña.Text = "";
            msjTipo.Text = msjIniciar.Text = msjClave.Text = msjUsuario.Text = "";
            dwlTipo.SelectedValue = null;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            String P_Usuraio = txtUsuario.Text;
            Regex r = new Regex ("^[A-Za-z]+$");

            SqlDataReader loguear;
            objLogin.Usuario = txtUsuario.Text;
            objLogin.Clave = txtContraseña.Text;
            objLogin.Tipo = dwlTipo.SelectedValue;
            Session["sesion"] = "logueado";

            if (objLogin.Usuario == txtUsuario.Text)
            {
                msjUsuario.Visible = false;
                if (objLogin.Clave == txtContraseña.Text)
                {
                    msjClave.Visible = false;
                    if (objLogin.Tipo == dwlTipo.SelectedValue)
                    {
                        msjTipo.Visible = false;
                        loguear = objLogin.iniciarSesion();
                        if (loguear.Read() == true)
                        {
                            string u = loguear.GetString(4);
                            if (u == "Administrador")
                            {
                                Response.Redirect("Frm_Administrador.aspx");
                            }
                            else if (u == "Empleado")
                            {
                                Response.Redirect("Frm_Empleadomenu.aspx?CC=" + loguear.GetString(0));
                            }
                        }
                        else
                        {
                            msjIniciar.Text = "Usuario o clave incorrecta";
                            msjIniciar.Visible = true;
                            txtUsuario.Text = "";
                            txtContraseña.Text = "";
                            dwlTipo.SelectedValue = dwlTipo.SelectedItem.Text = "Seleccione";
                            loguear.Close();
                        }
                    }
                    else { msjTipo.Text = objLogin.Tipo; msjTipo.Visible = true; }
                }
                else { msjClave.Text = objLogin.Clave; msjClave.Visible = true; }
            }
            else { msjUsuario.Text = objLogin.Usuario; msjUsuario.Visible = true; }
        }

    }
}