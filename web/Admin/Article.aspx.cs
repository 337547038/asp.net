using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Utility;
using GL.Model;
using GL.Bll;
using System.IO;
using System.Data;
public partial class Admin_Article : GL.Bll.ClassBll
{
    private string datatable = "";
    protected string ItemName = "";
    protected int mid = 1;
    protected string Language = "";
    private string lansql = "";//语言
    protected int tid;
    protected string ac = "";
    protected bool verific = false;//发表是否需要审核
    protected bool del = false;//删除权限
    protected bool sxddl = false;//属性查找
    private string showhidelistvalue = "";//列表可选字段值
    protected void Page_Load(object sender, EventArgs e)
    {
        mid = BasePage.GetRequestId(Request.QueryString["mid"]);
        tid = BasePage.GetRequestId(Request.QueryString["tid"]);
        if (mid == 0) { mid = 1; }
        if (!String.IsNullOrEmpty(Request.QueryString["language"]))
        {
            Language = BasePage.GetRequestId(Request.QueryString["language"]).ToString();
            lansql = " and Languagen=" + BasePage.GetRequestId(Language);
        }
        ac = Request.QueryString["ac"];
        ModelModel mo = new ModelBll().GetModel(mid);
        datatable = mo.ModelTable;
        ItemName = mo.ItemName;

        if (!Page.IsPostBack)
        {
            string checklogin = new AdminBll().CheckLogin("m" + mid);
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }

            verific = BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "ms" + mid);//不需要审核的管理员，显示审核，审核其它需要审核的文章
            del = BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "md" + mid);

            if (!String.IsNullOrEmpty(mo.ModeContent))
            {
                //0模型内容可选字段`1模型栏目可选字段`2内容字段名称`3模型列表可选字段`4提示语`5发表审核选择
                string[] a = mo.ModeContent.Split('`');

                //下拉属性
                if (BasePage.ArrayExist(a[0], "9"))
                {
                    //推荐属性
                    sxddl = true;
                    ddlshuxi.Items.Insert(0, new ListItem("推荐", "1"));
                }
                if (BasePage.ArrayExist(a[0], "11"))
                {
                    //热门属性
                    sxddl = true;
                    ddlshuxi.Items.Insert(0, new ListItem("热门", "2"));
                }
                if (BasePage.ArrayExist(a[0], "12"))
                {
                    //最新属性
                    sxddl = true;
                    ddlshuxi.Items.Insert(0, new ListItem("最新", "3"));
                }
                if (sxddl)
                {
                    ddlshuxi.Items.Insert(0, new ListItem("按属性查看", ""));
                }
                showhidelistvalue = a[3];
                if (!BasePage.ArrayExist(a[0], "19"))
                {
                    //按栏目查看
                    ddlclassname.Visible = false;
                }
                if (a[5] == "0")//模型不需要审核，隐藏审核链接
                {
                    verific = true;
                }
            }

            DrLanguage.SelectedValue = Language;

            int sh = BasePage.GetRequestId(Request.QueryString["sh"]); ;//审核
            int sx = BasePage.GetRequestId(Request.QueryString["sx"]);//属性
            ddlshuxi.SelectedValue = sx.ToString();
            string keywords = Request.QueryString["keywords"];
            string strwhere = "id is not null ";

            if (String.IsNullOrEmpty(ac))
            {
                strwhere += " and IsDel=0 and Verific=0";
            }
            else if (ac == "del") //回收站
            {
                strwhere += " and IsDel=1";
                //actxt.InnerHtml = ItemName + "回收站列表";
            }
            else if (ac == "sh")//审核
            {
                strwhere += " and Verific=1";
                //actxt.InnerHtml = ItemName + "审核列表";
            }
            if (tid != 0)
            {
                strwhere += " and (Tid=" + tid + "";
                //读取所有子级
                if (showhidelist("8"))
                {
                    DataTable dt = new ClassBll().GetListTree(mid, tid, "");
                    string allid = "";
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow drt in dt.Rows)
                        {
                            allid += drt["id"].ToString() + ",";
                        }
                        allid = allid.Substring(0, allid.Length - 1);
                        strwhere += " or Tid in (" + allid + ")";
                    }
                }
                strwhere += ")";
            }
            else
            {
                strwhere += lansql;//按栏目查看了就不需要语言了
            }
            if (sx != 0)
            {
                string sht = "";
                switch (sx)
                {
                    case 1:
                        sht = "IsRecommend=1";
                        break;
                    case 2:
                        sht = "IsPopular=1";
                        break;
                    case 3:
                        sht = "IsNew=1";
                        break;
                }
                strwhere += " and " + sht + "";
            }
            if (!String.IsNullOrEmpty(keywords))
            {
                strwhere += " and Title like '%" + keywords + "%'";
            }

            //列出所有栏目
            //string allclass = "ParentId=" + tid + " and ModelId=" + mid + lansql;
            //Repeater2.DataSource = new CommonBll().GetList("", "GL_Class", allclass, "Languagen asc,px desc,id desc");
            //Repeater2.DataBind();

            //批量处理时列出栏目
            ClassTreeBind(0, "请选择栏目", mid, this.ddlclassforall, "ClassType=0" + lansql);

            //按栏目查看下拉
            ClassTreeBind(0, "所有栏目", mid, this.ddlclassname, "ClassType=0" + lansql);
            ddlclassname.SelectedValue = tid.ToString();
            int pagesize = 25;
            int pageindex = BasePage.GetRequestId(Request.QueryString["page"]);
            int all = new CommonBll().GetRecordCount(datatable, strwhere);
            Repeater1.DataSource = new CommonBll().GetListPage("", datatable, strwhere, "px desc,id desc", pagesize, pageindex);
            Repeater1.DataBind();

            if (all > pagesize)
            {
                txtpage.Text = GetPage.GetAspxPager(all, pagesize, pageindex);
            }
            if (all == 0)
            {
                txtpage.Text = "<p align=\"left\" class=red>暂无相关内容</p>";
            }
            //txtpage.Text = strwhere;

            string bx = "<a href=\"Article.aspx?mid=" + mid + "\" class=\"home\">" + ItemName + "管理</ a > ";
            bx += "<a href=\"ArticleAdd.aspx?mid=" + mid + "&language=" + Language + "\" class=\"add\">添加" + ItemName + "</a>";
            if (del)
            {
                bx += "<a href=\"Article.aspx?ac=del&mid=" + mid + "&language=" + Language + "\" class=\"del\">" + ItemName + "回收站</a>";
            }
            if (!verific)
            {
                bx += "<a href=\"Article.aspx?mid=" + mid + "&language=" + Language + "&ac=sh\" class=\"sh\">审核" + ItemName + "</a>";
            }
            ((Literal)Master.FindControl("breadcrumbs")).Text = bx;
        }
    }

    //放入回收站
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        int id = BasePage.GetRequestId(delid);
       
        bool b = new ProductsBll().Update1(datatable, "IsDel", "1", id.ToString());
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "Article.aspx?mid=" + mid + "&Tid=" + tid + "&language=" + Language);
        }
    }

    protected string GetClassName(string PicUrl, string tid)
    {
        string ClassName = "";
        //根据是否上传了图片显示不同的图标
        if (!String.IsNullOrEmpty(PicUrl))
        {
            ClassName = "<span class=\"listpic\">";
        }
        else
        {
            ClassName = "<span class=\"listonpic\">";
        }
        //根据新闻ID取得栏目名称
        bool b = new CommonBll().Exists("GL_Class", int.Parse(tid));
        if (b)
        {
            ClassModel cm = new ClassBll().GetModel(int.Parse(tid));
            ClassName += "[<a href=\"Article.aspx?mid=" + mid + "&tid=" + tid + "\">" + cm.ClassName + "</a>]</span> ";
        }

        return ClassName;
    }

    //改变语言
    protected void DrLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Article.aspx?ac=" + ac + "&mid=" + mid + "&Language=" + DrLanguage.SelectedValue);
    }

    //改变栏目
    protected void ddlclassname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Article.aspx?ac=" + ac + "&mid=" + mid + "&tid=" + ddlclassname.SelectedValue + "&language=" + Language);
    }

    //改变属性
    protected void ddlshuxi_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Article.aspx?ac=" + ac + "&mid=" + mid + "&tid=" + tid + "&sx=" + ddlshuxi.SelectedValue + "&language=" + Language);
    }

    //查看按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Article.aspx?mid=" + mid + "&language=" + Language + "&tid=" + ddlclassname.SelectedValue + "&keywords=" + txtkeywords.Text.Trim().Replace("请输入关键字", ""));
    }

    //审核通过
    protected void Button2_Click1(object sender, EventArgs e)
    {
        string allid = Request.Form["checkbox"];
        if (!String.IsNullOrEmpty(allid))
        {
            bool b = new ArticleBll().Update1(datatable, "Verific", "0", allid);
            if (b)
            {
                BasePage.JscriptPrint(Page, "批量操作成功！", "article.aspx?mid=" + mid + "&ac=sh");
            }
        }
        else
        {
            BasePage.Alertback(Page, "请先选择要操作的选项ID");
            return;
        }
    }

    //删除还原
    protected void Unnamed3_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        int id = BasePage.GetRequestId(delid);

        bool b = new ArticleBll().Update1(datatable, "IsDel", "0", id.ToString());
        if (b)
        {
            
            BasePage.JscriptPrint(Page, "还原成功！", "Article.aspx?ac=del&Tid=" + tid + "&mid=" + mid + "&language=" + Language);
        }
    }

    //回收站中彻底删除
    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        int id = BasePage.GetRequestId(delid);
        
        bool b = new CommonBll().Delete(datatable, id);
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "Article.aspx?ac=del&Tid=" + tid + "&mid=" + mid + "&language=" + Language);
        }
    }

    //批量处理
    protected void Button3_Click(object sender, EventArgs e)
    {
        string radiobutton = Request.Form["radiobutton"];
        string allid = articleid.Text;
        if (Request.UrlReferrer != null)
        {
            ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
        }
        if (String.IsNullOrEmpty(radiobutton) || String.IsNullOrEmpty(allid))
        {
            BasePage.Alertback("请选择要操作的选项！");
            Response.End();
        }

        if (radiobutton == "1")//移动栏目
        {
            if (String.IsNullOrEmpty(ddlclassforall.SelectedValue))
            {
                BasePage.Alertback("请选择要移动到的栏目");
                Response.End();
            }
            else
            {
                bool b = new ArticleBll().Update1(datatable, "Tid", ddlclassforall.SelectedValue, allid);
                BasePage.AlertAndRedirect("转移成功", ViewState["UrlReferrer"].ToString());
            }
        }
        else if (radiobutton == "2")
        { //属性
            string ddlsx1 = ddlsx.SelectedValue;
            bool b = false;
            if (ddlsx1 == "0")
            { //设为热门
                b = new ArticleBll().Update1(datatable, "IsPopular", "1", allid);
            }
            else if (ddlsx1 == "1")
            { //取消热门
                b = new ArticleBll().Update1(datatable, "IsPopular", "0", allid);
            }
            else if (ddlsx1 == "2")
            { //设为推荐
                b = new ArticleBll().Update1(datatable, "IsRecommend", "1", allid);
            }
            else if (ddlsx1 == "3")
            { //取消推荐
                b = new ArticleBll().Update1(datatable, "IsRecommend", "0", allid);
            }
            else if (ddlsx1 == "4")
            { //设为最新
                b = new ArticleBll().Update1(datatable, "IsNew", "1", allid);
            }
            else if (ddlsx1 == "5")
            { //取消最新
                b = new ArticleBll().Update1(datatable, "IsNew", "0", allid);
            }
            if (b)
            {
                BasePage.AlertAndRedirect("设置成功", ViewState["UrlReferrer"].ToString());
            }
        }
        else if (radiobutton == "3")
        { //放入回收站
            
            bool b = new ArticleBll().Update1(datatable, "IsDel", "1", allid);
            BasePage.AlertAndRedirect("放入回收站成功", ViewState["UrlReferrer"].ToString());
        }
        else if (radiobutton == "8")
        { //彻底删除
           
            bool b = new CommonBll().DeleteList(datatable, allid);
            BasePage.AlertAndRedirect("彻底删除成功", ViewState["UrlReferrer"].ToString());
        }
        else if (radiobutton == "4")//改变作者
        {
            if (!String.IsNullOrEmpty(txtAuthor.Text))
            {
                bool b = new ArticleBll().Update1(datatable, "Author", txtAuthor.Text.Trim(), allid);
                BasePage.AlertAndRedirect("新作者改变成功", ViewState["UrlReferrer"].ToString());
            }
            else
            {
                BasePage.Alertback("请输入新作者名！");
                Response.End();
            }
        }
        else if (radiobutton == "5")
        { //来源
            if (!String.IsNullOrEmpty(txtOrigin.Text))
            {
                bool b = new ArticleBll().Update1(datatable, "Origin", txtOrigin.Text.Trim(), allid);
                BasePage.AlertAndRedirect("新来源改变成功", ViewState["UrlReferrer"].ToString());
            }
            else
            {
                BasePage.Alertback("请输入新来源！");
                Response.End();
            }
        }
        else if (radiobutton == "6")
        {
            //浏览次数
            if (!String.IsNullOrEmpty(txthits.Text))
            {
                bool b = new ArticleBll().Update1(datatable, "Hits", txthits.Text.Trim(), allid);
                BasePage.AlertAndRedirect("浏览次数修改成功", ViewState["UrlReferrer"].ToString());
            }
            else
            {
                BasePage.Alertback("请输入浏览次数！");
                Response.End();
            }
        }
        else if (radiobutton == "7")
        {
            //修改时间
            if (!String.IsNullOrEmpty(txteditdata.Text))
            {
                bool b = new ArticleBll().Update1(datatable, "EditDate", txteditdata.Text.Trim(), allid);
                BasePage.AlertAndRedirect("修改时间批量操作成功", ViewState["UrlReferrer"].ToString());
            }
            else
            {
                BasePage.Alertback("请输入修改时间！");
                Response.End();
            }
        }
    }

    //列表可选字段
    protected bool showhidelist(string v)
    {
        bool b = false;
        if (!String.IsNullOrEmpty(showhidelistvalue))
        {
            string[] a = showhidelistvalue.Split('|');
            if (BasePage.ArrayExist(a[0], v))
            {
                b = true;
            }
        }
        return b;
    }

}