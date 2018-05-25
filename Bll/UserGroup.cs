using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace GL.Bll
{
    public partial class UserGroupBll
    {
        private readonly GL.Dal.UserGroupDal dal = new GL.Dal.UserGroupDal();
        public UserGroupBll()
        { }
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.UserGroupModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.UserGroupModel model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.UserGroupModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

       

        #endregion  Method
    }
}

