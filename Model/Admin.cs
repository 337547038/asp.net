using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    /// <summary>
    /// AdminDal:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>

    public partial class AdminModel
    {
        public AdminModel()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _password;
        private int _sex;
        private string _email;
        private string _telphone;
        private DateTime _adddate = DateTime.Now;
        private string _lastloginip;
        private DateTime _lastlogintime = DateTime.Now;
        private int _locked = 0;
        private string _modelpower;
        private int _logintime = 0;
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
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
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
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TelPhone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastLoginIP
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 锁定
        /// </summary>
        public int Locked
        {
            set { _locked = value; }
            get { return _locked; }
        }
        /// <summary>
        /// 权限模块
        /// </summary>
        public string ModelPower
        {
            set { _modelpower = value; }
            get { return _modelpower; }
        }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginTime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }

        
        #endregion Model

    }
}