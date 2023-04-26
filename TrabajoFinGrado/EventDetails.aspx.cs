using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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


            string conectar2 = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar2 = new SqlConnection(conectar);
            // Crea una nueva instancia de SqlCommand y especifica que es un procedimiento almacenado
            SqlCommand cmd2 = new SqlCommand("ADD_EVENTS_DETAIL", sqlConectar);
            cmd2.Parameters.Add("@ID_EVENTO", SqlDbType.Int).Value = parametro;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Connection.Open();


            // Ejecuta el procedimiento almacenado y obtiene el código HTML generado
            string textoScript = "";
            using (SqlDataReader reader = cmd2.ExecuteReader())
            {
                while (reader.Read())
                {
                    textoScript += reader.GetString(0);
                }
            }

            // Asigna el código HTML generado a un control de ASP.NET
            cmd2.Connection.Close();
            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes.Add("type", "text/javascript");
            script.InnerHtml = textoScript;

            Page.Controls.Add(script);

            string conectar3 = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar3 = new SqlConnection(conectar);
            // Crea una nueva instancia de SqlCommand y especifica que es un procedimiento almacenado
            SqlCommand cmd3 = new SqlCommand("GENERAR_PRODCUTOS_RELACIONADOS", sqlConectar);
            cmd3.Parameters.Add("@ID", SqlDbType.Int).Value = parametro;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Connection.Open();


            // Ejecuta el procedimiento almacenado y obtiene el código HTML generado
            string html2 = "";
            using (SqlDataReader reader = cmd3.ExecuteReader())
            {
                while (reader.Read())
                {
                    html2 += reader.GetString(0);
                }
            }

            // Asigna el código HTML generado a un control de ASP.NET
            ProductosRelacionados.Text = html2;
            cmd3.Connection.Close();


        }
    }
}