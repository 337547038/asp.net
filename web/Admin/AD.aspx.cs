using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;
using System.Text;
public partial class Admin_AD : System.Web.UI.Page
{
    protected string action = "";
    protected int id;//广告id
    protected string datatable = "GL_AD";
    protected int tid;//广告位id
    protected void Page_Load(object sender, EventArgs e)
    {
        action = Request.QueryString["ac"];
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        string checklogin = new AdminBll().CheckLogin("15");
        if (checklogin != "true")
        {
            BasePage.Alertback(checklogin);
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            string bread = "<a href=\"AD.aspx\" class=\"home\">广告列表</a>";
            if (showhide("22"))
            {
                bread += "<a href=\"AD.aspx?ac=add1\" class=\"add\">添加广告位</a>";
            }
            if (showhide("18"))
            {
                bread += "<a class=\"add\" href=\"AD.aspx?ac=add&tid ="+tid+"\">添加新广告</a>";
            }
             ((Literal)Master.FindControl("breadcrumbs")).Text = bread;
            tid = BasePage.GetRequestId(Request.QueryString["tid"]);
            if (String.IsNullOrEmpty(action))//取得列表
            {
                string strwhere = "Tid=0";//显示广告位和单条广告Tid都为0
                if (tid != 0)
                {
                    strwhere = "Tid=" + tid;
                    txttxt.Text = "<span class=\"red\">查看广告位下的广告</span>";
                }
                int pagesize = 20;
                int pageindex = BasePage.GetRequestId(Request.QueryString["Page"]);
                Repeater1.DataSource = new CommonBll().GetListPage("", datatable, strwhere, "ADShowHide asc,isad desc,px desc,id desc", pagesize, pageindex);
                Repeater1.DataBind();
                int all = new CommonBll().GetRecordCount(datatable, strwhere);
                if (all > pagesize)
                {
                    txtfy.Text = GetPage.GetAspxPager(all, pagesize, pageindex);
                }
                else if (all <= 0)
                {
                    txtfy.Text = "<p class=\"red\" align=\"center\">无记录</p>";
                }
            }
            else if (action == "add")//添加广告
            {
                //已有广告列表
                ddltid.DataSource = new CommonBll().GetList("", datatable, "IsAD=1", "px desc,id desc");
                ddltid.DataTextField = "ADtitle";
                ddltid.DataValueField = "id";
                ddltid.DataBind();
                ddltid.Items.Insert(0, new ListItem("无广告位", "0"));
                ddltid.SelectedValue = tid.ToString();
                if (id != 0)//修改广告时
                {
                    ADModel ad = new ADBll().GetModel(id);
                    txtttile.Text = ad.ADtitle;
                    ddltid.SelectedValue = ad.Tid.ToString();
                    rashowhide.SelectedValue = ad.ADShowHide.ToString();
                    Rdtype.SelectedValue = ad.ADtype.ToString();
                    txtfile.Text = ad.ADurl;
                    txthttp.Text = ad.ADhttpurl;
                    txtheight1.Text = ad.ADheight.ToString();
                    txtwidth1.Text = ad.ADwidth.ToString();
                    txtpx.Text = ad.Px.ToString();
                    txtcontents.Text = ad.ADcontents;
                    Button2.Text = "修改广告";
                }
            }
            else if (action == "add1" && id != 0)//修改广告位时
            {
                ADModel ame = new ADBll().GetModel(id);
                txtwtitle.Text = ame.ADtitle;
                Rshowhide.SelectedValue = ame.ADShowHide.ToString();
                txtwwidth.Text = ame.ADwidth.ToString();
                txtwheight.Text = ame.ADheight.ToString();
                txtwcontents.Text = ame.ADcontents;
                txtadpx.Text = ame.Px.ToString();
                Button1.Text = "修改广告位";
            }
            else if (action == "del" && id != 0)
            { //删除
                bool b = false;
                //检查是否为广告位，如果是广告位则检查有没广告
                int i = new CommonBll().GetRecordCount(datatable, "id=" + id + " and IsAD=1");
                if (i > 0)
                {
                    //是广告位，检查有没广告
                    int ii = new CommonBll().GetRecordCount(datatable, "Tid=" + id);
                    if (ii > 0)
                    {
                        BasePage.Alertback("请先删除此广告位下的广告。");
                        Response.End();
                    }
                    else
                    {
                        //检查有没广告位管理权
                        if (showhide("22"))
                        {//广告位管理 
                            b = new CommonBll().Delete(datatable, id);//删除广告位
                        }
                        else
                        {
                            BasePage.Alertback("删除失败，您不能删除此广告位！");
                            Response.End();
                        }
                    }
                }
                else
                {
                    //非广告位
                    if (showhide("19"))
                    { //删除广告权限
                        b = new CommonBll().Delete(datatable, id);//删除广告位
                    }
                    else
                    {
                        BasePage.Alertback("删除失败，您不能删除此广告！");
                        Response.End();
                    }
                }
                if (Request.UrlReferrer != null)
                {
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                }
                if (b)
                {
                    BasePage.JscriptPrint(Page, "删除成功！", ViewState["UrlReferrer"].ToString());
                }
            }
            else if (action == "clone" && id != 0)
            {
                //克隆一条广告
                if (showhide("18"))
                {
                    string filename = "ADtitle,Tid,IsAD,ADtype,ADurl,ADhttpurl,ADcontents,Px,ADheight,ADwidth,ADShowHide";
                    string cstrwhere = "id=" + id;
                    int ci = new CommonBll().CloneData(filename, datatable, cstrwhere);
                    if (ci > 0)
                    {
                        if (Request.UrlReferrer != null)
                        {
                            ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                        }
                        BasePage.JscriptPrint(Page, "克隆成功！", ViewState["UrlReferrer"].ToString());
                    }
                }
            }
        }
    }

    //权限
    protected bool showhide(string p)
    {
        bool b = false;
        b = BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), p);
        return b;
    }

    //添加广告位
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (showhide("22"))
        {
            ADModel am = new ADModel();
            am.ADtitle = txtwtitle.Text;
            am.ADShowHide = BasePage.GetRequestId(Rshowhide.SelectedValue);
            am.ADwidth = BasePage.GetRequestId(txtwwidth.Text);
            am.ADheight = BasePage.GetRequestId(txtwheight.Text);
            am.ADcontents = txtwcontents.Text;
            am.IsAD = 1;//0为广告，1为广告位
            am.Tid = 0;//广告位和单条广告时tid都为0
            am.Px = BasePage.GetRequestId(txtadpx.Text);
            am.id = id;
            if (id == 0)
            {
                int i = new ADBll().Add(am);
               
                if (i > 0)
                {
                    BasePage.JscriptPrint(Page, "添加成功！", "AD.aspx?tid=" + i);
                }

            }
            else
            {
                bool b = new ADBll().Update(am);
                if (b)
                {
                    BasePage.JscriptPrint(Page, "修改成功！", "AD.aspx?tid=" + id);
                }
            }
        }
        else
        {
            BasePage.Alertback("添加失败，您不能添加广告位！");
            Response.End();
        }
    }


    ////添加广告
    protected void Button2_Click(object sender, EventArgs e)
    {
        int adtid = BasePage.GetRequestId(ddltid.SelectedValue);//已有广告位
        int adtype = BasePage.GetRequestId(Rdtype.SelectedValue);//展示类型
        int adwidth = BasePage.GetRequestId(txtwidth1.Text), adheight = BasePage.GetRequestId(txtheight1.Text);
        ADModel am = new ADModel();
        am.ADtitle = txtttile.Text;
        am.Tid = adtid;
        am.ADShowHide = BasePage.GetRequestId(rashowhide.SelectedValue);
        am.ADtype = adtype;
        am.ADurl = txtfile.Text;
        am.ADhttpurl = txthttp.Text;
        am.Px = BasePage.GetRequestId(txtpx.Text);
        am.IsAD = 0;
        //如果已有广告位时，宽高读取广告位的
        if (adtid != 0)
        {
            ADModel ad = new ADBll().GetModel(adtid);
            adwidth = BasePage.GetRequestId(ad.ADwidth.ToString());
            adheight = BasePage.GetRequestId(ad.ADheight.ToString());
        }
        am.ADwidth = adwidth;
        am.ADheight = adheight;

        //展示类型为代码时
        if (adtype == 2)
        {
            //代码
            am.ADcontents = txtcontents.Text;
        }
        
        else if (adtype == 1)
        {
            //图片
            if (String.IsNullOrEmpty(txthttp.Text.Trim()) || txthttp.Text == "#")
            {
                am.ADcontents = "<img src=\"" + txtfile.Text.Trim() + "\" width=\"" + adwidth + "\" height=\"" + adheight + "\" alt=\"\" />";
            }
            else
            {
                am.ADcontents = "<a href=\"" + txthttp.Text + "\"><img src=\"" + txtfile.Text.Trim() + "\" width=\"" + adwidth + "\" height=\"" + adheight + "\" alt=\"\" /></a>";
            }
        }

        am.id = id;
        string gourl = "";
        if (ddltid.SelectedValue == "0")
        {
            gourl = "AD.aspx";
        }
        else
        {
            gourl = "AD.aspx?tid=" + ddltid.SelectedValue;
        }
        if (id == 0)
        {
            if (showhide("18"))
            {
                int i = new ADBll().Add(am);
                if (i > 0)
                {
                    BasePage.JscriptPrint(Page, "添加成功！", gourl);
                }
            }
            else
            {
                BasePage.Alertback("添加失败，你不能添加广告！");
                Response.End();
            }
        }
        else
        {
            bool b = new ADBll().Update(am);
            if (b)
            {
                BasePage.JscriptPrint(Page, "修改成功！", gourl);
            }
        }

    }

    protected string Get0(string id, string isad)
    {
        string h = "";
        //如果是广告位
        if (isad == "1")
        {
            h = "<a href=\"?tid=" + id + "\">查看已有广告</a>&nbsp;";
            if (showhide("18"))//站点广告添加权限
            {
                h += " <a href=\"?ac=add&tid=" + id + "\">添加广告</a>&nbsp;";
            }
            if (showhide("22"))
            { //站点广告位管理，这时才能删除广告位
                h += "<a href=\"?ac=add1&id=" + id + "\">修改</a> <a href=\"?ac=del&id=" + id + "\">删除</a>";
            }
        }
        else if (isad == "0")
        {
            h = "<a href=\"?ac=add&id=" + id + "\">修改</a>&nbsp;";
            if (showhide("19"))
            { //删除广告
                h += "<a href=\"?ac=del&id=" + id + "\">删除</a>&nbsp;";
            }
            if (showhide("18"))
            { //有添加广告权时才能克隆
                h += "<a href=\"?ac=clone&id=" + id + "\">克隆</a>";
            }
        }
        return h;
    }


}