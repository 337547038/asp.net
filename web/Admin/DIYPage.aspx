<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="DIYPage.aspx.cs" Inherits="Admin_DIYPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (String.IsNullOrEmpty(action))
      { %>
    <table class="comm-table">
        <tr>
            <th class="align-center">
                页面名称
            </th>
            <th class="align-center">
                页面类型
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
                    <td class="align-center">
                        <%#Eval("PageName").ToString()%>
                    </td>
                    <td class="align-center">
                        <%#Eval("PageType").ToString()=="0"?"单页":"单页栏目"%>
                    </td>
                    <td class="align-center">
                        <%#GL.Utility.BasePage.formatDateTime(Eval("EditTime").ToString()) %>
                       
                    </td>
                    <td class="align-center link-margin">
                        <%#Getchildren(Eval("id").ToString(),Eval("PageType").ToString()) %>
                        <%if (GL.Utility.BasePage.ArrayExist(GL.Utility.Cookies.GetCookie("ModelPower"), "92"))
                          { %>
                        <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed1_Click" runat="server" CssClass="icon-del" title="删除"></asp:LinkButton><%} %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <% }
      else if (action == "add")
      { %>
    <script type="text/javascript">
        //编辑器
        editkind("ctl00$ContentPlaceHolder1$txtcontents");
        kindeditUploadImg("#image3", "#ctl00_ContentPlaceHolder1_txtPicUrl");
    </script>

    <table class="comm-table">
        <tr>
            <td class="align-right w100">
                单页名称：
            </td>
            <td>
                <asp:TextBox ID="txtPageName" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        
        <tr id="showddltid" runat="server">
            <td class="align-right">
                所属于栏目：
            </td>
            <td>
                <asp:DropDownList ID="ddltid" runat="server" CssClass="input-control select-control">
                </asp:DropDownList>
            </td>
        </tr>
        <% if(gethide("2"))
          {%>
        <tr>
            <td class="align-right">
                同类型优先：
            </td>
            <td>
                <asp:TextBox ID="txtpx" runat="server" CssClass="input-control required digits" Text="0"
                    MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        
       
        <%} if (gethide("7"))
           {%>
        <tr>
        <td class="align-right">单页图片：</td>
        <td><asp:TextBox ID="txtPicUrl" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>&nbsp;<input type="button" id="image3" value="上传图片" class="btn"/></td>
        </tr>
        <%} if (gethide("5"))
           { %>
        <tr class="seonone">
            <td class="align-right">
                Seo标题：
            </td>
            <td>
                <asp:TextBox ID="txtseotitle" runat="server" CssClass="input-control" MaxLength="150"></asp:TextBox>
            </td>
        </tr>
       <tr class="seonone">
            <td class="align-right">
                Seo关键字：
            </td>
            <td>
                <asp:TextBox ID="txtkeyword" runat="server" CssClass="textarea input-control" MaxLength="150" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr class="seonone">
            <td class="align-right">
                Seo描述：
            </td>
            <td>
                <asp:TextBox ID="txtSeoDescription" runat="server" CssClass="textarea input-control" MaxLength="300" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <%} if (!gethide("6"))
           { %>
        <tr>
            <td class="align-right">
                内容：
            </td>
            <td>
                <asp:TextBox ID="txtcontents" runat="server" TextMode="MultiLine" CssClass="textarea input-control wh required"></asp:TextBox>
            </td>
        </tr>
        <%} %>
        <tr id="showhide" runat="server">
        <td class="align-right">可选字段：</td>
        <td>
        <asp:CheckBoxList ID="txtpagecontentsfield" RepeatColumns="8" runat="server" CssClass="aspx-table">
        <asp:ListItem Value="1">所属栏目</asp:ListItem>
        <asp:ListItem Value="2">同类型优先</asp:ListItem>
        <asp:ListItem Value="3">模板地址</asp:ListItem>
       
        <asp:ListItem Value="5">SEO选项</asp:ListItem>
        <asp:ListItem Value="6">内容（反选）</asp:ListItem>
        <asp:ListItem Value="7">图片地址</asp:ListItem>
        </asp:CheckBoxList>
        </td>
        </tr>
       
        <tr><td></td>
            <td height="40">
                <asp:Button ID="Button1" runat="server" Text="新建单页" CssClass="btn" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <%}
      else if (action == "add1")
      {%>
    <table class="comm-table">
        <tr>
            <td class="align-right">
                单页栏目名称：
            </td>
            <td>
                <asp:TextBox ID="txtpagename1" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td></td>
            <td height="40">
                <asp:Button ID="Button2" runat="server" Text="新建单页栏目" CssClass="btn" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    <%} %>
</asp:Content>

