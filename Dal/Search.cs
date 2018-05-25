using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;
using GL.Model;
namespace GL.Dal
{
    /// <summary>
    /// 数据访问类:SearchModel
    /// </summary>
    public partial class SearchDal
    {
        public SearchDal()
        { }
        #region  BasicMethod
       

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.SearchModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_Search(");
            strSql.Append("keyword,num,lastdate)");
            strSql.Append(" values (");
            strSql.Append("@keyword,@num,@lastdate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@keyword", SqlDbType.NVarChar,50),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@lastdate", SqlDbType.DateTime)};
            parameters[0].Value = model.keyword;
            parameters[1].Value = model.num;
            parameters[2].Value = model.lastdate;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.SearchModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Search set ");
            strSql.Append("keyword=@keyword,");
            strSql.Append("num=@num");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@keyword", SqlDbType.NVarChar,50),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.keyword;
            parameters[1].Value = model.num;
            parameters[2].Value = model.id;

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
        /// 更新搜索次数
        /// </summary>
        public bool UpdateNum(string keyword)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Search set ");
            strSql.Append("num=num+1,");
            strSql.Append("lastdate=@lastdate");
            strSql.Append(" where keyword=@keyword");
            SqlParameter[] parameters = {
					new SqlParameter("@lastdate", SqlDbType.DateTime),
					new SqlParameter("@keyword", SqlDbType.NVarChar,50)};
            parameters[0].Value = DateTime.Now;
            parameters[1].Value = keyword;

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
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.SearchModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,keyword,num,lastdate from GL_Search ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            GL.Model.SearchModel model = new GL.Model.SearchModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.SearchModel DataRowToModel(DataRow row)
        {
            GL.Model.SearchModel model = new GL.Model.SearchModel();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["keyword"] != null)
                {
                    model.keyword = row["keyword"].ToString();
                }
                if (row["num"] != null && row["num"].ToString() != "")
                {
                    model.num = int.Parse(row["num"].ToString());
                }
                if (row["lastdate"] != null && row["lastdate"].ToString() != "")
                {
                    model.lastdate = DateTime.Parse(row["lastdate"].ToString());
                }
            }
            return model;
        }

     
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

