using System;
using System.Collections.Generic;
using System.Text;
using GL.Utility;
using System.Data;
using System.Data.SqlClient;
namespace GL.Dal
{
    /// <summary>
    /// 数据访问类:ProductsModel
    /// </summary>
    public partial class ProductsDal
    {
        public ProductsDal()
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
        public int Add(string datatable, GL.Model.ProductsModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + datatable + "(");
            strSql.Append("Tid,Title,Intro,Contents,Hits,AddDate,EditDate,IsRecommend,IsNew,IsPopular,Px,IsDel,PicUrl,BigPhoto,FilesUrl,Languagen,SeoTitle,SeoKeyWord,SeoDescription,Price,PriceMarket,IsSpecial,ProModel,ProSpecificat,ProducerName,Unit,TotalNum,Comment,Inputer,Contents2,Contents3,Verific,TitleColor)");
            strSql.Append(" values (");
            strSql.Append("@Tid,@Title,@Intro,@Contents,@Hits,@AddDate,@EditDate,@IsRecommend,@IsNew,@IsPopular,@Px,@IsDel,@PicUrl,@BigPhoto,@FilesUrl,@Languagen,@SeoTitle,@SeoKeyWord,@SeoDescription,@Price,@PriceMarket,@IsSpecial,@ProModel,@ProSpecificat,@ProducerName,@Unit,@TotalNum,@Comment,@Inputer,@Contents2,@Contents3,@Verific,@TitleColor)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Title", SqlDbType.NVarChar,150),
                    new SqlParameter("@Intro", SqlDbType.NVarChar,250),
                    new SqlParameter("@Contents", SqlDbType.NText),
                    new SqlParameter("@Hits", SqlDbType.Int,4),
                    new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@EditDate", SqlDbType.DateTime),
                    new SqlParameter("@IsRecommend", SqlDbType.Int,4),
                    new SqlParameter("@IsNew", SqlDbType.Int,4),
                    new SqlParameter("@IsPopular", SqlDbType.Int,4),
                    new SqlParameter("@Px", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Int,4),
                    new SqlParameter("@PicUrl", SqlDbType.NVarChar,50),
                    new SqlParameter("@BigPhoto", SqlDbType.NVarChar,50),
                    new SqlParameter("@FilesUrl", SqlDbType.NVarChar,50),
                    new SqlParameter("@Languagen", SqlDbType.Int,4),
                    new SqlParameter("@SeoTitle", SqlDbType.NVarChar,150),
                    new SqlParameter("@SeoKeyWord", SqlDbType.NVarChar,250),
                    new SqlParameter("@SeoDescription", SqlDbType.NVarChar,350),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@PriceMarket", SqlDbType.Decimal,9),
                    new SqlParameter("@IsSpecial", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProModel", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProSpecificat", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProducerName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Unit", SqlDbType.NVarChar,50),
                    new SqlParameter("@TotalNum", SqlDbType.Int,4),
                    new SqlParameter("@Comment", SqlDbType.Int,4),
                    new SqlParameter("@Inputer", SqlDbType.NVarChar,50),
                    new SqlParameter("@Contents2", SqlDbType.NText),
                    new SqlParameter("@Contents3", SqlDbType.NText),
                    new SqlParameter("@Verific", SqlDbType.Int,4),
                    new SqlParameter("@TitleColor", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Tid;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Intro;
            parameters[3].Value = model.Contents;
            parameters[4].Value = model.Hits;
            parameters[5].Value = model.AddDate;
            parameters[6].Value = model.EditDate;
            parameters[7].Value = model.IsRecommend;
            parameters[8].Value = model.IsNew;
            parameters[9].Value = model.IsPopular;
            parameters[10].Value = model.Px;
            parameters[11].Value = model.IsDel;
            parameters[12].Value = model.PicUrl;
            parameters[13].Value = model.BigPhoto;
            parameters[14].Value = model.FilesUrl;
            parameters[15].Value = model.Languagen;
            parameters[16].Value = model.SeoTitle;
            parameters[17].Value = model.SeoKeyWord;
            parameters[18].Value = model.SeoDescription;
            parameters[19].Value = model.Price;
            parameters[20].Value = model.PriceMarket;
            parameters[21].Value = model.IsSpecial;
            parameters[22].Value = model.ProModel;
            parameters[23].Value = model.ProSpecificat;
            parameters[24].Value = model.ProducerName;
            parameters[25].Value = model.Unit;
            parameters[26].Value = model.TotalNum;
           
            parameters[27].Value = model.Comment;
            parameters[28].Value = model.Inputer;
            parameters[29].Value = model.Contents2;
            parameters[30].Value = model.Contents3;
            parameters[31].Value = model.Verific;
            parameters[32].Value = model.TitleColor;

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
        public bool Update(string datatable, GL.Model.ProductsModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + datatable + " set ");
            strSql.Append("Tid=@Tid,");
            strSql.Append("Title=@Title,");
            strSql.Append("Intro=@Intro,");
            strSql.Append("Contents=@Contents,");
            strSql.Append("Hits=@Hits,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("EditDate=@EditDate,");
            strSql.Append("IsRecommend=@IsRecommend,");
            strSql.Append("IsNew=@IsNew,");
            strSql.Append("IsPopular=@IsPopular,");
            strSql.Append("Px=@Px,");
            strSql.Append("IsDel=@IsDel,");
            strSql.Append("PicUrl=@PicUrl,");
            strSql.Append("BigPhoto=@BigPhoto,");
            //strSql.Append("Languagen=@Languagen,");
            strSql.Append("SeoTitle=@SeoTitle,");
            strSql.Append("SeoKeyWord=@SeoKeyWord,");
            strSql.Append("SeoDescription=@SeoDescription,");
            strSql.Append("Price=@Price,");
            strSql.Append("PriceMarket=@PriceMarket,");
            strSql.Append("IsSpecial=@IsSpecial,");
            strSql.Append("ProModel=@ProModel,");
            strSql.Append("ProSpecificat=@ProSpecificat,");
            strSql.Append("ProducerName=@ProducerName,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("TotalNum=@TotalNum,");
            strSql.Append("Comment=@Comment,");
            strSql.Append("Inputer=@Inputer,");
            strSql.Append("FilesUrl=@FilesUrl,");
            strSql.Append("Contents2=@Contents2,");
            strSql.Append("Contents3=@Contents3,");
            strSql.Append("Verific=@Verific,");
            strSql.Append("TitleColor=@TitleColor");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Title", SqlDbType.NVarChar,150),
                    new SqlParameter("@Intro", SqlDbType.NVarChar,250),
                    new SqlParameter("@Contents", SqlDbType.NText),
                    new SqlParameter("@Hits", SqlDbType.Int,4),
                    new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@EditDate", SqlDbType.DateTime),
                    new SqlParameter("@IsRecommend", SqlDbType.Int,4),
                    new SqlParameter("@IsNew", SqlDbType.Int,4),
                    new SqlParameter("@IsPopular", SqlDbType.Int,4),
                    new SqlParameter("@Px", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Int,4),
                    new SqlParameter("@PicUrl", SqlDbType.NVarChar,50),
                    new SqlParameter("@BigPhoto", SqlDbType.NVarChar,50),
					//new SqlParameter("@Languagen", SqlDbType.Int,4),
					new SqlParameter("@SeoTitle", SqlDbType.NVarChar,150),
                    new SqlParameter("@SeoKeyWord", SqlDbType.NVarChar,250),
                    new SqlParameter("@SeoDescription", SqlDbType.NVarChar,350),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@PriceMarket", SqlDbType.Decimal,9),
                    new SqlParameter("@IsSpecial", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProModel", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProSpecificat", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProducerName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Unit", SqlDbType.NVarChar,50),
                    new SqlParameter("@TotalNum", SqlDbType.Int,4),
                    new SqlParameter("@Comment", SqlDbType.Int,4),
                    new SqlParameter("@Inputer", SqlDbType.NVarChar,50),
                    new SqlParameter("@FilesUrl", SqlDbType.NVarChar,50),
                    new SqlParameter("@Contents2", SqlDbType.NText),
                    new SqlParameter("@Contents3", SqlDbType.NText),
                    new SqlParameter("@Verific", SqlDbType.Int,4),
                    new SqlParameter("TitleColor",SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Tid;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Intro;
            parameters[3].Value = model.Contents;
            parameters[4].Value = model.Hits;
            parameters[5].Value = model.AddDate;
            parameters[6].Value = model.EditDate;
            parameters[7].Value = model.IsRecommend;
            parameters[8].Value = model.IsNew;
            parameters[9].Value = model.IsPopular;
            parameters[10].Value = model.Px;
            parameters[11].Value = model.IsDel;
            parameters[12].Value = model.PicUrl;
            parameters[13].Value = model.BigPhoto;
            //parameters[14].Value = model.Languagen;
            parameters[14].Value = model.SeoTitle;
            parameters[15].Value = model.SeoKeyWord;
            parameters[16].Value = model.SeoDescription;
            parameters[17].Value = model.Price;
            parameters[18].Value = model.PriceMarket;
            parameters[19].Value = model.IsSpecial;
            parameters[20].Value = model.ProModel;
            parameters[21].Value = model.ProSpecificat;
            parameters[22].Value = model.ProducerName;
            parameters[23].Value = model.Unit;
            parameters[24].Value = model.TotalNum;
           
            parameters[25].Value = model.Comment;
            parameters[26].Value = model.Inputer;
            parameters[27].Value = model.FilesUrl;
            parameters[28].Value = model.Contents2;
            parameters[29].Value = model.Contents3;
            parameters[30].Value = model.Verific;
            parameters[31].Value = model.TitleColor;
            parameters[32].Value = model.id;

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
        public GL.Model.ProductsModel GetModel(string datatable, int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Tid,Title,Intro,Contents,Hits,AddDate,EditDate,IsRecommend,IsNew,IsPopular,Px,IsDel,PicUrl,BigPhoto,Languagen,SeoTitle,SeoKeyWord,SeoDescription,Price,PriceMarket,IsSpecial,ProModel,ProSpecificat,ProducerName,Unit,TotalNum,Comment,Inputer,FilesUrl,Contents2,Contents3,Verific,TitleColor from " + datatable + " ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            GL.Model.ProductsModel model = new GL.Model.ProductsModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tid"] != null && ds.Tables[0].Rows[0]["Tid"].ToString() != "")
                {
                    model.Tid = int.Parse(ds.Tables[0].Rows[0]["Tid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Intro"] != null && ds.Tables[0].Rows[0]["Intro"].ToString() != "")
                {
                    model.Intro = ds.Tables[0].Rows[0]["Intro"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Contents"] != null && ds.Tables[0].Rows[0]["Contents"].ToString() != "")
                {
                    model.Contents = ds.Tables[0].Rows[0]["Contents"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Hits"] != null && ds.Tables[0].Rows[0]["Hits"].ToString() != "")
                {
                    model.Hits = int.Parse(ds.Tables[0].Rows[0]["Hits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditDate"] != null && ds.Tables[0].Rows[0]["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(ds.Tables[0].Rows[0]["EditDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsRecommend"] != null && ds.Tables[0].Rows[0]["IsRecommend"].ToString() != "")
                {
                    model.IsRecommend = int.Parse(ds.Tables[0].Rows[0]["IsRecommend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsNew"] != null && ds.Tables[0].Rows[0]["IsNew"].ToString() != "")
                {
                    model.IsNew = int.Parse(ds.Tables[0].Rows[0]["IsNew"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsPopular"] != null && ds.Tables[0].Rows[0]["IsPopular"].ToString() != "")
                {
                    model.IsPopular = int.Parse(ds.Tables[0].Rows[0]["IsPopular"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Px"] != null && ds.Tables[0].Rows[0]["Px"].ToString() != "")
                {
                    model.Px = int.Parse(ds.Tables[0].Rows[0]["Px"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDel"] != null && ds.Tables[0].Rows[0]["IsDel"].ToString() != "")
                {
                    model.IsDel = int.Parse(ds.Tables[0].Rows[0]["IsDel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicUrl"] != null && ds.Tables[0].Rows[0]["PicUrl"].ToString() != "")
                {
                    model.PicUrl = ds.Tables[0].Rows[0]["PicUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BigPhoto"] != null && ds.Tables[0].Rows[0]["BigPhoto"].ToString() != "")
                {
                    model.BigPhoto = ds.Tables[0].Rows[0]["BigPhoto"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Languagen"] != null && ds.Tables[0].Rows[0]["Languagen"].ToString() != "")
                {
                    model.Languagen = int.Parse(ds.Tables[0].Rows[0]["Languagen"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SeoTitle"] != null && ds.Tables[0].Rows[0]["SeoTitle"].ToString() != "")
                {
                    model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SeoKeyWord"] != null && ds.Tables[0].Rows[0]["SeoKeyWord"].ToString() != "")
                {
                    model.SeoKeyWord = ds.Tables[0].Rows[0]["SeoKeyWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SeoDescription"] != null && ds.Tables[0].Rows[0]["SeoDescription"].ToString() != "")
                {
                    model.SeoDescription = ds.Tables[0].Rows[0]["SeoDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PriceMarket"] != null && ds.Tables[0].Rows[0]["PriceMarket"].ToString() != "")
                {
                    model.PriceMarket = decimal.Parse(ds.Tables[0].Rows[0]["PriceMarket"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSpecial"] != null && ds.Tables[0].Rows[0]["IsSpecial"].ToString() != "")
                {
                    model.IsSpecial = ds.Tables[0].Rows[0]["IsSpecial"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProModel"] != null && ds.Tables[0].Rows[0]["ProModel"].ToString() != "")
                {
                    model.ProModel = ds.Tables[0].Rows[0]["ProModel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProSpecificat"] != null && ds.Tables[0].Rows[0]["ProSpecificat"].ToString() != "")
                {
                    model.ProSpecificat = ds.Tables[0].Rows[0]["ProSpecificat"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProducerName"] != null && ds.Tables[0].Rows[0]["ProducerName"].ToString() != "")
                {
                    model.ProducerName = ds.Tables[0].Rows[0]["ProducerName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Unit"] != null && ds.Tables[0].Rows[0]["Unit"].ToString() != "")
                {
                    model.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TotalNum"] != null && ds.Tables[0].Rows[0]["TotalNum"].ToString() != "")
                {
                    model.TotalNum = int.Parse(ds.Tables[0].Rows[0]["TotalNum"].ToString());
                }
                
                if (ds.Tables[0].Rows[0]["Comment"] != null && ds.Tables[0].Rows[0]["Comment"].ToString() != "")
                {
                    model.Comment = int.Parse(ds.Tables[0].Rows[0]["Comment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Inputer"] != null && ds.Tables[0].Rows[0]["Inputer"].ToString() != "")
                {
                    model.Inputer = ds.Tables[0].Rows[0]["Inputer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FilesUrl"] != null && ds.Tables[0].Rows[0]["FilesUrl"].ToString() != "")
                {
                    model.FilesUrl = ds.Tables[0].Rows[0]["FilesUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Contents2"] != null && ds.Tables[0].Rows[0]["Contents2"].ToString() != "")
                {
                    model.Contents2 = ds.Tables[0].Rows[0]["Contents2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Contents3"] != null && ds.Tables[0].Rows[0]["Contents3"].ToString() != "")
                {
                    model.Contents3 = ds.Tables[0].Rows[0]["Contents3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Verific"] != null && ds.Tables[0].Rows[0]["Verific"].ToString() != "")
                {
                    model.Verific = int.Parse(ds.Tables[0].Rows[0]["Verific"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TitleColor"] != null && ds.Tables[0].Rows[0]["TitleColor"].ToString() != "")
                {
                    model.TitleColor = ds.Tables[0].Rows[0]["TitleColor"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
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
        #endregion  Method
    }
}


