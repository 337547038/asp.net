using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GL.Bll;
using GL.Model;
using GL.Utility;

public partial class Admin_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userid = BasePage.GetRequestId(Cookies.GetCookie("User_Id"));
        if (userid == 1 || userid == 2)
        {

            if (!Page.IsPostBack)
            {
                ((Literal)Master.FindControl("breadcrumbs")).Text = "<span class=\"home\">管理员管理</span><a href=\"AdminAdd.aspx\" class=\"add\">添加管理员</a>";
                string checklogin = new AdminBll().CheckLogin("no");
                if (checklogin != "true")
                {
                    BasePage.Alertback(checklogin);
                    Response.End();
                }
                string strwhere = "";
                if (Cookies.GetCookie("User_Id") == "2")//屏蔽超级管理
                {
                    strwhere = "id>1";
                }
                DataSet ds = new DataSet();
                //ds = new AdminBll().GetList(strwhere);
                ds = new CommonBll().GetList("", "gl_admin", strwhere, "LastLoginTime desc");
                Repeater1.DataSource = ds;
                Repeater1.DataBind();

            }
        }
        else
        {
            //BasePage.Alertback("您还没登录或没有管理此内容权限！");
            //Response.End();
            //其它管理员直接跳到修改页面
            Response.Redirect("AdminAdd.aspx?id=" + userid);

        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        if (delid == "1")
        {
            BasePage.Alertback(Page, "不能删除超级管理员");
            return;
        }
        bool b = new CommonBll().DeleteList("GL_Admin", delid);
        if (Request.UrlReferrer != null)
            ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
        if (b)
        {
            BasePage.AlertAndRedirect(Page, "删除成功！", ViewState["UrlReferrer"].ToString());

        }
    }
}