using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace GL.Model
{
    public partial class ModelFieldModel
    {
        public ModelFieldModel()
        { }
        #region Model
        private int _id;
        private int _modeid;
        private string _fieldname;
        private string _fieldname2;
        private int _fieldtype = 0;
        private string _fieldintro;
        private int _fieldisnull = 0;
        private int _fieldpx = 0;
        private int _fieldonoff = 0;
        private string _fieldvaules;
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
        public int Modeid
        {
            set { _modeid = value; }
            get { return _modeid; }
        }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName
        {
            set { _fieldname = value; }
            get { return _fieldname; }
        }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName2
        {
            set { _fieldname2 = value; }
            get { return _fieldname2; }
        }
        /// <summary>
        /// 字段类型0为文本1为数值
        /// </summary>
        public int FieldType
        {
            set { _fieldtype = value; }
            get { return _fieldtype; }
        }
        /// <summary>
        /// 字段说明
        /// </summary>
        public string FieldIntro
        {
            set { _fieldintro = value; }
            get { return _fieldintro; }
        }
        /// <summary>
        /// 是否允许为空0为允许
        /// </summary>
        public int FieldIsNull
        {
            set { _fieldisnull = value; }
            get { return _fieldisnull; }
        }
        /// <summary>
        /// 排序顺序
        /// </summary>
        public int FieldPx
        {
            set { _fieldpx = value; }
            get { return _fieldpx; }
        }
        /// <summary>
        /// 是否启用0为启用
        /// </summary>
        public int FieldOnOff
        {
            set { _fieldonoff = value; }
            get { return _fieldonoff; }
        }
        /// <summary>
        /// 默认值，为下拉时，多个下拉英文豆号,隔开，字段与值为竖线｜隔开
        /// </summary>
        public string FieldVaules
        {
            set { _fieldvaules = value; }
            get { return _fieldvaules; }
        }
        #endregion Model

    }




}