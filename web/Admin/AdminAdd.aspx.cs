using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GL.Bll;
using GL.Model;
using GL.Utility;
using System.Text;
using System.Web.Security;
public partial class Admin_AdminAdd : System.Web.UI.Page
{
    protected int userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        userid = BasePage.GetRequestId(Cookies.GetCookie("User_Id").ToString());
        if (!Page.IsPostBack)
        {
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a href=\"AdminAdd.aspx\" class=\"home\">添加管理员</a>";
            string checklogin = new AdminBll().CheckLogin("no");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
            txtadmin1.Visible = false;//模型权限勾选，只允许两个用户可设置
            txtadmin.Visible = false;
            if (userid == 1)
            {
                txtadmin.Visible = true;//设置其它管理员默认权限
                txtadmin1.Visible = true;
            }
            else if (userid == 2)
            {
                txtadmin1.Visible = true;
            }
            int id = BasePage.GetRequestId(Request.QueryString["id"]);

            ActionName.Text = "添加网站管理员";
            //动态模型，其它管理员不显示这个
            if (userid == 1)
            {
                DataSet ds = new DataSet();
                ds = new CommonBll().GetList("", "GL_Model", "ModelLock=0", "id asc");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ListItem ListItem1 = new ListItem(dr["ModelName"].ToString() + "内容管理", "m" + dr["id"].ToString());
                        string[] a = dr["ModeContent"].ToString().Split('`');
                        if (a[5] == "1")//需要审核时显示
                        {
                            ListItem ListItem2 = new ListItem(dr["ModelName"].ToString() + "发表审核", "ms" + dr["id"].ToString());
                            txtModelPower.Items.Add(ListItem2);
                        }
                        ListItem ListItem3 = new ListItem(dr["ModelName"].ToString() + "内容删除", "md" + dr["id"].ToString());
                        ListItem ListItem4 = new ListItem(dr["ModelName"].ToString() + "栏目添加", "ca" + dr["id"].ToString());
                        ListItem ListItem5 = new ListItem(dr["ModelName"].ToString() + "栏目编辑", "ce" + dr["id"].ToString());
                        ListItem ListItem6 = new ListItem(dr["ModelName"].ToString() + "栏目删除", "cd" + dr["id"].ToString());
                        ListItem ListItem7 = new ListItem(dr["ModelName"].ToString() + "字段管理", "z" + dr["id"].ToString());
                        txtModelPower.Items.Add(ListItem1);
                        txtModelPower.Items.Add(ListItem3);
                        txtModelPower.Items.Add(ListItem4);
                        txtModelPower.Items.Add(ListItem5);
                        txtModelPower.Items.Add(ListItem6);
                        txtModelPower.Items.Add(ListItem7);
                    }
                }
            }

            if (id != 0)//编辑
            {
                if (userid == 2)//二管理员
                {
                    string adminpur = new CommonBll().GetTitle("GL_Webconfig", "adminpur", 1);
                    if (!String.IsNullOrEmpty(adminpur))
                    {
                        string[] ap = adminpur.Split('|');
                        for (int i = 0; i < ap.Length; i++)
                        {
                            string[] ap2 = ap[i].Split(',');
                            ListItem ListItem1 = new ListItem(ap2[0], ap2[1]);
                            txtModelPower2.Items.Add(ListItem1);
                        }
                    }
                }


                AdminModel model = new AdminBll().GetModel(id);
                txtUserName.Text = model.UserName;
                txtEmail.Text = model.Email;
                txtPassWordOld.Value = model.PassWord;
                txtTTelPhone.Text = model.TelPhone;
                if (model.Sex == 0)
                {
                    TxtSex.Checked = true;
                }
                else
                {
                    TxtSex1.Checked = true;
                }
                if (model.Locked == 1)
                {
                    txtLocked.Checked = true;
                }
                if (Request.QueryString["id"] == "1")
                {
                    txtLocked.Enabled = false;//管理员时锁定
                }
                if (userid == 1)
                {
                    SetChecked(this.txtModelPower, model.ModelPower, ",");
                }
                else if (userid == 2)
                {
                    SetChecked(this.txtModelPower2, model.ModelPower, ",");
                }
                Literal1.Text = " 不修改密码请留空！";
                ActionName.Text = "修改" + txtUserName.Text + "资料";

                string other = "";
                other += "<tr><td class=\"align-right\">添加时间：</td><td class=\"align-left\">" +BasePage.formatDateTime(model.AddDate.ToString()) + "</td></tr>";
                other += "<tr><td class=\"align-right\">登录次数：</td><td class=\"align-left\">" + model.LoginTime + "</td></tr>";
                other += "<tr><td class=\"align-right\">最后登录：</td><td class=\"align-left\">" + BasePage.formatDateTime(model.LastLoginTime.ToString()) + "</td></tr>";
                other += "<tr><td class=\"align-right\">最后登录IP：</td><td class=\"align-left\">" + model.LastLoginIP + "</td></tr>";
                Literal2.Text = other;
                Button1.Text = "确认修改";
                HiddenFieldmp.Value = model.ModelPower;
            }
        }
    }
    //添加
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = BasePage.GetRequestId(Request.QueryString["id"]);

        AdminModel model = new AdminModel();
        model.id = id;
        model.UserName = txtUserName.Text.Trim();
        model.Sex = TxtSex.Checked ? 0 : 1;
        model.TelPhone = txtTTelPhone.Text.Trim();
        model.Email = txtEmail.Text.Trim();
        model.AddDate = DateTime.Now;
        if (Request.QueryString["id"] == "1")
        {
            model.Locked = 0;
        }
        else
        {
            model.Locked = txtLocked.Checked ? 1 : 0;
        }
        if (userid == 1)
        { model.ModelPower = GetChecked(this.txtModelPower, ","); }
        else if (userid == 2)
        {
            model.ModelPower = GetChecked(this.txtModelPower2, ",");
        }
        else
        {
            model.ModelPower = HiddenFieldmp.Value;
        }
        addoreditadminpur();
        if (id != 0)
        {
            if (String.IsNullOrEmpty(txtPassWord.Text.Trim()))
            {
                model.PassWord = txtPassWordOld.Value;
            }
            else
            {
                model.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassWord.Text.Trim() + "fan<>?", "MD5");
            }
            int ex = new CommonBll().GetRecordCount("GL_Admin", "UserName='" + txtUserName.Text.Trim() + "' and id<>" + id);
            if (ex > 0)
            {
                BasePage.Alertback("此用户名已存在!");
            }
            else
            {
                bool b = new AdminBll().Update(model);
                if (b)
                {
                    BasePage.JscriptPrint(Page, "修改成功！", "admin.aspx");
                }
            }
        }
        else
        {
            if (userid <= 2)
            {
                //添加
                if (String.IsNullOrEmpty(txtPassWord.Text.Trim()))
                {
                    BasePage.Alertback("密码不能为空！");
                    Response.End();
                }
                if (new AdminBll().ExistName(txtUserName.Text.Trim()))
                {
                    BasePage.Alertback(Page, "用户名" + txtUserName.Text.Trim() + "已经存在，请用其它名称！");
                }
                else
                {
                    int b = new AdminBll().Add(model);
                    if (b > 0)
                    {
                        BasePage.JscriptPrint(Page, "添加成功！", "admin.aspx");
                    }
                }
            }

        }
    }

    protected void addoreditadminpur()
    {
        if (checkboxadmin.Checked && userid == 1)
        {
            StringBuilder ap = new StringBuilder();
            for (int i = 0; i < txtModelPower.Items.Count; i++)
            {
                if (txtModelPower.Items[i].Selected)
                {
                    if (String.IsNullOrEmpty(ap.ToString()))
                    {
                        ap.Append(txtModelPower.Items[i].Text + "," + txtModelPower.Items[i].Value);
                    }
                    else
                    {
                        ap.Append("|" + txtModelPower.Items[i].Text + "," + txtModelPower.Items[i].Value);
                    }
                }
            }
            string strSql = "update GL_WebConfig set Adminpur='" + ap.ToString() + "' where id=1";
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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