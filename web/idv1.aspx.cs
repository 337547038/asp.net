using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GL.Bll;
using GL.Model;
using GL.Utility;
public partial class idv1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      // BasePage.CheckSerialnumber();
       
    }

    //生成 url域名为空时生成16位（不检验域名），否则生成20位；data六位时间；isdel 等于1时删除
    protected string GenerateSerialNumber(string url, string data, string isdel)
    {
        string h = "";
        string r1 = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123698745";
        char[] temp = r1.ToCharArray();   //将字符串转换为数组
        string h1 = temp[new Random().Next(0, r1.Length - 1)].ToString();//随机，字符串第1位
        string h2 = temp[new Random().Next(0, r1.Length - 10)].ToString();//随机，即生成大小写，字符串第16位
        if (isdel == "1")
        {
            h2 = temp[new Random().Next(53, r1.Length - 1)].ToString();//随机生成1-9
        }
        string md5 = FormsAuthentication.HashPasswordForStoringInConfigFile(h1 + h2 + data + "gl?16", "MD5");
        if (data.Length == 8)
        {
            h = h1 + data.Substring(4, 2) + md5.Substring(4, 2) + data.Substring(0, 2) + md5.Substring(8, 2) + data.Substring(6, 2) + md5.Substring(3, 2) + data.Substring(2, 2) + h2;
            if (!String.IsNullOrEmpty(url))
            {
                string urlmd5 = FormsAuthentication.HashPasswordForStoringInConfigFile(h1 + url, "MD5");
                h += urlmd5.Substring(2, 4);
            }
        }
        else
        {
            Response.Write("时间应该为8位数字");
        }
        return h;
    }
    protected void button_Click(object sender, EventArgs e)
    {
        Response.Write(GenerateSerialNumber(txturl.Text,txtdata.Text,ddldel.SelectedValue));
    }
}
