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
    public partial class CarroCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                string nombreUsuario = (string)Session["usuarioLogueado"];

                string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection sqlConectar = new SqlConnection(conectar);
                // Crea una nueva instancia de SqlCommand y especifica que es un procedimiento almacenado
                SqlCommand cmd = new SqlCommand("GENERAR_CARRITO", sqlConectar);
                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = nombreUsuario;
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
            else
            {
                Response.Redirect("Login.aspx");

            }



        }

        protected void Vaciar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = (string)Session["usuarioLogueado"];

            
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                string sql = "DELETE FROM Entradas WHERE USERNAME = '" + nombreUsuario + "'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

            }
            string url = "CarroCompras.aspx";
            HttpContext.Current.Response.Redirect(url);

        }

        protected void Comprar_Click(object sender, EventArgs e)
        {
            string url = "Pago.aspx";
            HttpContext.Current.Response.Redirect(url);
        }
    }
}