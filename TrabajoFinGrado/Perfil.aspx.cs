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
    public partial class Perfil : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
           {
            //Miramos si el usuario esta logueado para poder mirar y cambiar sus datos
            if (Session["usuariologueado"] != null)
            {
            }
            else
            {
                Response.Redirect("Login.aspx");

            }
        }

        protected void Boton_Pulsar_Aqui_Click(object sender, EventArgs e)
        {
            //pondremos los textbox en enabled para que se puedan editar
            this.tbApellidos.Enabled = true;
            this.tbNombre.Enabled = true;
            this.tbEmail.Enabled = true;
            this.tbPassword.Enabled = true;
            this.tbPasswordConfirmed.Enabled = true;
            this.tbUsuario.Enabled = true;
            this.Cambiar_Info.Enabled = true;

            string usuariologueado = Session["usuariologueado"].ToString();
            lblBienvenida.Text = "Bienvenido/a  " + usuariologueado + " aquí tiene la información sobre su perfil.";

            //Cargamos todos los datos de la base de datos del perfil
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            string strCon = cadenaConexion;
            string sql = "";

            SqlConnection conexion = new SqlConnection(strCon);
            if (conexion == null)
            {
                conexion = new SqlConnection(strCon);
            }
            SqlCommand cmd;

            conexion.Open();

            cmd = new SqlCommand();

            SqlCommand id = new SqlCommand("SELECT ID FROM Usuarios WHERE  USERNAME='" + usuariologueado + "'", conexion);
            int id_usuarios = (int)id.ExecuteScalar();
            //Cambiamos el resultado de las consultas al textbox correspondiente
            SqlCommand text_username = new SqlCommand("SELECT USERNAME FROM Usuarios WHERE  ID='" + id_usuarios + "'", conexion);
            string username = (string)text_username.ExecuteScalar();
            tbUsuario.Text = username;
            SqlCommand text_nombre = new SqlCommand("SELECT NOMBRE FROM Usuarios WHERE  ID='" + id_usuarios + "'", conexion);
            string nombre = (string)text_nombre.ExecuteScalar();
            tbNombre.Text = nombre;
            SqlCommand text_apellidos = new SqlCommand("SELECT APELLIDOS FROM Usuarios WHERE  ID='" + id_usuarios + "'", conexion);
            string apellidos = (string)text_apellidos.ExecuteScalar();
            tbApellidos.Text = apellidos;
            //Ejecutamos este procedimiento para desencriptar las contraseñas y que nos salgan desencriptadas en los textbox
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            SqlCommand cmd2 = new SqlCommand("VALIDAR_USUARIO", sqlConectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd2.Connection.Open();

            cmd2.Parameters.Add("@USERNAME", SqlDbType.VarChar, 40).Value = tbUsuario.Text;
            cmd2.Parameters.Add("@CONTRASEÑA", SqlDbType.VarChar, 40).Value = tbPassword.Text;


            SqlDataReader sqlDataReader = cmd2.ExecuteReader();
            SqlDataReader dr = sqlDataReader;
            string password = "";
            if (dr.Read())
            {
                password = dr["psw"].ToString();

            }
            //Con las contraseñas ya desencriptadas las cambiamos en los textbox
            tbPassword.Text = password;
            tbPasswordConfirmed.Text = password;

            SqlCommand text_email = new SqlCommand("SELECT EMAIL FROM Usuarios WHERE  ID='" + id_usuarios + "'", conexion);
            string email = (string)text_email.ExecuteScalar();
            tbEmail.Text = email;





        }

        protected void Boton_Cambiar_Info_Click(object sender, EventArgs e)
        {

            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            string strCon = cadenaConexion;
            string sql = "";

            SqlConnection conexion = new SqlConnection(strCon);
            if (conexion == null)
            {
                conexion = new SqlConnection(strCon);
            }
            SqlCommand cmd;

            conexion.Open();

            cmd = new SqlCommand();
            //Comprobaremos el numero de usuarios con el usuario introducido, solo puede haber uno
            //SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE  USERNAME='" + tbUsuario.Text + "'", conexion);
            //int numero_usuarios = (int)command.ExecuteScalar();

            //SqlCommand command2 = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE EMAIL='" + tbEmail.Text + "'", conexion);
            //int numero_correos = (int)command2.ExecuteScalar();

           
            //if usuarios no coinciden ni email y contraseñas coinciden
            if (tbPasswordConfirmed.Text == tbPassword.Text)
            {

                string usuariologueado = Session["usuariologueado"].ToString();
                SqlCommand id = new SqlCommand("SELECT ID FROM Usuarios WHERE  USERNAME='" + usuariologueado + "'", conexion);
                int id_usuarios = (int)id.ExecuteScalar();
                //ejectuamos u nprocedimiento que hara un update con los datos escitos a la tabla 
                sql = "EXEC UPDATE_DATOS_PERFIL " + id_usuarios + ",'" + tbNombre.Text.ToString() + "','" + tbApellidos.Text.ToString() + "','" + tbUsuario.Text.ToString() + "','" + tbPassword.Text.ToString() + "','" + tbEmail.Text.ToString() + "'";

                cmd.CommandText = sql;
                cmd.Connection = conexion;
                cmd.ExecuteNonQuery();
                conexion.Close();

                Session["usuariologueado"] = tbUsuario.Text;
                this.lblAcierto.Text = "Informacion cambiada correctamente!";
                this.lblError.Text = "";

            }
            else
            {
                //Si las contraseñas son distintas
                if (tbPasswordConfirmed.Text != tbPassword.Text)
                {
                    this.lblError.Text = "Las contraseñas no coinciden!";
                    this.lblAcierto.Text = "";

                }
            }

        }
    }
}