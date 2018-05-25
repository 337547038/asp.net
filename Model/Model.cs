using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class ModelModel
    {
        public ModelModel()
        { }
        #region Model
        private int _id;
        private string _modelname;
        private string _modeltable;
        private string _itemname;
        private string _itemunit;
        private string _modecontent;
        private int _modellock = 0;
        private int _modeltype = 0;
        private int _modelclasslayer;
        /// <summary>
        /// 模型id
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 模型名称
        /// </summary>
        public string ModelName
        {
            set { _modelname = value; }
            get { return _modelname; }
        }
        /// <summary>
        /// 模型表名
        /// </summary>
        public string ModelTable
        {
            set { _modeltable = value; }
            get { return _modeltable; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName
        {
            set { _itemname = value; }
            get { return _itemname; }
        }
        /// <summary>
        /// 项目单位
        /// </summary>
        public string ItemUnit
        {
            set { _itemunit = value; }
            get { return _itemunit; }
        }
        

        public string ModeContent
        {
            set { _modecontent = value; }
            get { return _modecontent; }
        }


        /// <summary>
        /// 是否启用0为启用
        /// </summary>
        public int ModelLock
        {
            set { _modellock = value; }
            get { return _modellock; }
        }

        /// <summary>
        /// 模型类型0为文章1为产品
        /// </summary>
        public int ModelType
        {
            set { _modeltype = value; }
            get { return _modeltype; }
        }

       
        /// <summary>
        /// 此模型下栏目的级数
        /// </summary>
        public int ModelClassLayer
        {
            set { _modelclasslayer = value; }
            get { return _modelclasslayer; }
        }

        #endregion Model

    }
}

