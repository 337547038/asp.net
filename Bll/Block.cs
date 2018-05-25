using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Bll
{
    public partial class BlockBll
    {
        private readonly GL.Dal.BlockDal dal = new Dal.BlockDal();
        public BlockBll()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.BlockModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.BlockModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.BlockModel GetModel(int id)
        {

            return dal.GetModel(id);
        }
    }
}
