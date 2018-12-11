<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
            <asp:Button ID="btnGenerate" runat="server" Text="Generate QR" OnClick="btnGenerate_OnClick"/>
            <br/>
            <asp:PlaceHolder ID="PHQRCode" runat="server"></asp:PlaceHolder>
            
            </div>
    </form>
</body>
</html>
