using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;
using GL.Model;
namespace GL.Dal
{
    public partial class BlockDal
    {
        public BlockDal()
        { }
        public int Add(GL.Model.BlockModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_Block(");
            strSql.Append("Title,Contents,AddDate)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Contents,@AddDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Contents", SqlDbType.NText),
					new SqlParameter("@AddDate", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Contents;
            parameters[2].Value = model.AddDate;

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
        public bool Update(GL.Model.BlockModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Block set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Contents=@Contents,");
            strSql.Append("AddDate=@AddDate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Contents", SqlDbType.NText),
					new SqlParameter("@AddDate", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Contents;
            parameters[2].Value = model.AddDate;
            parameters[3].Value = model.id;

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
        public GL.Model.BlockModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Title,Contents,AddDate from GL_Block ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            GL.Model.BlockModel model = new GL.Model.BlockModel();
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
        public GL.Model.BlockModel DataRowToModel(DataRow row)
        {
            GL.Model.BlockModel model = new GL.Model.BlockModel();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Contents"] != null)
                {
                    model.Contents = row["Contents"].ToString();
                }
                if (row["AddDate"] != null)
                {
                    model.AddDate = row["AddDate"].ToString();
                }
            }
            return model;
        }
    }
}
