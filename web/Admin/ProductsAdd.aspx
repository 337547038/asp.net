<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductsAdd.aspx.cs" Inherits="Admin_ProductsAdd" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/jquery.colorpicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            //鼠标经过图片输入框时，显示图片
            $(".showpic").hover(function () {
                if ($(this).val() != "") {
                    $(this).after("<img src=\"" + $(this).val() + "\" style=\"position:absolute; left:0px; top:25px; width:120px;z-index:100\"/>");
                }
            }, function () {
                $(this).next("img").remove();
            })

            //删除相册的图片
            $(".shopmorepic span").on("click", function () {
                var id = $(this).parent("li").children(".txtpicid").val();
                if (id != "") {
                    $.get("ProductsAdd.aspx", { delid: id, ac: "uppic",mid:<%=mid%> });
                }
                $(this).parent("li").remove();
            });

            $("#cp1").colorpicker({
                target: $("#ctl00_ContentPlaceHolder1_txtTitle"),
                success: function (o, color) {
                    $("#ctl00_ContentPlaceHolder1_txtTitle").css("color", color);
                    $("#ctl00_ContentPlaceHolder1_txtTitle").attr("value", color);
                }
            });
            //$("#_creset").on("click", function() {
            //    $("#colortxt").attr("value", "");
            //    $("#txtTitle").css("color", "");
            //});
            //选择所属公司
            $(".select-company").click(function () {
                $.layer({ contents: "layer/iframe.aspx?ac=company", popType: 3, width: 400 });
            }); 
        });
        //由框架页触发,选择所属公司
        function chooseCompany(value, key) {
            $(".select-company").val(value);
            $("#ctl00_ContentPlaceHolder1_txtcompanyid").val(key);
             layer.close();
        }
        //裁切上传图片
        function imgjcrop(id, w, h) {
            $.layer({ contents: "ImgJcrop.aspx?w=" + w + "&h=" + h + "&id=" + id, popType: 1 });
        }
        //裁切成功，由框架页触发
        function imgJcropsuccess(id, txt) {
            // console.log('000000000');
            $("." + id).val(txt);
            layer.close();
        }
    </script>

    <script type="text/javascript">
        //编辑器
        kindupfile("#insertfile", "#ctl00_ContentPlaceHolder1_filesurl");
        editkind("ctl00$ContentPlaceHolder1$txtcontents");
        editkind("ctl00$ContentPlaceHolder1$txtcontents2");
        editkind("ctl00$ContentPlaceHolder1$txtcontents3");
        kindeditUploadImg("#image3", "#ctl00_ContentPlaceHolder1_txtPicUrl");
        kindeditUploadImg("#image4", "#ctl00_ContentPlaceHolder1_txtBigPhoto");


        //相册批量上传

        KindEditor.ready(function (K) {
            var editor = K.editor({
                allowFileManager: true
            });
            K('#J_selectImage').click(function () {
                editor.loadPlugin('multiimage', function () {
                    editor.plugin.multiImageDialog({
                        clickFn: function (urlList) {
                            var div = K('#J_imageView');
                            div.html('');
                            K.each(urlList, function (i, data) {
                                var htmltxt = "<li><img src=\"" + data.url + "\">\r";
                                htmltxt += "<input name=\"txtpicid\" type=\"hidden\" id=\"txtpicid\" value=\"0\" />\r";
                                htmltxt += "<input name=\"txtpicpath\" type=\"hidden\" id=\"txtpicpath\" value=\"" + data.url + "\" />\r";
                                htmltxt += "<input name=\"txtpicintro\" type=\"text\" id=\"txtpicintro\" class=\"txtpicintro2 input-control\" value=\"" + data.title + "\"/>\r";
                                htmltxt += "<input name=\"txtpicpx\" type=\"text\" id=\"txtpicpx\" class=\"txtpicpx2 input-control digits\" value=\"\" title=\"排序\"/>&nbsp;<span>删除</span></li>";
                                div.append(htmltxt);
                            });
                            editor.hideDialog();
                        }
                    });
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="com-div com-tab tab">
        <ul class="clearfix">
            <li class="active">基本信息</li>
            <%if (gethide("10"))
                {%><li>详细描述</li>
            <%} %>
            <%if (gethide("9"))
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
                        <asp:DropDownList ID="Drlanguage" runat="server" CssClass="input-control select-control" AutoPostBack="True"
                            OnSelectedIndexChanged="Drlanguage_SelectedIndexChanged">
                            <asp:ListItem Value="0">中文</asp:ListItem>
                            <asp:ListItem Value="1">英文</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="align-right" width="120">
                        <%=titletips2(0)%><%--标题--%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input-control required" MaxLength="150"></asp:TextBox>&nbsp;<%if (gethide("25"))
                                                                                                                                            {%><img src="images/colorpicker.png" id="cp1" style="cursor: pointer; position: relative; top: 2px"
                                                                                                                                             title="选择颜色" /><asp:HiddenField ID="colortxt" runat="server" />
                       <%} %><span class="input-tips"><asp:Literal ID="txtTips0" runat="server"></asp:Literal></span>

                    </td>
                </tr>
                <tr>
                    <td class="align-right">
                        <%=titletips2(1)%><%--归属栏目--%>：
                    </td>
                    <td>
                        <asp:Literal ID="txtTid" runat="server"></asp:Literal>&nbsp;
                       <span class="input-tips"><asp:Literal ID="txtTips1" runat="server"></asp:Literal></span>
                        <%if (gethide("4"))
                            { %>
                        <asp:CheckBox ID="txtRecommend" runat="server" /><%=titletips2(2)%><%--推荐--%>
                        <%}
                            if (gethide("11"))
                            { %>
                        <asp:CheckBox ID="txtPopular" runat="server" /><%=titletips2(3)%><%--热卖--%>
                        <%}
                            if (gethide("26"))
                            {%>
                        <asp:CheckBox ID="txtNew" runat="server" /><%=titletips2(4)%><%--最新--%>
                        <%}
                            if (gethide("27"))
                            { %>
                        <asp:CheckBox ID="txtIsSpecial" runat="server" /><%=titletips2(5)%><%--特价--%><%} %><span class="input-tips"><asp:Literal ID="txtTips2" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <asp:Literal ID="txtmodelfield" runat="server"></asp:Literal>
                <tr>
                    <td class="align-right">所属公司：</td>
                    <td>
                        <asp:TextBox ID="txtcompany" runat="server" CssClass="input-control select-company required" MaxLength="50" ReadOnly="true" placeholder="请选择所属公司"></asp:TextBox>
                        <asp:HiddenField ID="txtcompanyid" runat="server" />
                    </td>
                </tr>
                <%if (gethide("6"))
                    {%>
                <tr>
                    <td class="align-right">
                        <%=titletips2(6)%><%--小图--%>：
                    </td>
                    <td>
                        <p style="position: relative">
                            <asp:TextBox ID="txtPicUrl" runat="server" CssClass="input-control txtPicUrl showpic" MaxLength="50"></asp:TextBox>
                            <input type="button" id="image3" value="上传图片" class="btn btn-small f-left" />&nbsp;<%if (gethide("24"))
                                                                                                         { %><a href="javascript:void(0)" class="red f-left" onclick="imgjcrop('txtPicUrl',<%=isw %>,<%=ish %>)">裁剪上传</a>&nbsp;<%} %>
                            <span class="input-tips"><asp:Literal ID="txtTips3" runat="server"></asp:Literal></span>
                        </p>
                    </td>
                </tr>
                <%}
                    if (gethide("7"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(7)%><%--大图--%>：
                    </td>
                    <td style="position: relative">
                        <p style="position: relative">
                            <asp:TextBox ID="txtBigPhoto" runat="server" CssClass="input-control showpic txtBigPhoto" MaxLength="50"></asp:TextBox>
                            <input type="button" id="image4" value="上传图片" class="btn btn-small f-left" />&nbsp;<%if (gethide("24"))
                                                                                                         { %><a href="javascript:void(0)" class="red f-left" onclick="imgjcrop('txtBigPhoto',<%=ibw %>,<%=ibh %>)">裁剪上传</a><%} %>
                            <span class="input-tips"><asp:Literal ID="txtTips11" runat="server"></asp:Literal></span>
                        </p>
                    </td>
                </tr>
                <%}
                    if (gethide("21"))
                    {%>
                <tr>
                    <td class="align-right">
                        <%=titletips2(8)%><%--上传附件--%>：
                    </td>
                    <td>
                        <asp:TextBox ID="filesurl" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                        <input type="button" id="insertfile" value="选择附件" class="btn btn-small f-left" />
                        <span class="input-tips"><asp:Literal ID="txtTips6" runat="server"></asp:Literal></span>
                    </td>
                </tr>

                <%}
                    if (gethide("0"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(9)%><%--产品简介--%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtIntro" runat="server" CssClass="textarea input-control" TextMode="MultiLine"
                            MaxLength="300"></asp:TextBox>
                        <span class="input-tips"><asp:Literal ID="txtTips14" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <%}
                    if (gethide("1"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(10)%><%--内容--%>：<br />
                        <asp:Literal ID="txtTips8" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcontents" runat="server" TextMode="MultiLine" CssClass="textarea wh input-control required"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("22"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(11)%>：<br />
                        <asp:Literal ID="txtTips9" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcontents2" runat="server" TextMode="MultiLine" CssClass="textarea wh input-control required"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("23"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(12)%>：<br />
                        <asp:Literal ID="txtTips10" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcontents3" runat="server" TextMode="MultiLine" CssClass="textarea wh input-control required"></asp:TextBox>
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
        <%if (gethide("10"))
            {%>
        <div class="tab-pane">
            <table class="comm-table">
                <%if (gethide("3"))
                    { %>
                <tr>
                    <td class="align-right w150">添加时间：
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddDate" runat="server" CssClass="input-control required" MaxLength="50"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("5"))
                    {%>
                <tr>
                    <td class="align-right">排列顺序：
                    </td>
                    <td>
                        <asp:TextBox ID="txtpx" runat="server" CssClass="input-control digits" MaxLength="20"></asp:TextBox>
                        <span class="input-tips"><asp:Literal ID="txtTips7" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <%}
                    if (gethide("2"))
                    {%>
                <tr>
                    <td class="align-right">点击数：
                    </td>
                    <td>
                        <asp:TextBox ID="txtHits" runat="server" CssClass="input-control digits" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("8"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(13)%><%--相册--%>：
                    </td>
                    <td>
                        <input type="button" id="J_selectImage" value="批量上传" class="btn btn-small f-left" />
                        <span class="input-tips"><asp:Literal ID="txtTips15" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="shopmorepic moreimg">
                            <div id="J_imageView">
                            </div>
                            <!--最新上传-->
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <img src="<%#Eval("PhotoUrl") %>" alt="" />
                                        <input type="text" name="txtpicintro" id="txtpicintro" class="txtpicintro2 input-control"
                                            value="<%#Eval("Intro") %>" />
                                        <input type="text" name="txtpicpx" class="txtpicpx2 input-control digits"
                                            value="<%#Eval("Px") %>" />
                                        <input name="txtpicid" type="hidden" value="<%# Eval("id") %>" class="txtpicid"/>
                                        <input name="txtpicpath" type="hidden" value="" />
                                        <span>删除</span></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!--shopmorepic-->
                    </td>
                </tr>
                <%}
                    if (gethide("13"))
                    {%>
                <tr>
                    <td class="align-right">
                        <%=titletips2(14)%><%-- 市场价--%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceMarket" runat="server" CssClass="input-control number" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("12"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(15)%><%--会员价--%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="input-control number" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("19"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(16)%><%--型号--%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtProModel" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("20"))
                    {%>
                <tr>
                    <td class="align-right">
                        <%=titletips2(17)%><%--规格尺寸--%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtProSpecificat" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("14"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(18)%><%--生产商--%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtProducerName" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("15"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(19)%><%--单位--%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtUnit" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <%}
                    if (gethide("16"))
                    { %>
                <tr>
                    <td class="align-right">
                        <%=titletips2(20)%><%--库存量--%>：
                    </td>
                    <td>
                        <asp:TextBox ID="txtTotalNum" runat="server" CssClass="input-control digits" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>

                <%}
                    if (gethide("18"))
                    { %>
                <tr>
                    <td class="align-right">允许评论：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlComment" runat="server" CssClass="input-control select-control auto-width">
                            <asp:ListItem Value="1">所有人可评论</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">登录可发表</asp:ListItem>
                            <asp:ListItem Value="3">提交购买咨询可发表</asp:ListItem>
                            <asp:ListItem Value="4">禁止发表</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <%} %>
            </table>
        </div>
        <%}
            if (gethide("9"))
            {%>
        <div class="tab-pane">
            <table class="comm-table">
                <tr>
                    <td class="align-right w150">SEO标题：
                    </td>
                    <td>
                        <asp:TextBox ID="txtseotitle" runat="server" CssClass="input-control" MaxLength="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="align-right">SEO关键字：
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeyWord" runat="server" CssClass="textarea input-control" TextMode="MultiLine"
                            MaxLength="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="align-right">SEO描述：
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textarea input-control" TextMode="MultiLine"
                            MaxLength="300"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <%} %>
    </div>
    <asp:HiddenField ID="hiddenbackurl" runat="server" />
    
</asp:Content>

