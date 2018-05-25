using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;
using System.Data;
public partial class Admin_Link : System.Web.UI.Page
{
    protected int id = 0;
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a href=\"Link.aspx\" class=\"home\">友情链接</a><a href=\"?action=Add\" class=\"add\">添加链接</a>";
            string checklogin = new AdminBll().CheckLogin("4");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }

            if (!String.IsNullOrEmpty(Request.QueryString["action"]))
            {
                action = Request.QueryString["action"];
            }
            else
            {
                action = "show";
            }

            id = BasePage.GetRequestId(Request.QueryString["id"]);

            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                LinkModel model = new Linkll().GetModel(id);
                bool b = new CommonBll().Exists("GL_Link", id);
                if (b)
                {
                    txtName.Text = model.LinkName;
                    txtUrl.Text = model.LinkUrl;
                    txthide.Text = model.Hide.ToString();
                    txtTypelink.Text = model.LinkType.ToString();
                    txtClassPic.Text = model.LinkLogo;
                    txtUrl.Text = model.LinkUrl;
                    txtpx.Text = model.Px.ToString();
                    txthits.Text = model.Hits.ToString();
                    txtIntro.Text = model.LinkIntro;
                }


            }
            else
            {
                string keywords = Request.QueryString["keywords"];

                string strwhere = "id is not null";
                if (!String.IsNullOrEmpty(Request.QueryString["LinkType"]))
                {
                    int LinkType = BasePage.GetRequestId(Request.QueryString["LinkType"]);
                    strwhere += " and LinkType=" + LinkType;
                }
                if (!String.IsNullOrEmpty(Request.QueryString["keywords"]))
                {
                    strwhere += " and LinkName like '%" + keywords + "%'";
                }
                DataSet ds = new DataSet();
                int PageSize = 25;
                int PageIndex = BasePage.GetRequestId(Request.QueryString["Page"]); //当前第几页
                ds = new CommonBll().GetListPage("", "GL_Link", strwhere, "px desc,id desc", PageSize, PageIndex);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
                int totalrecord = new CommonBll().GetRecordCount("GL_Link", strwhere);//总记录数
                if (totalrecord == 0)
                {
                    txtpage.Text = "<p align=\"center\" class=\"red\">暂无链接</p>";
                }
                else if (totalrecord > PageSize)
                {
                    txtpage.Text = GL.Utility.GetPage.GetAspxPager(totalrecord, PageSize, PageIndex);
                }



            }


        }
    }

    //del
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        int id = BasePage.GetRequestId(delid);

        bool b = new CommonBll().Delete("GL_Link", id);
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "#");
        }
    }

    //delall
    protected void Button2_Click(object sender, EventArgs e)
    {
        string allid = Request.Form["checkbox"];
        if (!String.IsNullOrEmpty(allid))
        {
            bool b = new CommonBll().DeleteList("GL_Link", allid);
            if (b)
            {
                BasePage.JscriptPrint(Page, "批量删除成功！", "#");
            }
        }
        else
        {
            BasePage.Alertback("请选择要删除的选项！");
            return;
        }

    }

    //快速查看
    protected void Button1_Click(object sender, EventArgs e)
    {
        string keywords = txtkeywords.Text.Trim();
        if (keywords == "请输入关键字")
        {
            keywords = "";
        }
        Response.Redirect("Link.aspx?LinkType=" + ddlclassname.SelectedValue + "&keywords=" + keywords);
    }

    //add or edit
    protected void Button3_Click(object sender, EventArgs e)
    {
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        LinkModel model = new LinkModel();
        model.LinkName = txtName.Text;
        model.LinkUrl = txtUrl.Text;
        model.LinkLogo = txtClassPic.Text;
        model.Px = int.Parse(txtpx.Text);
        model.LinkType = int.Parse(txtTypelink.SelectedValue);
        model.LinkIntro = txtIntro.Text;
        model.Hide = int.Parse(txthide.SelectedValue);
        model.Hits = int.Parse(txthide.Text);
        model.AddTime = DateTime.Now;
        model.id = id;
        if (id == 0)
        {
            int i = new Linkll().Add(model);
            if (i > 0)
            {
                BasePage.JscriptPrint(Page, "添加成功！", "Link.aspx");
            }
        }
        else
        {
            bool bb = new Linkll().Update(model);
            if (bb)
            {
                BasePage.JscriptPrint(Page, "修改成功！", "Link.aspx");
            }
        }
    }
}