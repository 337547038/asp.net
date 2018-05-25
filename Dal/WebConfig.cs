using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;

namespace GL.Dal
{
    /// <summary>
    /// 数据访问类:WebConfigModel
    /// </summary>
    public partial class WebConfigDal
    {
        public WebConfigDal()
        { }
        #region  BasicMethod
        

        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(GL.Model.WebConfigModel model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into GL_WebConfig(");
        //    strSql.Append("SiteName,SiteTitle,SiteUrl,SiteTitleEn,SiteICP,SiteKeyword,SiteDescription,SiteKeywordEn,SiteDescriptionEn,IndexHtml,SiteFax,SiteTel,SiteAddress,SiteQQ,SiteMail,EmailSMTP,EmailName,EmailPassword)");
        //    strSql.Append(" values (");
        //    strSql.Append("@SiteName,@SiteTitle,@SiteUrl,@SiteTitleEn,@SiteICP,@SiteKeyword,@SiteDescription,@SiteKeywordEn,@SiteDescriptionEn,@IndexHtml,@SiteFax,@SiteTel,@SiteAddress,@SiteQQ,@SiteMail,@EmailSMTP,@EmailName,@EmailPassword)");
        //    strSql.Append(";select @@IDENTITY");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@SiteName", SqlDbType.NVarChar,50),
        //            new SqlParameter("@SiteTitle", SqlDbType.NVarChar,50),
        //            new SqlParameter("@SiteUrl", SqlDbType.NVarChar,50),
        //            new SqlParameter("@SiteTitleEn", SqlDbType.NVarChar,50),
        //            new SqlParameter("@SiteICP", SqlDbType.NVarChar,50),
        //            new SqlParameter("@SiteKeyword", SqlDbType.NVarChar,250),
        //            new SqlParameter("@SiteDescription", SqlDbType.NVarChar,250),
        //            new SqlParameter("@SiteKeywordEn", SqlDbType.NVarChar,250),
        //            new SqlParameter("@SiteDescriptionEn", SqlDbType.NVarChar,250),
        //            new SqlParameter("@IndexHtml", SqlDbType.Int,4),
        //            new SqlParameter("@SiteFax", SqlDbType.NVarChar,50),
        //            new SqlParameter("@SiteTel", SqlDbType.NVarChar,50),
        //            new SqlParameter("@SiteAddress", SqlDbType.NVarChar,250),
        //            new SqlParameter("@SiteQQ", SqlDbType.NVarChar,50),
        //            new SqlParameter("@SiteMail", SqlDbType.NVarChar,50),
        //            new SqlParameter("@EmailSMTP", SqlDbType.NVarChar,50),
        //            new SqlParameter("@EmailName", SqlDbType.NVarChar,50),
        //            new SqlParameter("@EmailPassword", SqlDbType.NVarChar,50)};
        //    parameters[0].Value = model.SiteName;
        //    parameters[1].Value = model.SiteTitle;
        //    parameters[2].Value = model.SiteUrl;
        //    parameters[3].Value = model.SiteTitleEn;
        //    parameters[4].Value = model.SiteICP;
        //    parameters[5].Value = model.SiteKeyword;
        //    parameters[6].Value = model.SiteDescription;
        //    parameters[7].Value = model.SiteKeywordEn;
        //    parameters[8].Value = model.SiteDescriptionEn;
        //    parameters[9].Value = model.IndexHtml;
        //    parameters[10].Value = model.SiteFax;
        //    parameters[11].Value = model.SiteTel;
        //    parameters[12].Value = model.SiteAddress;
        //    parameters[13].Value = model.SiteQQ;
        //    parameters[14].Value = model.SiteMail;
        //    parameters[15].Value = model.EmailSMTP;
        //    parameters[16].Value = model.EmailName;
        //    parameters[17].Value = model.EmailPassword;

        //    object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.WebConfigModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_WebConfig set ");
            strSql.Append("SiteName=@SiteName,");
            strSql.Append("SiteTitle=@SiteTitle,");
            strSql.Append("SiteUrl=@SiteUrl,");
            strSql.Append("SiteTitleEn=@SiteTitleEn,");
            strSql.Append("SiteICP=@SiteICP,");
            strSql.Append("SiteKeyword=@SiteKeyword,");
            strSql.Append("SiteDescription=@SiteDescription,");
            strSql.Append("SiteKeywordEn=@SiteKeywordEn,");
            strSql.Append("SiteDescriptionEn=@SiteDescriptionEn,");
            strSql.Append("SiteFax=@SiteFax,");
            strSql.Append("SiteTel=@SiteTel,");
            strSql.Append("SiteAddress=@SiteAddress,");
            strSql.Append("SiteQQ=@SiteQQ,");
            strSql.Append("SiteMail=@SiteMail,");
            strSql.Append("EmailSMTP=@EmailSMTP,");
            strSql.Append("EmailName=@EmailName,");
            strSql.Append("EmailPassword=@EmailPassword,");
            strSql.Append("Sitecnzz=@Sitecnzz,");
            strSql.Append("Other=@Other,");
            strSql.Append("SiteConfig=@SiteConfig");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@SiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteTitleEn", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteICP", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteKeyword", SqlDbType.NVarChar,250),
					new SqlParameter("@SiteDescription", SqlDbType.NVarChar,250),
					new SqlParameter("@SiteKeywordEn", SqlDbType.NVarChar,250),
					new SqlParameter("@SiteDescriptionEn", SqlDbType.NVarChar,250),
					new SqlParameter("@SiteFax", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteTel", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteAddress", SqlDbType.NVarChar,250),
					new SqlParameter("@SiteQQ", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteMail", SqlDbType.NVarChar,50),
					new SqlParameter("@EmailSMTP", SqlDbType.NVarChar,50),
					new SqlParameter("@EmailName", SqlDbType.NVarChar,50),
					new SqlParameter("@EmailPassword", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sitecnzz", SqlDbType.Text),
                    new SqlParameter("@Other", SqlDbType.NVarChar,250),
                    new SqlParameter("@SiteConfig",SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.SiteName;
            parameters[1].Value = model.SiteTitle;
            parameters[2].Value = model.SiteUrl;
            parameters[3].Value = model.SiteTitleEn;
            parameters[4].Value = model.SiteICP;
            parameters[5].Value = model.SiteKeyword;
            parameters[6].Value = model.SiteDescription;
            parameters[7].Value = model.SiteKeywordEn;
            parameters[8].Value = model.SiteDescriptionEn;
            parameters[9].Value = model.SiteFax;
            parameters[10].Value = model.SiteTel;
            parameters[11].Value = model.SiteAddress;
            parameters[12].Value = model.SiteQQ;
            parameters[13].Value = model.SiteMail;
            parameters[14].Value = model.EmailSMTP;
            parameters[15].Value = model.EmailName;
            parameters[16].Value = model.EmailPassword;
            parameters[17].Value = model.Sitecnzz;
            parameters[18].Value = model.Other;
            parameters[19].Value = model.SiteConfig;
            parameters[20].Value = model.id;

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
        public GL.Model.WebConfigModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,SiteName,SiteTitle,SiteUrl,SiteTitleEn,SiteICP,SiteKeyword,SiteDescription,SiteKeywordEn,SiteDescriptionEn,SiteFax,SiteTel,SiteAddress,SiteQQ,SiteMail,EmailSMTP,EmailName,EmailPassword,Sitecnzz,Other,SiteConfig from GL_WebConfig ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            GL.Model.WebConfigModel model = new GL.Model.WebConfigModel();
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
        public GL.Model.WebConfigModel DataRowToModel(DataRow row)
        {
            GL.Model.WebConfigModel model = new GL.Model.WebConfigModel();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["SiteName"] != null)
                {
                    model.SiteName = row["SiteName"].ToString();
                }
                if (row["SiteTitle"] != null)
                {
                    model.SiteTitle = row["SiteTitle"].ToString();
                }
                if (row["SiteUrl"] != null)
                {
                    model.SiteUrl = row["SiteUrl"].ToString();
                }
                if (row["SiteTitleEn"] != null)
                {
                    model.SiteTitleEn = row["SiteTitleEn"].ToString();
                }
                if (row["SiteICP"] != null && row["SiteICP"].ToString()!="")
                {
                    model.SiteICP = row["SiteICP"].ToString();
                    model.SiteIcpHtml = "<a href=\"http://www.miitbeian.gov.cn\"  target=\"_blank\">" + row["SiteICP"].ToString() + "</a>";
                }
                if (row["SiteKeyword"] != null)
                {
                    model.SiteKeyword = row["SiteKeyword"].ToString();
                }
                if (row["SiteDescription"] != null)
                {
                    model.SiteDescription = row["SiteDescription"].ToString();
                }
                if (row["SiteKeywordEn"] != null)
                {
                    model.SiteKeywordEn = row["SiteKeywordEn"].ToString();
                }
                if (row["SiteDescriptionEn"] != null)
                {
                    model.SiteDescriptionEn = row["SiteDescriptionEn"].ToString();
                }
               
                if (row["SiteFax"] != null)
                {
                    model.SiteFax = row["SiteFax"].ToString();
                }
                if (row["SiteTel"] != null)
                {
                    model.SiteTel = row["SiteTel"].ToString();
                }
                if (row["SiteAddress"] != null)
                {
                    model.SiteAddress = row["SiteAddress"].ToString();
                }
                if (row["SiteQQ"] != null)
                {
                    model.SiteQQ = row["SiteQQ"].ToString();
                }
                if (row["SiteMail"] != null)
                {
                    model.SiteMail = row["SiteMail"].ToString();
                }
                if (row["EmailSMTP"] != null)
                {
                    model.EmailSMTP = row["EmailSMTP"].ToString();
                }
                if (row["EmailName"] != null)
                {
                    model.EmailName = row["EmailName"].ToString();
                }
                if (row["EmailPassword"] != null)
                {
                    model.EmailPassword = row["EmailPassword"].ToString();
                }
                if (row["Sitecnzz"] != null)
                {
                    model.Sitecnzz = row["Sitecnzz"].ToString();
                }
                if (row["Other"] != null)
                {
                    model.Other = row["Other"].ToString();
                }
                if (row["SiteConfig"] != null) {
                    model.SiteConfig = row["SiteConfig"].ToString();
                }
            }
            return model;
        }

    

        #endregion  BasicMethod
      
    }
}

