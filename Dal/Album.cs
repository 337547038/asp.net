using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;
namespace GL.Dal
{
    public partial class AlbumDal
    {
        public AlbumDal()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.AlbumModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_Album(");
            strSql.Append("ModelId,ParentId,PhotoUrl,Px,Intro,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@ModelId,@ParentId,@PhotoUrl,@Px,@Intro,@AddTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ModelId", SqlDbType.Int,4),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@Px", SqlDbType.Int,4),
					new SqlParameter("@Intro", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ModelId;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.PhotoUrl;
            parameters[3].Value = model.Px;
            parameters[4].Value = model.Intro;
            parameters[5].Value = model.AddTime;

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
        public bool Update(GL.Model.AlbumModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Album set ");
            //strSql.Append("ModelId=@ModelId,");
            //strSql.Append("ParentId=@ParentId,");
            //strSql.Append("PhotoUrl=@PhotoUrl,");
            strSql.Append("Px=@Px,");
            strSql.Append("Intro=@Intro");
         //   strSql.Append("AddTime=@AddTime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					//new SqlParameter("@ModelId", SqlDbType.Int,4),
					//new SqlParameter("@ParentId", SqlDbType.Int,4),
					//new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@Px", SqlDbType.Int,4),
					new SqlParameter("@Intro", SqlDbType.NVarChar,50),
				//	new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
           // parameters[0].Value = model.ModelId;
           // parameters[1].Value = model.ParentId;
           // parameters[0].Value = model.PhotoUrl;
            parameters[0].Value = model.Px;
            parameters[1].Value = model.Intro;
         //   parameters[5].Value = model.AddTime;
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
        /// 更新指定字段
        /// </summary>
        /// <param name="sql">Intro=Intro</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Updatezd(string sql, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Album set " + sql + " where id=" + id);
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
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.AlbumModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ModelId,ParentId,PhotoUrl,Px,Intro,AddTime from GL_Album ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            GL.Model.AlbumModel model = new GL.Model.AlbumModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModelId"] != null && ds.Tables[0].Rows[0]["ModelId"].ToString() != "")
                {
                    model.ModelId = int.Parse(ds.Tables[0].Rows[0]["ModelId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentId"] != null && ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PhotoUrl"] != null && ds.Tables[0].Rows[0]["PhotoUrl"].ToString() != "")
                {
                    model.PhotoUrl = ds.Tables[0].Rows[0]["PhotoUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Px"] != null && ds.Tables[0].Rows[0]["Px"].ToString() != "")
                {
                    model.Px = int.Parse(ds.Tables[0].Rows[0]["Px"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Intro"] != null && ds.Tables[0].Rows[0]["Intro"].ToString() != "")
                {
                    model.Intro = ds.Tables[0].Rows[0]["Intro"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

      
     
        #endregion  Method
    }
}

