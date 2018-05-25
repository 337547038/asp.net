using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;
public partial class Admin_DIYPage : System.Web.UI.Page
{
    protected string action = "";
    private int id;
    private string datatable = "GL_DIYPage";
    private string contentsfield = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        showhide.Visible = false;
        showddltid.Visible = false;
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        if (!Page.IsPostBack)
        {
            string bx = "<a class=\"home\" href=\"DIYPage.aspx\">单页管理</a>";
            if (BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "91"))
            {
                bx += "<a href =\"?Ac=add&tid=" + Request.QueryString["tid"] + "\" class=\"add\">新建单页</a>";
            }
                ((Literal)Master.FindControl("breadcrumbs")).Text = bx;
            string checklogin = new AdminBll().CheckLogin("9");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }

            string siteconfig = new WebConfigBll().GetModel(1).SiteConfig;
            if (!String.IsNullOrEmpty(siteconfig))
            {
                string[] a = siteconfig.Split('|');
                if (a.Length > 0)
                {
                    if (a[3] == "0")
                    {
                        //隐藏
                        showhide.Visible = true;
                    }
                }
            }

            action = Request.QueryString["Ac"];
            int tid = BasePage.GetRequestId(Request.QueryString["tid"]);
            string strwhere = "Tid=" + tid;
            if (String.IsNullOrEmpty(action))
            {
                Repeater1.DataSource = new CommonBll().GetList("", datatable, strwhere, "PageType desc,px desc,id desc");
                Repeater1.DataBind();
            }
            else if (action == "add")
            {
                ddltid.DataSource = new CommonBll().GetList("", datatable, "PageType=1", "id desc");
                ddltid.DataTextField = "PageName";
                ddltid.DataValueField = "id";
                ddltid.DataBind();
                ddltid.Items.Insert(0, new ListItem("无上级栏目", "0"));
                if (id != 0)
                {
                    DiyPageModel dm = new DiyPageBll().GetModel(id);
                    txtPageName.Text = dm.PageName;
                    ddltid.SelectedValue = dm.Tid.ToString();
                    // ddltid.Enabled = false;
                    txtpx.Text = dm.Px.ToString();
                  
                    txtseotitle.Text = dm.SeoTitle;
                    txtkeyword.Text = dm.SeoKeyword;
                    txtSeoDescription.Text = dm.SeoDescription;
                    txtcontents.Text = dm.PageContents;
                    txtPicUrl.Text = dm.PagePicUrl;
                    Button1.Text = "确认修改";
                    contentsfield = dm.PageContentsField;
                    SetCheckedBox.SetChecked(this.txtpagecontentsfield, dm.PageContentsField, ",");
                }
                if (gethide("1"))
                {
                    showddltid.Visible = true;
                }
                if (tid != 0)//从栏目里点新建，则开启所属栏目
                {
                    showddltid.Visible = true;
                    ddltid.SelectedValue = tid.ToString();
                    txtpagecontentsfield.SelectedValue = "1";
                }
            }
            else if (action == "clone")
            { //克隆数据
                if (BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "91"))
                {
                    string filename = "PageName,ModelName,PageFilename,PageContents,EditTime,SeoTitle,SeoKeyword,SeoDescription,PageType,Px,Tid,PageContentsField,PagePicUrl";
                    int c = new CommonBll().CloneData(filename, datatable, "id=" + id);
                    if (c > 0)
                    {
                        BasePage.JscriptPrint(Page, "克隆成功！", "diypage.aspx?tid=" + tid);
                    }
                }
            }
        }
    }

    //del
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        if (!BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "92"))
        {
            BasePage.Alertback("您没有删除的权限！");
            Response.End();
        }
        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        int id = BasePage.GetRequestId(delid);
        //检查有无下级
        int exit = new CommonBll().GetRecordCount(datatable, "tid=" + id + " and PageType=0");
        if (exit > 0)
        {
            BasePage.Alertback("请先删除子栏目！");
            Response.End();
        }
        
        bool b = new CommonBll().Delete(datatable, id);
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "diypage.aspx");
        }
    }

    //add or edit
    protected void Button1_Click(object sender, EventArgs e)
    {
        DiyPageModel model = new DiyPageModel();
        model.PageName = txtPageName.Text;
       
        model.PageContents = txtcontents.Text;
        model.EditTime = DateTime.Now;
        if (!String.IsNullOrEmpty(txtseotitle.Text))
        {
            model.SeoTitle = txtseotitle.Text;
        }
        else
        {
            model.SeoTitle = txtPageName.Text;
        }
        model.SeoKeyword = txtkeyword.Text;
        model.SeoDescription = txtSeoDescription.Text;
        model.Px = BasePage.GetRequestId(txtpx.Text);
        model.Tid = BasePage.GetRequestId(ddltid.SelectedValue);
        model.PageType = 0;
        model.PagePicUrl = txtPicUrl.Text;

        model.PageContentsField = SetCheckedBox.GetChecked(this.txtpagecontentsfield, ",");

        model.id = id;
        if (id == 0)
        {
            if (!BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "91"))
            {
                BasePage.Alertback("您没有添加新单页的权限！");
                Response.End();
            }
            int i = new DiyPageBll().Add(model);
            if (i > 0)
            {
                BasePage.JscriptPrint(Page, "添加成功！", "DiyPage.aspx?tid=" + ddltid.SelectedValue);
            }
        }
        else
        {
            bool b = new DiyPageBll().Update(model);
            if (b)
            {

                BasePage.JscriptPrint(Page, "修改成功！", "DiyPage.aspx?tid=" + ddltid.SelectedValue);
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DiyPageModel model = new DiyPageModel();
        model.PageName = txtpagename1.Text;
        model.PageType = 1;
        model.EditTime = DateTime.Now;
        int i = new DiyPageBll().Add(model);
        if (!BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "91"))
        {
            BasePage.Alertback("您没有添加新单页的权限！");
            Response.End();
        }
        else
        {
            if (i > 0)
            {
                BasePage.JscriptPrint(Page, "添加成功！", "DiyPage.aspx");
            }
        }
    }


    protected string Getchildren(string id, string pagetype)
    {
        string h = "";
        if (pagetype == "0")
        {
            if (BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "91"))
            {
                h = "<a href=\"?Ac=clone&id=" + id + "\" title=\"克隆数据\">克隆</a> ";
            }
            h += "<a href=\"?Ac=add&id=" + id + "\">编辑</a>";
        }
        else if (pagetype == "1")
        {
            h = "<a href=\"?tid=" + id + "\">查看</a>";
        }
        return h;
    }

    //可选字段隐藏
    protected bool gethide(string eid)
    {
        if (BasePage.ArrayExist(contentsfield, eid))
        {
            return true;
        }
        return false;
    }

    
}