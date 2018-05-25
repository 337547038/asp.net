using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;

public partial class Admin_Error : System.Web.UI.Page
{
    protected string action = "";
    protected int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a class=\"home\" href=\"error.aspx\">运行错误记录</a>";
            string checklogin = new AdminBll().CheckLogin("20");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
            string t = GreateFiles.Read_File(Server.MapPath("~/error.txt"));
            if (!String.IsNullOrEmpty(t))
            {
                txtcon.Text = t.Replace("\r", "<br/>");
            }
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        GreateFiles.CreateFile(Server.MapPath("~/error.txt"), "");
        txtcon.Text = "";
        BasePage.JscriptPrint(Page, "清空成功！", "error.aspx");
    }
}