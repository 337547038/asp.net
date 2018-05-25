using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class ADModel
    {
        public ADModel()
        { }
        #region Model
        private int _id;
        private string _adtitle;
        private int? _tid;
        private int? _isad;
        private int? _adtype;
        private string _adhttpurl;
        private string _adcontents;
        private string _adurl;
        private int? _px;
        private int? _adheight;
        private int? _adwidth;
        private int? _adshowhide;
       
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
        public string ADtitle
        {
            set { _adtitle = value; }
            get { return _adtitle; }
        }
        /// <summary>
        /// 广告位id，广告位和单条广告为0
        /// </summary>
        public int? Tid
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 0为广告，1为广告位
        /// </summary>
        public int? IsAD
        {
            set { _isad = value; }
            get { return _isad; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ADtype
        {
            set { _adtype = value; }
            get { return _adtype; }
        }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string ADhttpurl
        {
            set { _adhttpurl = value; }
            get { return _adhttpurl; }
        }
        /// <summary>
        /// 广告内容
        /// </summary>
        public string ADcontents
        {
            set { _adcontents = value; }
            get { return _adcontents; }
        }
        /// <summary>
        /// 广告图片或flash路径
        /// </summary>
        public string ADurl
        {
            set { _adurl = value; }
            get { return _adurl; }
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
        public int? ADheight
        {
            set { _adheight = value; }
            get { return _adheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ADwidth
        {
            set { _adwidth = value; }
            get { return _adwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ADShowHide
        {
            set { _adshowhide = value; }
            get { return _adshowhide; }
        }
        
        #endregion Model

    }
}

