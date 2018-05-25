using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class DiyPageModel
    {
        public DiyPageModel()
        { }
        #region Model
        private int _id;
        private string _pagename;
        private string _pagecontents;
        private DateTime _edittime;
        private string _seotitle;
        private string _seokeyword;
        private string _seodescription;
        private int _pagetype = 0;
        private int _px = 0;
        private int _tid;
        private string _pagecontentsfield;
        private string _pagepicurl;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 单页名称
        /// </summary>
        public string PageName
        {
            set { _pagename = value; }
            get { return _pagename; }
        }
        
        /// <summary>
        /// 单页内容
        /// </summary>
        public string PageContents
        {
            set { _pagecontents = value; }
            get { return _pagecontents; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EditTime
        {
            set { _edittime = value; }
            get { return _edittime; }
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
        /// 0为单页1为单页栏目
        /// </summary>
        public int PageType
        {
            set { _pagetype = value; }
            get { return _pagetype; }
        }
        public int Px
        {
            set { _px = value; }
            get { return _px; }
        }
        public int Tid
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 显示录入字段
        /// </summary>
        public string PageContentsField
        {
            set { _pagecontentsfield = value; }
            get { return _pagecontentsfield; }
        }
        //单页图片
        public string PagePicUrl
        {
            set { _pagepicurl = value; }
            get { return _pagepicurl; }
        }
        #endregion Model

    }
}

