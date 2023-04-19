using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoFinGrado
{
    public partial class EventDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string parametro = Request.QueryString["id"];
            Session["id"] = parametro;

            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            // Crea una nueva instancia de SqlCommand y especifica que es un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("GENERAR_EVENTOS", sqlConectar);
            cmd.Parameters.Add("@ID_EVENTO", SqlDbType.Int).Value = parametro;
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
            cmd.Connection.Close();

        }
    }
}