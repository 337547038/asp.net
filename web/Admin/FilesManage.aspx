<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="FilesManage.aspx.cs" Inherits="Admin_FilesManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript">
        $(document).ready(function() {
            $(".showbig").hover(function() {
                var path = $(this).children("a").attr("rel");
                $(this).append("<img src=\"" + path + "\" width=\"200\">");
            }, function() {
                $(this).children("img").remove();
            });
        });
    </script>
    <style type="text/css">
        .showbig
        {
            position: relative;
            cursor: pointer;
        }
        .showbig img
        {
            position: absolute;left:100px;top:25px;
            max-width: 640px; z-index:100;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="comm-table">
        <tr>
            <td colspan="4" height="40" class="align-center">
                <asp:button id="Button1" runat="server" text="一键清除此目录无关联文件" cssclass="btn" onclick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <th class="align-center">文件名
            </th>
            <th class="align-center">创建时间
            </th>
            <th class="align-center">文件大小
            </th>
            <th class="align-center">管理
            </th>
        </tr>
        <asp:literal id="AllFolder" runat="server"></asp:literal>
        <asp:repeater id="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <img src="images/pic.jpg" class="icon-editdel" alt=""/>
                        <span class="showbig"><a rel="<%=Path %>/<%#Eval("Name")%>">
                            <%#Eval("Name")%></a></span>
                    </td>
                    <td class="align-center">
                        <%#GL.Utility.BasePage.formatDateTime(Eval("CreationTime").ToString())%>
                    </td>
                    <td class="align-center">
                        <%#GL.Utility.FileManage.GetFileSize(Convert.ToInt32(Eval("Length")))%>
                    </td>
                    <td class="align-center">
                        <asp:LinkButton ID="lbtdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%# Eval("FullName") %>'
                            OnClick="Unnamed1_Click" runat="server">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:repeater>
        <tr>
            <td class="align-right" colspan="4">共<asp:literal runat="server" id="allMsg"></asp:literal>条记录 页次：<asp:literal runat="server"
                id="nowPage"></asp:literal>/<asp:literal runat="server" id="allPages"></asp:literal>
                <asp:literal runat="server" id="onePage"></asp:literal>
                条/页
                <asp:hyperlink id="firstPage" runat="server">首页</asp:hyperlink>
                <asp:hyperlink id="prePage" runat="server">上一页</asp:hyperlink>
                <asp:hyperlink id="nextPage" runat="server">下一页</asp:hyperlink>
                <asp:hyperlink id="endPage" runat="server">尾页</asp:hyperlink>
            </td>
        </tr>

    </table>
</asp:Content>

