using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using GL.Bll;
using GL.Model;
using GL.Utility;
using System.Text.RegularExpressions;

public partial class Admin_ArticleAdd : System.Web.UI.Page
{
    protected string ItemName = "";
    protected int mid;
    protected int id;
    private string Language = "";
    protected string ModeContent = "";
    private string datatable = "";
    protected string iw = "";//裁剪图片宽
    protected string ih = "";//裁剪图片高
    private string titletips = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        mid = BasePage.GetRequestId(Request.QueryString["mid"]);
        if (mid == 0) { mid = 1; }
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        if (!String.IsNullOrEmpty(Request.QueryString["language"]))
        {
            Language = BasePage.GetRequestId(Request.QueryString["language"]).ToString();
        }

        string checklogin = new AdminBll().CheckLogin("m" + mid);
        if (checklogin != "true")
        {
            BasePage.Alertback(checklogin);
            Response.End();
        }
        //根据模型找出数据表名
        ModelModel mo = new ModelBll().GetModel(mid);
        datatable = mo.ModelTable;
        if (!Page.IsPostBack)
        {
            ItemName = mo.ItemName;
            if (!String.IsNullOrEmpty(mo.ModeContent))
            {
                //0模型内容可选字段`1模型栏目可选字段`2内容字段名称`3模型列表可选字段`4提示语
                string[] aa = mo.ModeContent.Split('`');
                string[] a = aa[4].Split('|');
                txtTips0.Text = a[0];
                txtTips1.Text = a[1];
                txtTips2.Text = a[2];
                txtTips3.Text = a[3];
                iw = a[4];
                ih = a[5];
                txtTips6.Text = a[6];
                txtTips7.Text = a[7];
                txtTips8.Text = a[8];
                txtTips9.Text = a[9];
                txtTips10.Text = a[10];
                txtTips11.Text = a[11];

                titletips = aa[2];
                ModeContent = aa[0];
            }
            //绑定栏目下拉
            txtLiteral9.Text = new ClassBll().GetClassSelect(0, "请选择所属类别", mid, "txtTid", "ClassType=0 and Languagen=" + BasePage.GetRequestId(Language) + "", "", "required input-control select-control");
            //绑定自定义字段
            GetModelField(id);

            //txtAddDate.Text = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
            txtAddDate.Text = BasePage.formatDateTime(DateTime.Now.ToString());
            Drlanguage.SelectedValue = Language.ToString();
            hiddenbackurl.Value = "Article.aspx?mid=" + mid;
            //修改时绑定数据
            if (id != 0)
            {
                ArticleModel am = new ArticleBll().GetModel(datatable, id);
                //根据语言和当前栏目重新绑定栏目
                // ClassTreeBind(0, "请选择所属类别", mid, this.txtTid, "ClassType=0 and Languagen=" + am.Languagen);
                txtLiteral9.Text = new ClassBll().GetClassSelect(0, "请选择所属类别", mid, "txtTid", "ClassType=0 and Languagen=" + am.Languagen + "", am.Tid.ToString(), "required input-control select-control");
                txtTitle.Text = am.Title;
                if (am.IsRecommend == 1)
                {
                    txtRecommend.Checked = true;
                }
                if (am.IsPopular == 1)
                {
                    txtPopular.Checked = true;
                }
                if (am.IsNew == 1)
                {
                    txtNew.Checked = true;
                }
                txtFullTitle.Text = am.FullTitle;
                txtPx.Text = am.Px.ToString();
                txtAuthor.Text = am.Author;
                txtOrigin.Text = am.Origin;
                txtHist.Text = am.Hits.ToString();
                //txtAddDate.Text = Convert.ToDateTime(am.AddDate).ToString("yyyy-MM-dd HH:mm:ss").ToString();
                txtAddDate.Text = BasePage.formatDateTime(am.AddDate.ToString());
                txtPicUrl.Text = am.PicUrl;
                txtKeyWord.Text = am.SeoKeyword;
                txtIntro.Text = am.Intro;
                txtcontents.Text = am.Contents;
                txtcontents2.Text = am.Contents2;
                txtcontents3.Text = am.Contents3;
                txtseotitle.Text = am.SeoTitle;
                txtDescription.Text = am.SeoDescription;
                filesurl.Text = am.FilesUrl;
                Button1.Text = "确认修改";
                Drlanguage.SelectedValue = am.Languagen.ToString();
                Drlanguage.Enabled = false;
               
                colortxt.Value = am.TitltColor;
                rallowcomment.SelectedValue = am.AllowComment.ToString();
                if (!String.IsNullOrEmpty(am.TitltColor))
                {
                    txtTitle.Style.Add("color", am.TitltColor);
                }
                // hiddenbackurl.Value = System.Web.HttpContext.Current.Request.RawUrl;
                if (Request.UrlReferrer != null)
                {
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                    hiddenbackurl.Value = ViewState["UrlReferrer"].ToString();
                }
            }

 ((Literal)Master.FindControl("breadcrumbs")).Text = "<a href=\"Article.aspx?mid=" + mid + "\" class=\"home\">" + ItemName + "管理</a> > 添加" + ItemName;
        }
    }

    //字段名，文本框名
    protected void GetModelField(int id)
    {
        DataSet ds = new CommonBll().GetList("", "GL_ModelField", "FieldOnOff=0 and Modeid=" + mid, "FieldPx desc,id desc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataSet ds2 = new DataSet();
            if (id != 0)
            {
                //赋值
                ds2 = new CommonBll().GetList("", datatable, "id=" + id, "px desc");
            }
            string v = "";
            StringBuilder fieldtxt = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {//0文本1数值2下拉3时间
                fieldtxt.Append("<tr><td class=\"align-right\">" + dr["FieldName2"].ToString() + "</td>\r<td class=\"alignleft\">");
                fieldtxt.Append("<input type=\"hidden\" name=\"hideFieldTitle\" id=\"hideFieldTitle\" value=\"" + dr["FieldName"].ToString() + "\">");
                fieldtxt.Append("<input type=\"hidden\" name=\"hideFieldType\" id=\"hideFieldType\" value=\"" + dr["FieldType"].ToString() + "\">");
                if (dr["FieldType"].ToString() == "2")
                {
                    fieldtxt.Append("<select class=\"" + WriteCss(BasePage.GetRequestId(dr["FieldIsNull"].ToString()), BasePage.GetRequestId(dr["FieldType"].ToString())) + "\" id=\"txtFieldContent\" name=\"txtFieldContent\">");
                    if (!String.IsNullOrEmpty(dr["FieldVaules"].ToString()))
                    {
                        string[] fv1 = dr["FieldVaules"].ToString().Split(',');
                        for (int i = 0; i < fv1.Length; i++)
                        {
                            string[] fv2 = fv1[i].Split('|');
                            string s = "";
                            string fv21 = "";//value值
                            if (fv2.Length == 2)
                            {
                                fv21 = fv2[1];
                            }
                            else
                            {
                                fv21 = fv2[0];
                            }
                            if (id != 0)
                            {
                                if (fv21.ToString() == ds2.Tables[0].Rows[0][dr["FieldName"].ToString()].ToString())
                                {
                                    s = "selected";
                                }
                            }
                            fieldtxt.Append("<option value=\"" + fv21 + "\" " + s + ">" + fv2[0] + "</option>\r");
                        }
                    }
                    else
                    {
                        fieldtxt.Append("<option value=\"\" ></option>\r");
                    }
                    fieldtxt.Append("</select>");
                }
                else
                {
                    v = dr["FieldVaules"].ToString();
                    if (id != 0)
                    {
                        v = ds2.Tables[0].Rows[0][dr["FieldName"].ToString()].ToString();
                    }
                    string d = "";
                    if (dr["FieldType"].ToString() == "3")
                    {
                        //时间
                        d = "onfocus=\"WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})\"";
                    }
                    fieldtxt.Append("<input type=\"text\" name=\"txtFieldContent\" id=\"txtFieldContent\"/ value=\"" + v + "\" class=\"" + WriteCss(BasePage.GetRequestId(dr["FieldIsNull"].ToString()), BasePage.GetRequestId(dr["FieldType"].ToString())) + "\" " + d + ">" + dr["FieldIntro"].ToString());
                }
                fieldtxt.Append("</td></tr>");
            }
            txtmodelfield.Text = fieldtxt.ToString();
        }
    }

    ///输出输出扩展字段的CSS
    protected string WriteCss(int isNull, int fieldType)
    {
        StringBuilder str = new StringBuilder();
        if (isNull == 1)
        {
            str.Append("required");
        }
        if (fieldType == 1)//数字
        {
            str.Append("digits");
        }
        else if (fieldType == 2)
        {
            //下拉
            str.Append(" input-control select-control");
        }
        else if (fieldType == 0 || fieldType == 3)
        {//文本或时间
            str.Append("input-control");
        }
        return str.ToString();
    }

    //可选字段隐藏
    protected bool gethide(string eid)
    {
        if (BasePage.ArrayExist(ModeContent, eid))
        {
            return true;
        }
        return false;
    }

    //add or edit
    protected void Button1_Click(object sender, EventArgs e)
    {
        ArticleModel ma = new ArticleModel();
        ma.Title = txtTitle.Text.Trim();
        int ctid = BasePage.GetRequestId(Request.Form["txtTid"]);
        ma.Tid = ctid;
        ma.FullTitle = txtFullTitle.Text;
        ma.Px = BasePage.GetRequestId(txtPx.Text);
        ma.Author = txtAuthor.Text;
        ma.Origin = txtOrigin.Text;
        ma.Hits = BasePage.GetRequestId(txtHist.Text);
        if (!String.IsNullOrEmpty(txtAddDate.Text))
        {
            ma.AddDate = DateTime.Parse(txtAddDate.Text);
        }
        else
        {
            ma.AddDate = DateTime.Now;
        }
        ma.EditDate = DateTime.Now;
        ma.PicUrl = txtPicUrl.Text;
        ma.SeoKeyword = txtKeyWord.Text;
        ma.Intro = txtIntro.Text;
        string contents1 = txtcontents.Text;
        if (txtspanfont.Checked)//过滤span font
        {
            contents1 = Regex.Replace(contents1, "(<span[^>]+>)|(</span>)", "");
            contents1 = Regex.Replace(contents1, "(<font[^>]+>)|(</font>)", "");//font
        }
        if (txthtml.Checked)
        {
            contents1 = BasePage.HtmlFilter(contents1);
        }
        ma.Contents = contents1;
        ma.Contents2 = txtcontents2.Text;
        ma.Contents3 = txtcontents3.Text;
        ma.Owner = Cookies.GetCookie("User_Name");
        ma.SeoDescription = txtDescription.Text;
        if (!String.IsNullOrEmpty(txtseotitle.Text))
        {
            ma.SeoTitle = txtseotitle.Text;
        }
        else
        {
            ma.SeoTitle = txtTitle.Text;
        }
        ma.Languagen = int.Parse(Drlanguage.SelectedValue);
        ma.IsPopular = txtPopular.Checked ? 1 : 0;
        ma.IsRecommend = txtRecommend.Checked ? 1 : 0;
        ma.IsNew = txtNew.Checked ? 1 : 0;
        ma.FilesUrl = filesurl.Text;
        ma.TitltColor = colortxt.Value;
        ma.AllowComment = int.Parse(rallowcomment.SelectedValue);
        if (BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "ms" + mid))
        {
            ma.Verific = 1;
        }
        else
        {
            ma.Verific = 0;
        }
        ma.id = id;
        //扩展字段
        string _sql = "";
        int modeexists = new CommonBll().GetRecordCount("GL_ModelField", "FieldOnOff=0 and Modeid=" + mid);
        if (modeexists > 0)
        {
            string[] _atype = Request.Params.GetValues("hideFieldType");//类型
            string[] _atitle = Request.Params.GetValues("hideFieldTitle");//
            string[] _bcontents = Request.Params.GetValues("txtFieldContent");
            if (_atype != null && _atitle != null && _bcontents != null)
            {
                for (int i = 0; i < _atitle.Length; i++)
                {
                    string vv = "'" + _bcontents[i] + "'";
                    if (_atype[i].ToString() == "1")
                    { //数值
                        vv = _bcontents[i];
                    }
                    if (String.IsNullOrEmpty(_sql))
                    {
                        _sql += _atitle[i] + "=" + vv;
                    }
                    else
                    {
                        _sql += "," + _atitle[i] + "=" + vv;
                    }
                }
            }
        }

        
        if (id == 0)
        {
            ma.IsDel = 0;
            int i = new ArticleBll().Add(datatable, ma);
            if (i > 0)
            {
                //更新自定义
                if (modeexists > 0)
                {
                    bool bb = new ArticleBll().Updatezd(datatable, _sql, i);
                }
                BasePage.JscriptPrint(Page, "添加成功！", "Article.aspx?mid=" + mid + "&tid=" + ctid + "&language=" + Language);//添加成功返回当前栏目
            }
        }
        else
        {
            bool b = new ArticleBll().Update(datatable, ma);
            if (b)
            {
                ////更新自定义
                if (modeexists > 0)
                {
                    bool bb = new ArticleBll().Updatezd(datatable, _sql, id);
                }
               
                BasePage.JscriptPrint(Page, "修改成功！", hiddenbackurl.Value.ToString());
            }
        }
    }

    protected void Drlanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ArticleAdd.aspx?mid=" + mid + "&language=" + Drlanguage.SelectedValue);
    }

    //字段名称
    protected string titletips2(int t)
    {
        string[] tt = titletips.Split(',');
        if (tt.Length == 12)
        {
            return tt[t];
        }
        else
        {
            return null;
        }

    }
}