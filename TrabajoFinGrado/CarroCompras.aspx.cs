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

        protected void Actualizar_Click(object sender, EventArgs e)
        {

            //if (IsPostBack)
            //{


            //    string nombreUsuario = (string)Session["usuarioLogueado"];
            //    int numFilas = Request.Form.Count / 2;
            //    for (int i = 1; i <= numFilas; i++)
            //    {
            //        string cantidadFieldName = "cantidad_" + i;
            //        string cantidadValue = Request.Form[cantidadFieldName];

            //        // Obtener el nombre de la columna "NOMBRE" correspondiente al campo de cantidad
            //        string nombreColumnName = "nombre_" + i;
            //        string nombreValue = Request.Form[nombreColumnName];

            //        // Realizar la actualización en la base de datos utilizando los valores recogidos
            //        // Ejemplo de actualización en la base de datos utilizando ADO.NET:
            //        string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            //        using (SqlConnection connection = new SqlConnection(connectionString))
            //        {
            //            string updateQuery = "UPDATE Entradas SET CANTIDAD_ENTRADAS = @Cantidad WHERE Nombre = '" + nombreValue + "' AND USERNAME =" + nombreUsuario;
            //            SqlCommand command = new SqlCommand(updateQuery, connection);
            //            command.Parameters.AddWithValue("@Cantidad", cantidadValue);
            //            command.Parameters.AddWithValue("@Nombre", nombreUsuario);
            //            connection.Open();
            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
        }

        }
    

}