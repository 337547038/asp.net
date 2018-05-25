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
public partial class Admin_Products : GL.Bll.ClassBll
{
    private string datatable = "";
    protected string ItemName = "";
    protected int mid = 1;
    protected string Language = "";
    private string lansql = "";
    public string ac = "";
    protected bool sxddl = false;//属性查找显示
    protected bool verific = false;//发表是否需要审核
    protected bool del = false;//删除权限
    private string showhidelistvalue = "";//列表可选字段值
    private int cid;
    protected void Page_Load(object sender, EventArgs e)
    {
        mid = BasePage.GetRequestId(Request.QueryString["mid"]);
        if (mid == 0)
        {
            mid = 2;
        }
        //根据模型找出数据表名
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
            ac = Request.QueryString["ac"];
            verific = BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "ms" + mid);
            del = BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "md" + mid);
            cid = BasePage.GetRequestId(Request.QueryString["cid"]);

            string company = Request.QueryString["company"];//按公司搜索
            int companyId = BasePage.GetRequestId(Request.QueryString["companyid"]);
            txtCompany.Text = company;

            if (!String.IsNullOrEmpty(mo.ModeContent))
            {
                //0模型内容可选字段`1模型栏目可选字段`2(以后添加)`3(以后添加)`4提示语`5发表审核选择
                string[] a = mo.ModeContent.Split('`');
                //下拉属性
                if (BasePage.ArrayExist(a[0], "4"))
                {
                    //推荐属性
                    sxddl = true;
                    ddlshuxi.Items.Insert(0, new ListItem("推荐", "1"));
                }
                if (BasePage.ArrayExist(a[0], "11"))
                {
                    //热卖属性
                    sxddl = true;
                    //ddlshuxi.Items.Insert(0, new ListItem("热门", "2"));
                    ddlshuxi.Items.Insert(0, new ListItem("热门", "2"));
                }
                if (BasePage.ArrayExist(a[0], "26"))
                {
                    //最新属性
                    sxddl = true;
                    ddlshuxi.Items.Insert(0, new ListItem("最新", "3"));
                }
                if (BasePage.ArrayExist(a[0], "27"))
                {
                    //最新属性
                    sxddl = true;
                    ddlshuxi.Items.Insert(0, new ListItem("特价", "4"));
                }
                if (sxddl)
                {
                    ddlshuxi.Items.Insert(0, new ListItem("按属性查看", ""));
                }
                showhidelistvalue = a[3];//0录入3添加时间4修改时间5属于6点击7优先
                if (a[5] == "0")//模型不需要审核，隐藏审核链接
                {
                    verific = true;
                }
            }

            if (!String.IsNullOrEmpty(Request.QueryString["language"]))
            {
                Language = BasePage.GetRequestId(Request.QueryString["language"]).ToString();
                lansql = " and Languagen=" + BasePage.GetRequestId(Language);
            }
            string strwhere = "id is not null";
            int sx = BasePage.GetRequestId(Request.QueryString["sx"]);//属性
            ddlshuxi.SelectedValue = sx.ToString();

            DrLanguage.SelectedValue = Language.ToString();
            string keywords = Request.QueryString["keywords"];

            if (String.IsNullOrEmpty(ac))
            {
                strwhere += " and IsDel=0 and Verific=0";
            }
            else if (ac == "del")
            {
                //回收站
                strwhere += " and IsDel=1";
                // actxt.InnerHtml = ItemName + "回收站列表";
            }
            else if (ac == "sh")
            {
                strwhere += " and Verific=1";
                //actxt.InnerHtml = ItemName + "审核列表";
            }
            if (cid != 0)
            {
                strwhere += " and (Tid=" + cid;
                //读取所有子级
                if (showhidelist("8"))
                {
                    DataTable dt = new ClassBll().GetListTree(mid, cid, "");
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
                strwhere += lansql;
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
                    case 4:
                        sht = "IsSpecial='1'";
                        break;
                }
                strwhere += " and " + sht + "";
            }
            //按公司查看
            if (companyId != 0)
            {
                strwhere += " and ShopId=" + companyId;
            }
            if (!String.IsNullOrEmpty(keywords))
            {
                strwhere += " and Title like '%" + keywords + "%'";
            }
            ////列出所有栏目
            //string allclass = "ParentId=" + cid + " and ModelId=" + mid + lansql;
            //Repeater2.DataSource = new CommonBll().GetList("", "GL_Class", allclass, "px desc,id desc");
            //Repeater2.DataBind();

            // Response.Write(strwhere);
            //Response.End();

            //绑定栏目下拉
            ClassTreeBind(0, "所有栏目", mid, this.ddlclassname, "ClassType=0" + lansql);
            ClassTreeBind(0, "请选择栏目", mid, this.changclass, "ClassType=0" + lansql);
            if (!string.IsNullOrEmpty(Request.Params["Cid"]))
            {
                ddlclassname.SelectedValue = Request.Params["Cid"].Trim();
            }
            //批量处理的ID
            articleid.Text = Request.QueryString["allid"];
            int PageSize = 20;
            int PageIndex = BasePage.GetRequestId(Request.QueryString["Page"]); //当前第几页

            Repeater1.DataSource = new CommonBll().GetListPage("", datatable, strwhere, "px desc,EditDate desc", PageSize, PageIndex);
            Repeater1.DataBind();

            int totalrecord = new CommonBll().GetRecordCount(datatable, strwhere);//总记录数
            if (totalrecord == 0)
            {
                txtpage.Text = "<p align=\"left\" class=\"red\">暂无产品</p>";
            }
            else if (totalrecord > PageSize)
            {
                txtpage.Text = GL.Utility.GetPage.GetAspxPager(totalrecord, PageSize, PageIndex);
            }


            string bx = "<a href=\"Products.aspx?mid=" + mid + "\" class=\"home\">" + ItemName + "管理</a>";
            bx += "<a href=\"ProductsAdd.aspx?mid=" + mid + "&language=" + Language + "\" class=\"add\">添加" + ItemName + "</a>";
            if (!verific)
            {
                bx += "<a href=\"?mid=" + mid + "&language=" + Language + "&ac=sh\" class=\"sh\">审核" + ItemName + "</a>";
            }
            if (del)
            {
                bx += "<a href=\"?ac=del&mid=" + mid + "&language=" + Language + "\" class=\"del\">" + ItemName + "回收站</a>";
            }
                ((Literal)Master.FindControl("breadcrumbs")).Text = bx;
        }

    }


    //delete 放入回收站
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        int id = BasePage.GetRequestId(lb.CommandArgument);

        bool b = new ProductsBll().Update1(datatable, "IsDel", "1", id.ToString());
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "Products.aspx?mid=" + mid + "&Tid=" + cid + "&language=" + Language);
        }
    }

    //彻底删除
    protected void Unnamed2_Click(object sender, EventArgs e)
    {

        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        int id = BasePage.GetRequestId(lb.CommandArgument);

        bool b = new CommonBll().Delete(datatable, id);
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "Products.aspx?ac=del&mid=" + mid + "&Tid=" + cid + "&language=" + Language);
        }
    }

    //还原
    protected void Unnamed3_Click(object sender, EventArgs e)
    {

        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        int id = BasePage.GetRequestId(lb.CommandArgument);
        bool b = new ProductsBll().Update1(datatable, "IsDel", "0", id.ToString());
        if (b)
        {

            BasePage.JscriptPrint(Page, "还原成功！", "Products.aspx?ac=del&mid=" + mid + "&Tid=" + cid + "&language=" + Language);
        }
    }

    //刷新
    protected void Unnamed4_Click(object sender, EventArgs e)
    {

        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        int id = BasePage.GetRequestId(lb.CommandArgument);
       
         bool b = new ProductsBll().Updatezd(datatable, "EditDate='"+ BasePage.formatDateTime(DateTime.Now.ToString()) + "'", id);
        Response.Write(DateTime.Now);


        if (Request.UrlReferrer != null)
        {
            ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
        }
        if (b)
        {

            BasePage.JscriptPrint(Page, "刷新成功！", ViewState["UrlReferrer"].ToString());
        }
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
                BasePage.JscriptPrint(Page, "批量操作成功！", "products.aspx?mid=" + mid + "&ac=sh");
            }
        }
        else
        {
            BasePage.Alertback(Page, "请先选择要操作的选项ID");
            return;
        }
    }

    //search
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Products.aspx?mid=" + Request.QueryString["mid"] + "&language=" + Language + "&cid=" + ddlclassname.SelectedValue + "&companyid=" + txtCompanyId.Value + "&company=" + txtCompany.Text + "&keywords=" + txtkeywords.Text.Trim().Replace("请输入关键字", ""));
    }

    //批量
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(articleid.Text))
        {
            string allid = articleid.Text;
            string radiobutton = Request.Form["radiobutton"];
            if (Request.UrlReferrer != null)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            }
            if (String.IsNullOrEmpty(radiobutton))
            {
                BasePage.Alertback(Page, "请选择要批量处理的选项");
                return;
            }
            // allid = allid.Substring(0, allid.Length - 1);//去掉最后一个,

            ProductsBll ArticleBll = new ProductsBll();
            if (radiobutton == "1")
            {
                if (!String.IsNullOrEmpty(changclass.SelectedValue))
                {
                    bool b = ArticleBll.Update1(datatable, "Tid", changclass.SelectedValue, allid);
                    if (b)
                    {
                        BasePage.JscriptPrint(Page, "批量处理成功！", ViewState["UrlReferrer"].ToString());
                    }
                }
                else
                {
                    BasePage.Alertback(Page, "请选择要移动到的新栏目");
                    return;
                }
            }
            if (radiobutton == "2")
            {
                if (!String.IsNullOrEmpty(ddlsx.SelectedValue))
                {
                    string ddlsx1 = ddlsx.SelectedValue;
                    bool b = false;
                    if (ddlsx1 == "0")//设为推荐
                    {
                        b = ArticleBll.Update1(datatable, "IsRecommend", "1", allid);
                    }
                    else if (ddlsx1 == "1")
                    {
                        b = ArticleBll.Update1(datatable, "IsRecommend", "0", allid);
                    }
                    else if (ddlsx1 == "2")//设为热卖
                    {
                        b = ArticleBll.Update1(datatable, "IsPopular", "1", allid);
                    }
                    else if (ddlsx1 == "3")
                    {
                        b = ArticleBll.Update1(datatable, "IsPopular", "0", allid);
                    }
                    else if (ddlsx1 == "4")//设为最新
                    {
                        b = ArticleBll.Update1(datatable, "IsNew", "1", allid);
                    }
                    else if (ddlsx1 == "5")//取消最新
                    {
                        b = ArticleBll.Update1(datatable, "IsNew", "0", allid);
                    }
                    else if (ddlsx1 == "6")//设为特价
                    {
                        b = ArticleBll.Update1(datatable, "IsSpecial", "1", allid);
                    }
                    else if (ddlsx1 == "7")//取消特价
                    {
                        b = ArticleBll.Update1(datatable, "IsSpecial", "0", allid);
                    }
                    if (b)
                    {
                        BasePage.JscriptPrint(Page, "批量处理成功！", ViewState["UrlReferrer"].ToString());
                        return;
                    }
                }
                else
                {
                    BasePage.Alertback(Page, "请选择要操作的属性值");
                    return;
                }
            }
            if (radiobutton == "3")
            {
                //放入回收站
                bool b = ArticleBll.Update1(datatable, "IsDel", "1", allid);
                if (b)
                {
                    BasePage.JscriptPrint(Page, "成功放入回收站！", ViewState["UrlReferrer"].ToString());
                }
            }
            if (radiobutton == "6")
            {
                if (!String.IsNullOrEmpty(txthits.Text.Trim()))
                {
                    bool b = ArticleBll.Update1(datatable, "Hits", txthits.Text.Trim(), allid);
                    if (b)
                    {
                        BasePage.JscriptPrint(Page, "批量操作成功！", ViewState["UrlReferrer"].ToString());
                    }
                }
                else
                {
                    BasePage.Alertback(Page, "请输入浏览次数，且仅能为数字");
                    return;
                }
            }
            if (radiobutton == "7")
            {
                if (!String.IsNullOrEmpty(txteditdata.Text.Trim()))
                {
                    bool b = ArticleBll.Update1(datatable, "EditDate", txteditdata.Text.Trim(), allid);
                    if (b)
                    {
                        BasePage.JscriptPrint(Page, "批量操作成功！", ViewState["UrlReferrer"].ToString());
                    }
                }
                else
                {
                    BasePage.Alertback(Page, "请输入最后修改时间");
                    return;
                }
            }
            if (radiobutton == "8")
            {
                bool b = new CommonBll().DeleteList(datatable, allid);
                if (b)
                {
                    BasePage.JscriptPrint(Page, "彻底删除成功！", ViewState["UrlReferrer"].ToString());
                }
            }

        }
        else
        {
            BasePage.Alertback(Page, "请先选择要操作的选项ID");
            return;
        }
    }


    //GetClassName
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
            ClassName += "[<a href=\"Products.aspx?mid=" + mid + "&cid=" + tid + "\">" + cm.ClassName + "</a>]</span> ";
        }

        return ClassName;
    }

    //按语言查看
    protected void DrLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Products.aspx?mid=" + mid + "&language=" + DrLanguage.SelectedValue);

    }

    //属性改变时
    protected void ddlshuxi_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Products.aspx?mid=" + mid + "&cid=" + Request.QueryString["cid"] + "&sx=" + ddlshuxi.SelectedValue + "&language=" + Language);
    }

    //按栏目查看
    protected void ddlclassname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Products.aspx?mid=" + mid + "&language=" + Language + "&cid=" + ddlclassname.SelectedValue);
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