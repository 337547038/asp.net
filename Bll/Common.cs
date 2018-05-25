using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace GL.Bll
{
    public partial class CommonBll
    {
        private readonly GL.Dal.CommonDal dal = new GL.Dal.CommonDal();
        public CommonBll()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string datatable, int id)
        {
            return dal.Exists(datatable, id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string datatable, int id)
        {
            return dal.Delete(datatable, id);
        }
        /// <summary>
        /// 按条件删除数据
        /// </summary>
        public bool Deletebywhere(string datatable, string strwhere)
        {
            return dal.Deletebywhere(datatable, strwhere);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string datatable, string idlist)
        {
            return dal.DeleteList(datatable, idlist);
        }

        /// <summary>
        /// 根据ID取得指定字段的值
        /// </summary>
        /// <param name="datatable">数据表</param>
        /// <param name="zd">字段名</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetTitle(string datatable, string zd, int id)
        {
            return dal.GetTitle(datatable, zd, id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="fieldname">字段名，默认为*</param>
        /// <param name="datatable">表名</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序，默认px desc,id desc</param>
        /// <returns></returns>
        public DataSet GetList(string fieldname, string datatable, string strWhere, string filedOrder)
        {
            return dal.GetList(fieldname,datatable, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据前几条
        /// </summary>
        /// <param name="fieldname">字段名，默认为*</param>
        /// <param name="datatable"></param>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder">排序，默认px desc,id desc</param>
        /// <returns></returns>
        public DataSet GetList(string fieldname,string datatable, int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(fieldname,datatable, Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListSql(string strSql)
        {
            return dal.GetListSql(strSql);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string datatable, string strWhere)
        {
            return dal.GetRecordCount(datatable, strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="fieldname">字段名，默认为*</param>
        /// <param name="datatable">数据表名称</param>
        /// <param name="strWhere">条件</param>
        /// <param name="orderby">排序，默认px desc,id desc</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <returns></returns>
        public DataSet GetListByPage(string fieldname, string datatable, string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(fieldname,datatable, strWhere, orderby, startIndex, endIndex);
        }

         #region 分页优化
        /// <summary>
        /// 分页优化
        /// </summary>
        /// <param name="fieldname">字段名，默认为*</param>
        /// <param name="datatable">数据表名称</param>
        /// <param name="strwhere">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="PageSize">每页多少条</param>
        /// <param name="PageIndex">当前第几页</param>
        /// <returns></returns>
        public DataSet GetListPage(string fieldname, string datatable, string strwhere, string orderby, int PageSize, int PageIndex)
        {
            return dal.GetListPage(fieldname,datatable, strwhere, orderby, PageSize, PageIndex);
        }
         #endregion

        #region 根据条件取得列表的第一条
        /// <summary>
        /// 根据条件取得列表的第一条
        /// </summary>
        /// <param name="fieldname">字段名，默认为*</param>
        /// <param name="datatable">数据表</param>
        /// <param name="strwhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public int GetFirstId(string fieldname, string datatable, string strwhere, string filedOrder)
        {
            return dal.GetFirstId(fieldname,datatable, strwhere, filedOrder);
        }
        #endregion
        /// <summary>
        /// 克隆一条数据
        /// </summary>
        /// <param name="fieldname">要克隆数据的字段名</param>
        /// <param name="datatable">表名</param>
        /// <param name="strwhere">条件</param>
        /// <returns></returns>
        public int CloneData(string fieldname, string datatable, string strwhere)
        {
            return dal.CloneData(fieldname, datatable, strwhere);
        }
        #endregion  Method
    }
}
