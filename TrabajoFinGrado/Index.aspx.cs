using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoFinGrado
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            // Crea una nueva instancia de SqlCommand y especifica que es un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("GENERAR_PRODCUTOS", sqlConectar);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();


            // Ejecuta el procedimiento almacenado y obtiene el código HTML generado
            string html = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    html += reader.GetString(0);
                }
            }

            // Asigna el código HTML generado a un control de ASP.NET
            Productos.Text = html;
        }

        protected void Boton_Search_Click(object sender, EventArgs e)
        {

            String fecha_eventos = Convert.ToString(fecha_evento_id.Text);
            System.Diagnostics.Debug.WriteLine(fecha_eventos);
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            // Crea una nueva instancia de SqlCommand y especifica que es un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("BP_BUSCAR_PRODCUTOS", sqlConectar);
            cmd.Parameters.Add("@SEARCH", SqlDbType.VarChar, 1000).Value = SearchBoxId.Text;
            cmd.Parameters.Add("@FECHA_EVENTO", SqlDbType.VarChar, 100).Value = fecha_eventos;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();

            // Ejecuta el procedimiento almacenado y obtiene el código HTML generado
            string html = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    html += reader.GetString(0);
                }
            }

            // Asigna el código HTML generado a un control de ASP.NET
            Productos.Text = html;
        }
    }
}