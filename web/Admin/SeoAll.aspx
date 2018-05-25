<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="SeoAll.aspx.cs" Inherits="Admin_SeoAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (Request.QueryString["action"] == "class")
        {%>
    <table class="comm-table">
        <tr>
            <th class="align-center">栏目名称</th>
            <th class="align-center">SEO标题</th>
            <th class="align-center">SEO关键字</th>
            <th class="align-center">SEO描述</th>
        </tr>

        <asp:repeater id="Repeater1" runat="server">
    <ItemTemplate>
<tr>
    
<td class="align-center"><%#GetModelName(Eval("ModelId").ToString()) %>-<%#Eval("ClassName") %><asp:HiddenField ID="HiddenField1" Value='<%#Eval("id") %>' runat="server" /></td>
<td class="align-center"><asp:TextBox ID="txtSeoTitle" runat="server" Text='<%#Eval("SeoTitle") %>' CssClass="input-control" MaxLength="150"></asp:TextBox></td>
<td class="align-center"><asp:TextBox ID="txtKeyWord" runat="server" Text='<%#Eval("SeoKeyWord") %>' TextMode="MultiLine" CssClass="textarea input-control" MaxLength="150"></asp:TextBox></td>
<td class="align-center"><asp:TextBox ID="txtSeoDescription" runat="server" Text='<%#Eval("SeoDescription") %>' TextMode="MultiLine" CssClass="textarea input-control" MaxLength="300"></asp:TextBox></td>
</tr>
</ItemTemplate>
    </asp:repeater>

        <tr>
            <td colspan="4" height="40">
                <asp:button id="Button1" runat="server" text="批量保存"
                    cssclass="btn" onclick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right">
                <asp:literal id="txtpage" runat="server"></asp:literal>
            </td>

        </tr>
    </table>
    <%}
        else if (Request.QueryString["action"] == "diypage")
        {%>
    <table class="comm-table">
        <tr>
            <th class="align-center">单页名称</th>
            <th class="align-center">SEO标题</th>
            <th class="align-center">SEO关键字</th>
            <th class="align-center">SEO描述</th>
        </tr>

        <asp:repeater id="Repeater2" runat="server">
    <ItemTemplate>
<tr>
    
<td class="align-center"><%#Eval("PageName")%><asp:HiddenField ID="HiddenField2" Value='<%#Eval("id") %>' runat="server" /></td>
<td class="align-center"><asp:TextBox ID="txtSeoTitle2" runat="server" Text='<%#Eval("SeoTitle") %>' CssClass="input-control"></asp:TextBox></td>
<td class="align-center" class="align-center"><asp:TextBox ID="txtKeyWord2" runat="server" Text='<%#Eval("SeoKeyword") %>' TextMode="MultiLine" CssClass="textarea input-control"></asp:TextBox></td>
<td class="align-center"><asp:TextBox ID="txtSeoDescription2" runat="server" Text='<%#Eval("SeoDescription") %>' TextMode="MultiLine" CssClass="textarea input-control"></asp:TextBox></td>
</tr>
</ItemTemplate>
    </asp:repeater>

        <tr>
            <td colspan="4" height="40">
                <asp:button id="Button2" runat="server" text="批量保存"
                    cssclass="btn" onclick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="alignright">
                <asp:literal id="Literal1" runat="server"></asp:literal>
            </td>

        </tr>
    </table>

    <%}
        else
        { %>
    <table class="comm-table">
        <tr>
            <td>&nbsp;&nbsp;先从上面选择需要设置的版块</td>
        </tr>
    </table>
    <%} %>
    <p style="margin-top: 15px; text-align: center">提示：SEO标题建议不超过80个字符，关键字不超过100字符，描述不超过200字符</p>
    <br />
    <br />
</asp:Content>

