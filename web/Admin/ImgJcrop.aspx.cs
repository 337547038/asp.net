using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.Linq;
using GL.Utility;
public partial class Admin_ImgJcrop : System.Web.UI.Page
{
    protected string iw = "";
    protected string ih = "";
    protected string id = "";
    protected string picPath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        picPath = Request.QueryString["p"];//图片路径
        id = Request.QueryString["id"];
        int Standard_Width = BasePage.GetRequestId(Request.QueryString["w"]);//裁剪后的图片宽度
        int Standard_Height = BasePage.GetRequestId(Request.QueryString["h"]);//裁剪后的图片高度
        iw = Standard_Width.ToString();
        ih = Standard_Height.ToString();
        if (!Page.IsPostBack)
        {
            string checklogin = new GL.Bll.AdminBll().CheckLogin("no");
            if (checklogin != "true")
            {
                BasePage.Alertback(checklogin);
                Response.End();
            }
           
            if (String.IsNullOrEmpty(iw.ToString()) || String.IsNullOrEmpty(ih.ToString()))
            {
                Response.Write("<script>alert('参数传递错误！')</script>");
                Response.End();
            }
            if (Request.QueryString["ac"] == "next")
            {


                if (String.IsNullOrEmpty(picPath) || String.IsNullOrEmpty(Standard_Width.ToString()) || String.IsNullOrEmpty(Standard_Height.ToString()))
                {
                    Response.Write("<script>alert('请先上传图片再按裁剪！')</script>");
                    Response.End();
                }
                if (!File.Exists(Server.MapPath(picPath)))
                {
                    Response.Write("<script>alert('参数传递错误，图片不存在!')</script>");
                    Response.End();
                }
                target.ImageUrl = picPath;

                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(Server.MapPath(picPath));
                if (imgPhoto.Width <= Standard_Width || imgPhoto.Height <= Standard_Height)//图片的宽高度小于裁剪后的宽高度时
                {
                    //BasePage.Alertback("此图片已是标准大小，不需要裁剪！");
                    imgPhoto.Dispose();
                    // Response.Write("<script>alert('此图片已是小图，不需要裁剪！')</script>");
                    //Response.End();
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script type=\"text/javascript\">alert('此图片已是小图，不需要裁剪');parent.imgJcropsuccess('" + id + "','" + picPath + "');</script>");
                }
                imgPhoto.Dispose();
                string[] fs = picPath.Split('.');
                if (fs[1] != "jpg")
                {
                    //Response.Write("<script>alert('仅支持jpg格式图片！')</script>");
                    // BasePage.Alertback("仅支持jpg格式图片");
                    // Response.End();
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script type=\"text/javascript\">alert('仅支持jpg格式图片!');parent.imgJcropsuccess('" + id + "','" + picPath + "');</script>");
                }
            }

        }

    }

    protected void saveImg(object sender, EventArgs e)
    {
        string tempurl = Server.MapPath(target.ImageUrl);
        int startX = BasePage.GetRequestId(x1.Text);
        int startY = BasePage.GetRequestId(y1.Text);
        int width = BasePage.GetRequestId(w.Text);
        int height = BasePage.GetRequestId(h.Text);
        int sw = BasePage.GetRequestId(Request.QueryString["w"]);
        int sh = BasePage.GetRequestId(Request.QueryString["h"]);
        ImgReduceCutOut(sw, sh, startX, startY, width, height, tempurl, tempurl);
        // BasePage.AlertAndRedirect("裁切成功，请点击返回！", "imgjcrop.aspx?ac=success&id=" + id + "&p=" + picPath);
        //直接执行引用页面的imgJcropsuccess方法
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script type=\"text/javascript\">parent.imgJcropsuccess('"+id+"','"+picPath+"');</script>");
        
  }


    /// <summary>
    /// 缩小裁剪图片
    /// </summary>
    /// <param name="Standard_Width">裁剪后的图片宽度</param>
    /// <param name="Standard_Height">裁剪后的图片商度</param>
    /// <param name="startX">开始裁剪的X坐标</param>
    /// <param name="startY">开始裁剪的Y坐标</param>
    /// <param name="int_Width">要缩小裁剪图片宽度</param>
    /// <param name="int_Height">要缩小裁剪图片长度</param>
    /// <param name="input_ImgUrl">要处理图片路径</param>
    /// <param name="out_ImgUrl">处理完毕图片路径</param>
    public void ImgReduceCutOut(int Standard_Width, int Standard_Height, int startX, int startY, int int_Width, int int_Height, string input_ImgUrl, string out_ImgUrl)
    {
        // ＝＝＝上传标准图大小＝＝＝
        int int_Standard_Width = Standard_Width;
        int int_Standard_Height = Standard_Height;

        int Reduce_Width = 0; // 缩小的宽度
        int Reduce_Height = 0; // 缩小的高度
        int CutOut_Width = 0; // 裁剪的宽度
        int CutOut_Height = 0; // 裁剪的高度
        int level = 100; //缩略图的质量 1-100的范围

        // ＝＝＝获得缩小，裁剪大小＝＝＝
        if (int_Standard_Height * int_Width / int_Standard_Width > int_Height)
        {
            Reduce_Width = int_Width;
            Reduce_Height = int_Standard_Height * int_Width / int_Standard_Width;
            CutOut_Width = int_Width;
            CutOut_Height = int_Height;
        }
        else if (int_Standard_Height * int_Width / int_Standard_Width < int_Height)
        {
            Reduce_Width = int_Standard_Width * int_Height / int_Standard_Height;
            Reduce_Height = int_Height;
            CutOut_Width = int_Width;
            CutOut_Height = int_Height;
        }
        else
        {
            Reduce_Width = int_Width;
            Reduce_Height = int_Height;
            CutOut_Width = int_Width;
            CutOut_Height = int_Height;
        }

        // ＝＝＝通过连接创建Image对象＝＝＝

        System.Drawing.Image oldimage = System.Drawing.Image.FromFile(input_ImgUrl);
        oldimage.Save(Server.MapPath("tepm.jpg"));
        oldimage.Dispose();

        //// ＝＝＝缩小图片＝＝＝
        //System.Drawing.Image thumbnailImage = oldimage.GetThumbnailImage(Reduce_Width, Reduce_Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
        Bitmap bm = new Bitmap(Server.MapPath("tepm.jpg"));


        // ＝＝＝处理JPG质量的函数＝＝＝
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        ImageCodecInfo ici = null;
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.MimeType == "image/jpeg")
            {
                ici = codec;
                break;
            }

        }
        EncoderParameters ep = new EncoderParameters();
        ep.Param[0] = new EncoderParameter(Encoder.Quality, (long)level);


        // ＝＝＝裁剪图片＝＝＝
        Rectangle cloneRect = new Rectangle(startX, startY, CutOut_Width, CutOut_Height);
        PixelFormat format = bm.PixelFormat;
        Bitmap cloneBitmap = bm.Clone(cloneRect, format);

        if (int_Width > int_Standard_Width)
        {
            //缩小图片
            System.Drawing.Image cutImg = cloneBitmap.GetThumbnailImage(int_Standard_Width, int_Standard_Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            cutImg.Save(out_ImgUrl, ici, ep);
            cutImg.Dispose();
        }
        else
        {
            //保存图片
            cloneBitmap.Save(out_ImgUrl, ici, ep);
        }
        cloneBitmap.Dispose();
        bm.Dispose();
        ////删除临时图片
        if (File.Exists(Server.MapPath("tepm.jpg")))
        {
            File.Delete(Server.MapPath("tepm.jpg"));
        }

    }

    public bool ThumbnailCallback()
    {
        return false;
    }
}