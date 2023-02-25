<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullList.aspx.cs" Inherits="LietuvosTransportas.Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/StyleFullList.css" runat="server" />
    <script src="../App_Data/jquery.min.js"></script>
    <link href="../App_Data/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../App_Data/jquery-ui.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <asp:Button CssClass="button" ID="btnShowLongDistance" runat="server" Text="Tarmiestiniai" OnClick="btnShowLongDistance_Click" style="margin-left:1310px"/>
            <br />
            <asp:Textbox id="country" CssClass="twitter-typeahead tt-query" runat="server"></asp:Textbox>
            <br />
            <%--<iframe id="pageEmbed" name="iframe" src="https://www.stops.lt/siauliai" width="100%" height="500" scrolling="auto" frameborder="1"></iframe>--%>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $('#country').typeahead({
                name: 'AnyNameHere',
                remote: "Countries.ashx?q=%QUERY",
                limit: 10
            });
        });
    </script>
</body>
</html>
