using System;
using System.Collections.Generic;
using System.Text;
using GL.Utility;
using System.Data;
using System.Data.SqlClient;
namespace GL.Dal
{
    public partial class CommonDal
    {
        public CommonDal()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string datatable, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + datatable);
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string datatable, int id)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + datatable + "");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string datatable, string idlist)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + datatable + " ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 按条件删除数据
        /// </summary>
        public bool Deletebywhere(string datatable, string strwhere)
        {
            BasePage.CheckSerialnumber(); 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + datatable + " ");
            strSql.Append(" where " + strwhere + "");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 " + zd + " from " + datatable + "");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
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
            StringBuilder strSql = new StringBuilder();
            if (String.IsNullOrEmpty(fieldname))
            {
                fieldname = "*";
            }
            strSql.Append("select " + fieldname + " FROM " + datatable + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (String.IsNullOrEmpty(filedOrder))
            {
                filedOrder = "px desc,id desc";
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
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
        public DataSet GetList(string fieldname, string datatable, int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            if (String.IsNullOrEmpty(fieldname))
            {
                fieldname = "*";
            }
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" " + fieldname + " FROM " + datatable + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (String.IsNullOrEmpty(filedOrder))
            {
                filedOrder = "px desc,id desc";
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListSql(string strSql)
        {
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string datatable, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + datatable + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
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
            StringBuilder strSql = new StringBuilder();
            if (String.IsNullOrEmpty(fieldname))
            {
                fieldname = "*";
            }
            strSql.Append("SELECT " + fieldname + " FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.px desc,T.id desc");
            }
            strSql.Append(")AS Row, T.*  from " + datatable + " T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
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
            if (PageIndex == 0)
            {
                PageIndex = 1;

            }
            int startIndex = PageSize * (PageIndex - 1) + 1;
            int endIndex = PageSize * PageIndex;
            DataSet ds = new DataSet();
            ds = GetListByPage(fieldname, datatable, strwhere, orderby, startIndex, endIndex);
            return ds;
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
            int id = 0;
            if (String.IsNullOrEmpty(fieldname))
            {
                fieldname = "*";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + fieldname + " FROM " + datatable + " ");
            if (strwhere.Trim() != "")
            {
                strSql.Append(" where " + strwhere);
            }
            if (!String.IsNullOrEmpty(filedOrder))
            {
                strSql.Append(" order by " + filedOrder);
            }
            DataSet ds = new DataSet();
            ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
            }
            return id;
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
            string strSql = "insert into " + datatable + " (" + fieldname + ") select " + fieldname + " from " + datatable + " where " + strwhere + " ";
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            return rows;
        }

        #endregion  Method
    }
}
