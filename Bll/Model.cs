using System;
using System.Collections.Generic;
using System.Text;
using GL.Dal;
using System.Data;

namespace GL.Bll
{
    /// <summary>
    /// ModelBll
    /// </summary>
    public partial class ModelBll
    {
        private readonly GL.Dal.ModelDal dal = new GL.Dal.ModelDal();
        public ModelBll()
        { }
        #region  Method

        /// <summary>
        /// 是否存在同名记录
        /// </summary>
        /// <param name="ExistsName">检查存在的名字</param>
        /// <param name="Field">检查字段</param>
        /// <returns></returns>
        public bool ExistsName(string ExName, string Field)
        {
            return dal.ExistsName(ExName, Field);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.ModelModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.ModelModel model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.ModelModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

       
       

        #endregion  Method
    }
}

