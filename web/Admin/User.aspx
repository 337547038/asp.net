<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="Admin_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/jsAddress.js"></script>
    <style type="text/css">
        .company {
            display: none;
        }
    </style>
    <script type="text/javascript">
        $(function () {
           
        });
        
    </script>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <%if (action == "show")
            { %>
        <div class="com-div top-search">
            <span class="label">快速查看：</span><asp:DropDownList ID="ddlUserGroup" runat="server" CssClass="select-control input-control">
            </asp:DropDownList>
            <asp:TextBox ID="txtkeywords" runat="server" CssClass="input-control" Text="请输入关键字"
                onFocus="this.value=''">
            </asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server"
                Text="查看" CssClass="btn" OnClick="Button1_Click" />
        </div>
        <table class="comm-table">
            <tr>
                <th width="7%" class="align-center">编号
                </th>
                <th class="align-center">用户名
                </th>
                <th class="align-center">所属用户组
                </th>
                <th class="align-center">最后登录时间
                </th>
                <th class="align-center">最后登录IP
                </th>
                <th class="align-center">登录次数
                </th>
                <th class="align-center">状态
                </th>
                <th class="align-center">操作
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <itemtemplate>
                <tr>
                    <td class="align-center">
                        <input type="checkbox" name="checkbox" value="<%#Eval("id") %>" />
                    </td>
                    <td class="align-center">
                        <img src="images/doc0.gif" alt=""/><%#Eval("UserName")%>
                    </td>
                    <td class="align-center">
                        <%#GetUserGroup(Eval("GroupID").ToString())%>
                    </td>
                    <td class="align-center">
                        <%#GL.Utility.BasePage.formatDateTime(Eval("LastLoginTime").ToString())%>
                    </td>
                    <td class="align-center">
                        <%#Eval("LastLoginIP")%>
                    </td>
                    <td class="align-center">
                        <%#Eval("LoginTimes")%>
                    </td>
                    <td class="align-center">
                        <%#Eval("Locked").ToString()=="0"?"正常":"锁定"%>
                    </td>
                    <td class="align-center link-margin">
                        <a href="?action=Add&id=<%#Eval("id") %>" class="icon-edit" title="编辑"></a>
                        <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed1_Click" runat="server" CssClass="icon-del" title="删除"></asp:LinkButton>
                    </td>
                </tr>
            </itemtemplate>
            </asp:Repeater>

            <tr>
                <td colspan="2">
                    <input name="allcheck" id="allcheck" type="checkbox" />全选
                <asp:Button ID="Button2" runat="server" Text="删除" CssClass="btn" OnClick="Button2_Click" />
                </td>
                <td colspan="6" class="align-right">

                    <asp:Literal ID="txtpage" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <% }
            else if (action == "Add")
            { %>
        <script type="text/javascript">
            $(function () {
                //头像
                kindeditUploadImg("#uploadFace", "#ctl00_ContentPlaceHolder1_txtface",false, function (url) {
                    $(".txtface").attr("src", url);
                });
                $(".radio-control input").click(function () {
                    if ($(this).val() == 0) {
                        $(".txtface").attr("src", "../Images/man.jpg");
                        $("#ctl00_ContentPlaceHolder1_txtface").val("../Images/man.jpg");
                    } else {
                        $(".txtface").attr("src", "../Images/woman.jpg");
                        $("#ctl00_ContentPlaceHolder1_txtface").val("../Images/woman.jpg");
                    } 
                });
                //kindeditUploadImg("#uploadLogo", "#ctl00_ContentPlaceHolder1_txtlogo", false);
                //kindeditUploadImg("#uploadBrandLogo", "#ctl00_ContentPlaceHolder1_txtBrandLogo", false);
                //kindeditUploadImg("#uploadBL", "#ctl00_ContentPlaceHolder1_txtBusinessLicense", false);
            });
        </script>
        <table class="comm-table">
            <tr>
                <th colspan="2">
                    <asp:Literal ID="Literal1" runat="server" Text="添加新用户"></asp:Literal>
                </th>

            </tr>
            <tr>
                <td class="align-right">用户组：
                </td>
                <td>
                    <asp:DropDownList ID="ddlGroupID" runat="server" CssClass="input-control select-control select-user-group">
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td class="align-right w150">*用户名称：
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="input-control required" MaxLength="50" placeholder=""></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="align-right">用户密码：
                </td>
                <td>
                    <asp:TextBox ID="txtPassWord" runat="server" CssClass="input-control" TextMode="Password" MaxLength="50"></asp:TextBox>
                    <span class="input-tips"><asp:Literal ID="Literal2" runat="server"></asp:Literal></span>
                </td>
            </tr>
            <tr>
                <td class="align-right">用户状态：
                </td>
                <td>
                    <asp:RadioButtonList ID="txtLocked" runat="server" RepeatColumns="3" CssClass="aspx-table">
                        <asp:ListItem Value="0" Selected="True">正常</asp:ListItem>
                        <asp:ListItem Value="1">锁定</asp:ListItem>
                        <asp:ListItem Value="2">待审核</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td class="align-right">电子邮箱：
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input-control email" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">手机：
                </td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" CssClass="input-control digits" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">微信：
                </td>
                <td>
                    <asp:TextBox ID="txtWenXin" runat="server" CssClass="input-control digits" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">QQ：
                </td>
                <td>
                    <asp:TextBox ID="txtQQ" runat="server" CssClass="input-control digits" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">城市：
                </td>
                <td>
                    <select id="ddlProvince" name="ddlProvince" class="input-control select-control auto-width"></select>
                    <select id="ddlCity" name="ddlCity" class="input-control select-control auto-width"></select>
                    <select id="ddlArea" name="ddlArea" class="input-control select-control auto-width"></select>
                </td>
            </tr>
            <tr>
                <td class="align-right">详细地址：
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="align-right">公司名称：
                </td>
                <td>
                    <asp:TextBox ID="txtCompany" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">性别：
                </td>
                <td>
                    <asp:RadioButtonList ID="txtSex" runat="server" RepeatColumns="2" CssClass="aspx-table radio-control">
                        <asp:ListItem Value="0" Selected="True">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="align-right">头像：
                </td>
                <td>
                    <img src="../Images/man.jpg" width="50" height="50" class="txtface"/>
                   <asp:HiddenField ID="txtface" runat="server" />
                    <input type="button" id="uploadFace" value="上传头像2" class="btn btn-small" />
                </td>
            </tr>
            <tr>
                <td class="align-right">注册来源：
                </td>
                <td>
                    <asp:TextBox ID="txtSource" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">注册时间：
                </td>
                <td>
                    <asp:Literal ID="txtregDate" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="align-right">最后登录：
                </td>
                <td>
                    <asp:Literal ID="txtlastLoginTime" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="align-right">最后登录IP：
                </td>
                <td>
                    <asp:Literal ID="txtlastLoginIP" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="align-right">登录次数：
                </td>
                <td>
                    <asp:Literal ID="txtloginTimes" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="确认添加" CssClass="btn" OnClick="Button4_Click" />
                </td>

            </tr>

        </table>
        <script type="text/javascript">
            addressInit('ddlProvince', 'ddlCity', 'ddlArea', '<%=ddlp %>', '<%=ddlc %>', '<%=ddla %>');
        </script>
    <% } %>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>

