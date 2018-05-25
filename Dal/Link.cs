using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;
namespace GL.Dal
{
    /// <summary>
    /// 数据访问类:LinkDal
    /// </summary>
    public partial class LinkDal
    {
        public LinkDal()
        { }
        #region  Method
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.LinkModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_Link(");
            strSql.Append("LinkName,LinkUrl,Px,LinkType,LinkLogo,LinkIntro,AddTime,Hide,Hits)");
            strSql.Append(" values (");
            strSql.Append("@LinkName,@LinkUrl,@Px,@LinkType,@LinkLogo,@LinkIntro,@AddTime,@Hide,@Hits)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkName", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@Px", SqlDbType.Int,4),
					new SqlParameter("@LinkType", SqlDbType.Int,4),
					new SqlParameter("@LinkLogo", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkIntro", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Hide", SqlDbType.Int,4),
					new SqlParameter("@Hits", SqlDbType.Int,4)};
            parameters[0].Value = model.LinkName;
            parameters[1].Value = model.LinkUrl;
            parameters[2].Value = model.Px;
            parameters[3].Value = model.LinkType;
            parameters[4].Value = model.LinkLogo;
            parameters[5].Value = model.LinkIntro;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.Hide;
            parameters[8].Value = model.Hits;

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
        public bool Update(GL.Model.LinkModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Link set ");
            strSql.Append("LinkName=@LinkName,");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("Px=@Px,");
            strSql.Append("LinkType=@LinkType,");
            strSql.Append("LinkLogo=@LinkLogo,");
            strSql.Append("LinkIntro=@LinkIntro,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Hide=@Hide,");
            strSql.Append("Hits=@Hits");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkName", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@Px", SqlDbType.Int,4),
					new SqlParameter("@LinkType", SqlDbType.Int,4),
					new SqlParameter("@LinkLogo", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkIntro", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Hide", SqlDbType.Int,4),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.LinkName;
            parameters[1].Value = model.LinkUrl;
            parameters[2].Value = model.Px;
            parameters[3].Value = model.LinkType;
            parameters[4].Value = model.LinkLogo;
            parameters[5].Value = model.LinkIntro;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.Hide;
            parameters[8].Value = model.Hits;
            parameters[9].Value = model.id;

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
        public GL.Model.LinkModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,LinkName,LinkUrl,Px,LinkType,LinkLogo,LinkIntro,AddTime,Hide,Hits from GL_Link ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            GL.Model.LinkModel model = new GL.Model.LinkModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LinkName"] != null && ds.Tables[0].Rows[0]["LinkName"].ToString() != "")
                {
                    model.LinkName = ds.Tables[0].Rows[0]["LinkName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkUrl"] != null && ds.Tables[0].Rows[0]["LinkUrl"].ToString() != "")
                {
                    model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Px"] != null && ds.Tables[0].Rows[0]["Px"].ToString() != "")
                {
                    model.Px = int.Parse(ds.Tables[0].Rows[0]["Px"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LinkType"] != null && ds.Tables[0].Rows[0]["LinkType"].ToString() != "")
                {
                    model.LinkType = int.Parse(ds.Tables[0].Rows[0]["LinkType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LinkLogo"] != null && ds.Tables[0].Rows[0]["LinkLogo"].ToString() != "")
                {
                    model.LinkLogo = ds.Tables[0].Rows[0]["LinkLogo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkIntro"] != null && ds.Tables[0].Rows[0]["LinkIntro"].ToString() != "")
                {
                    model.LinkIntro = ds.Tables[0].Rows[0]["LinkIntro"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Hide"] != null && ds.Tables[0].Rows[0]["Hide"].ToString() != "")
                {
                    model.Hide = int.Parse(ds.Tables[0].Rows[0]["Hide"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Hits"] != null && ds.Tables[0].Rows[0]["Hits"].ToString() != "")
                {
                    model.Hits = int.Parse(ds.Tables[0].Rows[0]["Hits"].ToString());
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

