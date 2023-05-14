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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string nombreUsuario = (string)Session["usuarioLogueado"];
            if(nombreUsuario == "admin")
            {
                Button2.Visible = true;
            }
            else
            {
                Button2.Visible = false;
            }
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
            cmd.Connection.Close();

        }

        protected void Boton_Search_Click(object sender, EventArgs e)
        {

            String fecha_eventos = Convert.ToString(fecha_evento_id.Text);
            String search = Convert.ToString(SearchBoxId.Text);

            //BUSCAR POR FECHA
            if (fecha_eventos != "" && search== "")
            {
                //System.Diagnostics.Debug.WriteLine(fecha_eventos);
                string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection sqlConectar = new SqlConnection(conectar);
                // Crea una nueva instancia de SqlCommand y especifica que es un procedimiento almacenado
                SqlCommand cmd = new SqlCommand("BUSQUEDA_POR_FECHA", sqlConectar);
                cmd.Parameters.Add("@FECHA_EVENTO", SqlDbType.VarChar, 100).Value = fecha_eventos;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();

                // Ejecuta el procedimiento almacenado y obtiene el código HTML generado
                string html = "";
                using (SqlDataReader reader2 = cmd.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        html += reader2.GetString(0);
                    }
                }

                // Asigna el código HTML generado a un control de ASP.NET
                Productos.Text = html;
                cmd.Connection.Close();
                //BUSCAR POR TEXTO
            }
            else if ((fecha_eventos == "" && search != "") || (fecha_eventos != "" && search != ""))
            {
                System.Diagnostics.Debug.WriteLine(fecha_eventos);
                string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection sqlConectar = new SqlConnection(conectar);
                // Crea una nueva instancia de SqlCommand y especifica que es un procedimiento almacenado
                SqlCommand cmd = new SqlCommand("BUSCAR_PRODCUTOS", sqlConectar);
                cmd.Parameters.Add("@SEARCH", SqlDbType.VarChar, 1000).Value = search;
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

        protected void Boton_Add_Click(object sender, EventArgs e)
        {
            string url = "AddEvents.aspx";
            HttpContext.Current.Response.Redirect(url);
        }

        [WebMethod]
        public static void Redireccionar()
        {
            string url = "EventDetails.aspx";
            HttpContext.Current.Response.Redirect(url);
        }




    }
}