<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loigin.aspx.cs" Inherits="TrabajoFinGrado.Loigin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="Style/LoginStyle.css" />
    <link rel="stylesheet" type="text/css" href="Style/materialize.css" />
    <link rel="stylesheet" type="text/css" href="Style/materialize.min.css" />
    <script src="js/materialize.js"></script>
    <script src="js/materialize.min.js"></script>
</head>


<body>
    <table>

        <!-- <img src="../Downloads/logo.png"> -->


        <div class="login-box">
            <h3>LOGIN</h3>
            <form>
                <div class="user-box">
                    <label>Username</label>
                    <input type="text" name="" required="" />
                </div>
                <div class="user-box">
                    <label>Password</label>
                    <input type="password" name="" required="" />
                </div>
                <br>
                <button class="btn waves-effect waves-light" type="submit" name="action">Submit
                    <i class="material-icons right"></i>
                </button>
            </form>
        </div>

    </table>

</body>

</html>


<style>
    @import url('https://fonts.googleapis.com/css2?family=Fuzzy+Bubbles:wght@400;700&family=Roboto+Mono:ital,wght@0,500;1,400&family=Roboto:ital,wght@0,700;1,100;1,400&family=Source+Code+Pro&display=swap');

    html {
        height: 100%;
    }

    body {
        margin: 0;
        padding: 0;
        font-family: sans-serif;
        
         background: linear-gradient(#141e30, #243b55); 
    }

    /*moviles*/
    @media only screen and (min-width:0px) {
        .login-box {
            position: absolute;
            top: 50%;
            left: 50%;
            width: 80%;
            max-width: 300px;
            padding: 40px;
            transform: translate(-50%, -50%);
            background: rgba(41, 37, 37, 0.5);
            box-sizing: border-box;
            box-shadow: 0 15px 25px rgb(0 0 0 / 60%);
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
            ;

        }

        h3 {
            /*margin y padding para cuadrar el texto */
            margin: 0 0 30px;
            padding: 0;
            /*color y alineacion del texto*/
            color: #fff;
            text-align: center;
            font-family: 'Source Code Pro', monospace;
        }

        .login-box .user-box {
            position: relative;
        }

        /*mofidicamos los inputs para introducir username y psw*/
        input {
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
            border-bottom: 1px solid #fff;
            color: #fff;
            /*fondo del input transparente, mas chulito*/
            background: transparent;
        }

        label {
            font-size: 16px;
            /*color del texto*/
            color: #fff;
        }

        button {
            padding-top: 5px;
        }
    }

    /*tablets pequeñas en vertical*/
    @media only screen and (min-width:720px) {
        .login-box {
            max-width: 300px;
            position: absolute;
            top: 50%;
            left: 70%;
            width: 80%;
        }
    }
    /*Escritorio o tablets grandes*/
    @media only screen and (min-width:1068px) {
        .login-box {
            max-width: 400px;
            position: absolute;
            top: 50%;
            left: 70%;
            width: 80%;
        }

    }

    /* EDITAR PARA LANDSCAPE, Y TABLET VERTICAL ESTO:
position: absolute;
    top: 20%;
    left: 45%;
    width: 80%;


*/
</style>
