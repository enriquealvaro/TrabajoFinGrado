<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="TrabajoFinGrado.EventDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<link rel="stylesheet" type="text/css" href="Style/LoginStyle.css" />--%>
    <link rel="stylesheet" type="text/css" href="Style/materialize.css" />
    <link rel="stylesheet" type="text/css" href="Style/materialize.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/boxicons@latest/css/boxicons.min.css" />
    <script src="js/materialize.js"></script>
    <script src="js/materialize.min.js"></script>
    <script src="js/nav.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyApvvXLJ_vd36K4-KVLA4BxUzssrwdu2W0"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>


</head>

<body>

    <script>
        function addCarrito() {
            console.log("hola");
        }
    </script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Navigation -->
    <div class="top-nav">

        <div class="container-top d-flex">
            <p id="p">Trabajo final de grado DAM-Dual Enrique Álvaro Escobar</p>
            <ul class="d-flex">
                <li><a href="#">About Us</a></li>
                <li><a href="#">FAQ</a></li>
                <li><a href="#">Contact</a></li>
            </ul>
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
                    <a href="product.html" class="nav-link">Events</a>
                </li>
                <li class="nav-item">
                    <a href="#terms" class="nav-link">Maps</a>
                </li>
                <li class="nav-item">
                    <a href="#about" class="nav-link">About</a>
                </li>
                <li class="nav-item">
                    <a href="#contact" class="nav-link">Contact</a>
                </li>
                <li class="icons d-flex">
                    <a href="Perfil.aspx" class="icon">
                        <i class="bx bx-user"></i>
                    </a>
                    <div class="icon">
                        <i class="bx bx-search"></i>
                    </div>

                    <a href="cart.html" class="icon">
                        <i class="bx bx-cart"></i>
                        <span class="d-flex">0</span>
                    </a>
                </li>
            </ul>

            <div class="icons d-flex">
                <a href="Perfil.aspx" class="icon">
                    <i class="bx bx-user"></i>
                </a>
                

                <a href="cart.html" class="icon">
                    <i class="bx bx-cart"></i>
                    <span class="d-flex">0</span>
                </a>
            </div>

            <div class="hamburger">
                <i class="bx bx-menu-alt-left"></i>
            </div>
        </div>
    </div>


    <div id="productos">
        <asp:Label ID="Productos" runat="server" Text=""></asp:Label>      
    </div>
     <div class="grid-containerr">
        <form runat="server">
            <div class="rowk">
            <asp:TextBox runat="server" ID="txtNumber" type="number" min="1" max ="10" />
            </div>
            <div class="rowk">
             <asp:Button class="addCart" runat="server" Text="Add To Cart" OnClick="AddCarrito_Click" Visible="true" />
            </div>
        </form>
    </div>

            
	          

    <form id="form1">
        <div id="map" style="height: 400px; width: 70%"></div>
        <br />
        <br />
    </form>
    <div id="text">
        <h3>Related Events: </h3>
    </div>
    <div id="productosRelacionados">
        <asp:Label ID="ProductosRelacionados" runat="server" Text=""></asp:Label>
    </div>




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
    .rowk{
        
  flex: 1;
  padding: 10px;

    }
            .grid-containerr {
            display: grid;
            justify-content: center;
            align-items: center;
            gap: 0px;
            height: 100%;
            padding-bottom: 20px;
        }
    #text {
        display: flex;
        justify-content: left;
        align-items: center;
        padding-left: 15%;
    }

    .button {
        width: fit-content;
        height: fit-content;
        margin-top: 10px;
    }

        .button a {
            display: inline-block;
            overflow: hidden;
            position: relative;
            font-size: 11px;
            color: #111;
            text-decoration: none;
            padding: 10px 15px;
            border: 1px solid #aaa;
            font-weight: bold;
            background: white;
        }

            .button a:after {
                content: "";
                position: absolute;
                top: 0;
                right: -10px;
                width: 0%;
                background: #111;
                height: 100%;
                z-index: -1;
                transition: width 0.3s ease-in-out;
                transform: skew(-25deg);
                transform-origin: right;
            }

            .button a:hover:after {
                width: 150%;
                left: -10px;
                transform-origin: left;
            }






            .button a:nth-of-type(2) {
                border-radius: 0px 50px 50px 0;
            }
    /*MOVIL (1 EVENTOS/FILA)*/
    @media only screen and (min-width: 0px)and (max-width: 440px) {
        .grid-container {
            display: grid;
            justify-content: center;
            align-items: center;
            gap: 0px;
            height: 100%;
        }

        .outer {
            position: relative;
            background: white;
            height: 250px;
            width: 300px;
            overflow: hidden;
            display: flex;
            align-items: center;
            padding-bottom: 30px;
            box-shadow: 14px 13px 20px -8px grey;
        }

        .content {
            animation-delay: 0.3s;
            position: absolute;
            width: 300px;
            text-align: center;
            left: 0px;
            z-index: 3
        }

        .grid-item {
            padding-top: 15px;
            text-align: center;
            padding-bottom: 15px;
            width: 300px;
        }

        #imaegenRelated {
            position: absolute;
            top: 0px;
            right: -20px;
            z-index: 0;
            animation-delay: 0.5s;
            filter: opacity(0.55);
        }
    }
    /*ENTRE MOVIL Y TABLET*/
    @media only screen and (min-width: 440px)and (max-width: 800px) {
        .grid-container {
            display: grid;
            justify-content: center;
            align-items: center;
            gap: 0px;
            height: 100%;
        }

        .outer {
            position: relative;
            background: white;
            height: 250px;
            width: 400px;
            overflow: hidden;
            display: flex;
            align-items: center;
            padding-bottom: 30px;
            box-shadow: 14px 13px 20px -8px grey;
        }

        .content {
            animation-delay: 0.3s;
            position: absolute;
            width: fit-content;
            text-align: center;
            left: 0px;
            z-index: 3;
        }

        .grid-item {
            padding-top: 15px;
            text-align: center;
            padding-bottom: 15px;
            width: 400px;
            display: grid;
            justify-content: center;
            align-items: center;
        }

        #imaegenRelated {
            position: absolute;
            top: 0px;
            right: -80px;
            z-index: 0;
            animation-delay: 0.5s;
            filter: opacity(0.65);
        }
    }
    /*TABLET (2EVENTOS/FILA)*/
    @media only screen and (min-width:800px) and (max-width:1000px) {

        .grid-container {
            display: grid;
            grid-template-columns: auto auto;
            padding-right: 5%;
            padding-left: 4%;
            grid-column-gap: 10%;
            justify-content: center;
        }


        .outer {
            position: relative;
            background: white;
            height: 250px;
            width: 300px;
            overflow: hidden;
            display: flex;
            align-items: center;
            padding-bottom: 30px;
            box-shadow: 14px 13px 20px -8px grey;
        }

        .content {
            animation-delay: 0.3s;
            position: absolute;
            width: 300px;
            text-align: center;
            left: 0px;
            z-index: 3
        }

        .grid-item {
            padding-top: 15px;
            text-align: center;
            padding-bottom: 15px;
            width: 300px;
        }

        #imaegenRelated {
            position: absolute;
            top: 0px;
            right: -20px;
            z-index: 0;
            animation-delay: 0.5s;
            filter: opacity(0.55);
        }
    }


    /*ENTRE TABLET Y DESKTOP**/
    @media only screen and (min-width:1000px) and (max-width:1400px) {

        .grid-container {
            display: grid;
            grid-template-columns: auto auto;
            padding-right: 5%;
            padding-left: 4%;
            grid-column-gap: 10%;
            justify-content: center;
        }

        .outer {
            position: relative;
            background: white;
            height: 250px;
            width: 400px;
            overflow: hidden;
            display: flex;
            align-items: center;
            padding-bottom: 30px;
            box-shadow: 14px 13px 20px -8px grey;
        }

        .content {
            animation-delay: 0.3s;
            position: absolute;
            width: fit-content;
            text-align: center;
            left: 0px;
            z-index: 3;
        }

        .grid-item {
            padding-top: 15px;
            text-align: center;
            padding-bottom: 15px;
            width: 400px;
            display: grid;
            justify-content: center;
            align-items: center;
        }

        #imaegenRelated {
            position: absolute;
            top: 0px;
            right: -80px;
            z-index: 0;
            animation-delay: 0.5s;
            filter: opacity(0.65);
        }
    }
    /*DESKTOP*/
    @media only screen and (min-width:1400px) and (max-width:2560px) {
        .grid-container {
            display: grid;
            grid-template-columns: auto auto auto;
            padding-right: 5%;
            padding-left: 4%;
            justify-content: center;
            grid-column-gap: 4%;
        }

        .outer {
            position: relative;
            background: white;
            height: 250px;
            width: 400px;
            overflow: hidden;
            display: flex;
            align-items: center;
            box-shadow: 7px 9px 20px -3px grey;
        }

        .grid-item {
            padding-top: 10px;
            text-align: center;
            padding-bottom: 30px;
        }

        .content {
            animation-delay: 0.3s;
            position: absolute;
            left: 20px;
            z-index: 3
        }

        #imaegenRelated {
            position: absolute;
            top: 0px;
            right: -60px;
            z-index: 0;
            animation-delay: 0.5s;
            filter: opacity(0.65);
        }
    }

    #form1 {
        display: flex;
        justify-content: center;
        align-items: center;
        padding-bottom: 50px;
    }

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
    /**********************************************/

    /* Product Details */
    .product-detail .details {
        display: grid;
        grid-template-columns: 1fr 1.2fr;
        gap: 7rem;
        padding-top: 20px;
    }

    .product-detail .left {
        display: flex;
        flex-direction: column;
    }

        .product-detail .left .main {
            text-align: center;
            background-color: #f6f2f1;
            margin-bottom: 2rem;
            height: 45rem;
        }

            .product-detail .left .main #imagenDetail {
                object-fit: cover;
                height: 100%;
                width: 100%;
                background-color: white;
            }

    .product-detail .right span {
        display: inline-block;
        font-size: 1.5rem;
        margin-bottom: 1rem;
    }

    .product-detail .right h1 {
        font-size: 4rem;
        line-height: 1.2;
        margin-bottom: 2rem;
        margin-top: -3rem;
    }

    .product-detail .right .price {
        font-size: 600;
        font-size: 2rem;
        color: var(--green);
    }

    .product-detail .right div {
        display: inline-block;
        position: relative;
        z-index: -1;
    }

    .product-detail .right select {
        font-family: 'Poppins', sans-serif;
        width: 20rem;
        padding: 0.7rem;
        border: 1px solid #ccc;
        appearance: none;
        outline: none;
    }

    .product-detail form {
        z-index: 0;
    }

        .product-detail form span {
            position: absolute;
            top: 50%;
            right: 1rem;
            transform: translateY(-50%);
            font-size: 2rem;
            z-index: 0;
        }

    .product-detail .form {
        margin-bottom: 3rem;
    }

        .product-detail .form input {
            padding: 0.8rem;
            text-align: center;
            width: 3.5rem;
            margin-right: 2rem;
        }

        .product-detail .form .addCart {
            background: #4caf50;
            padding: 0.8rem 4rem;
            color: #000;
            border-radius: 3rem;
        }

        .addCart {
            background: #4caf50;
            padding: 0.8rem 4rem;
            color: #000;
            border-radius: 3rem;
        }

    .product-detail h3 {
        margin-bottom: 2rem;
    }

    @media only screen and (max-width: 996px) {
        .product-detail .left {
            width: 30rem;
            height: 45rem;
        }

        .product-detail .details {
            gap: 3rem;
        }
    }

    @media only screen and (max-width: 650px) {
        .product-detail .details {
            grid-template-columns: 1fr;
        }

        .product-detail .right {
            margin-top: 1rem;
        }

        .product-detail .left {
            width: 100%;
            height: 45rem;
        }

        .product-detail .details {
            gap: 3rem;
        }
    }


    /*********************************************/

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

    .containerr {
        padding-top: 6%;
        max-width: 114rem;
        margin: 0 auto;
        padding: 0 3rem;
        padding-bottom: 6%;
    }

    .container-top {
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
            padding-top: 17px;
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
        .hamburger {
            display: none;
        }
    }



    h3 {
        /*margin y padding para cuadrar el texto */
        padding: 0;
        /*color y alineacion del texto*/
        color: rgb(0, 0, 0);
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
</style>
