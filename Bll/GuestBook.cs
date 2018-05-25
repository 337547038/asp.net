using System;
using System.Collections.Generic;
using System.Text;
using GL.Dal;
using System.Data;
namespace GL.Bll
{
    /// <summary>
    /// GL_GuestBook
    /// </summary>
    public partial class GuestBookBll
    {
        private readonly GL.Dal.GuestBookDal dal = new GL.Dal.GuestBookDal();
        public GuestBookBll()
        { }
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.GuestBookModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.GuestBookModel model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.GuestBookModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

       

        /// <summary>
        /// 更新回复、内容、状态
        /// </summary>
        public bool Update1(GL.Model.GuestBookModel model)
        {
            return dal.Update1(model);
        }
        #endregion  Method
    }
}

