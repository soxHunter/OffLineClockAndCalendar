<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clock.aspx.cs" Inherits="JsTest.WebForm2" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/themes/base/css/fontawesome.css" rel="stylesheet" />
    <link href="Content/themes/base/css/fa-brands.css" rel="stylesheet" />
    <link href="Content/themes/base/css/fa-regular.min.css" rel="stylesheet" />
    <link href="Content/themes/base/css/fa-solid.css" rel="stylesheet" />
    <link href="Content/themes/base/css/fa-solid.min.css" rel="stylesheet" />
    <link href="Content/themes/base/css/fa-svg-with-js.css" rel="stylesheet" />
    <link href="Content/themes/base/css/fontawesome.min.css" rel="stylesheet" />
    <link href="Content/themes/base/css/fontawesome-all.css" rel="stylesheet" />
    <link href="Content/themes/base/css/fontawesome.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Clock</title>
</head>
<body style="margin:0px;padding:0;">
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <p id="TodayDateLabel" style="font-size:40px; margin:0;padding:0;text-align:center;float:left;">
        <script>
            var TodayDate = new Date();
            var y = TodayDate.getFullYear();
            var m = TodayDate.getMonth()+1;
            var w = TodayDate.getDay();
            var d = TodayDate.getDate();

            var wk = new Array("日", "月", "火", "水", "木", "金", "土");
            document.write(y + " 年  " + m + " 月  " + d + " 日  （" + wk[w] +"）");
        </script>
    </p>
    <div>
        <div style="text-align:left;margin:0;padding:0;position:fixed;left:-80px;top:100px;"> 
            <canvas id="canvas" style="margin:0;padding:0;width:1000px;"></canvas>
        
            <script src="Scripts/ClockCanvas.js"></script>
        </div>
    
        <div style="position:fixed;left:800px;top:40px;">

                <asp:Literal ID="ThisMonthCurrendar" runat="server"></asp:Literal>

        </div>
    </div>
        <footer style="position:fixed;bottom:0px;"><i class="fa fa-copyright"></i> 2018 YOSHIOKA, Nami</footer>
</body>
</html>
