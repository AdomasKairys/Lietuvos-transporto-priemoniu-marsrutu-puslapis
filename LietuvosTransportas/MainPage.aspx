<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="LietuvosTransportas.Page1"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/MainStyle.css" runat="server" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="app-container">
             <div class="header-wrapper">
                <div class="header">
                    <img class="img" src="/Logo.jpg" alt="Logo" />
                    <div class="header-buttons">
                        <asp:Button CssClass="help-button" ID="help" runat="server" Text="Pagalba"/>
                        <asp:Button CssClass="help-button" ID="info" runat="server" Text="Informacija" Style="margin-left:20px"/>
                    </div>
                 </div>
             </div>

            <div class="app">
                <div class="app-inner">
                    <div class="main-button">
                        <asp:Button CssClass="button1" ID="BtnShowFull" runat="server" Text="Visi maršrutai" OnClick="BtnShowFull_Click"/>
                        <asp:Button CssClass="button2" ID="BtnSearch1" runat="server" Text="Maršrutų paieška" OnClick="BtnSearch1_Click"/>
                    </div>
                    <div class="main-button">
                        <asp:Button CssClass="button3" ID="BtnSearch2" runat="server" Text="Kelionės paieška" OnClick="BtnSearch2_Click"/>
                        <asp:Button CssClass="button4" ID="BtnMap" runat="server" Text="Žemėlapis" OnClick="BtnMap_Click"/>
                    </div>
                </div>
             </div>
        </div>
    </form>
</body>
</html>
