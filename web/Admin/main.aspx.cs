using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Utility;
using GL.Bll;
public partial class Admin_main : System.Web.UI.Page
{
    protected string uploadfile;
    protected string html;
    protected string wwwroot;
    protected string aspnet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string checklogin = new AdminBll().CheckLogin("no");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
             ((Literal)Master.FindControl("breadcrumbs")).Text = Cookies.GetCookie("User_Name") + " 您好！欢迎使用" + new CommonBll().GetTitle("GL_WebConfig", "SiteName", 1) + "网站管理后台。";
        }

    }


    //计算空间占用大小
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        uploadfile = FileManage.GetFileSize(BasePage.GetRequestId(FileManage.GetDirectoryLength(System.Web.HttpContext.Current.Server.MapPath("../UpLoadFile")).ToString()));
        html = FileManage.GetFileSize(BasePage.GetRequestId(FileManage.GetDirectoryLength(System.Web.HttpContext.Current.Server.MapPath("../html")).ToString()));
        wwwroot = FileManage.GetFileSize(BasePage.GetRequestId(FileManage.GetDirectoryLength(Request.ServerVariables["APPL_PHYSICAL_PATH"]).ToString()));

    }



}
