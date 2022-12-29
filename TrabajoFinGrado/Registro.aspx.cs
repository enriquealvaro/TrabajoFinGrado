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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblError.Text = "";
            lblErrorContrasenia.Text = "";
        }

        protected void Boton_Registro_Click(object sender, EventArgs e)
        {
            //inicializamos las variables 
            string nombre = "";
            string apellidos = "";
            string username = "";
            string password = "";
            string email = "";
            string password_confirmed = "";
            //damos valor a las variables segun lo escrito en el registro
            nombre = tbNombre.Text;
            apellidos = tbApellidos.Text;
            username = tbUsuario.Text;
            password = tbPassword.Text;
            password_confirmed = tbPasswordConfirmed.Text;
            email = tbEmail.Text;
            //inicializamos la conexion a la base de datos
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            string strCon = cadenaConexion;
            string sql = "";

            SqlConnection conexion = new SqlConnection(strCon);
            if (conexion == null)
            {
                conexion = new SqlConnection(strCon);
            }
            SqlCommand cmd;
            //Si falta algun campo por completar saltará una alerta
            if (nombre == "" || apellidos == "" || username == "" || password == "" || password_confirmed == "" || email == "")
            {
                lblError.Text = "Ningun campo puede quedar vacío!";
                lblErrorContrasenia.Text = "";

            }
            //Entrará aqui si las dos contraseñas coinciden
            else if (password == password_confirmed && password != "" && password != "")
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand();
                    //Comprobaremos el numero de usuarios con el usuario introducido, solo puede haber uno
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE  USERNAME='" + tbUsuario.Text + "'", conexion);
                    int numero_usuarios = (int)command.ExecuteScalar();

                    SqlCommand command2 = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE EMAIL='" + tbEmail.Text + "'", conexion);
                    int numero_correos = (int)command2.ExecuteScalar();


                    //Si no hay ningun registro en la base de datos con ese usuario o email
                    //se procede a hacer el procedimiento de registro de datos con contraseña encriptada
                    if (numero_usuarios < 1 && numero_correos < 1)
                    {
                        sql = "EXEC REGISTRO_USUARIOS '" + nombre.ToString() + "','" + apellidos.ToString() + "','" + username.ToString() + "','" + password.ToString() + "','" + email.ToString() + "'";

                        cmd.CommandText = sql;
                        cmd.Connection = conexion;
                        cmd.ExecuteNonQuery();
                        conexion.Close();

                        lblAcierto.Text = "Usuario creado correctamente!";

                        //Se quitara todos los inputs y aparecerá un boton para ir al texto
                        theDiv.Visible = false;
                        Boton_Registro.Visible = false;
                        Boton_Ir_Login.Visible = true;

                        lblError.Text = "";
                        lblErrorContrasenia.Text = "";
                    }
                    else
                    {
                        //Uusario ya existe
                        if(numero_usuarios>=1 && numero_correos < 1)
                        { 
                        lblError.Text = "El Usuario " + tbUsuario.Text + " ya existe!";
                        lblErrorContrasenia.Text = "";
                        tbPassword.Text = "";
                        tbPasswordConfirmed.Text = "";
                        //Correo ya existe
                        }else if(numero_usuarios < 1 && numero_correos >= 1)
                        {
                            lblError.Text = "El correo ya existe!";
                            lblErrorContrasenia.Text = "";
                            tbPassword.Text = "";
                            tbPasswordConfirmed.Text = "";
                        //correo y usuario ya existen
                        }else if(numero_usuarios >= 1 && numero_correos >= 1)
                        {
                            lblError.Text = "El usuario y correo ya existen!";
                            lblErrorContrasenia.Text = "";
                            tbPassword.Text = "";
                            tbPasswordConfirmed.Text = "";
                        }
                        

                    }
                    //Comprobaremos el numero de usuarios con el usuario introducido, solo puede haber uno

                }
                catch (Exception ex)
                {
                    if (conexion != null)
                    {
                        if (conexion.State != System.Data.ConnectionState.Closed)
                        {
                            conexion.Close();
                        }
                    }
                }
            }
            //Contraseñas no coinciden
            else
            {
                lblErrorContrasenia.Text = "Las contrasenias no coinciden!";
                lblError.Text = "";
                tbPassword.Text = "";
                tbPasswordConfirmed.Text = "";


            }

        }


        protected void Boton_Ir_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.Aspx");
        }


    }
}
