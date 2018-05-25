<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Model.aspx.cs" Inherits="Admin_Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="comm-table">
  <tr>
    <th width="7%" class="align-center">编号</th>
    <th width="31%" class="align-center">模型名称</th>
    <th width="25%" class="align-center">数据表名</th>
   
    <th width="13%" class="align-center">操作</th>
  </tr>
    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
  <tr>
    <td class="align-center"><input type="checkbox" name="checkbox" value="<%#Eval("id") %>" /></td>
    <td class="align-center"><img src="images/doc0.gif" alt=""/><%#Eval("ModelName") %><%#Eval("ModelLock").ToString()=="1"?"<font color=red>已禁用</font>":""%></td>
    <td class="align-center"><%#Eval("ModelTable") %></td>
    
    <td class="align-center link-margin"><a href="ModelField.aspx?mid=<%#Eval("id")%>">字段管理</a> <a href="ModelAdd.aspx?id=<%#Eval("id") %>" class="icon-edit" title="编辑"></a> <asp:LinkButton ID="lbtdel" onclientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>' onclick="Unnamed1_Click" runat="server" CssClass="icon-del" title="删除"></asp:LinkButton></td>
  </tr></ItemTemplate>
  </asp:Repeater>
</table>
</asp:Content>

