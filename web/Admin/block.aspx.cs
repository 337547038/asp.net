using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;
using System.Data;
public partial class Admin_block : System.Web.UI.Page
{
    protected string action = "";
    private int id;
    private string datatable = "GL_Block";
    protected void Page_Load(object sender, EventArgs e)
    {
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        if (!Page.IsPostBack)
        {
            string btxt = "<a href=\"block.aspx\" class=\"home\">方块碎片</a>";
            if (BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "23"))
            {
                btxt += "<a href=\"block.aspx?Ac=add\" class=\"add\">添加方块碎片</a>";
            }
            ((Literal)Master.FindControl("breadcrumbs")).Text = btxt;
            string checklogin = new AdminBll().CheckLogin("17");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }

            if (!String.IsNullOrEmpty(Request.QueryString["Ac"]))
            {
                action = Request.QueryString["Ac"];
            }
            else
            {
                action = "show";
            }
            //txtModelName.ReadOnly = true;
            if (id != 0)
            {
                BlockModel model = new BlockBll().GetModel(id);
                txtPageName.Text = model.Title;
                txtPageName.Enabled = false;
                txtcontents.Text = model.Contents;
                Button1.Text = "确认修改";
            }
            else
            {
                string strwhere = "";
                DataSet ds = new DataSet();
                int PageSize = 25;
                int PageIndex = BasePage.GetRequestId(Request.QueryString["Page"]); //当前第几页
                ds = new CommonBll().GetListPage("", datatable, strwhere, "id desc", PageSize, PageIndex);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                int totalrecord = new CommonBll().GetRecordCount(datatable, strwhere);//总记录数
                if (totalrecord == 0)
                {
                    txtpage.Text = "<p align=\"center\" class=\"red\">暂无相关数据</p>";
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
        if (!BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "23"))
        {
            BasePage.Alertback("您没有删除的权限！");
            Response.End();
        }
        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        int id = BasePage.GetRequestId(delid);

        bool b = new CommonBll().Delete(datatable, id);
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "block.aspx");
        }
    }

    //add or edit
    protected void Button1_Click(object sender, EventArgs e)
    {
        BlockModel model = new BlockModel();
        model.Title = txtPageName.Text;
        model.Contents = txtcontents.Text;
        model.AddDate = DateTime.Now.ToString();
        model.id = id;
        if (id == 0)
        {
            if (!BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "23"))
            {
                BasePage.Alertback("您没有删除的权限！");
                Response.End();
            }
            int i = new BlockBll().Add(model);
            if (i > 0)
            {
                BasePage.JscriptPrint(Page, "添加成功！", "block.aspx");
            }
        }
        else
        {
            bool b = new BlockBll().Update(model);
            if (b)
            {

                BasePage.JscriptPrint(Page, "修改成功！", "block.aspx");
            }
        }
    }



}