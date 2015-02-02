<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="webcloud._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 567px">
    <form id="form1" runat="server">
    <div style="height: 109px">
    
        Tên đăng nhập:&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="183px"></asp:TextBox>
        <br />
        Mậ khẩu:&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Height="16px" Width="183px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Đăng nhập" Width="108px" />
    
    </div>
    </form>
</body>
</html>
