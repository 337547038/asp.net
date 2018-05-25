using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;
using System.Data;

public partial class Admin_GuestBook : System.Web.UI.Page
{
    protected int id = 0;
    private string showhide = "";
    private string showhidelist = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a href=\"GuestBook.aspx\" class=\"home\">留言管理</a>";
            string checklogin = new AdminBll().CheckLogin("3");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
            id = BasePage.GetRequestId(Request.QueryString["id"]);

            string siteconfig = new WebConfigBll().GetModel(1).SiteConfig;
            if (!String.IsNullOrEmpty(siteconfig))
            {
                string[] a = siteconfig.Split('|');
                if (a.Length > 0)
                {
                    showhide = a[1];
                    showhidelist = a[2];
                }
            }

            if (id != 0)
            {
                GuestBookModel model = new GuestBookBll().GetModel(id);
                bool b = new CommonBll().Exists("GL_GuestBook", id);
                if (b)
                {
                    txtTitle.Text = model.Title;
                    txtUserName.Text = model.UserName;
                    txtTel.Text = model.Tel;
                    txtFax.Text = model.Fax;
                    txtMobile.Text = model.Mobile;
                    txtCompany.Text = model.Company;
                    txtAddress.Text = model.Address;
                    txtEmail.Text = model.Email;
                    txtSiteUrl.Text = model.SiteUrl;
                    txtCode.Text = model.Code;
                    txtAddTime.Text = model.AddTime.ToString();
                    txtQQ.Text = model.QQ;
                    txtWangWang.Text = model.WangWang;
                    txtMSN.Text = model.MSN;
                    txtContents.Text = model.Contents;
                    txtIP.Text = model.IP;
                    txtReply.Text = model.Reply;
                    txtReplyTime.Text = model.ReplyTime.ToString();
                    if (model.Verific == 0)
                    {
                        txtVerific.Checked = true;
                    }
                    if (model.Sex == 0)
                    {
                        txtsex.Text = "先生";
                    }
                    else if (model.Sex == 1)
                    {
                        txtsex.Text = "女士";
                    }
                }
                else
                {
                    BasePage.Alertback("参数出错。");
                    return;
                }


            }
            else
            {
                DataSet ds = new DataSet();
                int PageSize = 25;
                int PageIndex = BasePage.GetRequestId(Request.QueryString["Page"]); //当前第几页

                ds = new CommonBll().GetListPage("", "GL_GuestBook", "", "id desc", PageSize, PageIndex);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
                int totalrecord = new CommonBll().GetRecordCount("GL_GuestBook", "");//总记录数
                if (totalrecord == 0)
                {
                    txtpage.Text = "<p align=\"center\" class=\"red\">暂无相关留言</p>";
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

        bool b = new CommonBll().Delete("GL_GuestBook", id);
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "GuestBook.aspx");
        }
    }

    //Reply
    protected void Button1_Click(object sender, EventArgs e)
    {
        id = BasePage.GetRequestId(Request.QueryString["id"]);

        GuestBookModel model = new GuestBookModel();
        model.ReplyTime = DateTime.Now;
        model.Reply = txtReply.Text;
        model.Contents = txtContents.Text;
        model.id = id;
        if (txtVerific.Checked)
        {
            model.Verific = 0;
        }
        else
        {
            model.Verific = 1;
        }
        bool b = new GuestBookBll().Update1(model);
        if (b)
        {
            BasePage.JscriptPrint(Page, "修改/回复成功！", "GuestBook.aspx");
        }
    }

    //delall
    protected void Button2_Click(object sender, EventArgs e)
    {
        string allid = Request.Form["checkbox"];
        if (!String.IsNullOrEmpty(allid))
        {
            bool b = new CommonBll().DeleteList("GL_GuestBook", allid);
            if (b)
            {
                BasePage.JscriptPrint(Page, "批量删除成功！", "GuestBook.aspx");
            }
        }
        else
        {
            BasePage.Alertback("请选择要删除的选项！");
            return;
        }

    }

    //可选字段隐藏
    protected bool gethide(string eid)
    {
        if (BasePage.ArrayExist(showhide, eid))
        {
            return true;
        }
        return false;
    }
    //列表
    protected bool gethidelist(string eid)
    {
        if (BasePage.ArrayExist(showhidelist, eid))
        {
            return true;
        }
        return false;
    }
}