<%@ Page Language="C#" AutoEventWireup="true" CodeFile="idv1.aspx.cs" Inherits="idv1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>生成序列号</title>
</head>
<body>
    <form id="form1" runat="server">
    <p>生成 url域名为空时生成16位（不检验域名），否则生成20位；data六位时间；isdel 等于1时删除</p>
   域名：<asp:TextBox ID="txturl" runat="server"></asp:TextBox>
   <br />
   时间：<asp:TextBox ID="txtdata" runat="server"></asp:TextBox> 6位时间如:20151212<br />
   识别：<asp:DropDownList ID="ddldel" runat="server">
   <asp:ListItem Value="0">否</asp:ListItem>
   <asp:ListItem Value="1">是</asp:ListItem>
   </asp:DropDownList> <br />
   <asp:Button ID="button" runat="server" Text="生成" onclick="button_Click" />
    </form>
</body>
</html>
