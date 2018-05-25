using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GL.Bll
{
    public partial class DiyPageBll
    {
        private readonly GL.Dal.DiyPageDal dal = new GL.Dal.DiyPageDal();
        public DiyPageBll()
        { }
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.DiyPageModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.DiyPageModel model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 批量更新seo信息
        /// </summary>
        public bool Updateseo(GL.Model.DiyPageModel model)
        { return dal.Updateseo(model); }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.DiyPageModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

      

        #endregion  Method
    }
}

