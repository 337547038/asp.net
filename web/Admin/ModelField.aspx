<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ModelField.aspx.cs" Inherits="Admin_ModelField" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (String.IsNullOrEmpty(ac))
      {%>
<table class="comm-table">
  <tr>
    <th width="7%" class="align-center">编号</th>
    <th class="align-center">字段名称</th>
    <th class="align-center">字段别名</th>
    <th class="align-center">字段类型</th>
    <th class="align-center">允许为空</th>
    <th class="align-center">优先级别</th>
    <th class="align-center">是否启用</th>
    <th class="align-center">操作</th>
  </tr>
    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
  <tr>
    <td class="align-center"><input type="checkbox" name="checkbox" value="<%#Eval("id") %>" /></td>
    <td class="align-center"><img src="images/doc0.gif" alt=""/><%#Eval("FieldName")%></td>
    <td class="align-center"><%#Eval("FieldName2")%></td>
    <td class="align-center"><%#Eval("FieldType").ToString()=="0"?"文本":"数值"%></td>
    <td class="align-center"><%#Eval("FieldIsNull").ToString() == "1" ? "否" : "是"%></td>
    <td class="align-center"><%#Eval("FieldPx")%></td>
    <td class="align-center"><%#Eval("FieldOnOff").ToString()=="0"?"启用":"禁用"%></td>
    <td class="align-center link-margin"><a href="?ac=add&mid=<%#Eval("Modeid") %>&id=<%#Eval("id") %>" title="编辑" class="icon-edit"></a> <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>' OnClick="Unnamed1_Click" runat="server" CssClass="icon-del" title="删除"></asp:LinkButton></td>
  </tr></ItemTemplate>
  </asp:Repeater>

  <tr>
  <td colspan="8" class="align-right"><asp:Literal ID="txtpage" runat="server"></asp:Literal></td>
  </tr>
</table><%}
      else if (ac == "add")
      {%>
      <table class="comm-table">
      <tr>
        <th width="21%">添加模型字段</th>
        <th class="align-right" width="79%"></th>
      </tr>
      <tr>
        <td class="align-right">字段名称：</td>
        <td><asp:TextBox ID="txtFieldName" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox> 在数据库中显示的字段名,不可修改,如Title</td>
      </tr>
      <tr>
        <td class="align-right">字段别名：</td>
        <td><asp:TextBox ID="txtFieldName2" runat="server" CssClass="input-control required"  MaxLength="50"></asp:TextBox> 用于显示的提示名称，如标题</td>
      </tr>
      <tr>
        <td class="align-right">字段类型：</td>
        <td>
        <asp:DropDownList ID="txtFieldType" runat="server" CssClass="required input-control select-control">
        <asp:ListItem Value="">请选择类型</asp:ListItem>
        <asp:ListItem Value="0">文本</asp:ListItem>
        <asp:ListItem Value="1">数值</asp:ListItem>
        <asp:ListItem Value="2">下拉</asp:ListItem>
        <asp:ListItem Value="3">时间</asp:ListItem>
          </asp:DropDownList></td>
          
      </tr>
      <tr>
        <td class="align-right">是否允许为空</td>
        <td><asp:RadioButton ID="txtFieldIsNully" runat="server" Text="是" GroupName="yn" Checked="true"/><asp:RadioButton ID="txtFieldIsNulln" runat="server" Text="否" GroupName="yn"/></td>
          
      </tr>
      <tr>
        <td class="align-right">是否启用：</td>
        <td><asp:RadioButton ID="txtFieldOnOffy" runat="server" Text="是" GroupName="onoff" Checked="true"/><asp:RadioButton ID="txtFieldOnOffn" runat="server" Text="否" GroupName="onoff"/></td>
      </tr>
      <tr>
        <td class="align-right">优先级别：</td>
        <td><asp:TextBox ID="txtFieldPx" runat="server" CssClass="input-control digits required" Text="0" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">字段说明：</td>
        <td><asp:TextBox ID="txtFieldIntro" runat="server" CssClass="input-control"  MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">默认/下拉值：</td>
        <td><asp:TextBox ID="txtvalue" runat="server" CssClass="input-control"  MaxLength="50"></asp:TextBox> 为下拉时，多个下拉英文豆号,隔开，字段与值为竖线｜隔开</td>
      </tr>
      <tr>
     <td class="align-right">&nbsp;</td>
        <td><asp:Button ID="Button1" runat="server" Text="确认添加" 
                CssClass="btn" onclick="Button1_Click" /></td>
      </tr>
    </table>
<%} %>
</asp:Content>

