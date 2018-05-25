using System;
using System.Collections.Generic;
using System.Text;
using GL.Utility;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace GL.Dal
{
    public partial class ArticleDal
    {
        public ArticleDal()
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + datatable + " set ");
            strSql.Append("Hits=Hits+1");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};

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
        /// 增加一条数据
        /// </summary>
        public int Add(string datatable, GL.Model.ArticleModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + datatable + "(");
            strSql.Append("Tid,Title,FullTitle,Intro,Contents,Owner,Author,Origin,Hits,AddDate,EditDate,IsRecommend,IsNew,IsPopular,IsDel,Px,PicUrl,FilesUrl,Verific,SeoTitle,SeoKeyword,SeoDescription,Languagen,Contents2,Contents3,TitleColor,AllowComment)");
            strSql.Append(" values (");
            strSql.Append("@Tid,@Title,@FullTitle,@Intro,@Contents,@Owner,@Author,@Origin,@Hits,@AddDate,@EditDate,@IsRecommend,@IsNew,@IsPopular,@IsDel,@Px,@PicUrl,@FilesUrl,@Verific,@SeoTitle,@SeoKeyword,@SeoDescription,@Languagen,@Contents2,@Contents3,@TitleColor,@AllowComment)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@FullTitle", SqlDbType.NVarChar,150),
                    new SqlParameter("@Intro", SqlDbType.NVarChar,250),
                    new SqlParameter("@Contents", SqlDbType.NText),
                    new SqlParameter("@Owner", SqlDbType.NVarChar,50),
                    new SqlParameter("@Author", SqlDbType.NVarChar,50),
                    new SqlParameter("@Origin", SqlDbType.NVarChar,50),
                    new SqlParameter("@Hits", SqlDbType.Int,4),
                    new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@EditDate", SqlDbType.DateTime),
                    new SqlParameter("@IsRecommend", SqlDbType.Int,4),
                    new SqlParameter("@IsNew", SqlDbType.Int,4),
                    new SqlParameter("@IsPopular", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Int,4),
                    new SqlParameter("@Px", SqlDbType.Int,4),
                    new SqlParameter("@PicUrl", SqlDbType.NVarChar,50),
                    new SqlParameter("@FilesUrl", SqlDbType.NVarChar,50),
                    new SqlParameter("@Verific", SqlDbType.Int,4),
                    new SqlParameter("@SeoTitle", SqlDbType.NVarChar,100),
                    new SqlParameter("@SeoKeyword", SqlDbType.NVarChar,150),
                    new SqlParameter("@SeoDescription", SqlDbType.NVarChar,250),
                    new SqlParameter("@Languagen", SqlDbType.Int,4),
                    new SqlParameter("@Contents2", SqlDbType.NText),
                    new SqlParameter("@Contents3", SqlDbType.NText),
                    new SqlParameter("@TitleColor",SqlDbType.NVarChar,50),
                    new SqlParameter("@AllowComment",SqlDbType.NVarChar,50),
            };
            parameters[0].Value = model.Tid;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.FullTitle;
            parameters[3].Value = model.Intro;
            parameters[4].Value = model.Contents;
            parameters[5].Value = model.Owner;
            parameters[6].Value = model.Author;
            parameters[7].Value = model.Origin;
            parameters[8].Value = model.Hits;
            parameters[9].Value = model.AddDate;
            parameters[10].Value = model.EditDate;
            parameters[11].Value = model.IsRecommend;
            parameters[12].Value = model.IsNew;
            parameters[13].Value = model.IsPopular;
            parameters[14].Value = model.IsDel;
            parameters[15].Value = model.Px;
            parameters[16].Value = model.PicUrl;
            parameters[17].Value = model.FilesUrl;
            parameters[18].Value = model.Verific;
            parameters[19].Value = model.SeoTitle;
            parameters[20].Value = model.SeoKeyword;
            parameters[21].Value = model.SeoDescription;
            parameters[22].Value = model.Languagen;
            parameters[23].Value = model.Contents2;
            parameters[24].Value = model.Contents3;
            parameters[25].Value = model.TitltColor;
            parameters[26].Value = model.AllowComment;

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
        public bool Update(string datatable, GL.Model.ArticleModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + datatable + " set ");
            strSql.Append("Tid=@Tid,");
            strSql.Append("Title=@Title,");
            strSql.Append("FullTitle=@FullTitle,");
            strSql.Append("Intro=@Intro,");
            strSql.Append("Contents=@Contents,");
            strSql.Append("Owner=@Owner,");
            strSql.Append("Author=@Author,");
            strSql.Append("Origin=@Origin,");
            strSql.Append("Hits=@Hits,");
            //strSql.Append("AddDate=@AddDate,");
            strSql.Append("EditDate=@EditDate,");
            strSql.Append("IsRecommend=@IsRecommend,");
            strSql.Append("IsNew=@IsNew,");
            strSql.Append("IsPopular=@IsPopular,");
            //strSql.Append("IsDel=@IsDel,");
            strSql.Append("Px=@Px,");
            strSql.Append("PicUrl=@PicUrl,");
            strSql.Append("FilesUrl=@FilesUrl,");
            strSql.Append("Verific=@Verific,");
            strSql.Append("SeoTitle=@SeoTitle,");
            strSql.Append("SeoKeyword=@SeoKeyword,");
            strSql.Append("SeoDescription=@SeoDescription,");
            strSql.Append("Languagen=@Languagen,");
            strSql.Append("Contents2=@Contents2,");
            strSql.Append("Contents3=@Contents3,");
            strSql.Append("TitleColor=@TitleColor,");
            strSql.Append("AllowComment=@AllowComment");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@FullTitle", SqlDbType.NVarChar,150),
                    new SqlParameter("@Intro", SqlDbType.NVarChar,250),
                    new SqlParameter("@Contents", SqlDbType.NText),
                    new SqlParameter("@Owner", SqlDbType.NVarChar,50),
                    new SqlParameter("@Author", SqlDbType.NVarChar,50),
                    new SqlParameter("@Origin", SqlDbType.NVarChar,50),
                    new SqlParameter("@Hits", SqlDbType.Int,4),
					//new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@EditDate", SqlDbType.DateTime),
                    new SqlParameter("@IsRecommend", SqlDbType.Int,4),
                    new SqlParameter("@IsNew", SqlDbType.Int,4),
                    new SqlParameter("@IsPopular", SqlDbType.Int,4),
					//new SqlParameter("@IsDel", SqlDbType.Int,4),
					new SqlParameter("@Px", SqlDbType.Int,4),
                    new SqlParameter("@PicUrl", SqlDbType.NVarChar,50),
                    new SqlParameter("@FilesUrl", SqlDbType.NVarChar,50),
                    new SqlParameter("@Verific", SqlDbType.Int,4),
                    new SqlParameter("@SeoTitle", SqlDbType.NVarChar,100),
                    new SqlParameter("@SeoKeyword", SqlDbType.NVarChar,150),
                    new SqlParameter("@SeoDescription", SqlDbType.NVarChar,250),
                    new SqlParameter("@Languagen", SqlDbType.Int,4),
                    new SqlParameter("@Contents2", SqlDbType.NText),
                    new SqlParameter("@Contents3", SqlDbType.NText),
                    new SqlParameter("@TitleColor",SqlDbType.NVarChar,50),
                    new SqlParameter("@AllowComment",SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Tid;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.FullTitle;
            parameters[3].Value = model.Intro;
            parameters[4].Value = model.Contents;
            parameters[5].Value = model.Owner;
            parameters[6].Value = model.Author;
            parameters[7].Value = model.Origin;
            parameters[8].Value = model.Hits;
            //parameters[9].Value = model.AddDate;
            parameters[9].Value = model.EditDate;
            parameters[10].Value = model.IsRecommend;
            parameters[11].Value = model.IsNew;
            parameters[12].Value = model.IsPopular;
            // parameters[13].Value = model.IsDel;
            parameters[13].Value = model.Px;
            parameters[14].Value = model.PicUrl;
            parameters[15].Value = model.FilesUrl;
            parameters[16].Value = model.Verific;
            parameters[17].Value = model.SeoTitle;
            parameters[18].Value = model.SeoKeyword;
            parameters[19].Value = model.SeoDescription;
            parameters[20].Value = model.Languagen;
            parameters[21].Value = model.Contents2;
            parameters[22].Value = model.Contents3;
            parameters[23].Value = model.TitltColor;
            parameters[24].Value = model.AllowComment;
            parameters[25].Value = model.id;

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

        #region 更新自定义字段
        /// <summary>
        /// 更新自定义字段
        /// </summary>
        /// <param name="datatable">表</param>
        /// <param name="sql">执行的SQL语句</param>
        /// <returns></returns>
        public bool Updatezd(string datatable, string sql, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + datatable + " set " + sql + " where id=" + id);
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
        #endregion

        #region 更新指定字段的多条记录

        /// <summary>
        /// 更新指定字段的多条记录
        /// </summary>
        /// <param name="cnname">字段名</param>
        /// <param name="values">更新的值</param>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool Update1(string datatable, string cnname, string values, string id)
        {
            string strSql = "update " + datatable + " set " + cnname + "=@values where id in (" + id + ")";
            SqlParameter[] parameters = new SqlParameter[]{
					//new SqlParameter("@id",id),
					//new SqlParameter("@cnname",cnname),
					new SqlParameter("@values",values)
             };
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
        #endregion

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.ArticleModel GetModel(string datatable, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Tid,Title,FullTitle,Intro,Contents,Owner,Author,Origin,Hits,AddDate,EditDate,IsRecommend,IsNew,IsPopular,IsDel,Px,PicUrl,FilesUrl,Verific,SeoTitle,SeoKeyword,SeoDescription,Languagen,Contents2,Contents3,TitleColor,AllowComment from " + datatable + " ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            GL.Model.ArticleModel model = new GL.Model.ArticleModel();
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
        public GL.Model.ArticleModel DataRowToModel(DataRow row)
        {
            GL.Model.ArticleModel model = new GL.Model.ArticleModel();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["Tid"] != null && row["Tid"].ToString() != "")
                {
                    model.Tid = int.Parse(row["Tid"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["FullTitle"] != null)
                {
                    model.FullTitle = row["FullTitle"].ToString();
                }
                if (row["Intro"] != null)
                {
                    model.Intro = row["Intro"].ToString();
                }
                if (row["Contents"] != null)
                {
                    model.Contents = row["Contents"].ToString();
                }
                if (row["Owner"] != null)
                {
                    model.Owner = row["Owner"].ToString();
                }
                if (row["Author"] != null)
                {
                    model.Author = row["Author"].ToString();
                }
                if (row["Origin"] != null)
                {
                    model.Origin = row["Origin"].ToString();
                }
                if (row["Hits"] != null && row["Hits"].ToString() != "")
                {
                    model.Hits = int.Parse(row["Hits"].ToString());
                }
                if (row["AddDate"] != null && row["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(row["AddDate"].ToString());
                }
                if (row["EditDate"] != null && row["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(row["EditDate"].ToString());
                }
                if (row["IsRecommend"] != null && row["IsRecommend"].ToString() != "")
                {
                    model.IsRecommend = int.Parse(row["IsRecommend"].ToString());
                }
                if (row["IsNew"] != null && row["IsNew"].ToString() != "")
                {
                    model.IsNew = int.Parse(row["IsNew"].ToString());
                }
                if (row["IsPopular"] != null && row["IsPopular"].ToString() != "")
                {
                    model.IsPopular = int.Parse(row["IsPopular"].ToString());
                }
                if (row["IsDel"] != null && row["IsDel"].ToString() != "")
                {
                    model.IsDel = int.Parse(row["IsDel"].ToString());
                }
                if (row["Px"] != null && row["Px"].ToString() != "")
                {
                    model.Px = int.Parse(row["Px"].ToString());
                }
                if (row["PicUrl"] != null)
                {
                    model.PicUrl = row["PicUrl"].ToString();
                }
                if (row["FilesUrl"] != null)
                {
                    model.FilesUrl = row["FilesUrl"].ToString();
                }
                if (row["Verific"] != null && row["Verific"].ToString() != "")
                {
                    model.Verific = int.Parse(row["Verific"].ToString());
                }
                if (row["SeoTitle"] != null)
                {
                    model.SeoTitle = row["SeoTitle"].ToString();
                }
                if (row["SeoKeyword"] != null)
                {
                    model.SeoKeyword = row["SeoKeyword"].ToString();
                }
                if (row["SeoDescription"] != null)
                {
                    model.SeoDescription = row["SeoDescription"].ToString();
                }
                if (row["Languagen"] != null && row["Languagen"].ToString() != "")
                {
                    model.Languagen = int.Parse(row["Languagen"].ToString());
                }

                if (row["Contents2"] != null)
                {
                    model.Contents2 = row["Contents2"].ToString();
                }
                if (row["Contents3"] != null)
                {
                    model.Contents3 = row["Contents3"].ToString();
                }
                if (row["TitleColor"] != null)
                {
                    model.TitltColor = row["TitleColor"].ToString();
                }
                if (row["AllowComment"] != null && row["AllowComment"].ToString() != "")
                {
                    model.AllowComment = int.Parse(row["AllowComment"].ToString());
                }
            }
            return model;
        }



        /// <summary>
        /// 根据当前ID取得前后ID
        /// </summary>
        /// <param name="id">当前ID</param>
        /// <param name="type">前条或后条</param>
        /// <returns></returns>
        public int GetNextPrevid(string datatable, int id, string type, string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from " + datatable + " where ");
            if (strwhere.Trim() != "")
            {
                strSql.Append(" " + strwhere + " and ");
            }
            if (type == "next")//下一条
            {
                if (id > 0)
                {
                    strSql.Append(" id>" + id + " order by id asc");
                }
                else
                {
                    strSql.Append(" id is not null order by id desc");//读取最后一条
                }
            }
            else//上一条
            {
                if (id > 0)
                {
                    strSql.Append(" id<" + id + " order by id desc");
                }
                else
                {
                    strSql.Append(" id is not null order by id asc");//第一条
                }
            }

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 内容分页
        /// </summary>
        /// <param name="contents">内容</param>
        /// <param name="PageIndex">当前第几页</param>
        /// <param name="id">当前ID</param>
        /// <returns></returns>
        public string GetNextPage(string contents, int PageIndex, int id)
        {
            string[] page = Regex.Split(contents, @"\[NextPage\]", RegexOptions.IgnoreCase);
            if (page.Length > 1)//有分页
            {
                if (PageIndex > page.Length)//超出时显示最后一页
                {
                    PageIndex = page.Length;
                }
                if (PageIndex == 0)
                {
                    PageIndex = 1;
                }
                string fy = "<div class=\"pageconfy\">";
                for (int i = 1; i <= page.Length; i++)
                {
                    if (i == PageIndex)
                    {
                        fy += "<span class=\"cur\">[" + i + "]</span>";
                    }
                    else
                    {
                        fy += "<a href=\"?id=" + id + "&Page=" + i + "\">[" + i + "]</a>";
                    }
                }
                fy += "<a href=\"?id=" + id + "&Page=" + (PageIndex + 1) + "\">下一页</a>";
                fy += "</div>";
                contents = page[PageIndex - 1] + fy;
            }
            return contents;
        }
        #endregion  Method
    }
}