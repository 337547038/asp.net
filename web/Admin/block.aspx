<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="block.aspx.cs" Inherits="Admin_block" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (action == "show")
      { %>
    <table class="comm-table">
        <tr>
            <th class="align-center">
                方块名称
            </th>
            <th class="align-center">
                修改时间
            </th>
            <th class="align-center">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Title")%>
                    </td>
                    <td class="align-center">
                        <%#GL.Utility.BasePage.formatDateTime(Eval("AddDate").ToString())%>
                    </td>
                    <td class="align-center link-margin">
                        <a href="?Ac=add&id=<%#Eval("id") %>" class="icon-edit" title="编辑"></a>
                            <%if (GL.Utility.BasePage.ArrayExist(GL.Utility.Cookies.GetCookie("ModelPower"), "23"))
                              { %>
                        <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed1_Click" runat="server" CssClass="icon-del" title="删除"></asp:LinkButton><%} %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="4">
                <asp:Literal ID="txtpage" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <% }
      else if (action == "add")
      { %>
    <table class="comm-table">
        <tr>
            <td class="align-right">
                方块名称：
            </td>
            <td>
                <asp:TextBox ID="txtPageName" runat="server" CssClass="input-control w200 required" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="align-right">
                方块内容：
            </td>
            <td>
                <asp:TextBox ID="txtcontents" runat="server" TextMode="MultiLine" CssClass="input-control textarea required"></asp:TextBox>
            </td>
        </tr>
        <tr><td></td>
            <td height="40">
                <asp:Button ID="Button1" runat="server" Text="新建方块" CssClass="btn" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    <%} %>
</asp:Content>

