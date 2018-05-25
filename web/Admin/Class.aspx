<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Class.aspx.cs" Inherits="Admin_Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        kindeditUploadImg("#image3", "#ctl00_ContentPlaceHolder1_txtClassPic");
        $(function () {

            ///折叠展开
            $(".control .a").click(function () {
                var cl = $(this).parent().attr("class");
                var cl2 = cl.split(" ")[1];
                $(this).parent("tr").nextAll("."+cl2).toggleClass("hide");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (String.IsNullOrEmpty(ac))
        {%>
    <div class="com-div">
        <div class="morelanguage" style="padding: 5px 10px; overflow: hidden">
            <asp:dropdownlist
                id="DrLanguage" runat="server" autopostback="True" onselectedindexchanged="DrLanguage_SelectedIndexChanged" cssclass="input-control select-control">
            <asp:ListItem Value="">按语言查看</asp:ListItem>
            <asp:ListItem Value="0">中文</asp:ListItem>
            <asp:ListItem Value="1">英文</asp:ListItem>
        </asp:dropdownlist>
        </div>
    </div>

    <table class="comm-table">
        <tr>
            <th width="1%" class="align-center"></th>
            <th class="align-center">栏目名称
            </th>
            <th class="align-center">优先级别
            </th>
            <th class="align-center">管理选项
            </th>
        </tr>
        <asp:repeater id="Repeater1" runat="server">
            <ItemTemplate>
                <tr class="<%#getClass(Eval("ParentId").ToString(),Eval("id").ToString())%>">
                    <td class="align-center a">
                        <%#GetPic0(Eval("ClassLayer").ToString())%>
                    </td>
                    <td>
                        <%#GetPic(Eval("ClassLayer").ToString())%><%#Eval("ClassName")%><%#Eval("ClassType").ToString() == "1" ? "(外)" : ""%>
                    </td>
                    <td class="align-center">
                        <%#Eval("Px")%>
                    </td>
                    <td class="align-center link-margin">
                        <%if (GetPower("ca"))
                            {%><%#GetChildernAdd(Eval("ClassType").ToString(), Eval("id").ToString(), Eval("Languagen").ToString(), Eval("ClassLayer").ToString())%>
                        <%} %>
                        <%if (GetPower("ce"))
                            {%><a href="?ac=add&mid=<%=mid%>&id=<%#Eval("id") %>" class="icon-edit" title="编辑"></a><%} %>
                        <%if (GetPower("cd"))
                            {%><asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>'
                              OnClick="Unnamed1_Click" runat="server" CssClass="icon-del" title="删除"></asp:LinkButton><%} %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:repeater>
    </table>
    <%}
        else if (ac == "add")
        {%>
    <div class="com-div com-tab tab">
            <ul class="clearfix">
                <li class="active">基本信息</li>
                <%if (getmodelclass("9"))
                    { %><li class="seonone">SEO选项</li>
                <%} %>
                <%if (getmodelclass("8"))
                    { %><li>自设选项</li>
                <%} %>
            </ul>
    </div>
    <div class="tab-content">
        <div class="tab-pane active">
            <table class="comm-table">
                <tr class="morelanguage">
                    <td class="align-right">语言：
                    </td>
                    <td>
                        <asp:dropdownlist id="DropDownList1" runat="server" cssclass="input-control select-control">
                                        <asp:ListItem Value="0" Selected="True">中文</asp:ListItem>
                                        <asp:ListItem Value="1">英文</asp:ListItem>
                                    </asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td class="align-right w150">所属栏目：
                    </td>
                    <td>
                        <asp:literal id="txtTid" runat="server"></asp:literal>
                    </td>
                </tr>
                <tr>
                    <td class="align-right">栏目名称：
                    </td>
                    <td>
                        <asp:textbox id="txtClassName" runat="server" cssclass="input-control required" maxlength="50"></asp:textbox>
                    </td>
                </tr>
                <%if (getmodelclass("0"))
                    { %>
                <tr>
                    <td class="align-right">优先级别：
                    </td>
                    <td>
                        <asp:textbox id="txtPx" runat="server" cssclass="input-control required" text="0"
                            maxlength="50"></asp:textbox>
                    </td>
                </tr>
                <%}
                    if (getmodelclass("1"))
                    { %>
                <tr>
                    <td class="align-right">是否隐藏：
                    </td>
                    <td>
                        <asp:radiobuttonlist id="txtHide" runat="server" repeatcolumns="2" cssclass="aspx-table">
                                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:radiobuttonlist>
                    </td>
                </tr>
                 <%}
                    if (getmodelclass("2"))
                    { %>
                <tr>
                    <td class="align-right">允许评论：
                    </td>
                    <td>
                        <asp:radiobuttonlist id="rallowcomment" runat="server" repeatcolumns="2" cssclass="aspx-table">
                                        <asp:ListItem Value="1">允许</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">不允许</asp:ListItem>
                                    </asp:radiobuttonlist>
                    </td>
                </tr>
                <%}
                    if (getmodelclass("3"))
                    { %>
                <tr>
                    <td class="align-right">是否允许录入：
                    </td>
                    <td>
                        <asp:radiobuttonlist id="rinputa" runat="server" repeatcolumns="2" cssclass="aspx-table">
                                        <asp:ListItem Value="0" Selected="True">允许</asp:ListItem>
                                        <asp:ListItem Value="1">不允许</asp:ListItem>
                                    </asp:radiobuttonlist>
                    </td>
                </tr>
                <%}
                    if (getmodelclass("4"))
                    { %>
                <tr>
                    <td class="align-right">会员投稿：
                    </td>
                    <td>
                        <asp:radiobuttonlist id="rinputuser" runat="server" repeatcolumns="2" cssclass="aspx-table">
                                        <asp:ListItem Value="1">允许</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">不允许</asp:ListItem>
                                    </asp:radiobuttonlist>
                    </td>
                </tr>
                <%}
                    if (getmodelclass("5"))
                    { %>
                <tr>
                    <td class="align-right">栏目图片：
                    </td>
                    <td>
                        <asp:textbox id="txtClassPic" runat="server" cssclass="input-control" maxlength="50"></asp:textbox>
                        &nbsp;<input
                            type="button" id="image3" value="上传图片" class="btn btn-small" />
                    </td>
                </tr>
                
                <%}
                    if (getmodelclass("7"))
                    { %>
                <tr>
                    <td class="align-right">栏目简介：
                    </td>
                    <td class="align-left tdpadding">
                        <asp:textbox id="txtClassIntro" runat="server" textmode="MultiLine" cssclass="textarea input-control"></asp:textbox>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td></td>
                    <td class="align-left tdpadding">
                        <asp:button id="Button1" runat="server" text="添加新栏目" cssclass="btn" onclick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="tab-pane">
            <!--seo选项-->
            <%if (getmodelclass("9"))
                { %>
            <table class="comm-table">
                <tr>
                    <td class="align-right w150">SEO标题：
                    </td>
                    <td>
                        <asp:textbox id="txtseotitle" runat="server" cssclass="input-control required" maxlength="150"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="align-right">SEO关键词：
                    </td>
                    <td class="align-left tdpadding">
                        <asp:textbox id="txtKeyWord" runat="server" cssclass="textarea input-control required" textmode="MultiLine"
                            maxlength="150"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="align-right">SEO描述：
                    </td>
                    <td class="align-left tdpadding">
                        <asp:textbox id="txtDescription" runat="server" cssclass="textarea input-control required"
                            textmode="MultiLine" maxlength="300"></asp:textbox>
                    </td>
                </tr>
            </table>
            <%} %>
        </div>
        <div class="tab-pane">
            <!--自设选项 -->
            <%if (getmodelclass("8"))
                { %>
            <table class="comm-table">
                <tr>
                    <td class="align-right w150">自设内容1：
                    </td>
                    <td class="align-left tdpadding">
                        <asp:textbox id="txtcon1" runat="server" cssclass="textarea input-control" textmode="MultiLine"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="align-right">自设内容2：
                    </td>
                    <td class="align-left tdpadding">
                        <asp:textbox id="txtcon2" runat="server" cssclass="textarea input-control" textmode="MultiLine"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="align-right">自设内容3：
                    </td>
                    <td class="align-left tdpadding">
                        <asp:textbox id="txtcon3" runat="server" cssclass="textarea input-control" textmode="MultiLine"></asp:textbox>
                    </td>
                </tr>
            </table>
            <%} %>
        </div>
    </div>
    <%} %>
</asp:Content>

