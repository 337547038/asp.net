using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Text.RegularExpressions;

namespace GL.Utility
{
    /// <summary>
    ///GetPage 的摘要说明
    /// </summary>
    public class GetPage
    {
        public GetPage()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 静态列表页分页
        /// </summary>
        /// <param name="totalrecord">总记录数</param>
        /// <param name="PageSize">总页数</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="prefix">如:list</param>
        /// <param name="suffix">如:.shtml</param>
        /// <returns></returns>
        public static string GetHtmlPager(int totalrecord, int PageSize, int currentPage, string prefix, string suffix, int pagestyle)
        {
            int pageCount = 1;//根据传过每个记录数算出总分页
            if (totalrecord % PageSize != 0)
            {
                pageCount = (totalrecord / PageSize) + 1;
            }
            else
            {
                pageCount = (totalrecord / PageSize);
            }

            int stepNum = 4;
            int pageRoot = 1;
            pageCount = pageCount == 0 ? 1 : pageCount;
            currentPage = currentPage == 0 ? 1 : currentPage;
            StringBuilder sb = new StringBuilder();
            sb.Append("<div id=\"fenye\" class=\"fy\">");
            if (currentPage - stepNum < 2)
                pageRoot = 1;
            else
                pageRoot = currentPage - stepNum;
            int pageFoot = pageCount;
            if (currentPage + stepNum >= pageCount)
                pageFoot = pageCount;
            else
                pageFoot = currentPage + stepNum;
            if (pagestyle == 2)
            {
                if (pageRoot == 1)
                {
                    if (currentPage > 1)
                    {

                        string y = "_" + Convert.ToString(currentPage - 1);
                        if (currentPage == 2)
                        {
                            y = "";
                        }
                        sb.Append("<a href=\"" + prefix + y + suffix + "\" title=\"上页\" class=\"other\">&lt;&lt;Previous</a>");
                    }
                    else
                    {
                        sb.Append("<span>&lt;&lt;Previous</span>");
                    }
                }
                else
                {
                    string y = "_" + Convert.ToString(currentPage - 1);
                    if (currentPage == 2)
                    {
                        y = "";
                    }
                    sb.Append("<a href=\"" + prefix + y + suffix + "' title=\"上页\" class=\"other\">&lt;&lt;Previous</a>");
                }
                for (int i = pageRoot; i <= pageFoot; i++)
                {
                    if (i == currentPage)
                    {
                        sb.Append("<a href=\"javascript:;\" class=\"current\">" + i.ToString() + "</a>");
                    }
                    else
                    {
                        string y = "_" + i.ToString();
                        if (i == 1)
                        {
                            y = "";
                        }
                        sb.Append("<a href=\"" + prefix + y + suffix + "\" title=\"第" + i.ToString() + "页\">" + i.ToString() + "</a>\r");
                    }
                    if (i == pageCount)
                        break;
                }
                if (pageFoot == pageCount)
                {
                    if (pageCount > currentPage)
                    {
                        sb.Append("<a href=\"" + prefix + "_" + Convert.ToString(currentPage + 1) + suffix + "\" title=\"下页\" class=\"other\">Next&gt;&gt;</a>");
                    }
                    else
                    {
                        sb.Append("<span>Next&gt;&gt;</span>");
                    }
                }
                else
                {
                    sb.Append("<a href=\"" + prefix + "_" + Convert.ToString(currentPage + 1) + suffix + "\" title=\"下页\" class=\"other\">Next&gt;&gt;</a>");
                }

            }
            else
            {
                sb.Append("共<span class=\"totalrecord\">" + totalrecord + "</span>条");
                sb.Append("每页<span class=\"totalrecord\">" + PageSize + "</span>篇");
                sb.Append("&nbsp;页次：<span class=\"currpage\">" + currentPage.ToString() + "</span>/<span class=\"totalpage\">" + pageCount.ToString() + "</span>\r");

                if (pageRoot == 1)
                {
                    if (currentPage > 1)
                    {
                        sb.Append("<a href=\"" + prefix + suffix + "\" title=\"首页\">首页</a>");
                        string y = "_" + Convert.ToString(currentPage - 1);
                        if (currentPage == 2)
                        {
                            y = "";
                        }
                        sb.Append("<a href=\"" + prefix + y + suffix + "\" title=\"上页\">上页</a>");
                    }
                    else
                    {
                        sb.Append("<a href=\"javascript:;\">首页</a>");
                        sb.Append("<a href=\"javascript:;\">上页</a>");
                    }
                }
                else
                {
                    sb.Append("<a href=\"" + prefix + suffix + "' title=\"首页\">首页</a>");
                    string y = "_" + Convert.ToString(currentPage - 1);
                    if (currentPage == 2)
                    {
                        y = "";
                    }
                    sb.Append("<a href=\"" + prefix + y + suffix + "' title=\"上页\">上页</a>");
                }
                for (int i = pageRoot; i <= pageFoot; i++)
                {
                    if (i == currentPage)
                    {
                        sb.Append("<a href=\"javascript:;\" class=\"cur\">" + i.ToString() + "</a>");
                    }
                    else
                    {
                        string y = "_" + i.ToString();
                        if (i == 1)
                        {
                            y = "";
                        }
                        sb.Append("<a href=\"" + prefix + y + suffix + "\" title=\"第" + i.ToString() + "页\">" + i.ToString() + "</a>\r");
                    }
                    if (i == pageCount)
                        break;
                }
                if (pageFoot == pageCount)
                {
                    if (pageCount > currentPage)
                    {
                        sb.Append("<a href=\"" + prefix + "_" + Convert.ToString(currentPage + 1) + suffix + "\" title=\"下页\">下页</a>");
                        sb.Append("<a href=\"" + prefix + "_" + pageCount.ToString() + suffix + "\" title=\"尾页\">尾页</a>");
                    }
                    else
                    {
                        sb.Append("<a href=\"javascript:;\">下页</a>");
                        sb.Append("<a href=\"javascript:;\">尾页</a>");
                    }
                }
                else
                {
                    sb.Append("<a href=\"" + prefix + "_" + Convert.ToString(currentPage + 1) + suffix + "\" title=\"下页\">下页</a>");
                    sb.Append("<a href=\"" + prefix + "_" + pageCount.ToString() + suffix + "\" title=\"尾页\">尾页</a>");
                }
            }
            sb.Append("</div>");
            return sb.ToString();
        }

        /// <summary>
        /// 动态列表分页从静态修改而成
        /// </summary>
        /// <param name="totalrecord">总记录数</param>
        /// <param name="PageSize">每页多少条记录</param>
        /// <param name="currentPage">当前页</param>
        /// <returns></returns>
        public static string GetAspxPager(int totalrecord, int PageSize, int currentPage)
        {

            int pageCount;  //根据传过每个记录数算出总分页娄
            if (totalrecord % PageSize != 0)
            {
                pageCount = (totalrecord / PageSize) + 1;
            }
            else
            {
                pageCount = (totalrecord / PageSize);
            }
            string url = "";
            string url2 = System.Web.HttpContext.Current.Request.CurrentExecutionFilePath;//url= /aaa/bbb.aspx
            string url3 = HttpContext.Current.Request.Url.Query;//参数url= ?id=5&name=kelli
            string url4 = System.Web.HttpContext.Current.Request.RawUrl;//url= /aaa/bbb.aspx?id=5&name=kelli

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"page=.*", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@"&page=.*", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            url4 = regex.Replace(url4.ToLower(), "");
            url4 = regex2.Replace(url4.ToLower(), "");

            if (String.IsNullOrEmpty(url3))//如果取得参数为空
            {
                url = url2 + "?";
            }
            else
            {
                if (String.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["page"]))//仅加一次&
                {
                    url = url4 + "&";
                }
                else
                {
                    url = url4;
                }

            }
            int stepNum = 4;
            int pageRoot = 1;
            pageCount = pageCount == 0 ? 1 : pageCount;
            currentPage = currentPage == 0 ? 1 : currentPage;
            StringBuilder sb = new StringBuilder();
            sb.Append("<div id=\"fenye\">");
            sb.Append("共&nbsp;<span id=\"totalrecord\">" + totalrecord + "&nbsp;</span>条&nbsp;");
            sb.Append("每页&nbsp;<span id=\"totalrecord\">" + PageSize + "&nbsp;</span>条&nbsp;");
            sb.Append("页次：<span id=\"currpage\" style=\"color:red\">" + currentPage.ToString() + "</span>/<span id=\"totalpage\">" + pageCount.ToString() + "&nbsp;</span>\r");
            if (currentPage - stepNum < 2)
                pageRoot = 1;
            else
                pageRoot = currentPage - stepNum;
            int pageFoot = pageCount;
            if (currentPage + stepNum >= pageCount)
                pageFoot = pageCount;
            else
                pageFoot = currentPage + stepNum;
            if (pageRoot == 1)
            {
                if (currentPage > 1)
                {
                    sb.Append("<a href='" + url + "Page=1" + "' title='首页'>首页</a>&nbsp;\r");
                    sb.Append("<a href='" + url + "Page=" + Convert.ToString(currentPage - 1) + "' title='上页'>上页</a>&nbsp;\r");
                }
                else
                {
                    sb.Append("首页&nbsp;\r");
                    sb.Append("上页&nbsp;\r");
                }
            }
            else
            {
                sb.Append("<a href='" + url + "Page=1" + "' title='首页'>首页</a>&nbsp;\r");
                sb.Append("<a href='" + url + "Page=" + Convert.ToString(currentPage - 1) + "' title='上页'>上页</a>&nbsp;\r");
            }
            //for (int i = pageRoot; i <= pageFoot; i++)
            //{
            //    if (i == currentPage)
            //    {
            //        sb.Append("<li class='current'>&nbsp;" + i.ToString() + "&nbsp;</li>\r");
            //    }
            //    else
            //    {
            //        sb.Append("<li>&nbsp;<a href='" + prefix + i.ToString() + suffix + "' title='第" + i.ToString() + "页'>" + i.ToString() + "</a>&nbsp;</li>\r");
            //    }
            //    if (i == pageCount)
            //        break;
            //}
            if (pageFoot == pageCount)
            {
                if (pageCount > currentPage)
                {
                    sb.Append("<a href='" + url + "Page=" + Convert.ToString(currentPage + 1) + "' title='下页'>下页</a>&nbsp;\r");
                    sb.Append("<a href='" + url + "Page=" + pageCount.ToString() + "' title='尾页'>尾页</a>&nbsp;\r");
                }
                else
                {
                    sb.Append("下页&nbsp;\r");
                    sb.Append("尾页&nbsp;\r");
                }
            }
            else
            {
                sb.Append("<a href='" + url + "Page=" + Convert.ToString(currentPage + 1) + "' title='下页'>下页</a>&nbsp;\r");
                sb.Append("<a href='" + url + "Page=" + pageCount.ToString() + "' title='尾页'>尾页</a>&nbsp;\r");
            }
            sb.Append("</div>");
            return sb.ToString();
        }

        /// <summary>
        /// 动态列表分页从静态修改而成不同输入样式
        /// </summary>
        /// <param name="totalrecord">总记录数</param>
        /// <param name="PageSize">每页多少条记录</param>
        /// <param name="currentPage">当前页</param>
        /// <returns></returns>
        public static string GetAspxPager(int totalrecord, int PageSize, int currentPage, int style)
        {

            int pageCount;  //根据传过每个记录数算出总分页娄
            if (totalrecord % PageSize != 0)
            {
                pageCount = (totalrecord / PageSize) + 1;
            }
            else
            {
                pageCount = (totalrecord / PageSize);
            }
            string url = "";
            string url2 = System.Web.HttpContext.Current.Request.CurrentExecutionFilePath;//url= /aaa/bbb.aspx
            string url3 = HttpContext.Current.Request.Url.Query;//参数url= ?id=5&name=kelli
            string url4 = System.Web.HttpContext.Current.Request.RawUrl;//url= /aaa/bbb.aspx?id=5&name=kelli
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"page=.*", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@"&page=.*", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            url4 = regex.Replace(url4.ToLower(), "");
            url4 = regex2.Replace(url4.ToLower(), "");

            if (String.IsNullOrEmpty(url3))//如果取得参数为空
            {
                url = url2 + "?";
            }
            else
            {
                if (String.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["page"]))//仅加一次&
                {
                    url = url4 + "&";
                }
                else
                {
                    url = url4;
                }

            }
            int stepNum = 4;
            int pageRoot = 1;
            pageCount = pageCount == 0 ? 1 : pageCount;
            currentPage = currentPage == 0 ? 1 : currentPage;
            StringBuilder sb = new StringBuilder();
            sb.Append("<div id=\"fenye\">");
            sb.Append("共&nbsp;<span id=\"totalrecord\">" + totalrecord + "&nbsp;</span>条&nbsp;");
            sb.Append("每页&nbsp;<span id=\"totalrecord\">" + PageSize + "&nbsp;</span>条&nbsp;");
            sb.Append("页次：<span id=\"currpage\" style=\"color:red\">" + currentPage.ToString() + "</span>/<span id=\"totalpage\">" + pageCount.ToString() + "&nbsp;</span>\r");
            pageRoot = currentPage - stepNum;
            pageRoot = pageRoot > 2 ? pageRoot : 1;
            int pageFoot = currentPage + stepNum;
            pageFoot = pageFoot > pageCount ? pageCount : pageFoot;


            if (pageRoot == 1)
            {
                if (currentPage > 1)
                {
                    sb.Append("<a href='" + url + "Page=1" + "' title='首页'>首页</a>&nbsp;\r");
                    sb.Append("<a href='" + url + "Page=" + Convert.ToString(currentPage - 1) + "' title='上页'>上页</a>&nbsp;\r");
                }
                else
                {
                    sb.Append("首页&nbsp;\r");
                    sb.Append("上页&nbsp;\r");
                }
            }
            else
            {
                sb.Append("<a href='" + url + "Page=1" + "' title='首页'>首页</a>&nbsp;\r");
                sb.Append("<a href='" + url + "Page=" + Convert.ToString(currentPage - 1) + "' title='上页'>上页</a>&nbsp;\r");
            }
            //for (int i = pageRoot; i <= pageFoot; i++)
            //{
            //    if (i == currentPage)
            //    {
            //        sb.Append("<li class='current'>&nbsp;" + i.ToString() + "&nbsp;</li>\r");
            //    }
            //    else
            //    {
            //        sb.Append("<li>&nbsp;<a href='" + url +"Page="+ i.ToString() + "' title='第" + i.ToString() + "页'>" + i.ToString() + "</a>&nbsp;</li>\r");
            //    }
            //    if (i == pageCount)
            //        break;
            //}
            if (pageFoot == pageCount)
            {
                if (pageCount > currentPage)
                {
                    sb.Append("<a href='" + url + "Page=" + Convert.ToString(currentPage + 1) + "' title='下页'>下页</a>&nbsp;\r");
                    sb.Append("<a href='" + url + "Page=" + pageCount.ToString() + "' title='尾页'>尾页</a>&nbsp;\r");
                }
                else
                {
                    sb.Append("下页&nbsp;\r");
                    sb.Append("尾页&nbsp;\r");
                }
            }
            else
            {
                sb.Append("<a href='" + url + "Page=" + Convert.ToString(currentPage + 1) + "' title='下页'>下页</a>&nbsp;\r");
                sb.Append("<a href='" + url + "Page=" + pageCount.ToString() + "' title='尾页'>尾页</a>&nbsp;\r");
            }
            sb.Append("</div>");
            return sb.ToString();
        }

        /// <summary>
        /// 内容分页代码
        /// </summary>
        /// <param name="contents">内容</param>
        /// <param name="PageIndex">当前页</param>
        /// <returns></returns>
        public static string ContentPage(string contents, int PageIndex)
        {
            string url = System.Web.HttpContext.Current.Request.RawUrl;//url= /aaa/bbb.aspx?id=5&name=kelli
            string[] page = Regex.Split(contents, @"\[NextPage\]", RegexOptions.IgnoreCase);
            if (page.Length > 1)//有分页
            {
                if (PageIndex > page.Length)//超出时显示最后一页
                {
                    PageIndex = page.Length;
                }
                if (PageIndex == 0)
                {
                    PageIndex = 1;
                }
                string fy = "<div class=\"pageconfy\">";
                if (PageIndex > 1)
                {
                    fy += "<a href=\"" + url + "&Page=" + (PageIndex - 1) + "\">上一页</a>";
                }
                for (int i = 1; i <= page.Length; i++)
                {
                    if (i == PageIndex)
                    {
                        fy += "<span class=\"cur\">[" + i + "]</span>";
                    }
                    else
                    {
                        fy += "<a href=\"" + url + "&Page=" + i + "\">[" + i + "]</a>";
                    }
                }
                if (PageIndex < page.Length)
                {
                    fy += "<a href=\"" + url + "&Page=" + (PageIndex + 1) + "\">下一页</a>";
                }

                fy += "</div>";
                return page[PageIndex - 1] + fy;
            }
            else
            {
                return contents;
            }
        }




        /// <summary>
        /// 伪静态分页
        /// </summary>
        /// <param name="totalrecord">总记录数</param>
        /// <param name="PageSize">每页多少条记录</param>
        /// <param name="currentPage">当前页</param>
        /// <returns></returns>
        public static string GetHtmlPager(int totalrecord, int PageSize, int currentPage)
        {

            int pageCount;  //根据传过每个记录数算出总分页娄
            if (totalrecord % PageSize != 0)
            {
                pageCount = (totalrecord / PageSize) + 1;
            }
            else
            {
                pageCount = (totalrecord / PageSize);
            }
            string url = HttpContext.Current.Request.RawUrl;
            //如果url不包含.html，为无后缀重写
            int pageType = 0;//0正常，1无后缀重写，2带?参数
            if (url.IndexOf(".html") == -1)
            {
                pageType = 1;
                Regex regex1 = new Regex(@"/p([0-9]+)", RegexOptions.IgnoreCase);
                url = regex1.Replace(url.ToLower(), "");
            }
            else if (url.IndexOf("?") != -1)
            {
                pageType = 2;
                Regex regex1 = new Regex(@"&page=([0-9]+)", RegexOptions.IgnoreCase);
                url = regex1.Replace(url.ToLower(), "");
                Regex regex2 = new Regex(@"page=([0-9]+)", RegexOptions.IgnoreCase);
                url = regex2.Replace(url.ToLower(), "");
            }
            if (pageType == 0)
            {
                Regex regex = new Regex(@"-p(.*).html", RegexOptions.IgnoreCase);
                Regex regex2 = new Regex(@".html", RegexOptions.IgnoreCase);
                url = regex.Replace(url.ToLower(), "");
                url = regex2.Replace(url.ToLower(), "");
            }

            pageCount = pageCount == 0 ? 1 : pageCount;
            currentPage = currentPage == 0 ? 1 : currentPage;
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"pagination\">");
            sb.Append("<span class=\"totalrecord\">共<b>" + totalrecord + "</b>条</span>");
            sb.Append("<span class=\"totalrecord\">每页<b>" + PageSize + "</b>条</span>");
            sb.Append("<span class=\"currpage\">页次：<b class=\"active\">" + currentPage.ToString() + "</b>/<b>" + pageCount.ToString() + "</b></span>");

            if (currentPage == 1)
            {
                sb.Append("<span class=\"link\">首页</span>");
                sb.Append("<span class=\"link\">上页</span>");
            }
            else
            {
                string prev = "";
                string first = "";
                if (pageType == 0)
                {
                    prev = url + "-p" + (currentPage - 1) + ".html";
                    first = url + ".html";
                }
                else if (pageType == 1)
                {
                    prev = url + "/p" + (currentPage - 1) + "";
                    first = url;
                }
                else if (pageType == 2)
                {
                    prev = url + "&page=" + (currentPage - 1) + "";
                    first = url;
                }
                sb.Append("<a href='" + first + "' title='首页'>首页</a>");
                if (currentPage > 2)
                {
                    sb.Append("<a href='" + prev + "' title='上页'>上页</a>");
                }
                else
                {
                    //这时上一页为第一页，即首页
                    sb.Append("<a href='" + first + "' title='上页'>上页</a>");
                }
            }
            if (pageCount > currentPage)
            {
                string next = "";
                string last = "";
                if (pageType == 0)
                {
                    next = url + "-p" + (currentPage + 1) + ".html";
                    last = url + "-p" + pageCount + ".html";
                }
                else if (pageType == 1)
                {
                    next = url + "/p" + (currentPage + 1) + "";
                    last = url + "/p" + pageCount + "";
                }
                else if (pageType == 2)
                {
                    next = url + "&page=" + (currentPage + 1) + "";
                    last = url + "&page=" + pageCount + "";
                }
                sb.Append("<a href='" + next + "' title='下页'>下页</a>");
                sb.Append("<a href='" + last + "' title='尾页'>尾页</a>");

            }
            else
            {
                sb.Append("<span class=\"link\">下页</span>");
                sb.Append("<span class=\"link\">尾页</span>");
            }
            sb.Append("</div>");
            return sb.ToString();
        }
    }
}