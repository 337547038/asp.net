using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GL.Utility;
using GL.Model;
using GL.Bll;
using System.Text;
using System.Data;
public partial class Admin_ProductsAdd : System.Web.UI.Page
{
    protected string ItemName = "";
    private string datatable = "";
    protected int mid = 2;
    protected int id = 0;
    protected string ModeContent = "";
    private string Language = "";
    protected string isw = "";//以下四个为裁剪图片大小宽高
    protected string ish = "";
    protected string ibw = "";
    protected string ibh = "";
    private string titletips = "";//字段名
    protected void Page_Load(object sender, EventArgs e)
    {
        //删除相册图片
        if (Request.QueryString["ac"] == "uppic")
        {
            new CommonBll().Delete("GL_Album", BasePage.GetRequestId(Request.QueryString["delid"]));
        }

        mid = BasePage.GetRequestId(Request.QueryString["mid"]);
        if (mid == 1) { mid = 2; }
        id = BasePage.GetRequestId(Request.QueryString["id"]);
        if (!String.IsNullOrEmpty(Request.QueryString["language"]))
        {
            Language = BasePage.GetRequestId(Request.QueryString["Language"]).ToString();
        }

        //根据模型找出数据表名
        ModelModel mo = new ModelBll().GetModel(mid);
        datatable = mo.ModelTable;
        ItemName = mo.ItemName;
        if (!Page.IsPostBack)
        {
            string checklogin = new AdminBll().CheckLogin("m" + mid);
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }

            //绑定栏目下拉
            // ClassTreeBind(0, "请选择所属类别", mid, this.txtTid, "ClassType=0 and Languagen=" + Language);
            txtTid.Text = new ClassBll().GetClassSelect(0, "请选择所属类别", mid, "txtTid", "ClassType=0 and Languagen=" + BasePage.GetRequestId(Language) + "", "", "required input-control select-control");


            FieldBind(id);//绑定自定义
                         
            txtAddDate.Text = BasePage.formatDateTime(DateTime.Now.ToString());
            Drlanguage.SelectedValue = Language.ToString();

            hiddenbackurl.Value = "Products.aspx?mid=" + mid;
            //将公司名读取

            txtcompany.Text = Cookies.GetCookie("company").ToString();
            txtcompanyid.Value = Cookies.GetCookie("companyId").ToString();

            GetData();//编辑时

            //提示
            if (!String.IsNullOrEmpty(mo.ModeContent))
            {//0模型内容可选字段`1模型栏目可选字段`2内容字段名称`3模型列表可选字段`4提示语`5发表审核选择
                string[] aa = mo.ModeContent.Split('`');
                string[] a = aa[4].Split('|');
                ModeContent = aa[0];
                txtTips0.Text = a[0];
                txtTips1.Text = a[1];
                txtTips2.Text = a[2];
                txtTips3.Text = a[3];
                isw = a[4];
                ish = a[5];
                txtTips6.Text = a[6];
                txtTips7.Text = a[7];
                txtTips8.Text = a[8];
                txtTips9.Text = a[9];
                txtTips10.Text = a[10];
                txtTips11.Text = a[11];
                ibw = a[12];
                ibh = a[13];
                txtTips14.Text = a[14];
                txtTips15.Text = a[15];
                titletips = aa[2];
            }
 ((Literal)Master.FindControl("breadcrumbs")).Text = "<a class=\"home\" href=\"Products.aspx?mid=" + mid + "\">" + ItemName + "管理</a><span class=\"add\">添加" + ItemName + "</span><a href=\"Products.aspx?del=del&mid=" + mid + "\" class=\"del\">" + ItemName + "回收站</a>";
        }

    }

    protected void GetData()
    {
        //绑定数据
        if (id != 0)
        {
            ProductsModel pm = new ProductsBll().GetModel(datatable, id);
            //根据语言重新绑定栏目
            // ClassTreeBind(0, "请选择所属类别", mid, this.txtTid, "ClassType=0 and Languagen=" + pm.Languagen);
            txtTid.Text = new ClassBll().GetClassSelect(0, "请选择所属类别", mid, "txtTid", "ClassType=0 and Languagen=" + pm.Languagen + "", pm.Tid.ToString(), "required input-control select-control");
            txtTitle.Text = pm.Title;

            if (pm.IsRecommend == 1)
            {
                txtRecommend.Checked = true;
            }
            if (pm.IsPopular == 1)
            {
                txtPopular.Checked = true;
            }
            if (pm.IsNew == 1)
            {
                txtNew.Checked = true;
            }
            if (pm.IsSpecial == "1")
            {
                txtIsSpecial.Checked = true;
            }
            txtPicUrl.Text = pm.PicUrl;
            txtBigPhoto.Text = pm.BigPhoto;
            txtcontents.Text = pm.Contents;
            txtcontents2.Text = pm.Contents2;
            txtcontents3.Text = pm.Contents3;
            txtAddDate.Text = BasePage.formatDateTime(pm.AddDate.ToString());
            txtpx.Text = pm.Px.ToString();
            txtHits.Text = pm.Hits.ToString();
            txtPrice.Text = pm.Price.ToString();
            txtPriceMarket.Text = pm.PriceMarket.ToString();
            txtProModel.Text = pm.ProModel;
            txtProSpecificat.Text = pm.ProSpecificat;
            txtProducerName.Text = pm.ProducerName;
            txtUnit.Text = pm.Unit;
            txtTotalNum.Text = pm.TotalNum.ToString();
            ddlComment.SelectedValue = pm.Comment.ToString();
            
            txtIntro.Text = pm.Intro;

            txtseotitle.Text = pm.SeoTitle;
            txtKeyWord.Text = pm.SeoKeyWord;
            txtDescription.Text = pm.SeoDescription;

            filesurl.Text = pm.FilesUrl;

            colortxt.Value = pm.TitleColor;

            Button1.Text = "确认修改";
            Drlanguage.SelectedValue = pm.Languagen.ToString();
            Drlanguage.Enabled = false;
            txtcompanyid.Value = pm.ShopId.ToString();
            //将公司id转名称显示
            txtcompany.Text = new CommonBll().GetTitle("gl_shop", "Company", BasePage.GetRequestId(pm.ShopId.ToString()));
            //相册
            Repeater1.DataSource = new CommonBll().GetList("", "GL_Album", "ModelId=" + mid + " and ParentId=" + id, "id asc");
            Repeater1.DataBind();

            if (Request.UrlReferrer != null)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                hiddenbackurl.Value = ViewState["UrlReferrer"].ToString();
            }
        }
    }

    //绑定自定义字段
    private void FieldBind(int id)
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
                fieldtxt.Append("<tr><td class=\"align-right\">" + dr["FieldName2"].ToString() + "</td>\r<td class=\"align-left\">");
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
            str.Append("w200 digits");
        }
        else if (fieldType == 2)
        {
            //下拉
            str.Append(" ddlinput");
        }
        else if (fieldType == 0 || fieldType == 3)
        {//文本或时间
            str.Append("w200 input");
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

    //语言选择
    protected void Drlanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ProductsAdd.aspx?mid=" + mid + "&Language=" + Drlanguage.SelectedValue);
    }

    //添加修改
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.Form["txtTid"]) || string.IsNullOrEmpty(txtTitle.Text))
        {
            BasePage.Alertback("标题名称和所属栏目不能为空");
            return;
        }
        ProductsModel pm = new ProductsModel();
        pm.Languagen = int.Parse(Drlanguage.SelectedValue);
        pm.Title = txtTitle.Text.Trim();
        int ctid = BasePage.GetRequestId(Request.Form["txtTid"]);
        pm.Tid = ctid;
        pm.PicUrl = txtPicUrl.Text;
        pm.BigPhoto = txtBigPhoto.Text;
        pm.Contents = txtcontents.Text;
        pm.Contents2 = txtcontents2.Text;
        pm.Contents3 = txtcontents3.Text;
        pm.IsRecommend = txtRecommend.Checked ? 1 : 0;
        pm.IsNew = txtNew.Checked ? 1 : 0;
        pm.IsPopular = txtPopular.Checked ? 1 : 0;
        pm.IsSpecial = txtIsSpecial.Checked ? "1" : "0";

        if (!String.IsNullOrEmpty(txtAddDate.Text))
        {
            pm.AddDate = DateTime.Parse(txtAddDate.Text);
        }
        else
        {
            pm.AddDate = DateTime.Now;
        }

        pm.Px = BasePage.GetRequestId(txtpx.Text);
        pm.Hits = BasePage.GetRequestId(txtHits.Text);
        if (!string.IsNullOrEmpty(txtPrice.Text))
        {
            pm.Price = decimal.Parse(txtPrice.Text);
        }
        else
        {
            pm.Price = 0;
        }
        if (!String.IsNullOrEmpty(txtPriceMarket.Text))
        {
            pm.PriceMarket = decimal.Parse(txtPriceMarket.Text);
        }
        else
        {
            pm.PriceMarket = 0;
        }
        pm.ProducerName = txtProducerName.Text;
        pm.ProModel = txtProModel.Text;
        pm.ProSpecificat = txtProSpecificat.Text;
        pm.Unit = txtUnit.Text;
        pm.TitleColor = colortxt.Value;
        if (!String.IsNullOrEmpty(txtTotalNum.Text))
        {
            pm.TotalNum = int.Parse(txtTotalNum.Text);
        }
        else
        {
            pm.TotalNum = 0;
        }

        pm.Comment = BasePage.GetRequestId(ddlComment.SelectedValue);
        pm.Intro = txtIntro.Text;
        if (!String.IsNullOrEmpty(txtseotitle.Text.Trim()))
        {
            pm.SeoTitle = txtseotitle.Text;
        }
        else
        {
            pm.SeoTitle = txtTitle.Text;
        }
        pm.SeoKeyWord = txtKeyWord.Text;
        pm.SeoDescription = txtDescription.Text;
        pm.EditDate = DateTime.Now;
        pm.Inputer = Cookies.GetCookie("User_Name");
        pm.FilesUrl = filesurl.Text;
        //if (BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), "ms" + mid))
        //{
        //    pm.Verific = 1;
        //}
        //else
        //{
        //    pm.Verific = 0;
        //}
        pm.Verific = 0;
        pm.ShopId = BasePage.GetRequestId(txtcompanyid.Value);
        
        pm.id = id;

        //扩展字段
        string _sql = "";
        int modeexists = new CommonBll().GetRecordCount("GL_ModelField", "FieldOnOff=0 and Modeid=" + mid);
        if (modeexists > 0)
        {
            string[] _atype = Request.Params.GetValues("hideFieldType");//类型
            string[] _atitle = Request.Params.GetValues("hideFieldTitle");//
            string[] _bcontents = Request.Params.GetValues("txtFieldContent");
            if (_atitle != null && _bcontents != null && _atype != null)
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

        //将公司名存进cookies，方便下次添加
        Cookies.SaveCookie("company", txtcompany.Text, 0);
        Cookies.SaveCookie("companyId", txtcompanyid.Value, 0);

        //更新相册

        if (id == 0)
        {
            int i = new ProductsBll().Add(datatable, pm);
            if (i > 0)
            {
                //更新自定义
                if (modeexists > 0)
                {
                    bool bb = new ProductsBll().Updatezd(datatable, _sql, i);
                }

                UpateAlbum(i);
                BasePage.JscriptPrint(Page, "添加成功！"+txtcompanyid.Value, "Products.aspx?mid=" + mid + "&cid=" + ctid + "&language=" + BasePage.GetRequestId(Language));
            }

        }
        else
        {
            bool b = new ProductsBll().Update(datatable, pm);
            if (b)
            {
                //更新自定义
                if (modeexists > 0)
                {
                    bool bb = new ProductsBll().Updatezd(datatable, _sql, id);
                }


                UpateAlbum(id);
                BasePage.JscriptPrint(Page, "修改成功！", hiddenbackurl.Value.ToString());
            }
        }
    }

    //更新相册
    protected void UpateAlbum(int id)
    {
        string[] _fileurl = Request.Params.GetValues("txtpicpath");//文件路径,修改时没有
        string[] _fileid = Request.Params.GetValues("txtpicid");//id
        string[] _fileintro = Request.Params.GetValues("txtpicintro");//说明
        string[] _filepx = Request.Params.GetValues("txtpicpx");//排序
        if (_fileid != null && _fileintro != null && _fileid != null)
        {
            for (int i = 0; i < _fileid.Length; i++)
            {
                AlbumModel am = new AlbumModel();
                am.ModelId = mid;
                am.ParentId = id;
                am.PhotoUrl = _fileurl[i];

                am.Intro = _fileintro[i];
                am.AddTime = DateTime.Now;
                am.id = BasePage.GetRequestId(_fileid[i]);
                am.Px = BasePage.GetRequestId(_filepx[i]);
                if (BasePage.GetRequestId(_fileid[i]) == 0)
                {
                    int ai = new AlbumBll().Add(am);
                }
                else
                {
                    bool b = new AlbumBll().Update(am);
                }
            }
        }
    }

    //字段名称
    protected string titletips2(int t)
    {
        string[] tt = titletips.Split(',');
        if (tt.Length == 21)
        {
            return tt[t];
        }
        else
        {
            return null;
        }

    }



}
