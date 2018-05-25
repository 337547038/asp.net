using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace GL.Bll
{
    public partial class AlbumBll
    {
        private readonly GL.Dal.AlbumDal dal = new GL.Dal.AlbumDal();
        public AlbumBll()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.AlbumModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.AlbumModel model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新自定义字段
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Updatezd(string sql, int id)
        {
            return dal.Updatezd(sql, id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.AlbumModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

        
        #endregion  Method
    }
}

