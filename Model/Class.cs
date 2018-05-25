using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class ClassModel
    {
        public ClassModel()
        { }
        #region Model
        private int _id;
        private int? _modelid;
        private string _classname;
        private int? _classtype = 0;
        private int? _parentid;
        private int? _classlayer;
        private int? _px = 0;
        private string _seotitle;
        private string _seokeyword;
        private string _seodescription;
        private string _classintro;
        private int? _hide;
        private string _classpic;
        
        private DateTime? _adddate;
        private int? _languagen = 0;
        private string _contents;
        private int? _inputa;
        private int? _inputuser;
        private int? _allowcomment;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 所属模型ID
        /// </summary>
        public int? ModelId
        {
            set { _modelid = value; }
            get { return _modelid; }
        }
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string ClassName
        {
            set { _classname = value; }
            get { return _classname; }
        }
        /// <summary>
        /// 栏目类型0系统栏目1为外链
        /// </summary>
        public int? ClassType
        {
            set { _classtype = value; }
            get { return _classtype; }
        }
        /// <summary>
        /// 父栏目ID
        /// </summary>
        public int? ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 栏目深度
        /// </summary>
        public int? ClassLayer
        {
            set { _classlayer = value; }
            get { return _classlayer; }
        }
        /// <summary>
        /// 排列顺序
        /// </summary>
        public int? Px
        {
            set { _px = value; }
            get { return _px; }
        }
        /// <summary>
        /// seo标题
        /// </summary>
        public string SeoTitle
        {
            set { _seotitle = value; }
            get { return _seotitle; }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        public string SeoKeyWord
        {
            set { _seokeyword = value; }
            get { return _seokeyword; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string SeoDescription
        {
            set { _seodescription = value; }
            get { return _seodescription; }
        }
        /// <summary>
        /// 栏目简介
        /// </summary>
        public string ClassIntro
        {
            set { _classintro = value; }
            get { return _classintro; }
        }
        /// <summary>
        /// 是否隐藏0是
        /// </summary>
        public int? Hide
        {
            set { _hide = value; }
            get { return _hide; }
        }
        /// <summary>
        ///  栏目图片
        /// </summary>
        public string ClassPic
        {
            set { _classpic = value; }
            get { return _classpic; }
        }
       
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 语言类型
        /// </summary>
        public int? Languagen
        {
            set { _languagen = value; }
            get { return _languagen; }
        }
        /// <summary>
        /// 自设内容
        /// </summary>
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
        }
        /// <summary>
        /// 后台文章录入时是否允许录入0为允许
        /// </summary>
        public int? InputA
        {
            set { _inputa = value; }
            get { return _inputa; }
        }
        /// <summary>
        /// 是否允许会员投稿录入1为允许
        /// </summary>
        public int? InputUser
        {
            set { _inputuser = value; }
            get { return _inputuser; }
        }
        /// <summary>
        ///允许发表评论，1允许 
        /// </summary>
       public int? AllowComment
        {
            set { _allowcomment = value; }
            get { return _allowcomment; }
        }
        #endregion Model

    }
}

