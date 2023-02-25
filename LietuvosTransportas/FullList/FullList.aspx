<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullList.aspx.cs" Inherits="LietuvosTransportas.Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/StyleFullList.css" runat="server" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <asp:Button CssClass="button" ID="btnShowLongDistance" runat="server" Text="Tarmiestiniai" OnClick="btnShowLongDistance_Click" style="margin-left:1310px"/>
            <br />
            <asp:TextBox CssClass="search" ID="searchBox" runat="server" >Pasirinkite miesta cia</asp:TextBox>
            <br />
            <iframe id="pageEmbed" name="iframe" src="https://www.stops.lt/siaulia" width="100%" height="500" scrolling="auto" frameborder="1"></iframe>
        </div>
    </form>
</body>
</html>
