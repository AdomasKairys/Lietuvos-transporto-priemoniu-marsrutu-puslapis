<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="LietuvosTransportas.Pages.Map" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/StylePages.css" runat="server" />
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
            <br />
            <ajaxToolkit:ComboBox CssClass="search" ID="SearchBox" runat="server" UseSubmitBehavior="false" AutoCompleteMode="SuggestAppend" MaxLength="0" style="display: inline;" DataTextField="name" OnTextChanged="SearchBox_TextChanged" DropDownStyle="DropDownList" ></ajaxToolkit:ComboBox>
            <br />
            <br />
            <iframe id="PageEmbed" name="iframe" src="https://www.stops.lt/" style="position: absolute;width:0;height:0;border:0;" scrolling="auto" runat="server"></iframe>
        </div>
    </form>
</body>
</html>
