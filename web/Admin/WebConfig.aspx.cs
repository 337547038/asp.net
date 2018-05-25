using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;
public partial class Admin_WebConfig : System.Web.UI.Page
{
    protected string showhide = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        shsiteconfig.Visible = false;

        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<span class=\"home\">系统基本设置</span>";
            string checklogin = new AdminBll().CheckLogin("0");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
            if (BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "6"))
            {
                shsiteconfig.Visible = true;
            }
            WebConfigModel wm = new WebConfigBll().GetModel(1);
            txtSiteName.Text = wm.SiteName;
            txtsitetitle.Text = wm.SiteTitle;
            txtsitetitleen.Text = wm.SiteTitleEn;
            txtSiteUrl.Text = wm.SiteUrl;
            txticp.Text = wm.SiteICP;
            
            txtSiteKeyword.Text = wm.SiteKeyword;
            txtSiteKeyworden.Text = wm.SiteKeywordEn;
            txtSiteDescription.Text = wm.SiteDescription;
            txtSiteDescriptionen.Text = wm.SiteDescriptionEn;
            txtsiteemail.Text = wm.SiteMail;
            txtEmailsmtp.Text = wm.EmailSMTP;
            txtSmtpName.Text = wm.EmailName;
            txtsitecnzz.Text = wm.Sitecnzz;
            txtfax.Text = wm.SiteFax;
            txttel.Text = wm.SiteTel;
            txtaddress.Text = wm.SiteAddress;
            txtqq.Text = wm.SiteQQ;
            txtaddress.Text = wm.SiteAddress;
            txtother.Text = wm.Other;
            txtSmtpPassword.Attributes.Add("value", wm.EmailPassword);
            txtidnum.Text = BasePage.SiteId();
            if (!String.IsNullOrEmpty(wm.SiteConfig))
            {
                string siteconfig = wm.SiteConfig;
                string[] a = siteconfig.Split('|');
                if (a.Length > 0)
                {
                    SetCheckedBox.SetChecked(this.CheckBoxList1, a[0], ",");//基本配置
                    SetCheckedBox.SetChecked(this.CheckBoxList2, a[1], ",");//留言内容
                    SetCheckedBox.SetChecked(this.CheckBoxList3, a[2], ",");//留言列表
                    RadioButtonList1.SelectedValue = a[3];//单页显示可选
                    showhide = a[0];
                }

            }
            //序列号
            //string word = GreateFiles.Read_File(Server.MapPath("~/id.txt"));
            //if (!String.IsNullOrEmpty(word))
            //{
            //    txtidnum.Text = word.Trim();
            //}

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        WebConfigModel wm = new WebConfigModel();
        wm.SiteName = txtSiteName.Text;
        wm.SiteTitle = txtsitetitle.Text;
        wm.SiteTitleEn = txtsitetitleen.Text;
        wm.SiteUrl = txtSiteUrl.Text;
        wm.SiteICP = txticp.Text;

        wm.SiteKeyword = txtSiteKeyword.Text;
        wm.SiteKeywordEn = txtSiteKeyworden.Text;
        wm.SiteDescription = txtSiteDescription.Text;
        wm.SiteDescriptionEn = txtSiteDescriptionen.Text;
        wm.EmailSMTP = txtEmailsmtp.Text;
        wm.EmailName = txtSmtpName.Text;
        wm.EmailPassword = txtSmtpPassword.Text;
        wm.Sitecnzz = txtsitecnzz.Text;
        wm.SiteMail = txtsiteemail.Text;
        wm.SiteFax = txtfax.Text;
        wm.SiteTel = txttel.Text;
        wm.SiteQQ = txtqq.Text;
        wm.SiteAddress = txtaddress.Text;
        wm.Other = txtother.Text;
        //0基本配置,1留言内容,2留言列表,3单页勾选显示
        wm.SiteConfig = SetCheckedBox.GetChecked(this.CheckBoxList1, ",") + "|" + SetCheckedBox.GetChecked(this.CheckBoxList2, ",") + "|" + SetCheckedBox.GetChecked(this.CheckBoxList3, ",") + "|" + RadioButtonList1.SelectedValue;
        wm.id = 1;

        bool b = new WebConfigBll().Update(wm);

        if (b)
        {
            BasePage.JscriptPrint(Page, "更新成功！", "WebConfig.aspx");
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
       // return true;
    }
}