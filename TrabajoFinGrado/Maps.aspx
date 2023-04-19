<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maps.aspx.cs" Inherits="TrabajoFinGrado.Maps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyApvvXLJ_vd36K4-KVLA4BxUzssrwdu2W0"></script>
    <title></title>

</head>
<body>
    <form id="form1">
            <div id="map" style="height: 500px"></div>
        </form>

    <%--<script>

        function initMap() {
            var map = new google.maps.Map(document.getElementById("map"), {
                center: { lat: 40.4165, lng: -3.70256 },
                zoom: 13,
            });

            // Agrega los marcadores al mapa
            var marker1 = new google.maps.Marker({
                position: { lat: 37.774, lng: -122.4194 },
                map: map,
                title: "San Francisco",
                id: "marker1" // Asigna un ID al marcador
            });
            marker1.addListener("click", function () {
                window.location.href = "DetalleMarcador.aspx?id=" + this.id;
            });
            var marker2 = new google.maps.Marker({
                position: { lat: 12, lng: -4 },
                map: map,
                title: "San Jose",
                id: "marker2" // Asigna un ID al marcador
            });

            marker2.addListener("click", function () {
                window.location.href = "DetalleMarcador.aspx?id=" + this.id;
            });

            
           
        }

        google.maps.event.addDomListener(window, "load", initMap);



    </script>--%>

</body>
</html>
