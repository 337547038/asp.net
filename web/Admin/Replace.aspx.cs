using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using GL.Utility;
using GL.Bll;
using System.Data;
public partial class Admin_Replace : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<span class=\"home\">数据库字段替换</span>";
            string checklogin = new AdminBll().CheckLogin("10");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
            string[] ss = DbHelperSQL.connectionString.Split(';')[1].Split('=');
            DataSet ds = TabelName(ss[1]);
            ddlTable.DataSource = ds;
            ddlTable.DataTextField = "Name";
            ddlTable.DataValueField = "Name";
            ddlTable.DataBind();
            ddlTable.Items.Insert(0, new ListItem("请选择表名", ""));
            ddlTable.SelectedValue = Request.QueryString["tablename"];
            if (!String.IsNullOrEmpty(Request.QueryString["tablename"]))
            {
                DataSet ds2 = tableColumns(Request.QueryString["tablename"]);
                ddltableColumns.DataSource = ds2;
                ddltableColumns.DataTextField = "Name";
                ddltableColumns.DataValueField = "Name";
                ddltableColumns.DataBind();
                ddltableColumns.Items.Insert(0, new ListItem("请选择字段", ""));
                //  DropDownList2.SelectedValue = Request.QueryString["tableColumns"];
            }
            HiddenField1.Value = DbHelperSQL.connectionString.ToString();
        }
    }

    /// <summary>
    /// 取得所有表名
    /// </summary>
    /// <param name="database">数据库名</param>
    /// <returns></returns>

    public DataSet TabelName(string database)
    {
        string strSql = "Select Name FROM " + database + "..SysObjects Where XType='U' orDER BY Name";
        //string strSql = "SELECT table_name FROM information_schema.tables WHERE table_schema = '" + database + "' ORDER BY table_name ASC";//mysql
        //return DbHelperMySQL.Query(strSql.ToString());
        return DbHelperSQL.Query(strSql.ToString());


    }

    /// <summary>
    /// 取得表中的所有字段
    /// </summary>
    /// <param name="tableColumns">表名</param>
    /// <returns></returns>
    public DataSet tableColumns(string tableColumns)
    {
        string strSql = "Select Name FROM SysColumns Where id=Object_Id('" + tableColumns + "') and colid<>(select top 1 keyno from sysindexkeys where id=Object_Id('" + tableColumns + "'))";
        return DbHelperSQL.Query(strSql.ToString());
        //mysql
        //string strSql = "select COLUMN_NAME from INFORMATION_SCHEMA.Columns where table_name='" + tableColumns + "'";
        // return DbHelperMySQL.Query(strSql.ToString());

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string tablename = ddlTable.SelectedValue;
        Response.Redirect("replace.aspx?tablename=" + tablename);
    }

    /// <summary>
    /// 更新替换数据
    /// </summary>
    /// <param name="tablename">表名</param>
    /// <param name="cnname">字段名</param>
    /// <param name="oldvalues">要替换的内容</param>
    /// <param name="newvalues">新内容</param>
    /// <param name="strwhere">查找条件</param>
    /// <returns></returns>
    public int ReplaceData(string tablename, string cnname, string oldvalues, string newvalues, string strwhere)
    {

        StringBuilder strSql = new StringBuilder();

        strSql.Append("update  " + tablename + "  set  " + cnname + " = replace(Cast(" + cnname + " as ");

        strSql.Append("nvarchar(4000)), ");


        strSql.Append(" '" + oldvalues + "', '" + newvalues + "')");
        if (strwhere.Trim() != "")
        {
            strSql.Append(" where " + strwhere);
        }
        try
        {
            int i = DbHelperSQL.ExecuteSql(strSql.ToString());
            return i;
        }
        catch (Exception ex)
        {
            System.Web.HttpContext.Current.Response.Write("<br/><font color=red>" + ex.Message + "<br/>请尝试将替换成新的值修改为数字型或该字段对应的字符类型！</font>");
            //System.Web.HttpContext.Current.Response.End();
            return 0;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string tablename = ddlTable.SelectedValue;
        string tableColumns = ddltableColumns.SelectedValue;

        int i = ReplaceData(tablename, tableColumns, txtoldvalues.Text.Trim(), txtnewvalues.Text, "");
        if (i > 0)
        {
            BasePage.JscriptPrint(Page, "替换成功！受影响记录数：" + i, "#");
            return;
        }
    }
}