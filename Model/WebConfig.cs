using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class WebConfigModel
    {
        public WebConfigModel()
        { }
        #region Model
        private int _id;
        private string _sitename;
        private string _sitetitle;
        private string _siteurl;
        private string _sitetitleen;
        private string _siteicp;
        private string _siteicphtml;
        private string _sitekeyword;
        private string _sitedescription;
        private string _sitekeyworden;
        private string _sitedescriptionen;
      
        private string _sitefax;
        private string _sitetel;
        private string _siteaddress;
        private string _siteqq;
        private string _sitemail;
        private string _emailsmtp;
        private string _emailname;
        private string _emailpassword;
        private string _sitecnzz;
        private string _other;
        private string _siteconfig;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteName
        {
            set { _sitename = value; }
            get { return _sitename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteTitle
        {
            set { _sitetitle = value; }
            get { return _sitetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteUrl
        {
            set { _siteurl = value; }
            get { return _siteurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteTitleEn
        {
            set { _sitetitleen = value; }
            get { return _sitetitleen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteICP
        {
            set { _siteicp = value; }
            get { return _siteicp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteIcpHtml
        {
            set { _siteicphtml = value; }
            get { return _siteicphtml; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteKeyword
        {
            set { _sitekeyword = value; }
            get { return _sitekeyword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteDescription
        {
            set { _sitedescription = value; }
            get { return _sitedescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteKeywordEn
        {
            set { _sitekeyworden = value; }
            get { return _sitekeyworden; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteDescriptionEn
        {
            set { _sitedescriptionen = value; }
            get { return _sitedescriptionen; }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public string SiteFax
        {
            set { _sitefax = value; }
            get { return _sitefax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteTel
        {
            set { _sitetel = value; }
            get { return _sitetel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteAddress
        {
            set { _siteaddress = value; }
            get { return _siteaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteQQ
        {
            set { _siteqq = value; }
            get { return _siteqq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteMail
        {
            set { _sitemail = value; }
            get { return _sitemail; }
        }
        /// <summary>
        /// SMTP服务器地址
        /// </summary>
        public string EmailSMTP
        {
            set { _emailsmtp = value; }
            get { return _emailsmtp; }
        }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string EmailName
        {
            set { _emailname = value; }
            get { return _emailname; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string EmailPassword
        {
            set { _emailpassword = value; }
            get { return _emailpassword; }
        }

        public string Sitecnzz
        {
            set { _sitecnzz = value; }
            get { return _sitecnzz; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string Other
        {
            set { _other = value; }
            get { return _other; }
        }

        /// <summary>
        /// 配置信息
        /// </summary>
        public string SiteConfig
        {
            set { _siteconfig = value; }
            get { return _siteconfig; }
        }
        #endregion Model

    }
}

