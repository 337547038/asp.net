using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;
public partial class Admin_searchkey : System.Web.UI.Page
{
    protected string datatable = "GL_Search";
    protected string ac = "";
    private int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        ac = Request.QueryString["ac"];
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a href=\"searchkey.aspx\" class=\"home\">搜索关键词</a>";
            string checklogin = new AdminBll().CheckLogin("no");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
            if (id != 0)
            {
                SearchModel s = new SearchBll().GetModel(id);
                txtkey.Text = s.keyword;
                txtnum.Text = s.num.ToString();
                txtpx.Text = s.px.ToString();
            }
            else
            {
                int PageSize = 30;
                int PageIndex = BasePage.GetRequestId(Request.QueryString["Page"]);
                string strwhere = "";
                int all = new CommonBll().GetRecordCount(datatable, strwhere);
                if (all > 0)
                {
                    Repeater1.DataSource = new CommonBll().GetListPage("", datatable, strwhere, "px desc,num desc", PageSize, PageIndex);
                    Repeater1.DataBind();
                    if (all > PageSize)
                    {
                        fy.InnerHtml = GetPage.GetAspxPager(all, PageSize, PageIndex);
                    }
                }
            }
        }
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {

        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        int id = BasePage.GetRequestId(delid);

        bool b = new CommonBll().Delete(datatable, id);
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "searchkey.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txtkey.Text) && !String.IsNullOrEmpty(txtnum.Text))
        {
            SearchModel s = new SearchModel();
            s.keyword = txtkey.Text;
            s.num = BasePage.GetRequestId(txtnum.Text);
            s.px = BasePage.GetRequestId(txtpx.Text);
            s.id = id;
            bool b = new SearchBll().Update(s);
            if (b)
            {
                BasePage.JscriptPrint(Page, "修改成功！", "searchkey.aspx");
            }
        }
    }
}
