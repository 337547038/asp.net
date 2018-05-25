using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace GL.Bll
{
    /// <summary>
    /// ProductsModel
    /// </summary>
    public partial class ProductsBll
    {
        private readonly GL.Dal.ProductsDal dal = new GL.Dal.ProductsDal();
        public ProductsBll()
        { }
        #region  Method
        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="datatable"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateHit(string datatable, int id)
        {
            return dal.UpdateHit(datatable, id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(string datatable, GL.Model.ProductsModel model)
        {
            return dal.Add(datatable, model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(string datatable, GL.Model.ProductsModel model)
        {
            return dal.Update(datatable, model);
        }

        #region 更新自定义字段
        /// <summary>
        /// 更新自定义字段
        /// </summary>
        /// <param name="datatable">表</param>
        /// <param name="sql">执行的SQL语句</param>
        /// <returns></returns>
        public bool Updatezd(string datatable, string sql, int id)
        {
            return dal.Updatezd(datatable, sql, id);
        }
        #endregion

        #region 更新一条记录的某一字段

        /// <summary>
        /// 更新指定字段的多条记录
        /// </summary>
        /// <param name="cnname">字段名</param>
        /// <param name="values">更新的值</param>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool Update1(string datatable, string cnname, string values, string id)
        {
            return dal.Update1(datatable, cnname, values, id);
        }
        #endregion

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.ProductsModel GetModel(string datatable, int id)
        {

            return dal.GetModel(datatable, id);
        }

       


		 /// <summary>
        /// <summary>
        /// 根据当前ID取得前后ID
        /// </summary>
        /// <param name="id">当前ID</param>
        /// <param name="type">前条或后条next</param>
      /// <param name="strwhere">条件</param>
        /// <returns></returns>
        public int GetNextPrevid(string datatable, int id, string type, string strwhere)
        {
            return dal.GetNextPrevid(datatable, id, type, strwhere);
        }

        #endregion  Method
    }
}