using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Bll;
using GL.Model;
using GL.Utility;
using System.Data;
using System.Web.Security;
public partial class Admin_User : System.Web.UI.Page
{

    protected int id = 0;
    protected string action = "";
    protected string datatable = "GL_User";
    protected string ddlp = "广东";
    protected string ddlc = "广州市";
    protected string ddla = "天河区";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a class=\"home\" href=\"User.aspx\">会员管理</a><a class=\"add\" href=\"?action=Add\">添加会员</a>";
            string checklogin = new AdminBll().CheckLogin("7");
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

            DataSet dsUserGroup = new CommonBll().GetList("", "GL_UserGroup", "", "id asc");
            if (action == "Add")
            {
                //用户组
                ddlGroupID.DataSource = dsUserGroup;
                ddlGroupID.DataTextField = "GroupName";
                ddlGroupID.DataValueField = "id";
                ddlGroupID.DataBind();

                if (id != 0)
                {
                    //编辑修改
                    Literal1.Text = "修改用户信息";
                    Literal2.Text = "不修改请留空";
                    UserModel model = new UserBll().GetModel(id);
                    ddlGroupID.SelectedValue = model.GroupID.ToString();
                    txtUserName.Text = model.UserName;
                    HiddenField1.Value = model.PassWord;
                    txtLocked.SelectedValue = model.Locked.ToString();
                    txtEmail.Text = model.Email;
                    txtQQ.Text = model.QQ;
                    string city = model.City;
                    if (city != "")
                    {
                        string[] v = city.Split(',');
                        ddlp = v[0];
                        ddlc = v[1];
                        ddla = v[2];
                    }
                    txtAddress.Text = model.Address;
                    txtSex.SelectedValue = model.Sex.ToString();
                    txtregDate.Text = BasePage.formatDateTime(model.RegDate.ToString());
                    txtlastLoginTime.Text = BasePage.formatDateTime(model.LastLoginTime.ToString());
                    txtlastLoginIP.Text = model.LastLoginIP;
                    txtloginTimes.Text = model.LoginTimes.ToString();
                    txtCompany.Text = model.Company;
                    txtTel.Text = model.Tel;
                    txtWenXin.Text = model.WenXin;
                    txtSource.Text = model.Source;
                    

                    Button4.Text = "确认修改";
                }
            }
            else
            {
                //列表
                //绑定快速查看下拉
                ddlUserGroup.DataSource = dsUserGroup;
                ddlUserGroup.DataTextField = "GroupName";
                ddlUserGroup.DataValueField = "id";
                ddlUserGroup.DataBind();
                ddlUserGroup.Items.Insert(0, new ListItem("所有会员组", ""));

                string keywords = Request.QueryString["keywords"];
                string strwhere = "id is not null";
                int GroupId = 0;
                if (!String.IsNullOrEmpty(Request.QueryString["GroupId"]))
                {
                    GroupId = int.Parse(Request.QueryString["GroupId"]);
                    strwhere += " and GroupId=" + GroupId;
                }
                if (!String.IsNullOrEmpty(Request.QueryString["keywords"]))
                {
                    strwhere += " and UserName like '%" + keywords + "%'";
                }
                ddlUserGroup.SelectedValue = GroupId.ToString();
                DataSet ds = new DataSet();
                int PageSize = 25;
                int PageIndex = BasePage.GetRequestId(Request.QueryString["Page"]); //当前第几页
                ds = new CommonBll().GetListPage("", datatable, strwhere, "LastLoginTime desc", PageSize, PageIndex);

                Repeater1.DataSource = ds;
                Repeater1.DataBind();
                int totalrecord = new CommonBll().GetRecordCount(datatable, strwhere);//总记录数
                if (totalrecord == 0)
                {
                    txtpage.Text = "<p align=\"center\" class=\"red\">暂无会员</p>";
                }
                else if (totalrecord > PageSize)
                {
                    txtpage.Text = GetPage.GetAspxPager(totalrecord, PageSize, PageIndex);
                }
            }

        }
    }

    //会员所在组名
    protected string GetUserGroup(string id)
    {
        int idd = BasePage.GetRequestId(id);
        UserGroupModel model = new UserGroupBll().GetModel(idd);
        return model.GroupName;
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

    //delall
    protected void Button2_Click(object sender, EventArgs e)
    {
        string allid = Request.Form["checkbox"];
        if (!String.IsNullOrEmpty(allid))
        {
            bool b = new CommonBll().DeleteList(datatable, allid);
            if (b)
            {
                BasePage.JscriptPrint(Page, "批量删除成功！", "#");
            }
        }
        else
        {
            BasePage.Alertback("请选择要删除的选项！");
            return;
        }

    }

    //快速查看
    protected void Button1_Click(object sender, EventArgs e)
    {
        string keywords = txtkeywords.Text.Trim();
        if (keywords == "请输入关键字")
        {
            keywords = "";
        }
        Response.Redirect("User.aspx?GroupId=" + ddlUserGroup.SelectedValue + "&keywords=" + keywords);
    }

    //add or edit
    protected void Button4_Click(object sender, EventArgs e)
    {
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        UserModel model = new UserModel();
        model.UserName = txtUserName.Text;
        model.GroupID = BasePage.GetRequestId(ddlGroupID.SelectedValue);
        if (id != 0)//编辑时
        {
            if (!String.IsNullOrEmpty(txtPassWord.Text.Trim()))
            {
                model.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassWord.Text.Trim() + "<>?", "MD5");
            }
            else
            {
                if (!String.IsNullOrEmpty(HiddenField1.Value))
                {
                    model.PassWord = HiddenField1.Value;
                }
                else
                {
                    BasePage.Alertback("操作超时，请刷新后重试");
                    return;
                }
            }
        }
        else
        {
            if (String.IsNullOrEmpty(txtPassWord.Text.Trim()))
            {
                BasePage.Alertback("密码不能为空，请重新输入");
                return;
            }
            else
            {
                model.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassWord.Text.Trim() + "<>?", "MD5");
            }
        }

        model.Locked = BasePage.GetRequestId(txtLocked.Text);
        model.Email = txtEmail.Text;
        model.QQ = txtQQ.Text;
        model.City = Request.Form["ddlProvince"] + "," + Request.Form["ddlCity"] + "," + Request.Form["ddlArea"];
        model.Address = txtAddress.Text;
        model.Sex = BasePage.GetRequestId(txtSex.SelectedValue);
        model.UserFace = txtface.Value;
        model.Company = txtCompany.Text;
        model.Tel = txtTel.Text;
        model.WenXin = txtWenXin.Text;
        model.Source = txtSource.Text;
        model.RegDate = DateTime.Parse(DateTime.Now.ToString());
        model.LoginTimes = 0;
        model.id = id;
        if (id == 0)
        {
            int exit = new CommonBll().GetRecordCount("GL_User", "UserName='" + txtUserName.Text.Trim() + "'");
            if (exit>0)
            {
                BasePage.Alertback(Page, "用户名" + txtUserName.Text.Trim() + "已经存在，请用其它名称！");
            }
            else
            {
                int i = new UserBll().Add(model);
                if (i > 0)
                {
                    BasePage.JscriptPrint(Page, "添加成功！", "User.aspx");
                }
            }
        }
        else
        {
            int ex = new CommonBll().GetRecordCount("GL_User", "UserName='" + txtUserName.Text.Trim() + "' and id<>" + id);
            if (ex > 0)
            {
                BasePage.Alertback(txtUserName.Text + " 用户名已存在!");
            }
            else
            {
                bool bb = new UserBll().Update(model);
                if (bb)
                {
                    BasePage.JscriptPrint(Page, "修改成功！", "User.aspx");
                }
            }
        }

    }
}