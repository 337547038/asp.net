<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="WebConfig.aspx.cs" Inherits="Admin_WebConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="comm-table">
      <tr>
        <th width="21%">系统基本设置</th>
        <th class="align-right" width="79%"></th>
      </tr>
      <tr>
        <td class="align-right">网站名称：</td>
        <td><asp:TextBox ID="txtSiteName" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">网站标题：</td>
        <td><asp:TextBox ID="txtsitetitle" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr class="morelanguage">
        <td class="align-right">英文网站标题：</td>
        <td><asp:TextBox ID="txtsitetitleen" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">网站域名：</td>
        <td><asp:TextBox ID="txtSiteUrl" runat="server" CssClass="input-control url" MaxLength="50"></asp:TextBox></td>
      </tr>
      <%if (gethide("0"))
        {%>
      <tr>
        <td class="align-right">备案号：</td>
        <td><asp:TextBox ID="txticp" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></td>
      </tr>
      
      <%} if (gethide("2"))
        {%>
      <tr>
        <td class="align-right">联系人：</td>
        <td><asp:TextBox ID="txtfax" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></td>
      </tr>
      <%} if (gethide("3"))
        {%>
      <tr>
        <td class="align-right">电话：</td>
        <td><asp:TextBox ID="txttel" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></td>
      </tr>
      <%} if (gethide("4"))
        {%>
      <tr>
        <td class="align-right">地址：</td>
        <td><asp:TextBox ID="txtaddress" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></td>
      </tr>
      <%} if (gethide("5"))
        {%>
      <tr>
        <td class="align-right">站长信箱：</td>
        <td>
        <asp:TextBox ID="txtsiteemail" runat="server" CssClass="input-control email" MaxLength="50"></asp:TextBox></td>
      </tr>
      <%} if (gethide("6"))
        {%>
      <tr>
        <td class="align-right">QQ：</td>
        <td><asp:TextBox ID="txtqq" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></td>
      </tr>
      <%} if (gethide("10"))
        {%>
      <tr>
        <td class="align-right">站点ID：</td>
        <td><asp:Literal ID="txtidnum" runat="server"></asp:Literal></td>
      </tr>
      <%} %>
      <tr>
        <td class="align-right">网站关键字：</td>
        <td><asp:TextBox ID="txtSiteKeyword" runat="server" CssClass="input-control textarea required" TextMode="MultiLine" MaxLength="150"></asp:TextBox></td>
      </tr>
      <tr class="morelanguage">
        <td class="align-right">英文网站关键字：</td>
        <td><asp:TextBox ID="txtSiteKeyworden" runat="server" CssClass="input-control textarea required" TextMode="MultiLine" MaxLength="150" ></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">网站描述：</td>
        <td><asp:TextBox ID="txtSiteDescription" runat="server" CssClass="input-control textarea required" TextMode="MultiLine" MaxLength="300"></asp:TextBox></td>
      </tr>
       <tr class="morelanguage">
        <td class="align-right">英文网站描述：</td>
        <td><asp:TextBox ID="txtSiteDescriptionen" runat="server" CssClass="input-control textarea required" TextMode="MultiLine" MaxLength="300"></asp:TextBox></td>
      </tr>
      <%if (gethide("7"))
        {%>
      <tr>
        <td class="align-right">统计代码：</td>
        <td><asp:TextBox ID="txtsitecnzz" runat="server" CssClass="input-control textarea" TextMode="MultiLine" MaxLength="150"></asp:TextBox></td>
      </tr>
      <%} if (gethide("8"))
        {%>
      <tr>
        <td class="align-right">其他：</td>
        <td><asp:TextBox ID="txtother" runat="server" CssClass="input-control textarea" TextMode="MultiLine" MaxLength="150"></asp:TextBox></td>
      </tr>
      <%} %>
    </table>
    <%if (gethide("9"))
      {%>
    <table class="comm-table">
      <tr>
        <th>邮件参数设置</th>
        <th class="align-right"></th>
      </tr>
      
      <tr>
        <td class="align-right" width="21%">SMTP服务器地址：</td>
        <td width="79%"><asp:TextBox ID="txtEmailsmtp" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">SMTP登录用户名：</td>
        <td><asp:TextBox ID="txtSmtpName" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">SMTP登录密码：</td>
        <td><asp:TextBox ID="txtSmtpPassword" runat="server" CssClass="input-control required" TextMode="Password" MaxLength="50"></asp:TextBox></td>
      </tr>
    </table>
    <%} %>
    <table class="comm-table" id="shsiteconfig" runat="server">
    <tr>
        <th class="align-right" width="21%">其他配置</th>
        <th></th>
      </tr>
      <tr>
      <td width="21%" class="align-right">基本配置显示字段：</td>
      <td width="79%"><asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="12" CssClass="aspx-table">
      <asp:ListItem Value="0">备案号</asp:ListItem>
     <%-- <asp:ListItem Value="1">首页静态</asp:ListItem>--%>
      <asp:ListItem Value="2">联系人</asp:ListItem>
      <asp:ListItem Value="3">电话</asp:ListItem>
      <asp:ListItem Value="4">地址</asp:ListItem>
      <asp:ListItem Value="5">邮箱</asp:ListItem>
      <asp:ListItem Value="6">QQ</asp:ListItem>
      <asp:ListItem Value="7">统计代码</asp:ListItem>
      <asp:ListItem Value="8">其他</asp:ListItem>
      <asp:ListItem Value="9">邮件参数设置</asp:ListItem>
      <asp:ListItem Value="10">站点ID</asp:ListItem>
      </asp:CheckBoxList></td>
      </tr>
    <tr>
     <td class="align-right">留言内容可选：</td>
     <td><asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatColumns="12" CssClass="aspx-table">
     <asp:ListItem Value="0">标题</asp:ListItem>
     <asp:ListItem Value="1">联系人</asp:ListItem>
     <asp:ListItem Value="2">性别</asp:ListItem>
     <asp:ListItem Value="3">电话</asp:ListItem>
     <asp:ListItem Value="4">手机</asp:ListItem>
     <asp:ListItem Value="5">QQ</asp:ListItem>
     <asp:ListItem Value="6">Msn</asp:ListItem>
     <asp:ListItem Value="7">WangWang</asp:ListItem>
     <asp:ListItem Value="8">邮箱</asp:ListItem>
     <asp:ListItem Value="9">地址</asp:ListItem>
     <asp:ListItem Value="10">邮编</asp:ListItem>
     <asp:ListItem Value="11">传真</asp:ListItem>
     <asp:ListItem Value="12">公司名称</asp:ListItem>
     <asp:ListItem Value="13">公司网址</asp:ListItem>
     <asp:ListItem Value="14">IP地址</asp:ListItem>
     <asp:ListItem Value="15">回复/回复时间</asp:ListItem>
     <asp:ListItem Value="16">审核</asp:ListItem>
     </asp:CheckBoxList></td>
     </tr>
     <tr>
     <td class="align-right">留言列表可选：</td>
     <td><asp:CheckBoxList ID="CheckBoxList3" runat="server" RepeatColumns="12" CssClass="aspx-table">
     <asp:ListItem Value="0">标题</asp:ListItem>
     <asp:ListItem Value="1">联系人</asp:ListItem>
     <asp:ListItem Value="3">电话</asp:ListItem>
     <asp:ListItem Value="4">手机</asp:ListItem>
     <asp:ListItem Value="16">审核</asp:ListItem>
     </asp:CheckBoxList></td>
     </tr>
     
     <tr>
     <td class="align-right">单页显示可选：</td>
     <td><asp:RadioButtonList ID="RadioButtonList1" RepeatColumns="2" runat="server" CssClass="aspx-table">
     <asp:ListItem Value="0" Selected="True">显示</asp:ListItem>
     <asp:ListItem Value="1">隐藏</asp:ListItem>
     </asp:RadioButtonList></td>
     </tr>
     
    </table>
    <table>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td align="center"><asp:Button ID="Button1" runat="server" Text="确认修改" 
                CssClass="btn" onclick="Button1_Click"/></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
    </table>
    
    <p>&nbsp;</p>
        <asp:HiddenField ID="hiddenfield1" runat="server" />
</asp:Content>

