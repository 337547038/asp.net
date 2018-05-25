<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="Admin_main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="comm-table">
            <tr>
                <th colspan="2">&nbsp;服务器信息</th>
                <th colspan="2">系统空间占用量（<asp:LinkButton ID="LinkButton1"
                    runat="server" OnClick="LinkButton1_Click"><font color="#FF0000">计算</font></asp:LinkButton>）</th>
            </tr>
            <tr>
                <td class="alignright" width="15%">站点域名：</td>
                <td width="35%"><%=Request.Url.Host%></td>
                <td class="alignright" width="15%">程序文件占用：</td>
                <td width="35%"><%=aspnet %></td>
            </tr>
            <tr>
                <td class="alignright">服务器名称：</td>
                <td><%=Server.MachineName%></td>
                <td class="alignright">UpLoadFile：</td>
                <td><%=uploadfile%></td>
            </tr>
            <tr>
                <td class="alignright">服务器IP：</td>
                <td><%=Request.ServerVariables["LOCAL_ADDR"] %></td>
                <td class="alignright">Html：</td>
                <td><%=html %></td>
            </tr>
            <tr>
                <td class="alignright">NET框架版本：</td>
                <td><%=Environment.Version.ToString()%></td>
                <td class="alignright">总占用空间：</td>
                <td><%=wwwroot%></td>
            </tr>
            <tr>
                <td class="alignright">操作系统：</td>
                <td><%=Environment.OSVersion.ToString()%></td>
                <td class="alignright">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="alignright">IIS环境：</td>
                <td><%=Request.ServerVariables["SERVER_SOFTWARE"]%></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="alignright">服务器端口：</td>
                <td><%=Request.ServerVariables["SERVER_PORT"]%></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="alignright">文件路径：</td>
                <td><%=Request.ServerVariables["APPL_PHYSICAL_PATH"]%></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="alignright">HTTPS支持：</td>
                <td><%=Request.ServerVariables["HTTPS"]%></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="alignright">seesion总数：</td>
                <td><%=Session.Keys.Count.ToString()%></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
</asp:Content>

