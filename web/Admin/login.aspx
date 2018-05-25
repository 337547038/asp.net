<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Admin_login" Debug=true%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站后台管理系统</title>
	<link href="css/style.css" rel="stylesheet" type="text/css"/>
	<style type="text/css">
	body{background:#016BA9;}
	.login{ width:250px; margin:0 auto; margin-top:100px; color:#FFFFFF}
	.login .logininput{ margin:5px auto; width:150px;}
	.login #Button1{background:url(../images/button_submit.gif) repeat-x #e3f1fa;border:1px solid #aed0ea;padding:0px 10px;height:24px;line-height:24px;color:#333;cursor:pointer; margin-left:50px;}
	</style>
</head>
<body>
    <form id="form1" runat="server">
	<div style="height:74px; width:100%; background:url(images/headbg.jpg) left top repeat-x;"></div>
    <div class="login">用户名：<asp:TextBox ID="txtUserName" runat="server" CssClass="logininput" MaxLength="10"></asp:TextBox>
   <br/>
    密&nbsp;&nbsp;码：<asp:TextBox ID="txtPassWord" runat="server" TextMode="Password"  CssClass="logininput" MaxLength="20"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="登录" onclick="Button1_Click" />
	</div>
    </form>
</body>
</html>
