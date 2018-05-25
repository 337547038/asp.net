using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class AlbumModel
    {
        public AlbumModel()
        { }
        #region Model
        private int _id;
        private int _modelid;
        private int _parentid;
        private string _photourl;
        private int _px;
        private string _intro;
        private DateTime _addtime;
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
        public int ModelId
        {
            set { _modelid = value; }
            get { return _modelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PhotoUrl
        {
            set { _photourl = value; }
            get { return _photourl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Px
        {
            set { _px = value; }
            get { return _px; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Intro
        {
            set { _intro = value; }
            get { return _intro; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}

