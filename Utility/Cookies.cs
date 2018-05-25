using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace GL.Utility
{
    public class Cookies
    {
        /// <summary> 
        /// 保存一个Cookie 
        /// </summary> 
        /// <param name="CookieName">Cookie名称</param> 
        /// <param name="CookieValue">Cookie值</param> 
        /// <param name="CookieTime">Cookie过期时间(小时),0为关闭页面失效</param> 
        public static void SaveCookie(string CookieName, string CookieValue, double CookieTime)
        {
            CookieValue = System.Web.HttpContext.Current.Server.UrlEncode(CookieValue);//转码
            HttpCookie myCookie = new HttpCookie(CookieName);
            DateTime now = DateTime.Now;
            myCookie.Value = CookieValue;
            if (CookieTime != 0)
            {

                myCookie.Expires = now.AddDays(CookieTime);
                if (HttpContext.Current.Response.Cookies[CookieName] != null)
                    HttpContext.Current.Response.Cookies.Remove(CookieName);
                HttpContext.Current.Response.Cookies.Add(myCookie);
            }
            else
            {
                if (HttpContext.Current.Response.Cookies[CookieName] != null)
                    HttpContext.Current.Response.Cookies.Remove(CookieName);
                HttpContext.Current.Response.Cookies.Add(myCookie);
            }
        }

        /// <summary> 
        /// 取得CookieValue 
        /// </summary> 
        /// <param name="CookieName">Cookie名称</param> 
        /// <returns>Cookie的值</returns> 
        public static string GetCookie(string CookieName)
        {
            HttpCookie myCookie = new HttpCookie(CookieName);
            myCookie = HttpContext.Current.Request.Cookies[CookieName];
            if (myCookie != null) { 
                //  return myCookie.Value;
             return   System.Web.HttpContext.Current.Server.UrlDecode(myCookie.Value);
            }
            else { 
                return "";
            }
        }

        ///<summary>
        ///清除cookiesvalue
        ///</summary>
        ///<param name="CookieName">Cookie名称</param>
        public static void ClearCookie(string CookieName)
        {
            HttpCookie myCookie = new HttpCookie(CookieName);
            DateTime now = DateTime.Now;

            myCookie.Expires = now.AddYears(-2);

            HttpContext.Current.Response.Cookies.Add(myCookie);
        }
    }
}
