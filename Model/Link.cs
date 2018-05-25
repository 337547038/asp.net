using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    /// <summary>
    /// LinkModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class LinkModel
    {
        public LinkModel()
        { }
        #region Model
        private int _id;
        private string _linkname;
        private string _linkurl;
        private int _px = 0;
        private int _linktype = 0;
        private string _linklogo;
        private string _linkintro;
        private DateTime _addtime = DateTime.Now;
        private int _hide = 0;
        private int _hits = 0;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 链接名称
        /// </summary>
        public string LinkName
        {
            set { _linkname = value; }
            get { return _linkname; }
        }
        /// <summary>
        /// 链接的网站地址
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Px
        {
            set { _px = value; }
            get { return _px; }
        }
        /// <summary>
        /// 链接类型0为文字1为LOGO
        /// </summary>
        public int LinkType
        {
            set { _linktype = value; }
            get { return _linktype; }
        }
        /// <summary>
        /// LOGO地址
        /// </summary>
        public string LinkLogo
        {
            set { _linklogo = value; }
            get { return _linklogo; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string LinkIntro
        {
            set { _linkintro = value; }
            get { return _linkintro; }
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
        public int Hide
        {
            set { _hide = value; }
            get { return _hide; }
        }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        #endregion Model

    }
}


