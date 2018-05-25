<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="searchkey.aspx.cs" Inherits="Admin_searchkey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="comm-table">
     <%if(String.IsNullOrEmpty(ac)){ %>
     <tr>
            <th class="align-center">
                关键词名称
            </th>
            <th class="align-center">
                最后搜索时间
            </th>
            <th class="align-center">
                搜索次数
            </th>
         <th class="align-center">
                排序
            </th>
            <th class="align-center">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <tr>
        <td><%#Eval("Keyword") %></td>
        <td class="align-center"><%#Eval("lastdate") %></td>
        <td class="align-center"><%#Eval("num") %></td>
        <td class="align-center"><%#Eval("px") %></td>
        <td class="align-center link-margin"><a href="searchkey.aspx?ac=edit&id=<%#Eval("id") %>" class="icon-edit" title="编辑"></a> <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed1_Click" runat="server" CssClass="icon-del" title="删除"></asp:LinkButton></td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr>
        <td colspan="5" id="fy" runat="server" class="align-right"></td>
        </tr>
        <%}else if(ac=="edit"){ %>
        <tr>
       <td class="align-right" width="200">
                关键词：
            </td>
            <td>
                <asp:TextBox ID="txtkey" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
       <td class="align-right">
                搜索次数：
            </td>
            <td>
                <asp:TextBox ID="txtnum" runat="server" CssClass="input-control required digits" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
         <td class="align-right">
                手动排序：
            </td>
            <td>
                <asp:TextBox ID="txtpx" runat="server" CssClass="input-control required digits" MaxLength="50" value="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
       <td class="align-right">
                
            </td>
            <td height="40">
                <asp:Button ID="Button1" runat="server" Text="修改关键词" CssClass="btn" OnClick="Button1_Click" />
            </td>
        </tr>
        <%} %>
     </table>
</asp:Content>

