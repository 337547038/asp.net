<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ArticleAdd.aspx.cs" Inherits="Admin_ArticleAdd" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/jquery.colorpicker.js"></script>
    <script type="text/javascript">
        kindeditUploadImg("#image3", "#ctl00_ContentPlaceHolder1_txtPicUrl");
        kindupfile("#insertfile", "#ctl00_ContentPlaceHolder1_filesurl");
        editkind("ctl00$ContentPlaceHolder1$txtcontents");
        editkind("ctl00$ContentPlaceHolder1$txtcontents2");
        editkind("ctl00$ContentPlaceHolder1$txtcontents3");
        $(function () {
            $("#cp1").colorpicker({
                target: $("#ctl00_ContentPlaceHolder1_txtTitle"),
                success: function (o, color) {
                    $("#ctl00_ContentPlaceHolder1_txtTitle").css("color", color);
                    $("#ctl00_ContentPlaceHolder1_txtTitle").attr("value", color);
                }
            });
            
        });
        function imgjcrop(id, w, h) {
            $.layer({ contents: "ImgJcrop.aspx?w=" + w + "&h=" + h + "&id=" + id, popType: 1 });
        }
        //裁切成功，由框架页触发
        function imgJcropsuccess(id, txt) {
            $("." + id).val(txt);
            layer.close();
        }
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="com-div com-tab tab">
        <ul class="clearfix">
            <li class="active">基本信息</li>
            <%if (gethide("20"))
                {%><li>详细描述</li>
            <%} %>
            <%if (gethide("6"))
                {%><li class="seonone">SEO选项</li>
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
                        <asp:DropDownList ID="Drlanguage" CssClass="input-control select-control" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="Drlanguage_SelectedIndexChanged">
                            <asp:ListItem Value="0">中文</asp:ListItem>
                            <asp:ListItem Value="1">英文</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="align-right w150">
                        <%=titletips2(0)%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input-control required" MaxLength="150"></asp:TextBox>&nbsp;<%if (gethide("22"))
                                                                                                                                            { %><img src="images/colorpicker.png" id="cp1" style="cursor: pointer; position: relative; top: 2px"
                                                                                                                                             title="选择颜色" /><asp:HiddenField ID="colortxt" runat="server" />
                       <%} %>
                        <span class="input-tips"><asp:Literal ID="txtTips0" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <%if (gethide("0"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(1)%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtFullTitle" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                       <span class="input-tips"><asp:Literal ID="txtTips11" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <% }
                    if (gethide("19"))
                    {%>
                <tr>
                    <td class="align-right">
                        <%=titletips2(4)%><!--归属栏目-->：
                    </td>
                    <td>
                        <asp:Literal ID="txtLiteral9" runat="server"></asp:Literal>
                        <span class="input-tips"><asp:Literal ID="txtTips1" runat="server"></asp:Literal></span>
                        <%if (gethide("9"))
                            {%><asp:CheckBox ID="txtRecommend" runat="server" /><%=titletips2(7)%>
                        <%}if (gethide("11"))
                                                                                                      { %>
                        <asp:CheckBox ID="txtPopular" runat="server" /><%=titletips2(8)%><%}
                                                                                             if (gethide("12"))
                                                                                             {%>
                        <asp:CheckBox ID="txtNew" runat="server" /><%=titletips2(9)%><%} %>
                        <span class="input-tips"><asp:Literal ID="txtTips2" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <%} %>
                <asp:Literal ID="txtmodelfield" runat="server"></asp:Literal>
                <%if (gethide("8"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(10)%><!--图片地址-->：
                    </td>
                    <td>
                        <asp:TextBox ID="txtPicUrl" runat="server" CssClass="input-control txtPicUrl" MaxLength="50"></asp:TextBox>&nbsp;<input
                            type="button" id="image3" value="上传图片" class="btn btn-small f-left" /><%if (gethide("18"))
                                                                                                     {%><a
                                                                                                   href="javascript:void(0)" class="red f-left" onclick="imgjcrop('txtPicUrl',<%=iw %>,<%=ih %>)">裁剪上传</a><%} %>
                        <span class="input-tips"><asp:Literal ID="txtTips3" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <%}
                    if (gethide("13"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(11)%><!--上传附件-->：
                    </td>
                    <td>
                        <asp:TextBox ID="filesurl" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                        <input type="button" id="insertfile" value="选择<%=titletips2(11)%>" class="btn btn-small f-left" />
                       <span class="input-tips"><asp:Literal ID="txtTips6" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <%}
                    if (gethide("10"))
                    {%>
                <tr>
                    <td class="align-right">
                        <%=ItemName%><%=titletips2(3)%>：<br />
                        <asp:Literal ID="txtTips8" runat="server"></asp:Literal>
                        <%if (gethide("21"))
                            { %>
                        <p class="nextpage" style="cursor: pointer">
                            插入分页 [NextPage]
                        </p>
                        <br />
                        <%} %>
                                    过滤span font
                        <asp:CheckBox ID="txtspanfont" runat="server" /><br />
                        过滤html
                        <asp:CheckBox ID="txthtml" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtcontents" runat="server" TextMode="MultiLine" CssClass="textarea input-control wh required"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("16"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=ItemName%>：
                                    <asp:Literal ID="txtTips9" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcontents2" runat="server" TextMode="MultiLine" CssClass="textarea wh input-control"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("17"))
                    {%>
                <tr>
                    <td class="align-right">
                        <%=ItemName%>：
                                    <asp:Literal ID="txtTips10" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcontents3" runat="server" TextMode="MultiLine" CssClass="textarea wh input-control"></asp:TextBox>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td class="align-right">&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="确认添加" CssClass="btn" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <%if (gethide("20"))
            { %>
        <div class="tab-pane">
            <table class="comm-table">
                <%if (gethide("1"))
                    {%>
                <tr>
                    <td class="align-right w150">优先等级：
                    </td>
                    <td>
                        <asp:TextBox ID="txtPx" runat="server" CssClass="input-control required digits" Text="0"
                            MaxLength="10"></asp:TextBox>
                        <span class="input-tips"><asp:Literal ID="txtTips7" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <%}
                    if (gethide("2"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(5)%><!--作者-->：
                    </td>
                    <td>
                        <asp:TextBox ID="txtAuthor" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("3"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(6)%><!--来源-->：
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrigin" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("4"))
                    {%>
                <tr>
                    <td class="align-right">点击：
                    </td>
                    <td>
                        <asp:TextBox ID="txtHist" runat="server" CssClass="input-control required digits" Text="0"
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("15"))
                    {%>
                <tr>
                    <td class="align-right">允许评价：
                    </td>
                    <td>
                        <asp:radiobuttonlist id="rallowcomment" runat="server" repeatcolumns="2" cssclass="aspx-table">
                                        <asp:ListItem Value="1" Selected="True">允许</asp:ListItem>
                                        <asp:ListItem Value="0">不允许</asp:ListItem>
                                    </asp:radiobuttonlist>
                    </td>
                </tr>
                <%}
                    if (gethide("5"))
                    {%>
                <tr>
                    <td class="align-right">添加时间：
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddDate" runat="server" CssClass="input-control required" MaxLength="50"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                    </td>
                </tr>

                <%}
                    if (gethide("7"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(2)%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtIntro" runat="server" CssClass="textarea input-control" TextMode="MultiLine"
                            MaxLength="300"></asp:TextBox>
                    </td>
                </tr>
                <%} %>
            </table>
        </div>
        <%} %>
        <%if (gethide("6"))
            { %>
        <div class="tab-pane">
            <table class="comm-table">
                <tr>
                    <td class="align-right w150">优化标题：
                    </td>
                    <td>
                        <asp:TextBox ID="txtseotitle" runat="server" CssClass="input-control" MaxLength="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="align-right">Meta关键词：
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeyWord" runat="server" CssClass="textarea input-control" TextMode="MultiLine"
                            MaxLength="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="align-right">Meta描述：
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textarea input-control" TextMode="MultiLine"
                            MaxLength="250"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <%} %>
    </div>
    <asp:HiddenField ID="hiddenbackurl" runat="server" />
</asp:Content>

