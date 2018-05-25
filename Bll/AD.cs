using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Bll
{
    public partial class ADBll
    {
        private readonly GL.Dal.ADDal dal = new Dal.ADDal();
        public ADBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.ADModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.ADModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.ADModel GetModel(int id)
        {

            return dal.GetModel(id);
        }
        #endregion  BasicMethod
    }
}

