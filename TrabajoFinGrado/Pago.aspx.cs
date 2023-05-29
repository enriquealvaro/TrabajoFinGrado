using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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

            if (nombreUsuario != "" && precioTotal != "" & num_tarjeta != "" && fecha_cad != "" && cvc != "")
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

                    

                    string nombre_evento = "";
                    string cantidad_entradas = "";
                    string selectQuery = "SELECT NOMBRE_EVENTO FROM Entradas WHERE USERNAME = @NombreUsuario";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    nombre_evento = reader.GetString(0);
                                }
                            }
                        }
                    }

                    string selectQuery2 = "SELECT CANTIDAD_ENTRADAS FROM Entradas WHERE USERNAME = @NombreUsuario AND NOMBRE_EVENTO = @NombreEvento ";

                    using (SqlCommand command = new SqlCommand(selectQuery2, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        command.Parameters.AddWithValue("@NombreEvento", nombre_evento);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    cantidad_entradas = reader.GetString(0);
                                }
                            }
                        }
                    }

                    //Añadir rutas
                    string rutaRelativa = "~/images/plantilla.pdf";
                    string rutaVirtual = VirtualPathUtility.ToAbsolute(rutaRelativa);

                    // Ruta de la plantilla PDF
                    string plantillaPdfPath = Server.MapPath(rutaVirtual);
                    precioTotal = precioTotal + " €";
                    // Crear el PDF de salida en memoria
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Cargar la plantilla PDF
                        using (PdfReader pdfReader = new PdfReader(plantillaPdfPath))
                        {
                            // Crear el PDF de salida
                            using (PdfStamper pdfStamper = new PdfStamper(pdfReader, ms))
                            {
                                AcroFields formFields = pdfStamper.AcroFields;

                                // Rellenar los campos de la plantilla 
                                formFields.SetField("username", nombreUsuario);
                                formFields.SetField("nombre_c", nombre_evento);
                                formFields.SetField("cant_entradas", cantidad_entradas);
                                formFields.SetField("precio", precioTotal);



                                // Guardar y cerrar el PDF de salida
                                pdfStamper.FormFlattening = true;
                            }
                        }

                        // Obtener el contenido del MemoryStream
                        byte[] contenidoPDF = ms.ToArray();

                        // Descargar el PDF 
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        //Response.AppendHeader("Content-Disposition", "attachment; filename=Entradas.pdf");

                        // Especificar que el archivo PDF se descargará en lugar de mostrarse en el navegador
                        //Response.AppendHeader("Content-Length", contenidoPDF.Length.ToString());
                        Response.BinaryWrite(contenidoPDF);
                        Response.End();

                        string sql = "DELETE FROM Entradas WHERE USERNAME = '" + nombreUsuario + "'";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                        connection.Close();


                    }

                }

            }
            
            
           else
            {
                lblError.Text = "Campos Vacios";
                lblAcierto.Text = "";
            }





        }
    }
}