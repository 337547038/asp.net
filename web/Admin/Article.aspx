<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="Admin_Article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function() {
            var allid = "";
            $(".submit2").click(function() {
                $("input[name=checkbox]:checkbox:checked").each(function() {
                    if (allid == "") {
                        allid = $(this).val();
                    }
                    else {
                        allid += "," + $(this).val();
                    }
                });
                if (allid == "") { alert("请选择要处理的选项"); } else {
                    $("#forall").show();
                    $("html,body").animate({ scrollTop: $("#forall").offset().top }, 1000);
                    $(".articleid").val(allid);
                    allid = "";
                }
            });
            $("#allcolse").click(function() {
                $("#forall").hide();
                allid = "";
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="com-div top-search">
        <span class="label">快速查看：</span>
        <span class="morelanguage">
            <asp:DropDownList ID="DrLanguage" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="DrLanguage_SelectedIndexChanged"
                    CssClass="input-control select-control auto-width">
                    <asp:ListItem Value="">按语言查看</asp:ListItem>
                    <asp:ListItem Value="0">中文</asp:ListItem>
                    <asp:ListItem Value="1">英文</asp:ListItem>
                </asp:DropDownList>
                </span>
        <asp:DropDownList ID="ddlclassname" runat="server" AutoPostBack="True" CssClass="input-control select-control auto-width"
                    OnSelectedIndexChanged="ddlclassname_SelectedIndexChanged">
                </asp:DropDownList>
        <%if (sxddl)
                  { %>
                <asp:DropDownList ID="ddlshuxi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlshuxi_SelectedIndexChanged"
                    CssClass="input-control select-control auto-width">
                </asp:DropDownList>
                <%} %>
        <asp:TextBox ID="txtkeywords" runat="server" CssClass="input-control" Text="请输入关键字"
                    onFocus="this.value=''" MaxLength="50"></asp:TextBox>&nbsp;<asp:Button ID="Button1"
                        runat="server" Text="查看" CssClass="btn" OnClick="Button1_Click" />
    </div>
    <%--<table class="comm-table">
        <tr>
            <td>
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <a href="?mid=<%=mid %>&tid=<%#Eval("id") %>" class="sfolder">
                            <%#Eval("ClassName") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <th id="actxt" runat="server"></th>
        </tr>
    </table>--%>
    <table class="comm-table">
        <tr>
            <th class="align-center" style="width:10px">
            </th>
            <th class="align-center">
                <%=ItemName%>标题
            </th>
            <%if (showhidelist("0"))
              { %><th class="align-center">
                  录入
              </th>
            <%} if (showhidelist("1"))
              { %>
            <th class="align-center">
                作者
            </th>
            <%} if (showhidelist("2"))
              {%>
            <th class="align-center">
                来源
            </th>
            <%} if (showhidelist("3"))
              { %>
            <th class="align-center">
                添加时间
            </th>
            <%} if (showhidelist("4"))
              {%>
            <th class="align-center">
                修改日期
            </th>
            <%} if (showhidelist("5"))
              {%>
            <th class="align-center">
                属性
            </th>
            <%} if (showhidelist("6"))
              { %>
            <th class="align-center">
                点击
            </th>
            <%} if (showhidelist("7"))
              {%>
            <th class="align-center">
                排序
            </th>
            <%} %>
            <th class="align-center">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="align-center">
                        <input name="checkbox" type="checkbox" value="<%#Eval("id")%>" />
                    </td>
                    <td>
                        <%#GetClassName(Eval("PicUrl").ToString(), Eval("Tid").ToString())%><span title="<%#Eval("Title")%>"
                            style="color: <%#Eval("TitleColor")%>"><%#Eval("Title")%></span>
                    </td>
                    <%if (showhidelist("0"))
                      { %>
                    <td class="align-center">
                        <%#Eval("Owner")%>
                    </td>
                    <%} if (showhidelist("1"))
                      { %>
                    <td class="align-center">
                        <%#Eval("Author")%>
                    </td>
                    <%} if (showhidelist("2"))
                      { %>
                    <td class="align-center">
                        <%#Eval("Origin")%>
                    </td>
                    <%} if (showhidelist("3"))
                      { %>
                    <td class="align-center">
                         <%#GL.Utility.BasePage.formatDateTime(Eval("AddDate").ToString())%>
                    </td>
                    <%} if (showhidelist("4"))
                      { %>
                    <td class="align-center">
                        <%#GL.Utility.BasePage.formatDateTime(Eval("EditDate").ToString())%>
                    </td>
                    <%} if (showhidelist("5"))
                      {%>
                    <td class="align-center">
                        <%#Eval("IsRecommend").ToString() == "1" ? "荐" : ""%>
                        <%#Eval("IsPopular").ToString() == "1" ? "热" : ""%>
                        <%#Eval("IsNew").ToString() == "1" ? "新" : ""%>
                    </td>
                    <%} if (showhidelist("6"))
                      { %>
                    <td class="align-center">
                        <%#Eval("Hits")%>
                    </td>
                    <%} if (showhidelist("7"))
                      { %>
                    <td class="align-center">
                        <%#Eval("Px")%>
                    </td>
                    <%} %>
                    <td class="align-center link-margin">
                        <a href="ArticleAdd.aspx?mid=<%=mid %>&id=<%#Eval("id") %>" class="icon-edit" title="编辑"></a>
                        <% if (ac == "del" && del)
                           {%>
                        <asp:LinkButton ID="LinkButton1" OnClientClick="return confirm('确定还原吗？')" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed3_Click" runat="server">还原</asp:LinkButton>
                        <asp:LinkButton ID="lbtdel2" OnClientClick="return confirm('确定彻底删除吗？')" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed2_Click" runat="server" CssClass="icon-del" title="彻底删除"></asp:LinkButton><%}
                           else if (del)
                           {%>
                        <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed1_Click" runat="server" CssClass="icon-del" title="回收站"></asp:LinkButton>
                        <%} %>
                        
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="2">
                <input name="allcheck" id="allcheck" type="checkbox" />全选
                <span class="btn btn-small submit2">批量处理</span>
                <%if (ac == "sh")
                  {%>
                <asp:Button ID="Button2" runat="server" Text="审核通过" CssClass="btn" OnClick="Button2_Click1" /><%} %>
            </td>
            <td colspan="9" class="align-right">
                <asp:Literal ID="txtpage" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <div id="forall" class="hide">
        <table class="comm-table">
            <tr>
                <td class="align-right w200">
                    要处理的<%=ItemName%>ID
                </td>
                <td>
                    <asp:TextBox ID="articleid" runat="server" CssClass="input-control articleid"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">
                    <input type="radio" name="radiobutton" value="1" />
                    移动到栏目
                </td>
                <td>
                    <asp:DropDownList ID="ddlclassforall" runat="server" CssClass="input-control select-control">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="align-right">
                    <input type="radio" name="radiobutton" value="2" />
                    属性
                </td>
                <td>
                    <asp:DropDownList ID="ddlsx" runat="server" CssClass="input-control select-control">
                        <asp:ListItem Value="0">设为热门</asp:ListItem>
                        <asp:ListItem Value="1">取消热门</asp:ListItem>
                        <asp:ListItem Value="2">设为推荐</asp:ListItem>
                        <asp:ListItem Value="3">取消推荐</asp:ListItem>
                        <asp:ListItem Value="4">设为最新</asp:ListItem>
                        <asp:ListItem Value="5">取消最新</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="align-right">
                    删除
                </td>
                <td>
                    <input type="radio" name="radiobutton" value="3" />
                    放入回收站<input type="radio" name="radiobutton" value="8" />
                    彻底删除
                </td>
            </tr>
            <tr>
                <td class="align-right">
                    <input type="radio" name="radiobutton" value="4" />
                    作者
                </td>
                <td>
                    <asp:TextBox ID="txtAuthor" runat="server" CssClass="input-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">
                    <input type="radio" name="radiobutton" value="5" />
                    来源
                </td>
                <td>
                    <asp:TextBox ID="txtOrigin" runat="server" CssClass="input-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">
                    <input type="radio" name="radiobutton" value="6" />
                    浏览次数
                </td>
                <td>
                    <asp:TextBox ID="txthits" runat="server" CssClass="input-control digits" Text="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">
                    <input type="radio" name="radiobutton" value="7" />
                    修改时间
                </td>
                <td>
                    <asp:TextBox ID="txteditdata" runat="server" CssClass="input-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="批量处理" CssClass="btn" OnClick="Button3_Click" />
                    <span id="allcolse" style="cursor: pointer">关闭</span>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

