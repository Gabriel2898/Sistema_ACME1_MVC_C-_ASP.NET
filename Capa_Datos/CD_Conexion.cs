using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Conexion
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HRLASRM;Initial Catalog=talento_humano_bd;Integrated Security=True");

        public SqlConnection AbrirConexion()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;

        }

        public SqlConnection CerrarConexion()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;

        }
    }
}
