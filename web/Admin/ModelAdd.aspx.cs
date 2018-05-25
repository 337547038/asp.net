using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using GL.Bll;
using GL.Model;
using GL.Utility;
using System.IO;
public partial class Admin_ModelAdd : System.Web.UI.Page
{
    public bool modeltype = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string txtAction = "";
            string checklogin = new AdminBll().CheckLogin("1");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }

            int id = BasePage.GetRequestId(Request.QueryString["id"]);

            string type = Request.QueryString["type"];
            DrModelType.SelectedValue = type;
            if (type == "1")
            {
                modeltype = true;//产品模型
            }

            if (id != 0)
            {
                txtAction = "修改模型信息";
                txtAction2.Text = "修改模型信息";
                Button1.Text = "确认修改";
                ModelModel model = new ModelBll().GetModel(id);
                txtModelName.Text = model.ModelName;
                txtModelTable.Text = model.ModelTable;
                txtModelTable.Enabled = false;
                txtItemName.Text = model.ItemName;
                txtItemUnit.Text = model.ItemUnit;
                RaModelLock.SelectedValue = model.ModelLock.ToString();
                DrModelType.SelectedValue = model.ModelType.ToString();
                txtclassnum.Text = model.ModelClassLayer.ToString();
                if (model.ModelType == 1)//0文章1产品
                {
                    modeltype = true;
                }
                DrModelType.Enabled = false;
                if (!String.IsNullOrEmpty(model.ModeContent))
                {
                    //0模型内容可选字段`1模型栏目可选字段`2内容字段名称`3模型列表可选字段`4提示语`5发表审核选择
                    string[] aa = model.ModeContent.Split('`');
                    string[] tips = aa[4].Split('|');
                    txt0.Text = tips[0];
                    txt1.Text = tips[1];
                    txt2.Text = tips[2];
                    txt3.Text = tips[3];
                    txt4.Text = tips[4];
                    txt5.Text = tips[5];
                    txt6.Text = tips[6];
                    txt7.Text = tips[7];
                    txt8.Text = tips[8];
                    txt9.Text = tips[9];
                    txt10.Text = tips[10];
                    if (!modeltype)//文章模型
                    {
                        SetCheckedBox.SetChecked(this.txtModeContent, aa[0], ",");//模型内容可选
                        SetCheckedBox.SetChecked(this.txtmodelcheckclass, aa[1], ",");//栏目可选
                        txt25.Text = aa[2];
                        SetCheckedBox.SetChecked(this.txtchecklist, aa[3], ",");//模型列表可选
                        txta11.Text = tips[11];
                        ddlsendsh.SelectedValue = aa[5].ToString();
                    }
                    else
                    { //0模型内容可选字段`1模型栏目可选字段`2内容字段名称`3模型列表可选字段`4提示语`5发表审核选择
                        SetCheckedBox.SetChecked(this.txtModeContent2, aa[0], ",");//模型内容可选
                        SetCheckedBox.SetChecked(this.txtmodelcheckclass, aa[1], ",");//栏目可选
                        txt26.Text = aa[2];
                        SetCheckedBox.SetChecked(this.txtchecklist, aa[3], ",");//模型列表可选

                        txtp11.Text = tips[11];
                        txtp12.Text = tips[12];
                        txtp13.Text = tips[13];
                        txtp14.Text = tips[14];
                        txtp15.Text = tips[15];
                        ddlsendsh.SelectedValue = aa[5].ToString();
                    }
                }
            }
            else
            {
                txtAction = "添加新模型";
                txtAction2.Text = "添加新模型";
            }

            ((Literal)Master.FindControl("breadcrumbs")).Text = "<span class=\"home\"></span>" + txtAction;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = BasePage.GetRequestId(Request.QueryString["id"]);

        ModelModel model = new ModelModel();
        model.ModelName = txtModelName.Text;
        model.ModelTable = txtModelTable.Text;
        model.ItemName = txtItemName.Text;
        model.ItemUnit = txtItemUnit.Text;
        model.ModelClassLayer = BasePage.GetRequestId(txtclassnum.Text);
        model.ModelLock = int.Parse(RaModelLock.SelectedValue);
        StringBuilder modelcontents = new StringBuilder();
        string tipstxt = txt0.Text + "|" + txt1.Text + "|" + txt2.Text + "|" + txt3.Text + "|" + txt4.Text + "|" + txt5.Text + "|" + txt6.Text + "|" + txt7.Text + "|" + txt8.Text + "|" + txt9.Text + "|" + txt10.Text + "|";
        
        if (DrModelType.SelectedValue == "0")//文章模型
        {
            //0模型内容可选字段`1模型栏目可选字段`2内容字段名称`3模型列表可选字段`4提示语`5发表审核选择
            //tips提示语
            tipstxt += txta11.Text;
            modelcontents.Append(SetCheckedBox.GetChecked(this.txtModeContent, ",") + "`" + SetCheckedBox.GetChecked(this.txtmodelcheckclass, ",") + "`" + txt25.Text + "`" + SetCheckedBox.GetChecked(this.txtchecklist, ",") + "`" + tipstxt + "`" + ddlsendsh.SelectedValue);
        }
        else
        {
            // 0模型内容可选字段`1模型栏目可选字段`2内容字段名称`3模型列表可选字段`4提示语`5发表审核选择
            tipstxt += txtp11.Text + "|" + txtp12.Text + "|" + txtp13.Text + "|" + txtp14.Text + "|" + txtp15.Text;
            modelcontents.Append(SetCheckedBox.GetChecked(this.txtModeContent2, ",") + "`" + SetCheckedBox.GetChecked(this.txtmodelcheckclass, ",") + "`" + txt26.Text + "`" + SetCheckedBox.GetChecked(this.txtchecklist, ",") + "`" + tipstxt + "`" + ddlsendsh.SelectedValue);
        }
        model.ModeContent = modelcontents.ToString();
        model.ModelType = BasePage.GetRequestId(DrModelType.SelectedValue);
        model.id = id;

       

        if (id != 0)
        {
            bool b = new ModelBll().Update(model);
            if (b)
            {
                BasePage.JscriptPrint(Page, "模型修改成功！", "Model.aspx");
            }
        }
        else
        {
            bool b1 = new ModelBll().ExistsName(txtModelTable.Text, "ModelTable");
            if (b1)
            {
                BasePage.JscriptPrint(Page, "数据表名不能重复！", "##");
            }
            else
            {

                // bool jj = false;
                //创建数据表
                if ((DbHelperSQL.TabExists(txtModelTable.Text)))
                {
                    BasePage.JscriptPrint(Page, "添加失败，存在同名数据表！", "##");
                    return;
                }
                else
                {
                    string data = "GL_Article";
                    if (DrModelType.SelectedValue == "1")//产品模型
                    {
                        data = "GL_Products";
                    }
                    //复制表(只复制结构)
                    // string strsql = "select * into " + txtModelTable.Text + " from " + data + " where 1<>1";
                    string strsql = "CREATE TABLE " + txtModelTable.Text + " LIKE " + data + "";
                    object obj = DbHelperSQL.GetSingle(strsql.ToString());
                }
                int i = new ModelBll().Add(model);
                if (i > 0)
                {

                    BasePage.JscriptPrint(Page, "模型添加成功！", "Model.aspx");
                }
            }
        }
    }

    //模型类型选择
    protected void DrModelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrModelType.SelectedValue == "1")
        {
            Response.Redirect("ModelAdd.aspx?type=1");
        }
    }
}