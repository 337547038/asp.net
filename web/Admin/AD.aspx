<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AD.aspx.cs" Inherits="Admin_AD" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            //根据广告类型显示和隐藏相对选项
            function adType() {
                var radioValue = $(".ad-type-radio input:checked").val();
                if (radioValue == 1) {
                    $('.ad-type1').show();
                    $('.ad-type2').hide();
                } else {
                    $('.ad-type1').hide();
                    $('.ad-type2').show();
                }
            }
            adType();
            $(".ad-type-radio input").click(function () {
                adType();
            });
            //根据有无广告位显示或隐藏
            function ddlinput() {
                var sv = $('.ddlinput').val();
                if (sv == 0) {
                    //无广告位
                    $('.ad-input').attr("disabled", false);
                } else {
                    $('.ad-input').attr("disabled", 'disabled');
                }
            }
            ddlinput();
            $('.ddlinput').change(function () {
                ddlinput();
            });
            kindeditUploadImg('#uploadImage', '#ctl00_ContentPlaceHolder1_txtfile');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (String.IsNullOrEmpty(action))
        {%>
    <table class="comm-table">
        <tr>
            <td colspan="6">
                <asp:Literal ID="txttxt" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th class="align-center">ID
            </th>
            <th class="align-center">广告/广告位名称
            </th>
            <th class="align-center">宽度
            </th>
            <th class="align-center">高度
            </th>
            <th class="align-center">是否启用
            </th>
            <th class="align-center">管理
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="align-center">
                        <%#Eval("id") %>
                    </td>
                    <td class="align-center">
                        <%#Eval("ADtitle")%>
                    </td>
                    <td class="align-center">
                        <%#Eval("ADwidth")%>Px
                    </td>
                    <td class="align-center">
                        <%#Eval("ADheight")%>Px
                    </td>
                    <td class="align-center">
                        <%#Eval("ADshowhide").ToString()=="0"?"启用":"<span class=\"red\">禁用</span>"%>
                    </td>
                    <td class="align-center link-margin">
                        <%#Get0(Eval("id").ToString(), Eval("IsAD").ToString())%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="6" class="align-right">
                <asp:Literal ID="txtfy" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <%}
        else if (action == "add1")//添加广告位
        {%>
    <table class="comm-table">
        <tr>
            <td class="align-right w150">广告位名称：
            </td>
            <td>
                <asp:TextBox ID="txtwtitle" runat="server" CssClass="input-control" required placeholder="请输入广告位名称"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="align-right">是否启用：
            </td>
            <td>
                <asp:RadioButtonList ID="Rshowhide" runat="server" RepeatColumns="5" CssClass="aspx-table">
                    <asp:ListItem Value="0" Selected="True">启用</asp:ListItem>
                    <asp:ListItem Value="1">禁用</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="align-right">宽度：
            </td>
            <td>
                <asp:TextBox ID="txtwwidth" runat="server" CssClass="input-control digits required" placeholder="请输入宽"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="align-right">高度：
            </td>
            <td>
                <asp:TextBox ID="txtwheight" runat="server" CssClass="input-control digits required" placeholder="请输入高"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="align-right">优先级：
            </td>
            <td>
                <asp:TextBox ID="txtadpx" runat="server" CssClass="input-control digits required" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="align-right">备注：
            </td>
            <td>
                <asp:TextBox ID="txtwcontents" runat="server" CssClass="input-control textarea" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="添加广告位" CssClass="btn" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    <%}
        else if (action == "add")//添加广告
        {%>
    <table class="comm-table">
        <tr>
            <td class="align-right w150">广告名称：
            </td>
            <td>
                <asp:TextBox ID="txtttile" runat="server" CssClass="input-control required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="align-right">已有广告位：
            </td>
            <td>
                <asp:DropDownList ID="ddltid" runat="server" CssClass="ddlinput input-control">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="align-right">是否启用：
            </td>
            <td>
                <asp:RadioButtonList ID="rashowhide" runat="server" RepeatColumns="5" CssClass="aspx-table">
                    <asp:ListItem Value="0" Selected="True">启用</asp:ListItem>
                    <asp:ListItem Value="1">禁用</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr class="adshowtype">
            <td class="align-right">展现方式：
            </td>
            <td>
                <asp:RadioButtonList ID="Rdtype" runat="server" RepeatColumns="5" CssClass="aspx-table ad-type-radio">
                    <asp:ListItem Value="1" Selected="True">图片</asp:ListItem>
                    <asp:ListItem Value="2">代码</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr class="ad-type2">
            <td class="align-right">广告HTML代码：
            </td>
            <td>
                <asp:TextBox ID="txtcontents" runat="server" CssClass="input-control textarea" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr class="ad-type1">
            <td class="align-right">
                <span class="ttype">图片</span>地址：
            </td>
            <td>
                <asp:TextBox ID="txtfile" runat="server" CssClass="input-control"></asp:TextBox>&nbsp;<input
                    type="button" id="uploadImage" class="btn btn-small" value="选择上传广告" />
            </td>
        </tr>
        <tr class="ad-type1">
            <td class="align-right">链接地址：
            </td>
            <td>
                <asp:TextBox ID="txthttp" runat="server" CssClass="input-control"></asp:TextBox>
            </td>
        </tr>
        <tr class="ad-type1">
            <td class="align-right">宽度：
            </td>
            <td>
                <asp:TextBox ID="txtwidth1" runat="server" CssClass="input-control digits required ad-input"></asp:TextBox>
            </td>
        </tr>
        <tr class="ad-type1">
            <td class="align-right">高度：
            </td>
            <td>
                <asp:TextBox ID="txtheight1" runat="server" CssClass="input-control digits required ad-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="align-right">优先等级：
            </td>
            <td>
                <asp:TextBox ID="txtpx" runat="server" CssClass="input-control digits" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="添加广告" CssClass="btn" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    <%} %>
</asp:Content>

