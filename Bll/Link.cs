using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GL.Bll
{
    /// <summary>
    /// Linkll
    /// </summary>
    public partial class Linkll
    {
        private readonly GL.Dal.LinkDal dal = new GL.Dal.LinkDal();
        public Linkll()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.LinkModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.LinkModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.LinkModel GetModel(int id)
        {

            return dal.GetModel(id);
        }


        #endregion  Method
    }
}
