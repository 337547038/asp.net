<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminAdd.aspx.cs" Inherits="Admin_AdminAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="comm-table">
        <tr>
            <th colspan="2">
                <asp:Literal ID="ActionName" runat="server"></asp:Literal></th>
        </tr>
        <tr>
            <td class="align-right">管理员名称：</td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="align-right">初始密码：</td>
            <td>
                <asp:TextBox ID="txtPassWord" runat="server" CssClass="input-control" TextMode="Password" MaxLength="50"></asp:TextBox>
                <asp:HiddenField ID="txtPassWordOld" runat="server" />
                <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="align-right">性别：</td>
            <td>
                <asp:RadioButton ID="TxtSex" runat="server" Text="男" Checked="true" GroupName="s1" /><asp:RadioButton ID="TxtSex1" runat="server" Text="女" GroupName="s1" /></td>
        </tr>
        <tr>
            <td class="align-right">电话：</td>
            <td>
                <asp:TextBox ID="txtTTelPhone" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="align-right">邮箱：</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input-control email" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="align-right">锁定：</td>
            <td>

                <asp:CheckBox ID="txtLocked" runat="server" Text="锁定后将不能登录后台" />
            </td>
        </tr>
        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
        <tr id="txtadmin1" runat="server">
            <td class="align-right">模块权限：</td>
            <td>
                <%if (userid == 1)
                    {%>

                <asp:CheckBoxList ID="txtModelPower" runat="server"
                    RepeatDirection="Horizontal" RepeatColumns="6" CssClass="aspx-table">
                    <asp:ListItem Value="0">网站基本设置</asp:ListItem>
                    <asp:ListItem Value="6">网站高级设置</asp:ListItem>
                    <asp:ListItem Value="1">网站模型管理</asp:ListItem>
                    <asp:ListItem Value="2">批量SEO设置</asp:ListItem>
                    <asp:ListItem Value="3">留言管理</asp:ListItem>
                    <asp:ListItem Value="4">友情链接</asp:ListItem>
                    <%--<asp:ListItem Value="5">在线订单管理</asp:ListItem>--%>

                    <asp:ListItem Value="7">会员管理</asp:ListItem>
                    <asp:ListItem Value="14">会员组管理</asp:ListItem>
                    <asp:ListItem Value="8">上传文件管理</asp:ListItem>
                    <asp:ListItem Value="9">单页编辑</asp:ListItem>
                    <asp:ListItem Value="91">单页添加</asp:ListItem>
                    <asp:ListItem Value="92">单页删除</asp:ListItem>
                    <asp:ListItem Value="10">数据库字段替换</asp:ListItem>
                    <%--<asp:ListItem Value="11">店铺管理</asp:ListItem>--%>
                    <%--<asp:ListItem Value="12">发布管理</asp:ListItem>
                    <asp:ListItem Value="13">模板管理</asp:ListItem>--%>

                    <asp:ListItem Value="15">站点广告</asp:ListItem>
                    <asp:ListItem Value="18">站点广告添加</asp:ListItem>
                    <asp:ListItem Value="19">站点广告删除</asp:ListItem>
                    <asp:ListItem Value="22">站点广告位管理</asp:ListItem>

                    <asp:ListItem Value="16">上传图片文件</asp:ListItem>
                    <asp:ListItem Value="17">方块碎片</asp:ListItem>
                    <asp:ListItem Value="23">方块碎片添加删除</asp:ListItem>
                    <asp:ListItem Value="20">系统运行错误记录</asp:ListItem>
                    <%--<asp:ListItem Value="21">文章信息采集</asp:ListItem>--%>
                    <asp:ListItem Value="24">搜索关键词管理</asp:ListItem>
                </asp:CheckBoxList>
                <%}
                    else
                    { %>
                <asp:CheckBoxList ID="txtModelPower2" runat="server" RepeatDirection="Horizontal"
                    RepeatColumns="6" CssClass="aspx-table">
                </asp:CheckBoxList>
                <%} %>
            </td>
        </tr>
        <tr id="txtadmin" runat="server">
            <td class="align-right">设置默认权限：</td>
            <td>
                <asp:CheckBox ID="checkboxadmin" runat="server" Text="将此设为管理员默认权限" /></td>
        </tr>
        <tr>
            <td width="15%">&nbsp;</td>
            <td width="85%">
                <asp:Button ID="Button1" runat="server" Text="确认添加"
                    CssClass="btn" OnClick="Button1_Click" /></td>
        </tr>
    </table>
    <asp:HiddenField ID="HiddenFieldmp" runat="server" />
</asp:Content>

