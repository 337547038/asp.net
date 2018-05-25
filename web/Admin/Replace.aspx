<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Replace.aspx.cs" Inherits="Admin_Replace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="comm-table">
  <tr>
  <td class="align-right">数据表名：</td>
  <td><asp:DropDownList ID="ddlTable" runat="server" CssClass="required input-control select-control" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" >
      </asp:DropDownList>
  </td>
  </tr>
  <tr>
    <td class="align-right">字段名：</td>
    <td>
        <asp:DropDownList ID="ddltableColumns" runat="server" CssClass="required input-control select-control" >
        </asp:DropDownList>
    </td>
  </tr>
  
  <tr>
    <td class="align-right">将字符：</td>
    <td>
        <asp:TextBox ID="txtoldvalues" runat="server" CssClass="textarea input-control required" TextMode="MultiLine"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="align-right">替换成：</td>
    <td>
        <asp:TextBox ID="txtnewvalues" runat="server" CssClass="textarea input-control" TextMode="MultiLine"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="alignright">注意事项：</td>
    <td>1、执行操作前，请备份数据库文件。2、执行过程请不要刷新页面或关闭浏览器。</td>
  </tr>
  <tr><td></td>
    <td height="50"><asp:Button ID="Button1" runat="server" Text="开始替换" 
            CssClass="btn" onclick="Button1_Click"/></td>
  </tr>
  </table><asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>

