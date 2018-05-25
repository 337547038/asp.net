using System;
namespace GL.Model
{
    /// <summary>
    /// UserModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class UserModel
    {
        public UserModel()
        { }
        #region Model
        private int _id;
        private int? _groupid;
        private string _username;
        private string _password;
        private int? _locked;
        private string _email;
        private string _qq;
        private string _city;
        private string _address;
        private int? _sex;
        private string _userface;
        private DateTime? _regdate;
        private DateTime? _lastlogintime;
        private int? _logintimes;
        private string _company;
        private string _tel;
        private string _lastloginip;
        private string _wenxin;
        private string _source;
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
        public int? GroupID
        {
            set { _groupid = value; }
            get { return _groupid; }
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
        /// 密码问题
        /// </summary>
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int? Locked
        {
            set { _locked = value; }
            get { return _locked; }
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
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
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
        public int? Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 头像
        /// </summary>
        public string UserFace
        {
            set { _userface = value; }
            get { return _userface; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RegDate
        {
            set { _regdate = value; }
            get { return _regdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int? LoginTimes
        {
            set { _logintimes = value; }
            get { return _logintimes; }
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
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
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
        public string WenXin
        {
            set { _wenxin = value; }
            get { return _wenxin; }
        }
        /// <summary>
        /// 注册来源
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        #endregion Model

    }
}

