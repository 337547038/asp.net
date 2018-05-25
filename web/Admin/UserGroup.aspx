<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="UserGroup.aspx.cs" Inherits="Admin_UserGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (action == "show")
        { %>

    <table class="comm-table">
        <tr>
            <th width="7%" class="align-center">编号</th>
            <th class="align-center">会员组名称</th>
            <th class="align-center">允许注册</th>
            <th class="align-center">操作</th>
        </tr>
        <asp:repeater id="Repeater1" runat="server">
    <ItemTemplate>
  <tr>
      
    <td class="align-center"><input type="checkbox" name="checkbox" value="<%#Eval("id") %>"/></td>
    <td class="align-center"><img src="images/doc0.gif" alt=""/><%#Eval("GroupName")%></td>
    
    <td class="align-center"><%#Eval("ShowOnReg").ToString() == "0" ? "允许" : "不允许"%></td>
    
    <td class="align-center link-margin"><a href="User.aspx?GroupId=<%#Eval("id") %>">查看组成员</a> <a href="?action=Add&id=<%#Eval("id") %>" class="icon-edit" title="编辑"></a> <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>' OnClick="Unnamed1_Click" runat="server" title="删除" CssClass="icon-del"></asp:LinkButton></td>
  </tr></ItemTemplate>
  </asp:repeater>

        <tr>
            <td></td>
            <td colspan="3" class="align-right">
                <asp:literal id="txtpage" runat="server"></asp:literal>
            </td>
        </tr>
    </table>
    <% }
        else if (action == "Add")
        { %>
    <table class="comm-table">
        <tr>
            <th width="21%">
                <asp:literal id="Literal1" runat="server" text="添加会员组"></asp:literal>
            </th>
            <th class="align-right" width="79%"></th>
        </tr>
        <tr>
            <td class="align-right">会员组名称：</td>
            <td>
                <asp:textbox id="txtGroupName" runat="server" cssclass="input-control required" maxlength="50"></asp:textbox>
            </td>
        </tr>

        <tr>
            <td class="align-right">是否允许注册：</td>
            <td>
                <asp:radiobuttonlist id="txtShowOnReg" runat="server" repeatcolumns="2" cssclass="aspx-table">
          <asp:ListItem Value="0" Selected="True">允许</asp:ListItem>
          <asp:ListItem Value="1">不允许</asp:ListItem>
          </asp:radiobuttonlist>
            </td>

        </tr>
        <tr>
            <td class="align-right">权限列表：</td>
            <td>
                <asp:checkboxlist id="PowerList" runat="server" repeatcolumns="4" cssclass="aspx-table">
        <asp:ListItem Value="0">权限一</asp:ListItem>
        <asp:ListItem Value="1">权限二</asp:ListItem>
        <asp:ListItem Value="2">权限三</asp:ListItem>
          </asp:checkboxlist>
            </td>

        </tr>
        <tr>
            <td class="align-right">会员组说明：</td>
            <td>
                <asp:textbox id="txtDescript" runat="server" cssclass="textarea input-control required" textmode="MultiLine" maxlength="300"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td class="align-right">&nbsp;</td>
            <td>
                <asp:button id="Button3" runat="server" text="确认添加"
                    cssclass="btn" onclick="Button3_Click" />
            </td>
        </tr>
    </table>
    <% } %>
</asp:Content>

