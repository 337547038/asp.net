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

public partial class Admin_Default : System.Web.UI.Page
{

    protected string siteurl = "";
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


            //model
            //Repeater_model.DataSource = new CommonBll().GetList("", "GL_Model", "ModelLock=0", "id asc");
            //Repeater_model.DataBind();
            DataSet dsm = new CommonBll().GetList("", "GL_Model", "ModelLock=0", "id asc");
            string dsmli = "";
            foreach (DataRow dr in dsm.Tables[0].Rows)
            {
                if (GetPower("z" + dr["id"].ToString()))
                {
                    dsmli += "<li><a href=\"ModelField.aspx?mid=" + dr["id"].ToString() + "\" target=\"main\"> " + dr["ModelName"].ToString() + "字段</a></li>\r";
                }
            }
            txtmodel.Text = dsmli;

            //Article
            DataSet ds = new CommonBll().GetList("", "GL_Model", "ModelLock=0", "id asc");
            string aml = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (GetPower("m" + dr["id"].ToString()))
                {
                    string id = dr["id"].ToString();
                    string url = "Article.aspx?mid=" + id;
                    if (dr["ModelType"].ToString() == "1")
                    {
                        url = "Products.aspx?mid=" + id;
                    }
                    string url2 = "ArticleAdd.aspx?mid=" + id;
                    if (dr["ModelType"].ToString() == "1")
                    {
                        url2 = "ProductsAdd.aspx?mid=" + id;
                    }

                    aml += "<li><a href=\"" + url + "\" target=\"main\">" + dr["ModelName"].ToString() + "</a><span><a href=\"" + url2 + "\" target=\"main\">添加</a></span></li>\r";
                }
            }
            Articlemodel.Text = aml;

            //Class
            //Repeater_Class.DataSource = new CommonBll().GetList("", "GL_Model", "ModelLock=0", "id asc");
            //Repeater_Class.DataBind();

            DataSet dsc = new CommonBll().GetList("", "GL_Model", "ModelLock=0", "id asc");
            string dsclass = "";
            foreach (DataRow dr in dsc.Tables[0].Rows)
            {
                if (GetPower("ce" + dr["id"].ToString()))
                {
                    dsclass += "<li><a href=\"Class.aspx?mid=" + dr["id"].ToString() + "\" target=\"main\"> " + dr["ModelName"].ToString() + "栏目管理</a></li>\r";
                }
            }
            txtClass.Text = dsclass;

            siteurl = new CommonBll().GetTitle("GL_WebConfig", "SiteUrl", 1);
//取得域名
            string cururl = Request.Url.Host.ToString();
            if (!String.IsNullOrEmpty(cururl))
            {

            }
        }
    }

    //修改密码
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    string PassWord = txtPassword.Text.Trim();
    //    if (String.IsNullOrEmpty(PassWord))
    //    {
    //        BasePage.Alertback(Page, "密码不能为空！");
    //        return;
    //    }
    //    PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PassWord+"guilin", "MD5");
    //    bool b = new AdminBll().Updatepsd(PassWord, Cookies.GetCookie("User_Name"));
    //    if (b)
    //    {
    //        BasePage.Alertback(Page, "密码修改成功！");

    //    }
    //}

    //安全退出
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Cookies.ClearCookie("User_Name");
        Cookies.ClearCookie("ModelPower");
        Cookies.ClearCookie("LoginTime");
        Cookies.ClearCookie("Id");
        Cookies.ClearCookie("Login");
        Response.Redirect("login.aspx");
    }


    //Power
    protected bool GetPower(string id)
    {
        bool a = false;
        if (BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), id))
        {
            a = true;
        }
        return a;
    }





}
