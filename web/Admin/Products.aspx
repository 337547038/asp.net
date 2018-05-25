<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Admin_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .showpic{position:relative}
        .comm-table .titlepic{position:absolute;left:0;top:30px;z-index:50;max-width:400px; display:none}
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            var allid = "";
            $(".submit2").click(function () {
                $("input[name=checkbox]:checkbox:checked").each(function () {
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
                    $("#articleid").val(allid);
                    allid = "";
                }
            });
            $("#allcolse").click(function () {
                $("#forall").hide();
                allid = "";
            });

            //鼠标经过标题时，显示图片
            $(".showpic").hover(function () {
                $(this).children(".titlepic").show();
            }, function () {
                $(this).children(".titlepic").hide();
            })
            //按公司查看
            $(".select-company").click(function () {
                $.layer({ contents: "layer/iframe.aspx?ac=company", popType: 3, width: 400 });
            });

        });
        //由框架页触发,按公司查看
        function chooseCompany(value, key) {
            $(".select-company").val(value);
            $("#ctl00_ContentPlaceHolder1_txtCompanyId").val(key);
            layer.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        <asp:DropDownList ID="ddlclassname" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclassname_SelectedIndexChanged"
            CssClass="input-control select-control auto-width">
        </asp:DropDownList>
        <%if (sxddl)
            { %>
        <asp:DropDownList ID="ddlshuxi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlshuxi_SelectedIndexChanged"
            CssClass="input-control select-control auto-width">
        </asp:DropDownList>
        <%} %>
        <asp:TextBox ID="txtCompany" runat="server" CssClass="input-control select-company" placeholder="按公司查看" MaxLength="50"></asp:TextBox>
        <asp:HiddenField ID="txtCompanyId" runat="server" />
        <asp:TextBox ID="txtkeywords" runat="server" CssClass="input-control" Text="请输入关键字"
            onFocus="this.value=''" MaxLength="50"></asp:TextBox>&nbsp;<asp:Button ID="Button1"
                runat="server" Text="查看" CssClass="btn" OnClick="Button1_Click" />
    </div>

    <table class="comm-table">
        <tr>
            <th style="width:10px"></th>
            <th class="align-center">
                <%=ItemName%>标题
            </th>
            <%if (showhidelist("0"))
                { %>
            <th class="align-center">录入
            </th>
            <%}
              if (showhidelist("3"))
              { %>
            <th class="align-center">添加日期
            </th>
            <%}
              if (showhidelist("4"))
              { %>
            <th class="align-center">修改日期
            </th>
            <%}
              if (showhidelist("5"))
              { %>
            <th class="align-center">属性
            </th>
            <%}
              if (showhidelist("6"))
              { %>
            <th class="align-center">点击
            </th>
            <%}
              if (showhidelist("7"))
              { %>
            <th class="align-center">排序
            </th>
            <%} %>
            <th class="align-center">操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="align-center">
                        <input name="checkbox" type="checkbox" value="<%#Eval("id")%>" />
                    </td>
                    <td>
                        <p class="showpic">
                            <%#GetClassName(Eval("PicUrl").ToString(), Eval("Tid").ToString())%><span title="<%#Eval("Title")%>"
                                style="color: <%#Eval("TitleColor")%>"><%#Eval("Title")%></span>
                            <img class="titlepic" src="<%#Eval("PicUrl") %>" alt="" />
                        </p>
                    </td>
                    <%if (showhidelist("0"))
                        { %>
                    <td class="align-center">
                        <%#Eval("Inputer")%>
                    </td>
                    <%}
                        if (showhidelist("3"))
                        { %>
                    <td class="align-center">
                        <%#GL.Utility.BasePage.formatDateTime(Eval("AddDate").ToString())%>
                    </td>
                    <%}
                        if (showhidelist("4"))
                        { %>
                    <td class="align-center">
                        <%#GL.Utility.BasePage.formatDateTime(Eval("EditDate").ToString())%>
                    </td>
                    <%}
                        if (showhidelist("5"))
                        { %>
                    <td class="align-center">
                        <%#Eval("IsRecommend").ToString() == "1" ? "荐" : ""%>
                        <%#Eval("IsPopular").ToString() == "1" ? "热" : ""%>
                        <%#Eval("IsNew").ToString() == "1" ? "新" : ""%>
                        <%#Eval("IsSpecial").ToString() == "1" ? "特" : ""%>
                    </td>
                    <%}
                    if (showhidelist("6"))
                    {%>
                    <td class="align-center">
                        <%#Eval("Hits")%>
                    </td>
                    <%}
                        if (showhidelist("7"))
                        { %>
                    <td class="align-center">
                        <%#Eval("Px")%>
                    </td>
                    <%} %>
                    <td class="align-center link-margin">
                        <a href="ProductsAdd.aspx?mid=<%=mid %>&id=<%#Eval("id") %>" class="icon-edit" title="编辑"></a>
                        <%if (ac == "del" && del)
                            {%>
                        <asp:LinkButton ID="LinkButton1" OnClientClick="return confirm('确定还原吗？')" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed3_Click" runat="server">还原</asp:LinkButton>
                        <asp:LinkButton ID="lbtdel2" OnClientClick="return confirm('确定彻底删除吗？')" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed2_Click" runat="server">彻底删除</asp:LinkButton><%}
                                                                           else if (del)
                                                                           { %><asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("id") %>'
                              OnClick="Unnamed1_Click" runat="server" title="回收站" CssClass="icon-del"></asp:LinkButton><%} %>
                        <asp:LinkButton ID="LinkButton3" CommandArgument='<%# Eval("id") %>'
                            OnClick="Unnamed4_Click" runat="server" CssClass="icon-fresh" title="刷新修改时间"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="2">
                <input name="allcheck" id="allcheck" type="checkbox" />全选
                <span class="submit2 btn btn-small">批量处理</span>
                <%if (ac == "sh")
                    {%>
                <asp:Button ID="Button2" runat="server" Text="审核通过" CssClass="btn" OnClick="Button2_Click1" /><%} %>
            </td>
            <td colspan="7" class="align-right">
                <asp:Literal ID="txtpage" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <div id="forall" class="hide">
        <table class="comm-table">
            <tr class="hide">
                <td class="align-right">要处理的<%=ItemName%>ID
                </td>
                <td>
                    <asp:TextBox ID="articleid" runat="server" CssClass="input-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align-right">
                    <input type="radio" name="radiobutton" value="1" />
                    移动栏目
                </td>
                <td>
                    <asp:DropDownList ID="changclass" runat="server" CssClass="input-control select-control">
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
                        <asp:ListItem Value="0">设为推荐</asp:ListItem>
                        <asp:ListItem Value="1">取消推荐</asp:ListItem>
                        <asp:ListItem Value="2">设为热卖</asp:ListItem>
                        <asp:ListItem Value="3">取消热卖</asp:ListItem>
                        <asp:ListItem Value="4">设为最新</asp:ListItem>
                        <asp:ListItem Value="5">取消最新</asp:ListItem>
                        <asp:ListItem Value="6">设为特价</asp:ListItem>
                        <asp:ListItem Value="7">取肖特价</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="align-right">删除
                </td>
                <td>
                    <input type="radio" name="radiobutton" value="3" />
                    放入回收站
                    <input type="radio" name="radiobutton" value="8" />
                    彻底删除
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
                <td></td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="批量处理" CssClass="btn" OnClick="Button3_Click" />
                    <span id="allcolse">关闭</span>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

