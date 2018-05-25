using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.IO;

namespace GL.Utility
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region 修改过滤特殊字符
        /// <summary>
        /// 修改特殊字符
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        public static string CheckStr(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }
            else
            {
                //return str.Replace("<br />\r\n", "\r\n").Replace("&", "&amp;").Replace("'", "&apos;").Replace(@"""", "&quot;").Replace(" ", "&nbsp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace(" ", "&nbsp;").Replace("where", "wh&#101;re").Replace("select", "sel&#101;ct").Replace("insert", "ins&#101;rt").Replace("create", "cr&#101;ate").Replace("drop", "dro&#112").Replace("alter", "alt&#101;r").Replace("delete", "del&#101;te").Replace("update", "up&#100;ate").Replace("or", "o&#114").Replace("\"", @"&#34;").Replace("\r\n", "<br />\r\n").Replace("and", "an&#101;d");
                str = str.ToLower().Replace("&", "&amp;");
                str = str.ToLower().Replace("<", "&lt;");
                str = str.ToLower().Replace(">", "&gt;");
                str = str.ToLower().Replace("'", "&apos;");
                str = str.ToLower().Replace("%", ".%.");
                str = str.ToLower().Replace(" ", "&nbsp:");
                str = str.ToLower().Replace("and", "an&#100");
                str = str.ToLower().Replace("insert", "ins&#101;rt");
                str = str.ToLower().Replace("where", "wh&#101;re");
                str = str.ToLower().Replace("create", "cr&#101;ate");
                str = str.ToLower().Replace("drop", "dro&#112");
                str = str.ToLower().Replace("alter", "alt&#101;r");
                str = str.ToLower().Replace("delete", "d&#101;lete");
                str = str.ToLower().Replace("update", "up&#100;ate");
                str = str.ToLower().Replace("or", "o&#114");
                str = str.ToLower().Replace("=", ".=.");
                str = str.ToLower().Replace("?", ".?.");
                str = str.ToLower().Replace("select", "s&#101;lect");
                return str;

            }
        }
        #endregion

        #region 恢复过滤特殊字符
        /// <summary>
        /// 恢复特殊字符
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        public static string UnCheckStr(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }
            else
            {
                //return str.Replace("\r\n", "<br />\r\n").Replace("&amp;", "&").Replace("&apos;", "'").Replace("&quot;", @"""").Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp;", " ").Replace("wh&#101;re", "where").Replace("sel&#101;ct", "select").Replace("ins&#101;rt", "inset").Replace("cr&#101;ate", "create").Replace("dro&#112", "drop").Replace("alt&#101;r", "alter").Replace("del&#101;te", "delete").Replace("up&#100;ate", "update").Replace("o&#114", "or").Replace(@"&#34;", "\"").Replace("<br />\r\n", "\r\n").Replace("and", "an&#101;d");
                str = str.ToLower().Replace("amp;", "&");
                str = str.ToLower().Replace("&lt;", "<");
                str = str.ToLower().Replace("&gt;", ">");
                str = str.ToLower().Replace("&apos;", "'");
                str = str.ToLower().Replace(".%.;", "%");
                str = str.ToLower().Replace("&nbsp:", " ");
                str = str.ToLower().Replace("an&#100;", "and");
                str = str.ToLower().Replace("ins&#101;rt", "insert");
                str = str.ToLower().Replace("wh&#101;re", "where");
                str = str.ToLower().Replace("cr&#101;ate", "create");
                str = str.ToLower().Replace("dro&#112;", "drop");
                str = str.ToLower().Replace("alt&#101;r", "alter");
                str = str.ToLower().Replace("d&#101;lete", "delete");
                str = str.ToLower().Replace("up&#100;ate", "update");
                str = str.ToLower().Replace("o&#114;", "or");
                str = str.ToLower().Replace(".=.", "=");
                str = str.ToLower().Replace(".?.;", "?");
                str = str.ToLower().Replace("s&#101;lect", "select");
                return str;
            }
        }
        #endregion

        #region 弹出JavaScript窗口并返回
        /// <summary>
        /// 弹出JavaScript窗口并返回
        /// </summary>
        /// <param name="js">窗口信息</param>
        public static void Alertback(string message)
        {
            string js = @"<Script language='JavaScript'>alert('" + message + "');window.history.back()</Script>";
            HttpContext.Current.Response.Write(js);
        }
        public static void Alertback(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", "<Script language='JavaScript'>alert('" + msg + "');window.history.back()</Script>");
        }
        #endregion

        #region 弹出消息框并且转向新的URL
        /// <summary>
        /// 弹出消息框并且转向新的URL
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="toURL">连接地址</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            #region
            string js = "<Script language=JavaScript>alert('{0}');window.location.replace('{1}')</Script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
            HttpContext.Current.Response.End();

            #endregion
        }
        public static void AlertAndRedirect(System.Web.UI.Page page, string msg, string toUrl)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", "<Script language='JavaScript'>alert('" + msg + "');window.location.replace('" + toUrl + "')</Script>");
        }
        #endregion

        #region 添加编辑删除可以自动关闭的提示,结合js
        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        public static void JscriptPrint(System.Web.UI.Page page, string msgtitle, string url)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "parent.jsprint(\"" + msgtitle + "\",\"" + url + "\")\n";
            msbox += "</script>\n";
            page.ClientScript.RegisterStartupScript(page.GetType(), "JsPrint", msbox);
            //ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox);
        }


        #endregion

        #region 判断数组是否存在某个值的方法
        /// <summary>
        /// 判断数组是否存在某个值的方法
        /// </summary>
        /// <param name="Array">数组</param>
        /// <param name="str">str是否存在数组中</param>
        public static bool ArrayExist(string Array, string str)
        {
            bool b = false;
            if (String.IsNullOrEmpty(Array))
            {
                Array = "";
            }
            string str1 = Array;
            string[] str2 = str1.Split(',');

            foreach (string a in str2)
            {
                if (a == str)
                {
                    b = true;
                    break;
                }
            }

            return b;
        }
        #endregion

        #region 将指定字符串按指定长度进行剪切
        ///   <summary> 
        ///   将指定字符串按指定长度进行剪切， 
        ///   </summary> 
        ///   <param   name= "oldStr "> 需要截断的字符串 </param> 
        ///   <param   name= "maxLength "> 字符串的最大长度 </param> 
        ///   <param   name= "endWith "> 超过长度的后缀 </param> 
        ///   <returns> 如果超过长度，返回截断后的新字符串加上后缀，否则，返回原字符串 </returns> 
        public static string StringTruncat(string oldStr, int maxLength, string endWith)
        {
            if (string.IsNullOrEmpty(oldStr))
                //   throw   new   NullReferenceException( "原字符串不能为空 "); 
                return oldStr + endWith;
            if (maxLength < 1)
                throw new Exception("返回的字符串长度必须大于[0] ");
            if (oldStr.Length > maxLength)
            {
                string strTmp = oldStr.Substring(0, maxLength);
                if (string.IsNullOrEmpty(endWith))
                    return strTmp;
                else
                    return strTmp + endWith;
            }
            return oldStr;
        }
        #endregion

        #region 生成日期随机码
        /// <summary>
        /// 生成日期随机码
        /// </summary>
        /// <returns></returns>
        public static string GetRamCode()
        {
            #region
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            #endregion
        }
        #endregion

        #region 生成指定长度的字符串
        /// <summary>
        /// 生成指定长度的字符串,即生成strLong个str字符串
        /// </summary>
        /// <param name="strLong">生成的长度</param>
        /// <param name="str">以str生成字符串</param>
        /// <returns></returns>
        public static string StringOfChar(int strLong, string str)
        {
            string ReturnStr = "";
            for (int i = 0; i < strLong; i++)
            {
                ReturnStr += str;
            }

            return ReturnStr;
        }
        #endregion

        #region HTML过滤成普通文本
        /// <summary>
        /// HTML过滤成普通文本
        /// </summary>
        /// <param name="strHtml">HTML文本</param>
        /// <returns></returns>
        public static string HtmlFilter(string strHtml)
        {
            if (!String.IsNullOrEmpty(strHtml))
            {
                string tmpHtml = strHtml.Trim();
                tmpHtml = tmpHtml.Replace("&ldquo;", "“");
                tmpHtml = tmpHtml.Replace("&rdquo;", "”");
                tmpHtml = RegReplace(tmpHtml, @"<!\[CDATA\[(.*)\]\]>", "$1");
                tmpHtml = RegReplace(tmpHtml, @"<.+?>", "");
                tmpHtml = RegReplace(tmpHtml, @"<!--/*[^<>]*-->", "");
                tmpHtml = RegReplace(tmpHtml, @"(?:&nbsp;?)+", " ");
                tmpHtml = RegReplace(tmpHtml, @"&\w+?;", "");
                tmpHtml = RegReplace(tmpHtml, @"\s+", " ");
                return tmpHtml;
            }
            else
            {
                return strHtml;
            }
        }
        public static string RegReplace(string strSourceText, string strRegPattern, string strReplaceText)
        {
            Regex regRegex = CreateRegex(strRegPattern);
            if (string.IsNullOrEmpty(strSourceText))
            {
                return "";
            }
            else
            {
                return regRegex.Replace(strSourceText, strReplaceText);
            }
        }
        public static Regex CreateRegex(string regPattern)
        {
            string tmpRegPattern = regPattern;
            if (string.IsNullOrEmpty(tmpRegPattern))
            {
                tmpRegPattern = "";
            }
            return new Regex(tmpRegPattern, RegexOptions.IgnoreCase);
        }
        #endregion

        #region 检测是否有Sql危险字符
        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果Fales存在</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 检查危险字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string SqlStringFilter(string Str)
        {
            if (!String.IsNullOrEmpty(Str))
            {
                try
                {
                    string SqlStr = "*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(";
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.ToLower().IndexOf(ss.Trim()) >= 0)
                        {
                            BasePage.Alertback("字符串含有非法字符！");
                            break;
                        }
                    }
                    Str = Str.Replace("'", "''");
                }
                catch
                {
                    return Str;
                }
                return Str;
            }
            return Str;
        }


        #endregion

        #region 判断接收ID是否合法
        /// <summary>
        /// 判断接收ID是否合法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetRequestId(string id)
        {
            int gid;
            try
            {
                gid = Convert.ToInt32(id);
            }
            catch
            {
                gid = 0;
            }
            return gid;
        }

        #endregion

        #region 获得当前页面客户端的IP
        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string clientIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(clientIP))
            {
                clientIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(clientIP))
            {
                clientIP = HttpContext.Current.Request.UserHostAddress;
            }
            return clientIP;
        }

        #endregion

        #region 日期格式化
        /// <summary>
        /// 日期格式化
        /// </summary>
        /// <returns></returns>
        public static string formatDateTime(string dt)
        {
            string datetime = "";
            try
            {
                datetime = Convert.ToDateTime(dt).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {

            }
            return datetime;
        }

        #endregion

        /// <summary>
        /// 返回访问的url地址
        /// </summary>
        /// <param name="type">0时返回浏览器当前显示的地址，否则返回真实地址</param>
        /// <returns></returns>
        public static string GetUrl(int type)
        {
            if (type == 0) {
                return HttpContext.Current.Request.RawUrl;
                
            }else
            {
                return HttpContext.Current.Request.CurrentExecutionFilePath + HttpContext.Current.Request.Url.Query;
            }
        }

        /// <summary>
        /// 站点识别码
        /// </summary>
        /// <returns></returns>
        public static string SiteId()
        {
            return "";
        }
        /// <summary>
        /// 验证序列号
        /// </summary>
        public static void CheckSerialnumber()
        {
            //string word = GreateFiles.Read_File(System.Web.HttpContext.Current.Server.MapPath("~/id.txt")).Trim();//这里还要去掉前后空格
            //if (!String.IsNullOrEmpty(word))
            //{
            //    string url = HttpContext.Current.Request.Url.Host.ToString();//HttpContext.Current.Request.Url.Host;
            //    bool localhost = false;
            //    if (url == "localhost" || url.IndexOf("127") == 0 || url.IndexOf("192") == 0) { localhost = true; }
            //    if (word.Length == 20 || word.Length == 16)
            //    {
            //        int data = GetRequestId(word.Substring(5, 2) + word.Substring(12, 2) + word.Substring(2, 2) + word.Substring(9, 2));
            //        int isdel = GetRequestId(word.Substring(11, 1));
            //        int d = GetRequestId(Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd"));
            //        if (data < d)
            //        {
            //            delindex(isdel);
            //            HttpContext.Current.Response.End();
            //        }
            //        string h = word.Substring(0, 1) + word.Substring(11, 1);
            //        string md5 = FormsAuthentication.HashPasswordForStoringInConfigFile(h + data + "gl?16", "MD5");
            //        string sitemd5 = FormsAuthentication.HashPasswordForStoringInConfigFile(h + SiteId() + "gl?16", "MD5");
            //        if (md5.Substring(15, 1) != word.Substring(1, 1) || md5.Substring(8, 1) != word.Substring(7, 1) || md5.Substring(3, 1) != word.Substring(14, 1))
            //        {
            //            delindex(isdel);
            //            HttpContext.Current.Response.End();
            //        }
            //        if (word.Substring(4, 1) != sitemd5.Substring(8, 1) || word.Substring(8, 1) != sitemd5.Substring(18, 1) || word.Substring(15, 1) != sitemd5.Substring(25, 1))
            //        {
            //            delindex(isdel);
            //            HttpContext.Current.Response.End();
            //        }
            //        if (word.Length == 20 && !localhost)
            //        {
            //            string urlmd5 = FormsAuthentication.HashPasswordForStoringInConfigFile(md5 + url, "MD5");
            //            if (urlmd5.Substring(20, 4) != word.Substring(16, 4))
            //            {
            //                delindex(isdel);
            //                HttpContext.Current.Response.End();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        delindex(1);
            //        HttpContext.Current.Response.End();
            //    }
            //}
            //else
            //{
            //    delindex(1);
            //    HttpContext.Current.Response.End();
            //}
        }
        private static void delindex(int del)
        {
            if (del > 0)
            {
                if (File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/default.aspx")))
                {
                    GreateFiles.DeleteFile(System.Web.HttpContext.Current.Server.MapPath("~/default.aspx"));
                }
                if (File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/index.html")))
                {
                    GreateFiles.DeleteFile(System.Web.HttpContext.Current.Server.MapPath("~/index.html"));
                }
            }
        }
    }
}
