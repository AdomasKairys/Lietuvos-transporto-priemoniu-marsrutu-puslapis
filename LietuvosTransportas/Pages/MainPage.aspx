<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="LietuvosTransportas.Page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/StyleMain.css" runat="server" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="main-button">
                <asp:Button CssClass="button" ID="BtnShowFull" runat="server" Text="Visi marsrutai" OnClick="BtnShowFull_Click"/>
                <asp:Button CssClass="button" ID="BtnSearch1" runat="server" Text="Masrutu paieska" OnClick="BtnSearch1_Click" Style="margin-left:50px"/>
            </div>
            <br />
            <div class="main-button">
                <asp:Button CssClass="button" ID="BtnSearch2" runat="server" Text="Keliones paieska" OnClick="BtnSearch2_Click"/>
                <asp:Button CssClass="button" ID="BtnMap" runat="server" Text="Zemelapis" OnClick="BtnMap_Click" Style="margin-left:50px"/>
            </div>
        </div>
    </form>
</body>
</html>
