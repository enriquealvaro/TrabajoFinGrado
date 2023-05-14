using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoFinGrado
{
    public partial class AddEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombreUsuario = (string)Session["usuarioLogueado"];
            if (nombreUsuario == "admin")
            {
                
            }
            else
            {
                string url = "Login.aspx";
                HttpContext.Current.Response.Redirect(url);
            }
        }

        protected void Boton_Add_Click(object sender, EventArgs e)
        {
            string nombre = tbNombre.Text;
            string descripcion = tbDescripcion.Text;
            string fecha = tbFecha.Text;
            string hora = tbHora.Text;
            string lugar = tbLugar.Text;
            string artista = tbArtista.Text;
            string precio = tbPrecio.Text;
            string latitud = tbLatitud.Text;
            string longitud = tbLongitud.Text;
            string imagen = tbImagen.Text;
            string genero = tbGenero.Text;
            System.Diagnostics.Debug.WriteLine(fecha);
            System.Diagnostics.Debug.WriteLine(hora);

            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            string strCon = cadenaConexion;
            string sql = "";
            SqlConnection conexion = new SqlConnection(strCon);
            if (conexion == null)
            {
                conexion = new SqlConnection(strCon);
            }
            SqlCommand cmd;
            try
            {
            conexion.Open();

            cmd = new SqlCommand();
            sql = "EXEC ADD_PRODUCTS '" + nombre.ToString() + "','" + descripcion.ToString() + "','" + fecha.ToString() + 
                "','" + hora.ToString() + "','" + lugar.ToString() + "','" + artista.ToString() + "','" + precio.ToString() + 
                "','" + latitud.ToString() + "','" + imagen.ToString() + "','" + longitud.ToString() + "','" + genero.ToString() + "'";
            cmd.CommandText = sql;
            cmd.Connection = conexion;
            cmd.ExecuteNonQuery();
                lblAcierto.Text = "Evento añadido satisfactoriamente";
                Boton_Eventos.Visible = true;
            conexion.Close();
            }
            catch
            {
                if (conexion != null)
                {
                    if (conexion.State != System.Data.ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                }
                lblError.Text = "Se ha producido un error con la conexión con la base de datos";
            }

        }

        protected void Boton_Eventos_Click(object sender, EventArgs e)
        {
            string url = "Index.aspx";
            HttpContext.Current.Response.Redirect(url);
        }
        }
}