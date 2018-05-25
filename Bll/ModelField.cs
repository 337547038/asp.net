using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GL.Bll
{
    public partial class ModelFieldBll
    {
        private readonly GL.Dal.ModelFieldDal dal = new GL.Dal.ModelFieldDal();
        public ModelFieldBll()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.ModelFieldModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.ModelFieldModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.ModelFieldModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

       

        #endregion  Method
    }
}