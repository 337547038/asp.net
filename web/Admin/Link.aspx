<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Link.aspx.cs" Inherits="Admin_Link" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $(".hideshow").hide();
            $(".link-type input").click(function () {
                var v = $(".link-type input:checked").val();
                if (v == 1) {
                    $(".hideshow").css("display", "");
                }
                else {
                    $(".hideshow").css("display", "none");
                }
            });
            kindeditUploadImg('#uploadImage', '#ctl00_ContentPlaceHolder1_txtClassPic');
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (action == "show")
        { %>
    <div class="com-div top-search">

        <span class="label">快速查看：</span><asp:dropdownlist id="ddlclassname" runat="server" cssclass="select-control input-control">
                    <asp:ListItem Value="">选择所有</asp:ListItem>
                    <asp:ListItem Value="0">文字链接</asp:ListItem>
                    <asp:ListItem Value="1">图片链接</asp:ListItem>
                </asp:dropdownlist>
        <asp:textbox id="txtkeywords" runat="server" cssclass="input-control" text="请输入关键字"
            onfocus="this.value=''"></asp:textbox>
        &nbsp;<asp:button id="Button1" runat="server"
            text="查看" cssclass="btn" onclick="Button1_Click" />
    </div>
    <table class="comm-table">
        <tr>
            <th width="7%" class="align-center">编号
            </th>
            <th class="align-center">链接名称
            </th>
            <th class="align-center">链接地址
            </th>
            <th class="align-center">类型
            </th>
            <th class="align-center">显示
            </th>
            <th class="align-center">优先等级
            </th>
            <th class="align-center">点击次数
            </th>
            <th class="align-center">操作
            </th>
        </tr>
        <asp:repeater id="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <input type="checkbox" name="checkbox" value="<%#Eval("id") %>" />
                    </td>
                    <td>
                        <img src="images/doc0.gif" /><%#Eval("LinkName")%>
                    </td>
                    <td class="align-center">
                        <a href="<%#Eval("LinkUrl")%>" target="_blank">
                            <%#Eval("LinkUrl")%></a>
                    </td>
                    <td class="align-center">
                        <%#Eval("LinkType").ToString()=="0"?"文字":"图片"%>
                    </td>
                    <td class="align-center">
                        <%#Eval("Hide").ToString()=="0"?"显示":"隐藏"%>
                    </td>
                    <td class="align-center">
                        <%#Eval("Px")%>
                    </td>
                    <td class="align-center">
                        <%#Eval("Hits")%>
                    </td>
                    <td class="align-center link-margin">
                        <a href="?action=Add&id=<%#Eval("id") %>" class="icon-edit" title="编辑"></a>
                        <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed1_Click" runat="server" CssClass="icon-del" title="删除"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:repeater>
        <tr>
            <td colspan="2">
                <input name="allcheck" id="allcheck" type="checkbox" />全选
                <asp:button id="Button2" runat="server" text="删除" cssclass="btn btn-small" onclick="Button2_Click" />
            </td>
            <td colspan="6" class="align-right">
                <asp:literal id="txtpage" runat="server"></asp:literal>
            </td>
        </tr>
    </table>
    <% }
        else if (action == "Add")
        { %>
    <table class="comm-table">
        <tr>
            <th class="w150">
                <asp:literal id="Literal1" runat="server" text="添加友情链接"></asp:literal>
            </th>
            <th class="align-right showhide"></th>
        </tr>
        <tr>
            <td class="align-right">链接名称：
            </td>
            <td>
                <asp:textbox id="txtName" runat="server" cssclass="input-control required" maxlength="50"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td class="align-right">链接地址：
            </td>
            <td>
                <asp:textbox id="txtUrl" runat="server" cssclass="input-control required url" maxlength="50"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td class="align-right">是否显示：
            </td>
            <td>
                <asp:radiobuttonlist id="txthide" runat="server" repeatcolumns="2" cssclass="aspx-table">
                    <asp:ListItem Value="0" Selected="True">显示</asp:ListItem>
                    <asp:ListItem Value="1">隐藏</asp:ListItem>
                </asp:radiobuttonlist>
            </td>
        </tr>
        <tr>
            <td class="align-right">链接类型：
            </td>
            <td>
                <asp:radiobuttonlist id="txtTypelink" runat="server" repeatcolumns="2" cssclass="aspx-table link-type">
                    <asp:ListItem Value="0" Selected="True">文字</asp:ListItem>
                    <asp:ListItem Value="1">图片</asp:ListItem>
                </asp:radiobuttonlist>
            </td>
        </tr>
        <tr class="hideshow">
            <td class="align-right">Logo地址：
            </td>
            <td>
                <asp:textbox id="txtClassPic" runat="server" cssclass="input-control required" maxlength="50"></asp:textbox>
                <input type="button" id="uploadImage" value="选择图片" class="btn btn-small" />
            </td>
        </tr>
        <tr>
            <td class="align-right">优先等级：
            </td>
            <td>
                <asp:textbox id="txtpx" runat="server" cssclass="input-control digits required" text="0"
                    maxlength="50"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td class="align-right">点击次数：
            </td>
            <td>
                <asp:textbox id="txthits" runat="server" cssclass="input-control digits required" text="0"
                    maxlength="50"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td class="align-right">备注说明：
            </td>
            <td>
                <asp:textbox id="txtIntro" runat="server" cssclass="textarea input-control" textmode="MultiLine"
                    maxlength="150"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td class="align-right">&nbsp;
                
            </td>
            <td>
                <asp:button id="Button3" runat="server" text="确认添加" cssclass="btn" onclick="Button3_Click" />
            </td>
        </tr>
    </table>
    <% } %>
</asp:Content>

