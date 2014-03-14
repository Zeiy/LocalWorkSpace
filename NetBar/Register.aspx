<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NetBar.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="用户名："></asp:Label><asp:TextBox ID="userName" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="密 码:"></asp:Label><asp:TextBox ID="userPwd" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label3" runat="server" Text="重复密码："></asp:Label><asp:TextBox ID="rePwd" runat="server"></asp:TextBox><br />
        <asp:Button ID="register" runat="server" Text="创建" OnClick="register_Click" /><asp:Label ID="warmMsg" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
