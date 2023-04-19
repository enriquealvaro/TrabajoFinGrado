using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace TrabajoFinGrado
{
    public partial class Maps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string textoScript = "";

            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            // Crea una nueva instancia de SqlCommand y especifica que es un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("ADD_EVENTS_MAP", sqlConectar);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();


            // Ejecuta el procedimiento almacenado y obtiene el código HTML generado
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    textoScript += reader.GetString(0);
                }
            }

            // Asigna el código HTML generado a un control de ASP.NET
            cmd.Connection.Close();

            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes.Add("type", "text/javascript");
            script.InnerHtml = textoScript;

            Page.Controls.Add(script);

        }
    }
}