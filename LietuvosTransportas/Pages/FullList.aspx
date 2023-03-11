<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullList.aspx.cs" Inherits="LietuvosTransportas.Page2"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/PageStyle.css" runat="server" />
    <script src="../App_Data/jquery.min.js"></script>
    <link href="../App_Data/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../App_Data/jquery-ui.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="main">
            <asp:Button CssClass="button" UseSubmitBehavior = "false" ID="BtnReturn" runat="server" Text="Pradinis puslapis" OnClick="BtnReturn_Click" style="float:right;"/>
            <asp:Button CssClass="button" UseSubmitBehavior = "false" ID="BtnShowLongDistance" runat="server" Text="Tarmiestiniai" OnClick="BtnShowLongDistance_Click" style="float:right;"/>
            <br />
            <ajaxToolkit:ComboBox CssClass="search" ID="SearchBox1" runat="server" UseSubmitBehavior="false" AutoCompleteMode="SuggestAppend" MaxLength="0" style="display: inline;" DataTextField="name" DropDownStyle="DropDownList" ></ajaxToolkit:ComboBox>
            <br />
            <ajaxToolkit:ComboBox CssClass="search" ID="SearchBox2" runat="server" UseSubmitBehavior="false" AutoCompleteMode="SuggestAppend" MaxLength="0" style="display: inline;" DataTextField="name" DropDownStyle="DropDownList" ></ajaxToolkit:ComboBox>
            <asp:Button CssClass="button" UseSubmitBehavior = "false" ID="BtnSubmit" runat="server" Text="Paieška" OnClick="BtnSubmit_Click" />
        </div>
    </form>
</body>
</html>
