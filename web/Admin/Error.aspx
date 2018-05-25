<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Admin_Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="comm-table">
        <tr>
            <td>
                <asp:Literal ID="txtcon" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">清空记录</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>

