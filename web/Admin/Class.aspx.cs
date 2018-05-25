using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Utility;
using GL.Model;
using GL.Bll;
using System.Data;
public partial class Admin_Class : System.Web.UI.Page
{
    protected int mid;
    protected string ac = "";
    protected int id;
    protected int tid;
    private string datatable = "GL_Class";
    protected string Language = "";
    protected string modelclass = "";//可选字段显示
    protected void Page_Load(object sender, EventArgs e)
    {
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        tid = BasePage.GetRequestId(Request.QueryString["tid"]);
        mid = BasePage.GetRequestId(Request.QueryString["mid"]);
        string lansql = "";
        if (!String.IsNullOrEmpty(Request.QueryString["language"]))
        {
            Language = BasePage.GetRequestId(Request.QueryString["language"]).ToString();
            lansql = "Languagen=" + BasePage.GetRequestId(Language);
        }
        if (mid == 0) { mid = 1; }
        ac = Request.QueryString["ac"];

        if (!Page.IsPostBack)
        {
            string bx = "<a href=\"class.aspx?mid=" + mid + "&language=" + Language + "\" class=\"home\">栏目管理</a>";
            if (GetPower("ca"))
            {
                bx += "<a href=\"?ac=add&mid=" + mid + "&language=" + Language + "\" class=\"add\">添加新栏目</a>";
            }

            ((Literal)Master.FindControl("breadcrumbs")).Text = bx;
            string checklogin = new AdminBll().CheckLogin("ce" + mid);//栏目管理编辑是前提，有编辑权限才可能进来查看，添加和删除
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
            if (String.IsNullOrEmpty(ac))
            {
                DrLanguage.SelectedValue = Language.ToString();
                DataTable ds = new DataTable();
                ds = new ClassBll().GetListTree(mid, 0, lansql);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
            else if (ac == "add")
            {
                //显示可选栏目字段
                ModelModel m = new ModelBll().GetModel(mid);
                modelclass = m.ModeContent;
                if (tid == 0)
                {
                    txtTid.Text = "顶级分类";
                    DropDownList1.SelectedValue = Language;
                }
                else
                {
                    ClassModel tcm = new ClassBll().GetModel(tid);
                    txtTid.Text = tcm.ClassName;
                    DropDownList1.SelectedValue = tcm.Languagen.ToString();
                    DropDownList1.Enabled = false;
                    txtClassPic.Text = tcm.ClassPic;

                }
                if (id != 0)
                {
                    Button1.Text = "确认修改";
                    ClassModel cm = new ClassBll().GetModel(id);
                    DropDownList1.SelectedValue = cm.Languagen.ToString();
                    DropDownList1.Enabled = false;
                    if (cm.ParentId == 0)
                    { //顶级
                        txtTid.Text = "顶级分类";
                    }
                    else
                    {
                        txtTid.Text = new CommonBll().GetTitle(datatable, "ClassName", int.Parse(cm.ParentId.ToString
()));
                    }
                    txtClassName.Text = cm.ClassName;
                    txtPx.Text = cm.Px.ToString();
                    txtHide.SelectedValue = cm.Hide.ToString();
                    rinputa.SelectedValue = cm.InputA.ToString();
                    rinputuser.SelectedValue = cm.InputUser.ToString();
                    rallowcomment.SelectedValue = cm.AllowComment.ToString();
                    txtClassPic.Text = cm.ClassPic;

                    txtClassIntro.Text = cm.ClassIntro;
                    txtseotitle.Text = cm.SeoTitle;
                    txtKeyWord.Text = cm.SeoKeyWord;
                    txtDescription.Text = cm.SeoDescription;
                    string[] con = cm.Contents.Split('~');
                    txtcon1.Text = con[0];
                    txtcon2.Text = con[1];
                    txtcon3.Text = con[2];
                }
            }
        }
    }


    protected bool GetPower(string cn)
    {
        //编辑添加删除权限
        if (BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), cn + mid))
        {
            return true;
        }
        return false;
    }
    protected bool getmodelclass(string cn)
    {
        if (!String.IsNullOrEmpty(modelclass))
        {
            string[] a = modelclass.Split('`');
            //编辑添加删除权限
            if (BasePage.ArrayExist(a[1], cn))
            {
                return true;
            }
        }
        return false;
    }
    // children class
    protected string GetChildernAdd(string ClassType, string id, string Language, string ClassLayer)
    {
        string html = "";
        int classtype = BasePage.GetRequestId(ClassType);
        int modellayer = BasePage.GetRequestId(new CommonBll().GetTitle("GL_Model", "ModelClassLayer", mid));//显示级数
        if (classtype == 0 && int.Parse(ClassLayer) < modellayer)//只显示两级
        {
            html = "<a href=\"?ac=add&mid=" + mid + "&tid=" + id + "\" class=\"icon-add\" title=\"添加子栏目\"></a>";
        }

        return html;
    }
    //美化列表
    protected string GetPic0(string ClassLayer)
    {
        string _GetPic0 = "";
        int classLayer = BasePage.GetRequestId(ClassLayer);
        if (classLayer == 1)
        {
            _GetPic0 = "<img src=\"images/close2.gif\" />";
        }
        else
        {
            _GetPic0 = "<img src=\"images/close3.gif\" />";
        }
        return _GetPic0;
    }
    protected string GetPic(string ClassLayer)
    {
        string _GetPic = "";
        string LitStyle = "<span style=width:{0}px;text-align:right;display:inline-block;>{1}{2}</span>";
        string LitImg1 = "<img src=images/domain.gif class=\"icon-editdel\" />";
        string LitImg2 = "<img src=images/Smallfolder.gif class=\"icon-editdel\" />";
        string LitImg3 = "<img src=images/close3.gif class=\"icon-editdel\"/>";

        int classLayer = BasePage.GetRequestId(ClassLayer);
        if (classLayer == 1)
        {
            _GetPic = LitImg1;
        }
        else
        {
            _GetPic = string.Format(LitStyle, classLayer * 18, LitImg3, LitImg2);
        }
        return _GetPic;
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        ////检查有没删除的权限
        if (!BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "cd" + mid))
        {
            BasePage.Alertback(Page, "您没有删除此栏目的权限！");
            return;
        }

        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        string delid = lb.CommandArgument;
        int id = BasePage.GetRequestId(delid);

        //检查是否存在子栏目
        int bc = new CommonBll().GetRecordCount("GL_Class", "ParentId=" + id);
        if (bc > 0)
        {
            BasePage.Alertback(Page, "请先删除子栏目！");
            return;
        }
        else
        {
            bool b = new CommonBll().Delete("GL_Class", id);
            if (b)
            {
                BasePage.JscriptPrint(Page, "删除成功！", "back");
            }
        }
    }


    //按语言查看
    protected void DrLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Class.aspx?mid=" + mid + "&language=" + DrLanguage.SelectedValue);

    }
    //add or edit
    protected void Button1_Click(object sender, EventArgs e)
    {
        //根据ID取得父级相关信息
        int tid_ClassLayer = 0;
        if (tid != 0)
        {
            tid_ClassLayer = BasePage.GetRequestId(new CommonBll().GetTitle(datatable, "ClassLayer", tid));
        }
        ClassModel cm = new ClassModel();
        cm.ModelId = mid;

        cm.ParentId = tid;
        cm.ClassLayer = tid_ClassLayer + 1;
        if (!String.IsNullOrEmpty(txtseotitle.Text))
        {
            cm.SeoTitle = txtseotitle.Text;
        }
        else
        {
            cm.SeoTitle = txtClassName.Text;
        }
        cm.SeoKeyWord = txtKeyWord.Text;
        cm.SeoDescription = txtDescription.Text;
        cm.ClassIntro = txtClassIntro.Text;
        cm.Languagen = int.Parse(DropDownList1.SelectedValue);
        cm.Hide = int.Parse(txtHide.SelectedValue);
        cm.InputA = int.Parse(rinputa.SelectedValue);
        cm.AllowComment = int.Parse(rallowcomment.SelectedValue);
        cm.ClassPic = txtClassPic.Text;

        cm.InputUser = int.Parse(rinputuser.SelectedValue);
        cm.Contents = txtcon1.Text.Replace("~", "") + "~" + txtcon2.Text.Replace("~", "") + "~" + txtcon3.Text.Replace("~", "");

        cm.AddDate = DateTime.Now;
        cm.id = id;
        cm.ClassName = txtClassName.Text;
        cm.Px = BasePage.GetRequestId(txtPx.Text);
        if (id == 0)
        {
            if (GetPower("ca"))
            {
                string[] classname = txtClassName.Text.Split(',');
                string[] px = txtPx.Text.Split(',');
                if (classname.Length > 1)
                {
                    int ii = 0;
                    //批量添加
                    for (int i = 0; i < classname.Length; i++)
                    {
                        cm.ClassName = classname[i];
                        cm.SeoTitle = classname[i];
                        if (classname.Length == px.Length)
                        {
                            cm.Px = BasePage.GetRequestId(px[i]);
                        }
                        else
                        {
                            cm.Px = BasePage.GetRequestId(txtPx.Text);
                        }
                        ii = new ClassBll().Add(cm);
                    }
                    if (ii > 0)
                    {
                        BasePage.JscriptPrint(Page, "栏目批量添加成功！", "Class.aspx?mid=" + mid + "&language=" + Language + "");
                    }
                }
                else
                {
                    int i = new ClassBll().Add(cm);
                    if (i > 0)
                    {
                        BasePage.JscriptPrint(Page, "栏目添加成功！", "Class.aspx?mid=" + mid + "&language=" + Language + "");
                    }
                }
            }
            else
            {
                BasePage.Alertback("您没有添加栏目的权限");
            }
        }
        else
        {
            bool b = new ClassBll().Update(cm);
            if (b)
            {
                BasePage.JscriptPrint(Page, "栏目修改成功！", "Class.aspx?mid=" + mid + "&language=" + Language + "");
            }
        }
    }

    protected string getClass(string tid, string id)
    {
        //返回作为类名，用于折叠子级
        string cl = "";
        if (tid == "0")
        {
            //一级栏目，返回当前id
            cl = "control cl" + id;
        }
        else
        {
            cl = "hide cl" + tid;
        }
        return cl;
    }

}