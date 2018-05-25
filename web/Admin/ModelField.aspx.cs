using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Utility;
using GL.Model;
using System.Data;
public partial class Admin_ModelField : System.Web.UI.Page
{
    protected int mid;
    protected string ac = "";
    private int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        ac = Request.QueryString["ac"];
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        mid = BasePage.GetRequestId(Request.QueryString["mid"]);
        if (mid == 0) { mid = 1; }

        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a href=\"ModelField.aspx\" class=\"home\">模型字段管理</a><a href=\"ModelField.aspx?ac=add&mid="+mid+"\" class=\"add\">添加新字段</a>";
            string checklogin = new AdminBll().CheckLogin("z" + mid);
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
            if (id == 0)
            {
                DataSet ds = new DataSet();
                int PageSize = 25;
                int PageIndex = BasePage.GetRequestId(Request.QueryString["Page"]); //当前第几页
                ds = new CommonBll().GetListPage("", "GL_ModelField", "Modeid=" + mid, "FieldPx desc,id desc", PageSize, PageIndex);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();


                int totalrecord = new CommonBll().GetRecordCount("GL_ModelField", "Modeid=" + mid);
                if (totalrecord == 0)
                {
                    txtpage.Text = "<p align=\"center\" class=\"red\">暂无相关字段</p>";

                }
                else if (totalrecord > PageSize)
                {
                    txtpage.Text = GL.Utility.GetPage.GetAspxPager(totalrecord, PageSize, PageIndex);
                }
            }
            else
            {
                ModelFieldModel m = new ModelFieldBll().GetModel(id);
                txtFieldName.Text = m.FieldName;
                txtFieldName2.Text = m.FieldName2;
                txtFieldName.ReadOnly = true;
                txtFieldType.SelectedValue = m.FieldType.ToString();
                if (m.FieldIsNull == 0)
                {
                    txtFieldIsNully.Checked = true;
                    txtFieldIsNulln.Checked = false;
                }
                else
                {
                    txtFieldIsNully.Checked = false;
                    txtFieldIsNulln.Checked = true;
                }
                if (m.FieldOnOff == 0)
                {
                    txtFieldOnOffy.Checked = true;
                    txtFieldOnOffn.Checked = false;
                }
                else
                {
                    txtFieldOnOffy.Checked = false;
                    txtFieldOnOffn.Checked = true;
                }
                txtFieldPx.Text = m.FieldPx.ToString();
                txtFieldIntro.Text = m.FieldIntro;
                txtvalue.Text = m.FieldVaules;
                txtFieldType.Enabled = false;
                Button1.Text = "确认修改";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ModelFieldModel m = new ModelFieldModel();
        m.FieldName = "GL_" + txtFieldName.Text.Trim();//自定义字段加前缀，区别于系统字段
        m.FieldName2 = txtFieldName2.Text.Trim();
        m.FieldType = int.Parse(txtFieldType.SelectedValue);
        m.FieldIsNull = txtFieldIsNully.Checked ? 0 : 1;
        m.FieldOnOff = txtFieldOnOffy.Checked ? 0 : 1;
        m.FieldPx = int.Parse(txtFieldPx.Text);
        m.FieldIntro = txtFieldIntro.Text;
        m.Modeid = mid;
        m.FieldVaules = txtvalue.Text;
        m.id = id;
        if (id == 0)
        {
            //取得该模型数据表名称
            ModelModel mo = new ModelBll().GetModel(mid);
            bool bo = DbHelperSQL.ColumnExists(mo.ModelTable, txtFieldName.Text);
            if (bo)
            {
                BasePage.Alertback(Page, "字段名称已经存在于数据中");
                return;
            }
            else
            {
                //在数据库中添加字段
                string fieldtype;
                if (txtFieldType.Text == "1")
                {
                    fieldtype = " int";
                }
                else
                {
                    fieldtype = " nvarchar(50)";
                }
                string column = "GL_" + txtFieldName.Text.Trim() + fieldtype;
                string sqlContent = "alter table " + mo.ModelTable + " add " + column + "";
                object obj = DbHelperSQL.GetSingle(sqlContent.ToString());

                int i = new ModelFieldBll().Add(m);
                if (i > 0)
                {
                    BasePage.JscriptPrint(Page, "添加成功！", "ModelField.aspx?mid=" + mid);
                }
            }
        }
        else
        {

            bool b = new ModelFieldBll().Update(m);
            if (b)
            {
                BasePage.JscriptPrint(Page, "修改成功！", "ModelField.aspx?mid=" + mid);
            }
        }
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        int id = BasePage.GetRequestId(delid);

        bool b = new CommonBll().Delete("GL_ModelField", id);
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "modelfield.aspx");
        }
    }

}