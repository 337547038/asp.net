using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Bll
{
    public partial class SearchBll
    {
        private readonly GL.Dal.SearchDal dal = new GL.Dal.SearchDal();
        public SearchBll()
        { }
        #region  BasicMethod
        

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.SearchModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.SearchModel model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新搜索次数
        /// </summary>
        public bool UpdateNum(string keyword)
        {
            return dal.UpdateNum(keyword);
        }
      

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.SearchModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

      

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

