<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ModelAdd.aspx.cs" Inherits="Admin_ModelAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .p-line p{margin-bottom:5px;width:100%}
        .p-line p:after{display: block; content: '.'; clear: both; height: 0; line-height: 0; visibility: hidden;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="comm-table">
      <tr>
        <th width="21%"><asp:Literal ID="txtAction2" runat="server"></asp:Literal></th>
        <th class="align-right" width="79%"></th>
      </tr>
      <tr>
        <td class="align-right">模型类型：</td>
        <td><asp:DropDownList ID="DrModelType" runat="server" 
                AutoPostBack="True" onselectedindexchanged="DrModelType_SelectedIndexChanged" CssClass="select-control input-control">
        <asp:ListItem Value="0">文章模型</asp:ListItem>
        <asp:ListItem Value="1">产品模型</asp:ListItem>
            </asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="align-right">模型名称：</td>
        <td><asp:TextBox ID="txtModelName" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">数据表名：</td>
        <td><asp:TextBox ID="txtModelTable" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">栏目最多级数：</td>
        <td><asp:TextBox ID="txtclassnum" runat="server" CssClass="input-control required digits" Text="1" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">项目名称：</td>
        <td><asp:TextBox ID="txtItemName" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="align-right">项目单位：</td>
        <td><asp:TextBox ID="txtItemUnit" runat="server" CssClass="input-control required" MaxLength="50"></asp:TextBox></td>
      </tr>
      <tr>
      <td class="align-right">是否启用：</td>
      <td>
    <asp:RadioButtonList ID="RaModelLock" runat="server" RepeatColumns="2" CssClass="aspx-table">
    <asp:ListItem Value="0" Selected="True">启用</asp:ListItem>
    <asp:ListItem Value="1">禁用</asp:ListItem>
    </asp:RadioButtonList></td>
      </tr>
     
      <tr>
      <td class="align-right">发表审核：</td>
      <td><asp:DropDownList ID="ddlsendsh" runat="server" CssClass="input-control select-control">
      <asp:ListItem Value="0">不需要审核</asp:ListItem>
      <asp:ListItem Value="1">审核</asp:ListItem>
      </asp:DropDownList></td>
      </tr>
      <tr>
        <td class="align-right">模型内容可选字段：</td>
        <td>
        <%if (!modeltype) //文章模型
          {%>
        <asp:CheckBoxList ID="txtModeContent" runat="server" RepeatColumns="8" CssClass="aspx-table">
        <asp:ListItem Value="0">副标题</asp:ListItem>
        <asp:ListItem Value="1">优先等级</asp:ListItem>
        <asp:ListItem Value="2">作者</asp:ListItem>
        <asp:ListItem Value="3">来源</asp:ListItem>
        <asp:ListItem Value="4">点击</asp:ListItem>
        <asp:ListItem Value="5">添加时间</asp:ListItem>
        <asp:ListItem Value="6">SEO相关</asp:ListItem>
        <asp:ListItem Value="7">导读</asp:ListItem>
        <asp:ListItem Value="8">图片地址</asp:ListItem>
        <asp:ListItem Value="13">上传附件</asp:ListItem>
        <asp:ListItem Value="9">推荐属性</asp:ListItem>
        <asp:ListItem Value="10">内容</asp:ListItem>
        <asp:ListItem Value="11">热门属性</asp:ListItem>
        <asp:ListItem Value="12">最新属性</asp:ListItem>
        <asp:ListItem Value="15">允许评论</asp:ListItem>
        <%--<asp:ListItem Value="14">立即发布</asp:ListItem>--%>
        <asp:ListItem Value="16">内容2</asp:ListItem>
        <asp:ListItem Value="17">内容3</asp:ListItem>
        <asp:ListItem Value="18">图片剪切上传</asp:ListItem>
        <asp:ListItem Value="19">栏目</asp:ListItem>
        <asp:ListItem Value="20">添加详细信息</asp:ListItem>
        <asp:ListItem Value="21">内容插入分页</asp:ListItem>
        <asp:ListItem Value="22">选择标题颜色</asp:ListItem>
            </asp:CheckBoxList>
            <%}
          else //产品模型
          { %>
          <asp:CheckBoxList ID="txtModeContent2" runat="server" RepeatColumns="8" CssClass="aspx-table">
        <asp:ListItem Value="0">简介</asp:ListItem>
       <asp:ListItem Value="1">内容</asp:ListItem>
       <asp:ListItem Value="2">点击数</asp:ListItem>
       <asp:ListItem Value="3">添加时间</asp:ListItem>
       <asp:ListItem Value="4">推荐属性</asp:ListItem>
       <asp:ListItem Value="11">热卖属性</asp:ListItem>
       <asp:ListItem Value="26">最新属性</asp:ListItem>
       <asp:ListItem Value="27">特价属性</asp:ListItem>
       <asp:ListItem Value="5">优先等级</asp:ListItem>
       <asp:ListItem Value="6">产品图片</asp:ListItem>
       <asp:ListItem Value="7">产品大图</asp:ListItem>
       <asp:ListItem Value="8">产品相册</asp:ListItem>
       <asp:ListItem Value="9">SEO选项</asp:ListItem>
      <asp:ListItem Value="10">详细描述选项</asp:ListItem>
       <asp:ListItem Value="12">价格</asp:ListItem>
       <asp:ListItem Value="13">市场价</asp:ListItem>
       <asp:ListItem Value="14">生产商</asp:ListItem>
       <asp:ListItem Value="15">单位</asp:ListItem>
       <asp:ListItem Value="16">库存量</asp:ListItem>
       <%--<asp:ListItem Value="17">模板ID</asp:ListItem>--%>
       <asp:ListItem Value="18">评论</asp:ListItem>
	   <asp:ListItem Value="19">产品型号</asp:ListItem>
	   <asp:ListItem Value="20">产品规格</asp:ListItem>
	   <asp:ListItem Value="21">上传附件</asp:ListItem>
	   <asp:ListItem Value="22">内容2</asp:ListItem>
	   <asp:ListItem Value="23">内容3</asp:ListItem>
	   <asp:ListItem Value="24">图片剪切上传</asp:ListItem>
	   <asp:ListItem Value="25">选择标题颜色</asp:ListItem>
	   <%--<asp:ListItem Value="28">立即发布</asp:ListItem>--%>
            </asp:CheckBoxList>
            <%} %>
        </td>
      </tr>
      <tr>
      <td class="align-right">模型栏目可选字段：</td>
      <td>
      <asp:CheckBoxList ID="txtmodelcheckclass" runat="server" RepeatColumns="8" CssClass="aspx-table">
      <asp:ListItem Value="0">优先级别</asp:ListItem>
      <asp:ListItem Value="1">是否隐藏</asp:ListItem>
      <asp:ListItem Value="2">允许评论</asp:ListItem>
      <asp:ListItem Value="3">是否允许录入</asp:ListItem>
      <asp:ListItem Value="4">会员投稿</asp:ListItem>
      <asp:ListItem Value="5">栏目图片</asp:ListItem>
      <asp:ListItem Value="7">栏目简介</asp:ListItem>
      <asp:ListItem Value="8">自选选项</asp:ListItem>
      <asp:ListItem Value="9">SEO选项</asp:ListItem>
      </asp:CheckBoxList>
      </td>
      </tr>
      <%if (!modeltype)
        {%>
      <tr>
      <td class="align-right">内容字段名称：</td>
      <td style="line-height:30px;">标题,副标题,简介,内容,归属栏目,作者,来源,推荐,最新,热门,图片地址,附件地址<br />
      <asp:TextBox ID="txt25" runat="server" CssClass="input-control" MaxLength="50" Text="标题,副标题,简介,内容,归属栏目,作者,来源,推荐,最新,热门,图片地址,附件地址"></asp:TextBox></td>
      </tr>
     
      <%}
        else
        { %>
        <tr>
      <td class="align-right">内容字段名称：</td>
      <td style="line-height:30px;"><span style="line-height:18px">0标题,1归属栏目,2推荐,3热卖,4最新,5特价,6产品小图,7产品大图,8上传附件,9产品简介,10内容1,11内容2,12内容3,13产品相册,14市场价,15会员价,16产品型号,17产品规格尺寸,18生产商,19产品单位,20库存量</span><br />
      <asp:TextBox ID="txt26" runat="server" CssClass="input-control" MaxLength="100" Text="标题,归属栏目,推荐,热卖,最新,特价,产品小图,产品大图,上传附件,产品简介,内容1,内容2,内容3,产品相册,市场价,会员价,产品型号,产品规格尺寸,生产商,产品单位,库存量"></asp:TextBox></td>
      </tr>
      <%} %>
       <tr>
       <td class="align-right">模型列表可选字段：</td>
       <td><asp:CheckBoxList ID="txtchecklist" runat="server" RepeatColumns="9" CssClass="aspx-table">
       <asp:ListItem Value="0">录入</asp:ListItem>
       <asp:ListItem Value="1">作者(文章系统)</asp:ListItem>
       <asp:ListItem Value="2">来源(文章系统)</asp:ListItem>
       <asp:ListItem Value="3">添加时间</asp:ListItem>
       <asp:ListItem Value="4">修改时间</asp:ListItem>
       <asp:ListItem Value="5">属性</asp:ListItem>
       <asp:ListItem Value="6">点击</asp:ListItem>
       <asp:ListItem Value="7">优先排序</asp:ListItem>
       <asp:ListItem Value="8">列表显示子级</asp:ListItem>
       </asp:CheckBoxList></td>
      </tr>
      <tr>
      <td class="align-right">输入提示语：</td>
      <td style="line-height:30px;" class="p-line">
          <p><span class="f-left">标题：</span><asp:TextBox ID="txt0" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></p>
          <p><span class="f-left">归属栏目：</span><asp:TextBox ID="txt1" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></p>
          <p><span class="f-left">属性：</span><asp:TextBox ID="txt2" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></p>
           <p><span class="f-left">图片地址：</span><asp:TextBox ID="txt3" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></p>
        <p><span class="f-left">图片宽度：</span><asp:TextBox ID="txt4" runat="server" CssClass="input-control w50 digits" MaxLength="50"></asp:TextBox>
        <span class="f-left">图片高度：</span><asp:TextBox ID="txt5" runat="server" CssClass="input-control w50 digits" MaxLength="50"></asp:TextBox></p>
           <p><span class="f-left">附件上传：</span><asp:TextBox ID="txt6" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox><br /></p>
          <p><span class="f-left">优先等级：</span><asp:TextBox ID="txt7" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox><br /></p>
           <p><span class="f-left">内容：</span><asp:TextBox ID="txt8" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox><br /></p>
        <p><span class="f-left">内容2：</span><asp:TextBox ID="txt9" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox><br /></p>
        <p><span class="f-left">内容3：</span><asp:TextBox ID="txt10" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox><br /></p>
      <%if (!modeltype) //文章模型
        {%>
        <p><span class="f-left">副标题：</span><asp:TextBox ID="txta11" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></p>
          <%}
        else
        { %>
        <p><span class="f-left">产品大图：</span><asp:TextBox ID="txtp11" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></p>
        <p><span class="f-left">大图宽度：</span><asp:TextBox ID="txtp12" runat="server" CssClass="input-control w50 digits" MaxLength="50"></asp:TextBox>
        <span class="f-left">大图高度：</span><asp:TextBox ID="txtp13" runat="server" CssClass="input-control w50 digits" MaxLength="50"></asp:TextBox></p>
          <p><span class="f-left">产品简介：</span><asp:TextBox ID="txtp14" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></p>
        <p><span class="f-left">相册图片：</span><asp:TextBox ID="txtp15" runat="server" CssClass="input-control" MaxLength="50"></asp:TextBox></p>
          <%} %>
      </td>
      </tr>
      <tr>
        <td class="align-right">&nbsp;</td>
        <td><asp:Button ID="Button1" runat="server" Text="添加新模型" 
                CssClass="btn" onclick="Button1_Click" /></td>
          
      </tr>
    </table>
</asp:Content>

