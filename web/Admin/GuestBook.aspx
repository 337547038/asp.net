<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="GuestBook.aspx.cs" Inherits="Admin_GuestBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (id == 0)
  { %>
    <table class="comm-table">
        <tr>
            <th width="7%" class="align-center">编号</th>
            <%if (gethidelist("0"))
      { %>
            <th class="align-center">标题</th>
            <%} if (gethidelist("1"))
      {%>
            <th class="align-center">联系人</th>
            <%} if (gethidelist("3"))
      {%>
            <th class="align-center">电话</th>
            <%} if (gethidelist("4"))
      {%>
            <th class="align-center">手机</th>
            <%} %>
            <th class="align-center">留言时间</th>
            <%if (gethidelist("16"))
     { %>
            <th class="align-center">审核</th>
            <%} %>
            <th class="align-center">操作</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>

                    <td>
                        <input type="checkbox" name="checkbox" value="<%#Eval("id") %>" /></td>
                    <%if (gethidelist("0"))
                        { %>
                    <td class="align-center"><%#Eval("Title")%></td>
                    <%}
                    if (gethidelist("1"))
                    { %>
                    <td class="align-center"><%#Eval("UserName")%></td>
                    <%}
                    if (gethidelist("3"))
                    { %>
                    <td class="align-center"><%#Eval("Tel")%></td>
                    <%}
                    if (gethidelist("4"))
                    { %>
                    <td class="align-center"><%#Eval("Mobile")%></td>
                    <%} %>
                    <td class="align-center">
                        <%#GL.Utility.BasePage.formatDateTime(Eval("AddTime").ToString())%>
                       </td>
                    <%if (gethidelist("16"))
                        { %>
                    <td class="align-center"><%#Eval("Verific").ToString() == "1" ? "否" : "已审核"%></td>
                    <%} %>

                    <td class="align-center link-margin"><a href="?id=<%#Eval("id") %>">详情</a>
                        <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>' OnClick="Unnamed1_Click" runat="server" CssClass="icon-del" title="删除"></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>

        <tr>
            <td colspan="2">
                <input name="allcheck" id="allcheck" type="checkbox" />全选
      <asp:Button ID="Button2" runat="server" Text="删除" CssClass="btn"
          OnClick="Button2_Click" /></td>
            <td colspan="6" class="align-right">
                <asp:Literal ID="txtpage" runat="server"></asp:Literal></td>
        </tr>
    </table>
    <% }
        else
        { %>
    <table class="comm-table">
        <%if (gethide("0"))
            {%>
        <tr>
            <td class="align-right">标题：</td>
            <td>
                <asp:Literal ID="txtTitle" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("1"))
            { %>
        <tr>
            <td class="align-right">联系人：</td>
            <td>
                <asp:Literal ID="txtUserName" runat="server"></asp:Literal>
                <%if (gethide("2"))
                    { %>
                <asp:Literal ID="txtsex" runat="server"></asp:Literal><%} %></td>
        </tr>
        <%}
            if (gethide("3"))
            { %>
        <tr>
            <td class="align-right">电话：</td>
            <td>
                <asp:Literal ID="txtTel" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("4"))
            { %>
        <tr>
            <td class="align-right">手机：</td>
            <td>
                <asp:Literal ID="txtMobile" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("5"))
            { %>
        <tr>
            <td class="align-right">QQ：</td>
            <td>
                <asp:Literal ID="txtQQ" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("6"))
            { %>
        <tr>
            <td class="align-right">Msn：</td>
            <td>
                <asp:Literal ID="txtMSN" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("7"))
            { %>
        <tr>
            <td class="align-right">WangWang：</td>
            <td>
                <asp:Literal ID="txtWangWang" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("8"))
            { %>
        <tr>
            <td class="align-right">邮箱：</td>
            <td>
                <asp:Literal ID="txtEmail" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("9"))
            { %>
        <tr>
            <td class="align-right">地址：</td>
            <td>
                <asp:Literal ID="txtAddress" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("10"))
            { %>
        <tr>
            <td class="align-right">邮编：</td>
            <td>
                <asp:Literal ID="txtCode" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("11"))
            { %>
        <tr>
            <td class="align-right">传真：</td>
            <td>
                <asp:Literal ID="txtFax" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("12"))
            { %>
        <tr>
            <td class="align-right">公司名称：</td>
            <td>
                <asp:Literal ID="txtCompany" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("13"))
            { %>
        <tr>
            <td class="align-right">公司网址：</td>
            <td>
                <asp:Literal ID="txtSiteUrl" runat="server"></asp:Literal></td>
        </tr>
        <%}
            if (gethide("14"))
            { %>
        <tr>
            <td class="align-right">IP地址：</td>
            <td>
                <asp:Literal ID="txtIP" runat="server"></asp:Literal></td>
        </tr>
        <%} %>
        <tr>
            <td class="align-right">留言时间：</td>
            <td>
                <asp:Literal ID="txtAddTime" runat="server"></asp:Literal></td>
        </tr>
        <%if (gethide("15"))
            { %>
        <tr>
            <td class="align-right">回复时间：</td>
            <td>
                <asp:Literal ID="txtReplyTime" runat="server"></asp:Literal></td>
        </tr>
        <%} %>
        <tr>
            <td class="align-right">留言内容：</td>
            <td>
                <asp:TextBox ID="txtContents" runat="server" CssClass="textarea input-control" TextMode="MultiLine"></asp:TextBox></td>

        </tr>
        <tr>
            <%if (gethide("15"))
                { %>
            <td class="align-right">回复内容：</td>
            <td>
                <asp:TextBox ID="txtReply" runat="server" CssClass="textarea input-control" TextMode="MultiLine"></asp:TextBox></td>

        </tr>
        <%} %>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp; 
                <asp:Button ID="Button1" runat="server"
                    Text="确认" CssClass="btn" OnClick="Button1_Click" /><% if (gethide("16"))
                     {%><asp:CheckBox ID="txtVerific" runat="server" Text="通过审核" /><%} %></td>

        </tr>
    </table>
    <%} %>
</asp:Content>

