<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>网站内容管理后台</title>
    <link rel="stylesheet" href="css/style.css" type="text/css"/>
</head>
<body style="overflow: hidden" scroll="no">
    <form id="form1" runat="server">
        <div class="header">
            <div class="title">网站管理系统</div>
            <div class="tab">
                <ul class="clearfix">
                    <li class="active"><a href="javascript:;">内容管理</a></li>
                    <li><a href="javascript:;">网站设置</a></li>
                    <li><a href="javascript:;">互动相关</a></li>
                    <%if (GetPower("1"))
                        { %>
                    <li><a href="javascript:;">模型管理</a></li>
                    <%} %>
                    <li><a href="javascript:;">用户中心</a></li>
                </ul>
            </div>
            <div class="top-nav">
                <a href="<%=siteurl %>">网站首页</a><span>|</span>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">安全退出</asp:LinkButton><span>|</span>
                <a href="Admin.aspx" target="main">修改密码</a>
            </div>
        </div>
        <div class="main-body">
            <div class="left-sidebar tab-content">
                <div class="tab-pane active">
                    <h3 class="bg-icon">内容管理</h3>
                    <ul>
                        <asp:Literal ID="Articlemodel" runat="server"></asp:Literal>
                    </ul>
                    <h3 class="bg-icon">栏目管理</h3>
                    <ul>
                        <asp:Literal ID="txtClass" runat="server"></asp:Literal>
                    </ul>
                    
                   <%if (GetPower("9"))
                            { %>
                    <h3 class="bg-icon">单面管理</h3>
                    <ul>
                        
                        <li><a href="DIYPage.aspx" target="main">单页管理</a></li>
                        <%} %>
                        <%if (GetPower("91"))
                            { %>
                        <li><a href="DIYPage.aspx?Ac=add" target="main">新建单页</a></li>
                       
                    </ul>
                     <%}if (GetPower("17"))
                        {%>
                    <h3 class="bg-icon"><a href="block.aspx" target="main">方块碎片</a></h3>
                    <%} %>
                   
                </div>
                <div class="tab-pane">
                    <h3 class="bg-icon">系统设置</h3>
                    <ul>

                        <%if (GetPower("0"))
                            { %>
                        <li><a href="webconfig.aspx" target="main">网站基本设置</a></li>
                        <%}
                            if (GetPower("8"))
                            { %>
                        <li><a href="FilesManage.aspx" target="main">上传文件管理</a></li>
                        <%} %>
                        <li><a href="netinfo.aspx" target="main">服务器参数探测</a></li>
                        <%if (GetPower("10"))
                            { %>
                        <li><a href="Replace.aspx" target="main">数据库字段替换</a></li>
                        <%}
                            if (GetPower("20"))
                            { %>
                        <li><a href="Error.aspx" target="main">系统运行错误记录</a></li>
                        <%}
                            if (GetPower("24"))
                            { %>
                        <li><a href="searchkey.aspx" target="main">搜索关键词管理</a></li>
                        <%} %>
                    </ul>

                </div>
                <div class="tab-pane">
                    <h3 class="bg-icon">互动相关</h3>
                    <ul>
                        <%if (GetPower("3"))
                            { %>
                        <li><a href="GuestBook.aspx" target="main">留言管理</a></li>
                        <%} %>
                        <%if (GetPower("4"))
                            { %>
                        <li><a href="Link.aspx" target="main">友情链接</a></li>
                        <%} %>
                        
                        <%if (GetPower("2"))
                            { %>
                        <li class="seonone"><a href="SeoAll.aspx" target="main">SEO批量设置</a></li>
                        <%} %>
                        <%if (GetPower("15"))
                            { %>
                        <li><a href="AD.aspx" target="main">站点广告</a></li>
                        <%} %>
                    </ul>
                </div>
                <%if (GetPower("1"))
                    { %>
                <div class="tab-pane">
                    <h3 class="bg-icon">模型管理</h3>
                    <ul>
                        <li><a href="Model.aspx" target="main">模型管理首页</a></li>
                        <li><a href="ModelAdd.aspx" target="main">添加新模型</a></li>
                        <asp:Literal ID="txtmodel" runat="server"></asp:Literal>
                    </ul>
                </div>
                <%} %>
                <div class="tab-pane">
                    <h3 class="bg-icon">用户管理</h3>
                    <ul>
                        <% if (GL.Utility.Cookies.GetCookie("User_Id") == "1" || GL.Utility.Cookies.GetCookie("User_Id") == "2")
                            {%>
                        <li><a href="admin.aspx" target="main">管理员管理</a></li>
                        <%}
                            if (GetPower("7"))
                            { %>
                        <li><a href="user.aspx" target="main">注册会员管理</a></li>
                        <li><a href="user.aspx?Action=Add" target="main">添加会员</a></li>
                        <%}
                            if (GetPower("14"))
                            { %>
                        <li><a href="usergroup.aspx" target="main">用户组管理</a></li>
                        <%} %>
                    </ul>
                </div>
            </div>
            <div class="main-iframe">
                <iframe frameborder="0" id="iframe" name="main" scrolling="yes" src="main.aspx"></iframe>
            </div>
        </div>
        <div class="footer">
            <div class="left-siderbar-control">打开/关闭左栏</div>
            <div class="control">
               
            </div>
            <div class="copyright">版权所有 2011-2018</div>
        </div>
    </form>
    <script type="text/javascript" src="js/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="js/comm.js"></script>
</body>
</html>
