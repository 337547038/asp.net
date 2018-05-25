using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class ProductsModel
    {
        public ProductsModel()
        { }
        #region Model
        private int _id;
        private int? _tid;
        private string _title;
        private string _intro;
        private string _contents;
        private int? _hits;
        private DateTime? _adddate;
        private DateTime? _editdate;
        private int? _isrecommend = 0;
        private int? _isnew = 0;
        private int? _ispopular = 0;
        private int? _px = 0;
        private int? _isdel = 0;
        private string _picurl;
        private string _bigphoto;
        private string _filesurl;
        private int? _languagen = 0;
        private string _seotitle;
        private string _seokeyword;
        private string _seodescription;
        private decimal? _price;
        private decimal? _pricemarket;
        private string _isspecial;
        private string _promodel;
        private string _prospecificat;
        private string _producername;
        private string _unit;
        private int? _totalnum;
       
        private int? _comment;
        private string _inputer;
        private string _contents2;
        private string _contents3;
        private int? _verific;
        private string _titlecolor;
        private int? _shopid;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 父ID
        /// </summary>
        public int? Tid
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 简介
        /// </summary>
        public string Intro
        {
            set { _intro = value; }
            get { return _intro; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 
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
        /// 热卖
        /// </summary>
        public int? IsPopular
        {
            set { _ispopular = value; }
            get { return _ispopular; }
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
        /// 是否删除
        /// </summary>
        public int? IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 产品小图
        /// </summary>
        public string PicUrl
        {
            set { _picurl = value; }
            get { return _picurl; }
        }
        /// <summary>
        /// 产品大图地址
        /// </summary>
        public string BigPhoto
        {
            set { _bigphoto = value; }
            get { return _bigphoto; }
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
        /// 
        /// </summary>
        public int? Languagen
        {
            set { _languagen = value; }
            get { return _languagen; }
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
        public string SeoKeyWord
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
        /// 价格
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 市场价格
        /// </summary>
        public decimal? PriceMarket
        {
            set { _pricemarket = value; }
            get { return _pricemarket; }
        }
        /// <summary>
        /// 是否特价
        /// </summary>
        public string IsSpecial
        {
            set { _isspecial = value; }
            get { return _isspecial; }
        }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string ProModel
        {
            set { _promodel = value; }
            get { return _promodel; }
        }
        /// <summary>
        /// 产品规格 
        /// </summary>
        public string ProSpecificat
        {
            set { _prospecificat = value; }
            get { return _prospecificat; }
        }
        /// <summary>
        /// 生产商
        /// </summary>
        public string ProducerName
        {
            set { _producername = value; }
            get { return _producername; }
        }
        /// <summary>
        /// 产品单位
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 库存
        /// </summary>
        public int? TotalNum
        {
            set { _totalnum = value; }
            get { return _totalnum; }
        }
      
        /// <summary>
        /// 是否允许评论0允许
        /// </summary>
        public int? Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }
        /// <summary>
        /// 录入者
        /// </summary>
        public string Inputer
        {
            set { _inputer = value; }
            get { return _inputer; }
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
        /// 审核
        /// </summary>
        public int? Verific
        {
            set { _verific = value; }
            get { return _verific; }
        }
        /// <summary>
        /// 标题颜色
        /// </summary>
        public string TitleColor
        {
            set { _titlecolor = value; }
            get { return _titlecolor; }
        }

        /// <summary>
        /// 所属商店
        /// </summary>
        public int? ShopId
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        #endregion Model

    }
}

