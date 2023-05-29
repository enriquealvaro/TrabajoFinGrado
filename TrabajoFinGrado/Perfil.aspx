<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TrabajoFinGrado.Perfil" %>

<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<link rel="stylesheet" type="text/css" href="Style/LoginStyle.css" />--%>
    <link rel="stylesheet" type="text/css" href="Style/materialize.css" />
    <link rel="stylesheet" type="text/css" href="Style/materialize.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/boxicons@latest/css/boxicons.min.css"/>
    <script src="js/materialize.js"></script>
    <script src="js/materialize.min.js"></script>
    <script src = "js/nav.js"></script>

</head>


 <body>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
     
        <div class="top-nav">
        <div class="container-top d-flex">
            <p>Trabajo final de grado DAM-Dual Enrique Álvaro Escobar</p>

        </div>
    </div>
    <div class="navigation">
        <div class="nav-center container d-flex">
            <a href="Index.aspx" class="logo">
                <h1>MadEvents</h1>
            </a>

                    <ul class="nav-list d-flex">
          <li class="nav-item">
            <a href="Index.aspx" class="nav-link">Home</a>
          </li>
          <li class="nav-item">
            <a href="Index.aspx" class="nav-link">Events</a>
          </li>
          <li class="nav-item">
            <a href="Maps.aspx" class="nav-link">Maps</a>
          </li>
          <li class="icons d-flex">
            <a href="Index.aspx" class="icon">
              <i class="bx bx-user"></i>
            </a>
            
            <a href="CarroCompras.aspx" class="icon">
              <i class="bx bx-cart"></i>
              <span class="d-flex">0</span>
            </a>
          </li>
        </ul>

            <div class="icons d-flex">
                <a href="Perfil.aspx" class="icon">
                    <i class="bx bx-user"></i>
                </a>
                <a href="CarroCompras.aspx" class="icon">
                    <i class="bx bx-cart"></i>
                </a>
            </div>

            <div runat="server" class="hamburger">
                <i class="bx bx-menu-alt-left"></i>
            </div>
        </div>
    </div>
       
    <!-- Index -->
    <div class="container" runat="server">
        <div>
            <asp:Label ID="lblBienvenida" runat="server" Text="" CssClass="h3"></asp:Label>
        </div>

        <div class="cambiarInfo">
            <p>Si desea cambiar sus datos</p>
          <form runat="server">
            <asp:Button ID="Boton_Pulsar_Aqui" class="btn waves-light"  runat="server" Text="Pulse Aqui" Visible="true" OnClick="Boton_Pulsar_Aqui_Click" />
            </br></br>
        </div>

        <div class="infoMostrada">
            <div class="user-box">
               <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
               <asp:Label runat="server" ID="lblAcierto" ForeColor="Green"></asp:Label>

                <br />

                        <label>Username</label>
                        <asp:TextBox ID="tbUsuario" runat="server" enabled="false" Text="*******"></asp:TextBox>
                    </div>
                    <div class="user-box">
                        <label>Nombre</label>
                        <asp:TextBox ID="tbNombre" runat="server" enabled="false" Text="*******"></asp:TextBox>
                    </div>
                    <div class="user-box">
                        <label>Apellidos</label>
                        <asp:TextBox ID="tbApellidos" runat="server" enabled="false" Text="*******"></asp:TextBox>
                    </div>
                    <div class="user-box">
                        <label>Password</label>
                        <asp:TextBox ID="tbPassword" runat="server" type="text" enabled="false" Text="*******"></asp:TextBox>
                    </div>
                    <div class="user-box">
                        <label>Repeat Password</label>
                        <asp:TextBox ID="tbPasswordConfirmed" runat="server" type="text" enabled="false" Text="*******"></asp:TextBox>
                    </div>
                    <div class="user-box">
                        <label>Email</label>
                        <asp:TextBox ID="tbEmail" runat="server" enabled="false" Text="*******"></asp:TextBox>
                    </div>
            </br></br>
            <asp:Button ID="Cambiar_Info" class="btn waves-light"  runat="server" Text="Carmbiar Info" Enabled="false" OnClick="Boton_Cambiar_Info_Click" />
            </form>
  
        </div>

    </div>

    <!-- Footer -->
     <footer class="footer">
      <div class="row">
        <div class="col d-flex">
          <h4>INFORMATION</h4>
          <a href="">About us</a>
          <a href="">Contact Us</a>
          <a href="">Term & Conditions</a>
        </div>
        <div class="col d-flex">
          <h4>USEFUL LINK</h4>
          <a href="">Events</a>
          <a href="">Maps</a>
          
        </div>
        <div class="col d-flex">
          <span><i class="bx bxl-github"></i></span>
          <span><i class="bx bxl-linkedin"></i></span>
        </div>
      </div>
    </footer>

  </body>
    <script>
        const hamburger = document.querySelector(".hamburger");
        const navList = document.querySelector(".nav-list");
        if (hamburger) {
            hamburger.addEventListener("click", () => {
                navList.classList.toggle("open");
            });
        }
    </script>
</html>

<style>

html {
  box-sizing: border-box;
  font-size: 62.5%;
}

body {
  font-family: 'Roboto', sans-serif;
  font-size: 1.6rem;
  background-color: white;
  color: black;
  font-weight: 400;
  font-style: normal;
}

a {
  text-decoration: none;
  color: var(--black);
}

li {
  list-style: none;
}

/* 
=================
Navigation
=================
*/
.top-nav {
  background-color: rgb(10, 37, 190);
  font-size: 1.3rem;
  color: white;
}

.top-nav div {
  justify-content: space-between;
  height: 4.5rem;
}

.top-nav a {
  color: white;
  padding: 0 0.5rem;
}

.container {
    padding-top: 6%;
  max-width: 114rem;
  margin: 0 auto;
  padding: 0 3rem;
  padding-bottom: 6%;
}
.container-top{
    max-width: 114rem;
  margin: 0 auto;
  padding: 0 3rem;
}

.d-flex {
  display: flex;
  align-items: center;
}

/* 
=================
Navigation
=================
*/
.navigation {
  height: 6rem;
  line-height: 6rem;
  padding-bottom: 120px;
}

.nav-center {
  justify-content: space-between;
}

.nav-list .icons {
  display: none;
}

.nav-center .nav-link {
  font-size: 1.8rem;
  padding: 1rem;
}

/* Icons */

.icon {
  cursor: pointer;
  font-size: 2.5rem;
  padding: 0 1rem;
  color: #555;
  position: relative;
}

.icon span {
  position: absolute;
  top: 3px;
  right: -3px;
  background-color: #c1c1c1;
  color: white;
  border-radius: 50%;
  font-size: 1.3rem;
  height: 2rem;
  width: 2rem;
  justify-content: center;
}

@media only screen and (max-width: 768px) {
  .nav-list {
    position: fixed;
    top: 12%;
    left: -35rem;
    flex-direction: column;
    align-items: flex-start;
    box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.2);
    background-color: white;
    height: 100%;
    width: 0%;
    max-width: 35rem;
    z-index: 100;
    transition: all 300ms ease-in-out;
  }

  .nav-list.open {
    left: 0;
    width: 100%;
  }

  .nav-list .nav-item {
    margin: 0 0 1rem 0;
    width: 100%;
  }

  .nav-list .nav-link {
    font-size: 2rem;
    color: black;
  }

  .nav-center .hamburger {
    display: block;
    color: black;
    font-size: 3rem;
  }

  .icons {
    display: none;
  }

  .nav-list .icons {
    display: flex;
  }

  .top-nav ul {
    display: none;
  }

  .top-nav div {
    justify-content: center;
    height: 3rem;
  }
}
    @media only screen and (min-width: 768px) {
    .hamburger{
        display:none;
    }
    }

.login-box {
        position: relative;
        top: 50%;
        left: 50%;
        width: 80%;
        max-width: 400px;
        padding: 40px;
        transform: translate(-50%);
        background:rgb(255, 255, 255);
        box-sizing: border-box;
        box-shadow: 0 15px 25px rgba(212, 212, 212, 1);
        border-radius: 15px;
    }

    img {
        position: absolute;
        top: 20%;
        left: 45%;
        width: 80%;
        max-width: 300px;
        padding: 40px;
        transform: translate(-50%, -50%);
        
    }

    h3 {
        /*margin y padding para cuadrar el texto */
        margin: 0 0 30px;
        padding: 0;
        /*color y alineacion del texto*/
        color: rgb(0, 0, 0);
        text-align: center;
    }

    .login-box .user-box {
        position: relative;
    }

    /*mofidicamos los inputs para introducir username y psw*/
#tbUsuario, #tbPassword, #tbApellidos, #tbNombre, #tbEmail,#tbPasswordConfirmed  {
        /*edita anchura del input*/
        width: 100%;
        /*espacio entre inputs*/
        padding: 5px 0;
        font-size: 15px;
        margin-bottom: 20px;
        /*le quitamos el border a los inputs para que esten chulos*/
        border: none;
        /*para que al escirbir no se vean bordes*/
        outline: none;
        /*ponemos el borde de abajo nada mas*/
        border-bottom: 1px solid #26a69a;
        color: rgb(0, 0, 0);
        /*fondo del input transparente, mas chulito*/
        background: transparent;
    }
    .Registrarse{
        color: #26a69a;
        font-size:20%;
    }

    label {
        font-size: 16px;
        /*color del texto*/
        color: rgb(0, 0, 0);
    }

    button {
        padding-top: 5px;
    }

    /* Footer */
.footer {
    padding-top: 20%;
  padding: 7rem 1rem;
  background-color: rgb(10, 37, 190);
}

footer .row {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  max-width: 99.6rem;
  margin: 0 auto;
}

.footer .col {
  flex-direction: column;
  color: white;
  align-items: flex-start;
}
.footer .col a {
  color: white;
  font-size: 1.5rem;
  padding: 0.5rem;
  font-weight: 300;
}

.footer .col h4 {
  margin-bottom: 1rem;
}

@media only screen and (max-width: 567px) {
  footer .row {
    grid-template-columns: 1fr;
    row-gap: 3rem;
  }
}



</style>
