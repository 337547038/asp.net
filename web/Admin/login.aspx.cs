using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GL.Bll;
using GL.Model;
using GL.Utility;

public partial class Admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string UserName = txtUserName.Text.Trim();
        string PassWord = txtPassWord.Text.Trim();
        if (UserName == "" || PassWord == "")
        {
            BasePage.Alertback(Page, "请输入用户名和密码");
            return;
        }
        PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PassWord + "fan<>?", "MD5");
        bool b = new AdminBll().ExistName(UserName, PassWord);
        if (b)
        {
            string LastLoginIP = BasePage.GetClientIP();
            string LastLoginTime = DateTime.Now.ToString();
            Cookies.SaveCookie("User_Name", UserName, 0);
            AdminBll ad = new AdminBll();
            ad.UpdateLogin(LastLoginIP, UserName);
            AdminModel model = ad.Getid(UserName);
            Cookies.SaveCookie("ModelPower", model.ModelPower.ToString(), 0);
            Cookies.SaveCookie("LoginTime", model.LoginTime.ToString(), 0);
            Cookies.SaveCookie("User_Id", model.id.ToString(), 0);
            string MD5UserName = FormsAuthentication.HashPasswordForStoringInConfigFile(model.id.ToString() + UserName + "Cookies?", "MD5");
            Cookies.SaveCookie("MD5Name", MD5UserName, 0);
            Response.Redirect("default.aspx");
        }
        else
        {
            BasePage.AlertAndRedirect(Page, "用户名或密码错误！", "Login.aspx");
        }

    }
}
