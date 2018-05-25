using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class SearchModel
    {
        public SearchModel()
        { }
        #region Model
        private int _id;
        private string _keyword;
        private int? _num;
        private DateTime? _lastdate;
        private int? _px;
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
        public string keyword
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? lastdate
        {
            set { _lastdate = value; }
            get { return _lastdate; }
        }
        /// <summary>
        /// 手动排序
        /// </summary>
        public int? px
        {
            set { _px = value; }
            get { return _px; }
        }
        #endregion Model

    }
}

