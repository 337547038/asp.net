using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;
using System.Data;
public partial class Admin_Model : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a href=\"model.aspx\" class=\"home\">模型管理</a><a href=\"ModelAdd.aspx\" class=\"add\">添加新模型</a>";
            string checklogin = new AdminBll().CheckLogin("1");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
            DataSet ds = new DataSet();
            ds = new CommonBll().GetList("", "GL_Model", "", "id asc");
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        int id = BasePage.GetRequestId(delid);

        if (id == 1 || id == 2)//文章和产品模型
        {
            BasePage.Alertback(Page, "不能删除系统模型！");
            return;
        }
        //检查此模型是否有栏目
        int bc = new CommonBll().GetRecordCount("GL_Class", "ModelId=" + id);
        if (bc > 0)
        {
            BasePage.Alertback(Page, "请先删除此模型下的栏目 ！");
            return;
        }
        bool b = new CommonBll().Delete("GL_Model", id);
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "Model.aspx");
        }
    }
}