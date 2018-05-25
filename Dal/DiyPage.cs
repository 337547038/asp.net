using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;

namespace GL.Dal
{
    public partial class DiyPageDal
    {
        public DiyPageDal()
        { }
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.DiyPageModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_DIYPage(");
            strSql.Append("PageName,PageContents,EditTime,SeoTitle,SeoKeyword,SeoDescription,PageType,Px,Tid,PageContentsField,PagePicUrl)");
            strSql.Append(" values (");
            strSql.Append("@PageName@PageContents,@EditTime,@SeoTitle,@SeoKeyword,@SeoDescription,@PageType,@Px,@Tid,@PageContentsField,@PagePicUrl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PageName", SqlDbType.NVarChar,50),
					new SqlParameter("@PageContents", SqlDbType.NText),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@SeoTitle", SqlDbType.NVarChar,150),
					new SqlParameter("@SeoKeyword", SqlDbType.NVarChar,250),
					new SqlParameter("@SeoDescription", SqlDbType.NVarChar,350),
                    new SqlParameter("@Px",SqlDbType.Int,4),
                    new SqlParameter("@PageType",SqlDbType.Int,4),
                    new SqlParameter("@PageContentsField",SqlDbType.NVarChar,250),
                    new SqlParameter("@PagePicUrl",SqlDbType.NVarChar,50),
                    new SqlParameter("@Tid",SqlDbType.Int,4)};
            parameters[0].Value = model.PageName;
            parameters[1].Value = model.PageContents;
            parameters[2].Value = model.EditTime;
            parameters[3].Value = model.SeoTitle;
            parameters[4].Value = model.SeoKeyword;
            parameters[5].Value = model.SeoDescription;
            parameters[6].Value = model.Px;
            parameters[7].Value = model.PageType;
            parameters[8].Value = model.PageContentsField;
            parameters[9].Value = model.PagePicUrl;
            parameters[10].Value = model.Tid;

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
        public bool Update(GL.Model.DiyPageModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_DIYPage set ");
            strSql.Append("PageName=@PageName,");
            strSql.Append("ModelName=@ModelName,");
            strSql.Append("PageFilename=@PageFilename,");
            strSql.Append("PageContents=@PageContents,");
            strSql.Append("EditTime=@EditTime,");
            strSql.Append("SeoTitle=@SeoTitle,");
            strSql.Append("SeoKeyword=@SeoKeyword,");
            strSql.Append("SeoDescription=@SeoDescription,");
            strSql.Append("PageType=@PageType,");
            strSql.Append("PageContentsField=@PageContentsField,");
            strSql.Append("PagePicUrl=@PagePicUrl,");
            strSql.Append("Px=@Px,");
            strSql.Append("Tid=@Tid");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@PageName", SqlDbType.NVarChar,50),
					new SqlParameter("@PageContents", SqlDbType.NText),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@SeoTitle", SqlDbType.NVarChar,150),
					new SqlParameter("@SeoKeyword", SqlDbType.NVarChar,250),
					new SqlParameter("@SeoDescription", SqlDbType.NVarChar,350),
                    new SqlParameter("@PageType", SqlDbType.Int,4),
                    new SqlParameter("@Px", SqlDbType.Int,4),
                    new SqlParameter("@PageContentsField",SqlDbType.NVarChar,250),
                    new SqlParameter("@PagePicUrl",SqlDbType.NVarChar,50),
                    new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.PageName;
          
            parameters[1].Value = model.PageContents;
            parameters[2].Value = model.EditTime;
            parameters[3].Value = model.SeoTitle;
            parameters[4].Value = model.SeoKeyword;
            parameters[5].Value = model.SeoDescription;
            parameters[6].Value = model.PageType;
            parameters[7].Value = model.Px;
            parameters[8].Value = model.PageContentsField;
            parameters[9].Value = model.PagePicUrl;
            parameters[10].Value = model.Tid;
            parameters[11].Value = model.id;

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
        /// 批量更新seo信息
        /// </summary>
        public bool Updateseo(GL.Model.DiyPageModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_DIYPage set ");
            strSql.Append("SeoTitle=@SeoTitle,");
            strSql.Append("SeoKeyword=@SeoKeyword,");
            strSql.Append("SeoDescription=@SeoDescription");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@SeoTitle", SqlDbType.NVarChar,150),
					new SqlParameter("@SeoKeyword", SqlDbType.NVarChar,250),
					new SqlParameter("@SeoDescription", SqlDbType.NVarChar,350),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.SeoTitle;
            parameters[1].Value = model.SeoKeyword;
            parameters[2].Value = model.SeoDescription;
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
        public GL.Model.DiyPageModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,PageName,PageContents,EditTime,SeoTitle,SeoKeyword,SeoDescription,PageType,Px,Tid,PageContentsField,PagePicUrl from GL_DIYPage ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            GL.Model.DiyPageModel model = new GL.Model.DiyPageModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PageName"] != null && ds.Tables[0].Rows[0]["PageName"].ToString() != "")
                {
                    model.PageName = ds.Tables[0].Rows[0]["PageName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PageContents"] != null && ds.Tables[0].Rows[0]["PageContents"].ToString() != "")
                {
                    model.PageContents = ds.Tables[0].Rows[0]["PageContents"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EditTime"] != null && ds.Tables[0].Rows[0]["EditTime"].ToString() != "")
                {
                    model.EditTime = DateTime.Parse(ds.Tables[0].Rows[0]["EditTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SeoTitle"] != null && ds.Tables[0].Rows[0]["SeoTitle"].ToString() != "")
                {
                    model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SeoKeyword"] != null && ds.Tables[0].Rows[0]["SeoKeyword"].ToString() != "")
                {
                    model.SeoKeyword = ds.Tables[0].Rows[0]["SeoKeyword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SeoDescription"] != null && ds.Tables[0].Rows[0]["SeoDescription"].ToString() != "")
                {
                    model.SeoDescription = ds.Tables[0].Rows[0]["SeoDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PageType"] != null && ds.Tables[0].Rows[0]["PageType"].ToString() != "")
                {
                    model.PageType = int.Parse(ds.Tables[0].Rows[0]["PageType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Px"] != null && ds.Tables[0].Rows[0]["Px"].ToString() != "")
                {
                    model.Px = int.Parse(ds.Tables[0].Rows[0]["Px"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tid"] != null && ds.Tables[0].Rows[0]["Tid"].ToString() != "")
                {
                    model.Tid = int.Parse(ds.Tables[0].Rows[0]["Tid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PageContentsField"] != null && ds.Tables[0].Rows[0]["PageContentsField"].ToString() != "")
                {
                    model.PageContentsField = ds.Tables[0].Rows[0]["PageContentsField"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PagePicUrl"] != null && ds.Tables[0].Rows[0]["PagePicUrl"].ToString() != "")
                {
                    model.PagePicUrl = ds.Tables[0].Rows[0]["PagePicUrl"].ToString();
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

