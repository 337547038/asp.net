using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;
using System.Data;
public partial class Admin_UserGroup : System.Web.UI.Page
{
    protected string action = "";
    private int id;
    protected string datatable = "GL_UserGroup";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a class=\"home\" href=\"UserGroup.aspx\">会员组管理</a><a class=\"add\" href=\"?action=Add\">添加新组</a>";
            string checklogin = new AdminBll().CheckLogin("14");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }

            if (!String.IsNullOrEmpty(Request.QueryString["action"]))
            {
                action = Request.QueryString["action"];
            }
            else
            {
                action = "show";
            }
            id = BasePage.GetRequestId(Request.QueryString["id"]);
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                UserGroupModel model = new UserGroupBll().GetModel(id);
                bool b = new CommonBll().Exists(datatable, id);
                if (b)
                {
                    Literal1.Text = "修改会员组";
                    Button3.Text = "确认修改";
                    txtGroupName.Text = model.GroupName;
                    txtShowOnReg.Text = model.ShowOnReg.ToString();
                    txtDescript.Text = model.Descript;
                    SetChecked(this.PowerList, model.PowerList, ",");
                }


            }
            else
            {

                DataSet ds = new DataSet();
                int PageSize = 25;
                int PageIndex = BasePage.GetRequestId(Request.QueryString["Page"]); //当前第几页
                ds = new CommonBll().GetListPage("", datatable, "", "id desc", PageSize, PageIndex);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();


                int totalrecord = new CommonBll().GetRecordCount(datatable, "");//总记录数
                if (totalrecord == 0)
                {
                    txtpage.Text = "<p align=\"center\">无相关信息</p>";
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
        bool b = new CommonBll().Delete(datatable, id);
        if (b)
        {
            BasePage.JscriptPrint(Page, "删除成功！", "#");
        }
    }

    //add or edit
    protected void Button3_Click(object sender, EventArgs e)
    {
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        UserGroupModel model = new UserGroupModel();
        model.GroupName = txtGroupName.Text;
        model.ShowOnReg = int.Parse(txtShowOnReg.SelectedValue);
        model.Descript = txtDescript.Text;
        model.PowerList = GetChecked(this.PowerList, ",");
        model.id = id;
        if (id == 0)
        {
            int i = new UserGroupBll().Add(model);
            if (i > 0)
            {
                BasePage.JscriptPrint(Page, "添加成功！", "UserGroup.aspx");
            }
        }
        else
        {
            bool bb = new UserGroupBll().Update(model);
            if (bb)
            {
                BasePage.JscriptPrint(Page, "修改成功！", "UserGroup.aspx");
            }
        }
    }

    //string str = GetChecked(this.txtModelPower, ",");
    //txtUserName.Text = str;
    //SetChecked(this.txtModelPower, str1, ",");
    /// <summary>
    /// 初始化CheckBoxList中哪些是选中了的         /// </summary>
    /// <param name="checkList">CheckBoxList</param>
    /// <param name="selval">选中了的值串例如："0,1,1,2,1"</param>
    /// <param name="separator">值串中使用的分割符例如"0,1,1,2,1"中的逗号</param>
    public static string SetChecked(CheckBoxList checkList, string selval, string separator)
    {
        selval = separator + selval + separator;        //例如："0,1,1,2,1"->",0,1,1,2,1,"
        for (int i = 0; i < checkList.Items.Count; i++)
        {
            checkList.Items[i].Selected = false;
            string val = separator + checkList.Items[i].Value + separator;
            if (selval.IndexOf(val) != -1)
            {
                checkList.Items[i].Selected = true;
                selval = selval.Replace(val, separator);        //然后从原来的值串中删除已经选中了的
                if (selval == separator)        //selval的最后一项也被选中的话，此时经过Replace后，只会剩下一个分隔符
                {
                    selval += separator;        //添加一个分隔符
                }
            }
        }
        selval = selval.Substring(1, selval.Length - 2);        //除去前后加的分割符号
        return selval;
    }

    /// <summary>
    /// 得到CheckBoxList中选中了的值
    /// </summary>
    /// <param name="checkList">CheckBoxList</param>
    /// <param name="separator">分割符号</param>
    /// <returns></returns>
    public static string GetChecked(CheckBoxList checkList, string separator)
    {
        string selval = "";
        for (int i = 0; i < checkList.Items.Count; i++)
        {
            if (checkList.Items[i].Selected)
            {
                selval += checkList.Items[i].Value + separator;
            }
        }
        return selval;
    }
}
