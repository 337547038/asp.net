using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class BlockModel
    {
        public BlockModel()
        { }
        private int _id;
        private string _title;
        private string _contents;
        private string _adddate;
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
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
    }
}
