using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using GL.Bll;
using GL.Model;
using GL.Utility;
public partial class Admin_FilesManage : System.Web.UI.Page
{

    protected string Path = "/UpLoadFile";
    protected string position = "";
    private DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        string FolderPath = Request.QueryString["Path"];
        if (!String.IsNullOrEmpty(FolderPath))
        {
            FolderPath = FolderPath.Replace(".", "");
            FolderPath = Regex.Replace(FolderPath, @"((\\|/)+(\\*)+(/*)+(\\|/))", "/");
            Path = "/UpLoadFile/" + FolderPath;
            Path = Regex.Replace(Path, @"((\\|/)+(\\*)+(/*)+(\\|/))", "/");
        }
        if (!Page.IsPostBack)
        {
            
               string checklogin = new AdminBll().CheckLogin("8");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
            if (!String.IsNullOrEmpty(FolderPath))
            {
                //拆分路径，得到当前位置
                string[] p = FolderPath.Split('/');
                string urlp = "";
                for (int i = 0; i < p.Length; i++)
                {
                    if (!string.IsNullOrEmpty(p[i]))
                    {
                        urlp += "/" + p[i];
                        position += "/<a href=\"?Path=" + urlp + "\">" + p[i] + "</a>";
                    }
                }
            }
            ((Literal)Master.FindControl("breadcrumbs")).Text = "<a href =\"FilesManage.aspx\" class=\"home\">上传文件管理</a><a href =\"FilesManage.aspx\">根目录</a>" + position;
            AllFolder.Text = GetAllFolder(MapPath(Path));//列出所有文件夹
            GetFiles(Path);

            //分页 开始 -------
            string url = "?Path=" + Request.QueryString["Path"] + "&";
            int CurPage;
            if (Request.QueryString["Page"] != null && BasePage.GetRequestId(Request.QueryString["Page"]) > 0)
                CurPage = BasePage.GetRequestId(Request.QueryString["Page"]);
            else
                CurPage = 1;
            PagedDataSource ps = new PagedDataSource();
            //  ps.DataSource = ds.Tables["DS_News"].DefaultView;
            ps.DataSource = dt.DefaultView;
            ps.AllowPaging = true;
            //每个页面显示的条数
            ps.PageSize = 50;
            onePage.Text = ps.PageSize.ToString();
            //求数据的总数
            allMsg.Text = ps.DataSourceCount.ToString();
            ps.CurrentPageIndex = CurPage - 1;
            //求总页
            allPages.Text = ps.PageCount.ToString();
            nowPage.Text = CurPage.ToString();
            //将数据源与控件绑定
            Repeater1.DataSource = ps;
            Repeater1.DataBind();

            //上一页
            if (!ps.IsFirstPage)
            {
                firstPage.NavigateUrl = url + "Page=1";
                prePage.NavigateUrl = url + "Page=" + Convert.ToString(CurPage - 1);
            }
            //下一页
            if (!ps.IsLastPage)
            {
                nextPage.NavigateUrl = url + "Page=" + Convert.ToString(CurPage + 1);
                endPage.NavigateUrl = url + "Page=" + Convert.ToString(ps.PageCount);
            }
            //分页 结束 -------

        }
    }

    protected void GetFiles(string Path)
    {
        dt.Columns.Add(new DataColumn("Name", typeof(string)));
        dt.Columns.Add(new DataColumn("CreationTime", typeof(string)));
        dt.Columns.Add(new DataColumn("Length", typeof(int)));
        dt.Columns.Add(new DataColumn("FullName", typeof(string)));

        DirectoryInfo dir = new DirectoryInfo(MapPath(Path));
        foreach (FileInfo dChild in dir.GetFiles("*.*"))//这个地方也可以用一个星号表示所有文件类型，当然也可以用*.txt，*.gif这样的方法去限定文件的类型
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = dChild.Name.ToString();
            dr["CreationTime"] = dChild.CreationTime.ToString();
            dr["Length"] = dChild.Length;
            dr["FullName"] = dChild.FullName;

            dt.Rows.Add(dr);
        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        //当前点击按钮，获取传过来的ID
        LinkButton lb = (LinkButton)sender;
        string delname = lb.CommandArgument;
        bool b = IsExistFile(delname);
        DeleteFile(delname);
        if (Request.UrlReferrer != null)
        {
            ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            Response.Redirect(ViewState["UrlReferrer"].ToString());
        }
        else
        {
            Response.Redirect("FilesManage.aspx");
        }

    }

    #region 检测指定目录是否存在
    /// <summary> 
    /// 检测指定目录是否存在 
    /// </summary> 
    /// <param name="directoryPath">目录的绝对路径</param>         
    public static bool IsExistDirectory(string directoryPath)
    {
        return Directory.Exists(directoryPath);
    }
    #endregion

    #region 检测指定文件是否存在
    /// <summary> 
    /// 检测指定文件是否存在,如果存在则返回true。 
    /// </summary> 
    /// <param name="filePath">文件的绝对路径</param>         
    public static bool IsExistFile(string filePath)
    {
        return File.Exists(filePath);
    }
    #endregion

    #region 删除指定文件
    /// <summary> 
    /// 删除指定文件 
    /// </summary> 
    /// <param name="filePath">文件的绝对路径</param> 
    public static void DeleteFile(string filePath)
    {
        if (IsExistFile(filePath))
        {
            File.Delete(filePath);
        }
    }
    #endregion

    #region 删除指定目录
    /// <summary> 
    /// 删除指定目录及其所有子目录 
    /// </summary> 
    /// <param name="directoryPath">指定目录的绝对路径</param> 
    public static void DeleteDirectory(string directoryPath)
    {
        if (IsExistDirectory(directoryPath))
        {
            Directory.Delete(directoryPath, true);
        }
    }
    #endregion

    /// <summary>  
    /// 获取指定目录下的所有文件夹名  
    /// </summary>  
    /// <param name="path">目录路径</param>  
    /// <returns>string，返回所有文件夹名字</returns>  
    public string GetAllFolder(string path)
    {
        string folder_Names = "";
        string path1 = "";
        if (!String.IsNullOrEmpty(Request.QueryString["Path"]))
        {
            path1 = Request.QueryString["Path"] + "/";
        }
        else
        {
            path1 = "";
        }
        DirectoryInfo dir = new DirectoryInfo(path);
        foreach (DirectoryInfo subdir in dir.GetDirectories())
        {
            folder_Names += "<tr><td><a href=\"?Path=" + path1 + subdir.Name + "\"><img src=\"images/Smallfolder.gif\" class=\"icon-editdel\">" + subdir.Name + "</a></td>\r";
            folder_Names += "<td class=\"align-center\">" + subdir.CreationTime + "</td>\r";
            folder_Names += "<td class=\"align-center\">" + FileManage.GetFileSize(BasePage.GetRequestId(FileManage.GetDirectoryLength(subdir.FullName).ToString())) + "</td>\r";
            folder_Names += "<td></td></tr>\r";
        }
        return folder_Names;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        GetFiles(Path);
        bool Exists = false;
        if (!String.IsNullOrEmpty(Request.QueryString["Path"]))
        {
            Path = "/UpLoadFile/" + Request.QueryString["Path"];
        }
        int i = 0, j = 0;
        foreach (DataRow dtdr in dt.Rows)
        {
            string _path = dtdr["Name"].ToString();
            DataSet ds = new DataSet();
            int a = 0;

            if (!Exists)
            {
                a = new CommonBll().GetRecordCount("GL_Class", "ClassPic like '%" + _path + "%' or ClassIntro like '%" + _path + "%'");
                if (a > 0)//有数据时
                {
                    Exists = true;
                }
            }

            if (!Exists)
            {//友情链接图片
                a = new CommonBll().GetRecordCount("GL_Link", "LinkLogo like '%" + _path + "%'");
                if (a > 0)//有数据时
                {
                    Exists = true;
                }
            }
            if (!Exists)//内容模型
            {
                //ds = new ModelBll().GetList("ModelType=0");
                ds = new CommonBll().GetList("", "GL_Model", "ModelType=0", "id asc");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string strwhere = "PicUrl like '%" + _path + "%' or Contents like '%" + _path + "%' or FilesUrl like '%" + _path + "%' or Contents2 like '%" + _path + "%' or Contents3 like '%" + _path + "%'";
                    a = new CommonBll().GetRecordCount(dr["ModelTable"].ToString(), strwhere);
                    if (a > 0)//有数据时
                    {
                        Exists = true;
                    }
                }

            }
            if (!Exists)//产品模型
            {
                // ds = new ModelBll().GetList("ModelType=1");
                ds = new CommonBll().GetList("", "GL_Model", "ModelType=1", "id asc");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string strwhere = "PicUrl like '%" + _path + "%' or BigPhoto like '%" + _path + "%' or FilesUrl like '%" + _path + "%' or Contents like '%" + _path + "%' or Contents2 like '%" + _path + "%' or Contents3 like '%" + _path + "%'";
                    a = new CommonBll().GetRecordCount(dr["ModelTable"].ToString(), strwhere);
                    if (a > 0)//有数据时
                    {
                        Exists = true;
                    }
                }

            }
            if (!Exists)//产品相册
            {
                a = new CommonBll().GetRecordCount("GL_Album", "PhotoUrl like '%" + _path + "%'");//产品相册
                if (a > 0)//有数据时
                {
                    Exists = true;
                }

            }
            //单页内容
            if (!Exists)
            {
                a = new CommonBll().GetRecordCount("GL_DIYPage", "PageContents like '%" + _path + "%' or PagePicUrl like '%" + _path + "%'");
                if (a > 0)//有数据时
                {
                    Exists = true;
                }
            }
            //广告
            if (!Exists)
            {
                a = new CommonBll().GetRecordCount("GL_AD", "ADContents like '%" + _path + "%' or ADurl like '%" + _path + "%'");
                if (a > 0)//有数据时
                {
                    Exists = true;
                }
            }
            //方块
            if (!Exists)
            {
                a = new CommonBll().GetRecordCount("GL_Block", "Contents like '%" + _path + "%'");
                if (a > 0)//有数据时
                {
                    Exists = true;
                }
            }
            //会员表
            if (!Exists)
            {
                a = new CommonBll().GetRecordCount("GL_User", "UserFace like '%" + _path + "%' or CompanyLogo like '%" + _path + "%' or BrandLogo like '%" + _path + "%' or BusinessLicense like '%" + _path + "%'");
                if (a > 0)//有数据时
                {
                    Exists = true;
                }
            }

            if (!Exists)
            {
                DeleteFile(MapPath(Path + "/" + _path));
                j++;
            }
            Exists = false;
            i++;
        }
        string backurl = "filesmanage.aspx";
        if (Request.UrlReferrer != null)
        {
            ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            backurl = ViewState["UrlReferrer"].ToString();
        }
        BasePage.JscriptPrint(Page, "清除成功，共遍历" + i + "个文件，共删除" + j + "个文件", backurl);
    }
}