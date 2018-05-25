using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Bll
{
    public partial class WebConfigBll
    {
        private readonly GL.Dal.WebConfigDal dal = new GL.Dal.WebConfigDal();
        public WebConfigBll()
        { }
        #region  BasicMethod
        
        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(GL.Model.WebConfigModel model)
        //{
        //    return dal.Add(model);
        //}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.WebConfigModel model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.WebConfigModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

