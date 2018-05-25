using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class GuestBookModel
    {
        public GuestBookModel()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _username;
        private string _tel;
        private string _fax;
        private string _mobile;
        private string _company;
        private string _address;
        private string _email;
        private string _siteurl;
        private string _code;
        private int _sex = 0;
        private DateTime _addtime = DateTime.Now;
        private string _qq;
        private string _wangwang;
        private string _msn;
        private string _contents;
        private int _verific = 0;
        private string _ip;
        private string _reply;
        private DateTime _replytime = DateTime.Now;
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
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
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
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WangWang
        {
            set { _wangwang = value; }
            get { return _wangwang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MSN
        {
            set { _msn = value; }
            get { return _msn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int Verific
        {
            set { _verific = value; }
            get { return _verific; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Reply
        {
            set { _reply = value; }
            get { return _reply; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReplyTime
        {
            set { _replytime = value; }
            get { return _replytime; }
        }
        #endregion Model

    }
}

