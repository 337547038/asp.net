<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="comm-table">
  <tr>
    <th class="align-center">管理员</th>
    <th class="align-center">类型</th>
    <th class="align-center">最后登录IP</th>
    <th class="align-center">最后登录时间</th>
    <th class="align-center">登录次数</th>
	<th class="align-center">锁定</th>
	<th class="align-center">管理操作</th>
  </tr>
      <asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate>   
  <tr>
    <td class="align-center"><%#Eval("UserName") %></td>
    <td class="align-center"><%#Eval("id").ToString()=="1"?"<font color=red>超级管理员</font>":"普通管理员" %></td>
    <td class="align-center"><%#Eval("LastLoginIP") %></td>
	<td class="align-center"><%#GL.Utility.BasePage.formatDateTime(Eval("LastLoginTime").ToString()) %></td>
	<td class="align-center"><%#Eval("LoginTime") %></td>
	<td class="align-center"><%#Eval("Locked").ToString()=="0"?"正常":"<font color=red>锁定</font>" %></td>
    <td class="align-center link-margin"><a href="AdminAdd.aspx?id=<%#Eval("id") %>" class="icon-edit" title="编辑"></a> <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>' OnClick="Unnamed1_Click" runat="server" CssClass="icon-del"></asp:LinkButton></td>
  </tr>
  </ItemTemplate>
  </asp:Repeater>
</table>
</asp:Content>

