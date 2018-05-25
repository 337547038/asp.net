using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class ArticleModel
    {
        public ArticleModel()
        { }
        #region Model
        private int _id;
        private int? _tid;
        private string _title;
        private string _fulltitle;
        private string _intro;
        private string _contents;
        private string _owner;
        private string _author;
        private string _origin;
        private int? _hits;
        private DateTime? _adddate;
        private DateTime? _editdate;
        private int? _isrecommend;
        private int? _isnew;
        private int? _ispopular;
        private int? _isdel;
        private int? _px;
        private string _picurl;
        private string _filesurl;
        private int? _verific;
        private string _seotitle;
        private string _seokeyword;
        private string _seodescription;
        private int? _languagen;
        private string _contents2;
        private string _contents3;
        private string _titlecolor;
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
        /// 
        /// </summary>
        public int? Tid
        {
            set { _tid = value; }
            get { return _tid; }
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
        public string FullTitle
        {
            set { _fulltitle = value; }
            get { return _fulltitle; }
        }
        /// <summary>
        /// 导读
        /// </summary>
        public string Intro
        {
            set { _intro = value; }
            get { return _intro; }
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
        /// 录入者
        /// </summary>
        public string Owner
        {
            set { _owner = value; }
            get { return _owner; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 来源 
        /// </summary>
        public string Origin
        {
            set { _origin = value; }
            get { return _origin; }
        }
        /// <summary>
        /// 点击数
        /// </summary>
        public int? Hits
        {
            set { _hits = value; }
            get { return _hits; }
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
        /// 
        /// </summary>
        public DateTime? EditDate
        {
            set { _editdate = value; }
            get { return _editdate; }
        }
        /// <summary>
        /// 推荐
        /// </summary>
        public int? IsRecommend
        {
            set { _isrecommend = value; }
            get { return _isrecommend; }
        }
        /// <summary>
        /// 最新
        /// </summary>
        public int? IsNew
        {
            set { _isnew = value; }
            get { return _isnew; }
        }
        /// <summary>
        /// 热门
        /// </summary>
        public int? IsPopular
        {
            set { _ispopular = value; }
            get { return _ispopular; }
        }
        /// <summary>
        /// 删除标志
        /// </summary>
        public int? IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Px
        {
            set { _px = value; }
            get { return _px; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PicUrl
        {
            set { _picurl = value; }
            get { return _picurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FilesUrl
        {
            set { _filesurl = value; }
            get { return _filesurl; }
        }
        /// <summary>
        /// 审核状态 0 已审1待审 2退回
        /// </summary>
        public int? Verific
        {
            set { _verific = value; }
            get { return _verific; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoTitle
        {
            set { _seotitle = value; }
            get { return _seotitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoKeyword
        {
            set { _seokeyword = value; }
            get { return _seokeyword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SeoDescription
        {
            set { _seodescription = value; }
            get { return _seodescription; }
        }
        /// <summary>
        /// 语言
        /// </summary>
        public int? Languagen
        {
            set { _languagen = value; }
            get { return _languagen; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Contents2
        {
            set { _contents2 = value; }
            get { return _contents2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Contents3
        {
            set { _contents3 = value; }
            get { return _contents3; }
        }

        /// <summary>
        /// 标题颜色
        /// </summary>
        public string TitltColor
        {
            set { _titlecolor = value; }
            get { return _titlecolor; }
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