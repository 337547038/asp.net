using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Utility;
using GL.Model;
using GL.Bll;
using System.Data;
public partial class Admin_SeoAll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string checklogin = new AdminBll().CheckLogin("2");
        if (checklogin != "true")
        {
            BasePage.Alertback(checklogin);
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a href=\"Seoall.aspx\" class=\"home\">SEO批量设置</a><a class=\"add\" href=\"?action=class\">栏目批量设置</a><a href=\"?action=diypage\" class=\"add\">单页批量设置</a>";
            DataSet ds = new DataSet();
            int PageSize = 20;
            int PageIndex = BasePage.GetRequestId(Request.QueryString["Page"]); //当前第几页
            string ac = Request.QueryString["action"];
            if (ac == "class")
            {
                string strwhere = "ClassType=0";
                ds = new CommonBll().GetListPage("", "GL_Class", strwhere, "ModelId asc,px desc,id desc", PageSize, PageIndex);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();


                int totalrecord = new CommonBll().GetRecordCount("GL_Class", strwhere);//总记录数
                txtpage.Text = GL.Utility.GetPage.GetAspxPager(totalrecord, PageSize, PageIndex);
                if (totalrecord > PageSize)
                {
                    txtpage.Text = GL.Utility.GetPage.GetAspxPager(totalrecord, PageSize, PageIndex);
                }
                else
                {
                    txtpage.Text = "";
                }
            }
            if (Request.QueryString["action"] == "diypage")
            {
                string strwhere = "PageType=0";
                ds = new CommonBll().GetListPage("", "GL_DIYPage", strwhere, "id desc", PageSize, PageIndex);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();
                int totalrecord = new CommonBll().GetRecordCount("GL_DIYPage", strwhere);//总记录数
                txtpage.Text = GL.Utility.GetPage.GetAspxPager(totalrecord, PageSize, PageIndex);
                if (totalrecord > PageSize)
                {
                    txtpage.Text = GL.Utility.GetPage.GetAspxPager(totalrecord, PageSize, PageIndex);
                }
                else
                {
                    txtpage.Text = "";
                }

            }

        }
    }

    //save
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool b = false;
        foreach (RepeaterItem Item in Repeater1.Items)
        {
            TextBox txtSeoTitle = (TextBox)Item.FindControl("txtSeoTitle");
            TextBox txtKeyWord = (TextBox)Item.FindControl("txtKeyWord");
            TextBox txtSeoDescription = (TextBox)Item.FindControl("txtSeoDescription");
            HiddenField txtid = (HiddenField)Item.FindControl("HiddenField1");
            ClassModel cm = new ClassModel();
            cm.SeoTitle = txtSeoTitle.Text;
            cm.SeoKeyWord = txtKeyWord.Text;
            cm.SeoDescription = txtSeoDescription.Text;
            cm.id = int.Parse(txtid.Value);
            b = new ClassBll().Updateseo(cm);
        }
        if (b)
        {
            BasePage.JscriptPrint(Page, "批量保存成功！", "SeoAll.aspx?action=" + Request.QueryString["action"]);
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        bool b = false;
        foreach (RepeaterItem Item in Repeater2.Items)
        {
            TextBox txtSeoTitle2 = (TextBox)Item.FindControl("txtSeoTitle2");
            TextBox txtKeyWord2 = (TextBox)Item.FindControl("txtKeyWord2");
            TextBox txtSeoDescription2 = (TextBox)Item.FindControl("txtSeoDescription2");
            HiddenField txtid2 = (HiddenField)Item.FindControl("HiddenField2");
            DiyPageModel dm = new DiyPageModel();
            dm.SeoTitle = txtSeoTitle2.Text;
            dm.SeoKeyword = txtKeyWord2.Text;
            dm.SeoDescription = txtSeoDescription2.Text;
            dm.id = int.Parse(txtid2.Value);
            b = new DiyPageBll().Updateseo(dm);
        }
        if (b)
        {
            BasePage.JscriptPrint(Page, "批量保存成功！", "SeoAll.aspx?action=" + Request.QueryString["action"]);
        }

    }


    protected string GetModelName(string id)
    {
        return new CommonBll().GetTitle("GL_Model", "ModelName", BasePage.GetRequestId(id));
    }
}