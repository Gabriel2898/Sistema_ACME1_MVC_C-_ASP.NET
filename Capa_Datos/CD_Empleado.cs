using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Capa_Datos
{
    public class CD_Empleado
    {
        private CD_Conexion con = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        public void AgregarEmpleado(string ced, string n1, string n2, string a1, string a2, string dir, string tel, string mail, int idDep, int idCargo)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_agregarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@per_cedula", ced);
            comando.Parameters.AddWithValue("@per_primerNombre", n1);
            comando.Parameters.AddWithValue("@per_segundoNombre", n2);
            comando.Parameters.AddWithValue("@per_primerApellido", a1);
            comando.Parameters.AddWithValue("@per_segundoApellido", a2);
            comando.Parameters.AddWithValue("@per_direccion", dir);
            comando.Parameters.AddWithValue("@per_telefono", tel);
            comando.Parameters.AddWithValue("@per_correo", mail);
            comando.Parameters.AddWithValue("@dep_id", idDep);
            comando.Parameters.AddWithValue("@carg_id", idCargo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void EliminarEmpleado(string cedula)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_eliminarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@per_cedula", cedula);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarEmpleado()
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_mostrarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarEmpleado(string cedula)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("sp_buscarEmpleado", con.AbrirConexion());
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@per_cedula", cedula);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            return dtbl;

        }

        public void ActualizarEmpleado(string ced, string n1, string n2, string a1, string a2, string dir, string tel, string mail, int idDep, int idCargo)
        {
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "sp_editarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@per_cedula", ced);
            comando.Parameters.AddWithValue("@per_primerNombre", n1);
            comando.Parameters.AddWithValue("@per_segundoNombre", n2);
            comando.Parameters.AddWithValue("@per_primerApellido", a1);
            comando.Parameters.AddWithValue("@per_segundoApellido", a2);
            comando.Parameters.AddWithValue("@per_direccion", dir);
            comando.Parameters.AddWithValue("@per_telefono", tel);
            comando.Parameters.AddWithValue("@per_correo", mail);
            comando.Parameters.AddWithValue("@dep_id", idDep);
            comando.Parameters.AddWithValue("@carg_id", idCargo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }



        SqlDataAdapter sqlAdapter = null;
        public DataSet dsConsultarDepartamento()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                string stSentencia = "select * from tbl_departamento";

                sqlAdapter = new SqlDataAdapter(stSentencia, con.AbrirConexion());
                sqlAdapter.Fill(dsConsulta);

                return dsConsulta;
            }
            catch (Exception ex) { throw ex; }
        }

        public void cargarControlDepartamento(ref DropDownList ddlControl,
            DataSet dsConsulta,
            string stValor,
            string stTexto,
            string stTextoEncabezado)
        {
            try
            {
                ddlControl.DataSource = dsConsulta;
                ddlControl.DataValueField = stValor;
                ddlControl.DataTextField = stTexto;
                ddlControl.DataBind();

                ddlControl.Items.Insert(0, new ListItem(stTextoEncabezado));
            }
            catch (Exception ex) { throw ex; }
        }



        public DataSet dsConsultarCargo()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                string stSentencia = "select * from tbl_cargo";

                sqlAdapter = new SqlDataAdapter(stSentencia, con.AbrirConexion());
                sqlAdapter.Fill(dsConsulta);

                return dsConsulta;
            }
            catch (Exception ex) { throw ex; }
        }

        public void cargarControlCargo(ref DropDownList ddlControl,
            DataSet dsConsulta,
            string stValor,
            string stTexto,
            string stTextoEncabezado)
        {
            try
            {
                ddlControl.DataSource = dsConsulta;
                ddlControl.DataValueField = stValor;
                ddlControl.DataTextField = stTexto;
                ddlControl.DataBind();

                ddlControl.Items.Insert(0, new ListItem(stTextoEncabezado));
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
