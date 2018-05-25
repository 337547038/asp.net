using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GL.Bll
{
    public partial class UserBll
    {
        private readonly GL.Dal.UserDal dal = new GL.Dal.UserDal();
        public UserBll()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.UserModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.UserModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.UserModel GetModel(int id)
        {

            return dal.GetModel(id);
        }
    }
}

