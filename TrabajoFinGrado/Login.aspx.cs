using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Scripting.Hosting;

namespace TrabajoFinGrado
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
        }

        protected void Boton_Login_Click(object sender, EventArgs e)

        {
            string password = tbPassword.Text;
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("VALIDAR_USUARIO", sqlConectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 40).Value = tbUsuario.Text;
            cmd.Parameters.Add("@CONTRASEÑA", SqlDbType.VarChar, 40).Value = tbPassword.Text;


            SqlDataReader dr = cmd.ExecuteReader();
            string psw_d = "";
            if (dr.Read())
            {
                psw_d = dr["psw"].ToString();

            }
           

            if (psw_d == password &&(tbPassword.Text != "" || tbUsuario.Text != "") )
            {
                Session["usuariologueado"] = tbUsuario.Text;
                Response.Redirect("Index.aspx");
            }
            else
            {
                lblErrorContrasenia.Text = "Error de Usuario o Contraseña";
                lblError.Text = "";
            }

            cmd.Connection.Close();

        }

        protected void Boton_Registro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");

        }


    }
}
