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
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                string nombreUsuario = Session["usuarioLogueado"].ToString();
                int precioTotal = 0;
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    string selectQuery = "SELECT SUM(CAST(PRECIO_EVENTO AS INT) * CAST(cantidad_entradas AS INT)) AS total_precio FROM Entradas WHERE USERNAME = @NombreUsuario";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    precioTotal = reader.GetInt32(0);
                                }
                            }
                        }
                    }

                    connection.Close();
                }

                string precio = precioTotal.ToString();
                Session["Precio"] = precio;
                precio = "TOTAL: " + precio + " €";
                precioTot.Text = precio;

            }
            else
            {
                string url = "Login.aspx";
                HttpContext.Current.Response.Redirect(url);
            }
        }

        protected void Pagar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = Session["usuarioLogueado"].ToString();
            string precioTotal = Session["Precio"].ToString();
            string num_tarjeta = tbTarjeta.Text;
            string fecha_cad = tbmonth.Text;
            string cvc = tbCvc.Text;

            if(nombreUsuario!="" && precioTotal != "" & num_tarjeta != "" && fecha_cad !="" && cvc != "")
            {
                string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;


                using (SqlConnection connection = new SqlConnection(conectar))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear el comando para el procedimiento almacenado
                    using (SqlCommand command = new SqlCommand("ADD_COMPRAS", connection))
                    {
                        // Especificar que el comando es un procedimiento almacenado
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar los parámetros necesarios
                        command.Parameters.AddWithValue("@NUM_TARJETA", num_tarjeta);
                        command.Parameters.AddWithValue("@FECHA_CAD", fecha_cad);
                        command.Parameters.AddWithValue("@CVC", cvc);
                        command.Parameters.AddWithValue("@TOT", precioTotal);
                        command.Parameters.AddWithValue("@USERNAME", nombreUsuario);
                        // Agrega más parámetros según sea necesario

                        // Ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();
                    }
                    lblAcierto.Text = "Compra realizada con éxito";
                    lblError.Text = "";
                    tbCvc.Text = "";
                    tbmonth.Text = "";
                    tbTarjeta.Text = "";

                        string sql = "DELETE FROM Entradas WHERE USERNAME = '" + nombreUsuario + "'";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    // Cerrar la conexión

                    connection.Close();
                }
            }
            else
            {
                lblError.Text = "Campos Vacios";
                lblAcierto.Text = "";
            }


            // Crear la conexión



        }
    }
}