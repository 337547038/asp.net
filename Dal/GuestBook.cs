using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GL.Utility;
using System.Data.SqlClient;
namespace GL.Dal
{
    /// <summary>
    /// 数据访问类:GL_GuestBook
    /// </summary>
    public partial class GuestBookDal
    {
        public GuestBookDal()
        { }
        #region  Method
      
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.GuestBookModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_GuestBook(");
            strSql.Append("Title,UserName,Tel,Fax,Mobile,Company,Address,Email,SiteUrl,Code,Sex,AddTime,QQ,WangWang,MSN,Contents,Verific,IP,Reply,ReplyTime)");
            strSql.Append(" values (");
            strSql.Append("@Title,@UserName,@Tel,@Fax,@Mobile,@Company,@Address,@Email,@SiteUrl,@Code,@Sex,@AddTime,@QQ,@WangWang,@MSN,@Contents,@Verific,@IP,@Reply,@ReplyTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@WangWang", SqlDbType.NVarChar,50),
					new SqlParameter("@MSN", SqlDbType.NVarChar,50),
					new SqlParameter("@Contents", SqlDbType.NText),
					new SqlParameter("@Verific", SqlDbType.Int,4),
					new SqlParameter("@IP", SqlDbType.NVarChar,50),
					new SqlParameter("@Reply", SqlDbType.NText),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.Fax;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.Company;
            parameters[6].Value = model.Address;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.SiteUrl;
            parameters[9].Value = model.Code;
            parameters[10].Value = model.Sex;
            parameters[11].Value = model.AddTime;
            parameters[12].Value = model.QQ;
            parameters[13].Value = model.WangWang;
            parameters[14].Value = model.MSN;
            parameters[15].Value = model.Contents;
            parameters[16].Value = model.Verific;
            parameters[17].Value = model.IP;
            parameters[18].Value = model.Reply;
            parameters[19].Value = model.ReplyTime;

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
        public bool Update(GL.Model.GuestBookModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_GuestBook set ");
            strSql.Append("Title=@Title,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Company=@Company,");
            strSql.Append("Address=@Address,");
            strSql.Append("Email=@Email,");
            strSql.Append("SiteUrl=@SiteUrl,");
            strSql.Append("Code=@Code,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("WangWang=@WangWang,");
            strSql.Append("MSN=@MSN,");
            strSql.Append("Contents=@Contents,");
            strSql.Append("Verific=@Verific,");
            strSql.Append("IP=@IP,");
            strSql.Append("Reply=@Reply,");
            strSql.Append("ReplyTime=@ReplyTime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@WangWang", SqlDbType.NVarChar,50),
					new SqlParameter("@MSN", SqlDbType.NVarChar,50),
					new SqlParameter("@Contents", SqlDbType.NText),
					new SqlParameter("@Verific", SqlDbType.Int,4),
					new SqlParameter("@IP", SqlDbType.NVarChar,50),
					new SqlParameter("@Reply", SqlDbType.NText),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.Fax;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.Company;
            parameters[6].Value = model.Address;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.SiteUrl;
            parameters[9].Value = model.Code;
            parameters[10].Value = model.Sex;
            parameters[11].Value = model.AddTime;
            parameters[12].Value = model.QQ;
            parameters[13].Value = model.WangWang;
            parameters[14].Value = model.MSN;
            parameters[15].Value = model.Contents;
            parameters[16].Value = model.Verific;
            parameters[17].Value = model.IP;
            parameters[18].Value = model.Reply;
            parameters[19].Value = model.ReplyTime;
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
        /// 更新回复、内容、状态
        /// </summary>
        public bool Update1(GL.Model.GuestBookModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_GuestBook set ");
            strSql.Append("Contents=@Contents,");
            strSql.Append("Verific=@Verific,");
            strSql.Append("Reply=@Reply,");
            strSql.Append("ReplyTime=@ReplyTime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@Contents", SqlDbType.NText),
					new SqlParameter("@Verific", SqlDbType.Int,4),
					new SqlParameter("@Reply", SqlDbType.NText),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Contents;
            parameters[1].Value = model.Verific;
            parameters[2].Value = model.Reply;
            parameters[3].Value = model.ReplyTime;
            parameters[4].Value = model.id;

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
        public GL.Model.GuestBookModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Title,UserName,Tel,Fax,Mobile,Company,Address,Email,SiteUrl,Code,Sex,AddTime,QQ,WangWang,MSN,Contents,Verific,IP,Reply,ReplyTime from GL_GuestBook ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            GL.Model.GuestBookModel model = new GL.Model.GuestBookModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tel"] != null && ds.Tables[0].Rows[0]["Tel"].ToString() != "")
                {
                    model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Fax"] != null && ds.Tables[0].Rows[0]["Fax"].ToString() != "")
                {
                    model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Mobile"] != null && ds.Tables[0].Rows[0]["Mobile"].ToString() != "")
                {
                    model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Company"] != null && ds.Tables[0].Rows[0]["Company"].ToString() != "")
                {
                    model.Company = ds.Tables[0].Rows[0]["Company"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SiteUrl"] != null && ds.Tables[0].Rows[0]["SiteUrl"].ToString() != "")
                {
                    model.SiteUrl = ds.Tables[0].Rows[0]["SiteUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Code"] != null && ds.Tables[0].Rows[0]["Code"].ToString() != "")
                {
                    model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QQ"] != null && ds.Tables[0].Rows[0]["QQ"].ToString() != "")
                {
                    model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WangWang"] != null && ds.Tables[0].Rows[0]["WangWang"].ToString() != "")
                {
                    model.WangWang = ds.Tables[0].Rows[0]["WangWang"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MSN"] != null && ds.Tables[0].Rows[0]["MSN"].ToString() != "")
                {
                    model.MSN = ds.Tables[0].Rows[0]["MSN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Contents"] != null && ds.Tables[0].Rows[0]["Contents"].ToString() != "")
                {
                    model.Contents = ds.Tables[0].Rows[0]["Contents"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Verific"] != null && ds.Tables[0].Rows[0]["Verific"].ToString() != "")
                {
                    model.Verific = int.Parse(ds.Tables[0].Rows[0]["Verific"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IP"] != null && ds.Tables[0].Rows[0]["IP"].ToString() != "")
                {
                    model.IP = ds.Tables[0].Rows[0]["IP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Reply"] != null && ds.Tables[0].Rows[0]["Reply"].ToString() != "")
                {
                    model.Reply = ds.Tables[0].Rows[0]["Reply"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReplyTime"] != null && ds.Tables[0].Rows[0]["ReplyTime"].ToString() != "")
                {
                    model.ReplyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReplyTime"].ToString());
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

