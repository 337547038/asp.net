using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;
namespace GL.Dal
{
    public partial class UserDal
    {
        public UserDal()
        { }
        #region  Method


        public int Add(GL.Model.UserModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_User(");
            strSql.Append("GroupID,UserName,PassWord,Locked,Email,QQ,City,Address,Sex,UserFace,RegDate,LastLoginTime,LoginTimes,Company,Tel,LastLoginIP,WenXin,Source)");
            strSql.Append(" values (");
            strSql.Append("@GroupID,@UserName,@PassWord,@Locked,@Email,@QQ,@City,@Address,@Sex,@UserFace,@RegDate,@LastLoginTime,@LoginTimes,@Company,@Tel,@LastLoginIP,@WenXin,@Source)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@GroupID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
                    new SqlParameter("@Locked", SqlDbType.Int,4),
                    new SqlParameter("@Email", SqlDbType.NVarChar,50),
                    new SqlParameter("@QQ", SqlDbType.NVarChar,50),
                    new SqlParameter("@City", SqlDbType.NVarChar,50),
                    new SqlParameter("@Address", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sex", SqlDbType.Int,4),
                    new SqlParameter("@UserFace", SqlDbType.NVarChar,50),
                    new SqlParameter("@RegDate", SqlDbType.DateTime),
                    new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
                    new SqlParameter("@LoginTimes", SqlDbType.Int,4),
                    new SqlParameter("@Company", SqlDbType.NVarChar,50),
                    new SqlParameter("@Tel", SqlDbType.NVarChar,50),
                    new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,50),
                    new SqlParameter("@WenXin", SqlDbType.NVarChar,50),
                    new SqlParameter("@Source", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.GroupID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.PassWord;
            parameters[3].Value = model.Locked;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.QQ;
            parameters[6].Value = model.City;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.Sex;
            parameters[9].Value = model.UserFace;
            parameters[10].Value = model.RegDate;
            parameters[11].Value = model.LastLoginTime;
            parameters[12].Value = model.LoginTimes;
            parameters[13].Value = model.Company;
            parameters[14].Value = model.Tel;
            parameters[15].Value = model.LastLoginIP;
            parameters[16].Value = model.WenXin;
            parameters[17].Value = model.Source;

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
        public bool Update(GL.Model.UserModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_User set ");
            strSql.Append("GroupID=@GroupID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PassWord=@PassWord,");
            strSql.Append("Locked=@Locked,");
            strSql.Append("Email=@Email,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("City=@City,");
            strSql.Append("Address=@Address,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("UserFace=@UserFace,");
            strSql.Append("Company=@Company,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("WenXin=@WenXin,");
            strSql.Append("Source=@Source");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@GroupID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
                    new SqlParameter("@Locked", SqlDbType.Int,4),
                    new SqlParameter("@Email", SqlDbType.NVarChar,50),
                    new SqlParameter("@QQ", SqlDbType.NVarChar,50),
                    new SqlParameter("@City", SqlDbType.NVarChar,50),
                    new SqlParameter("@Address", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sex", SqlDbType.Int,4),
                    new SqlParameter("@UserFace", SqlDbType.NVarChar,50),
                    new SqlParameter("@Company", SqlDbType.NVarChar,50),
                    new SqlParameter("@Tel", SqlDbType.NVarChar,50),
                    new SqlParameter("@WenXin", SqlDbType.NVarChar,50),
                    new SqlParameter("@Source", SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.GroupID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.PassWord;
            parameters[3].Value = model.Locked;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.QQ;
            parameters[6].Value = model.City;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.Sex;
            parameters[9].Value = model.UserFace;
            parameters[10].Value = model.Company;
            parameters[11].Value = model.Tel;
            parameters[12].Value = model.WenXin;
            parameters[13].Value = model.Source;
            parameters[14].Value = model.id;

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
		public GL.Model.UserModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,GroupID,UserName,PassWord,Locked,Email,QQ,City,Address,Sex,UserFace,RegDate,LastLoginTime,LoginTimes,Company,Tel,LastLoginIP,WenXin,Source from GL_User ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            GL.Model.UserModel model = new GL.Model.UserModel();
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
        public GL.Model.UserModel DataRowToModel(DataRow row)
        {
            GL.Model.UserModel model = new GL.Model.UserModel();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                {
                    model.GroupID = int.Parse(row["GroupID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["PassWord"] != null)
                {
                    model.PassWord = row["PassWord"].ToString();
                }
                if (row["Locked"] != null && row["Locked"].ToString() != "")
                {
                    model.Locked = int.Parse(row["Locked"].ToString());
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["City"] != null)
                {
                    model.City = row["City"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(row["Sex"].ToString());
                }
                if (row["UserFace"] != null)
                {
                    model.UserFace = row["UserFace"].ToString();
                }
                if (row["RegDate"] != null && row["RegDate"].ToString() != "")
                {
                    model.RegDate = DateTime.Parse(row["RegDate"].ToString());
                }
                if (row["LastLoginTime"] != null && row["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(row["LastLoginTime"].ToString());
                }
                if (row["LoginTimes"] != null && row["LoginTimes"].ToString() != "")
                {
                    model.LoginTimes = int.Parse(row["LoginTimes"].ToString());
                }
                if (row["Company"] != null)
                {
                    model.Company = row["Company"].ToString();
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["LastLoginIP"] != null)
                {
                    model.LastLoginIP = row["LastLoginIP"].ToString();
                }
                if (row["WenXin"] != null)
                {
                    model.WenXin = row["WenXin"].ToString();
                }
                if (row["Source"] != null)
                {
                    model.Source = row["Source"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 更新一条数据(会员登录)
        /// </summary>
        public bool UpdateUser(GL.Model.UserModel model)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update GL_User set ");
            //strSql.Append("PassWord=@PassWord,");
            //strSql.Append("Email=@Email,");
            //strSql.Append("QQ=@QQ,");
            //strSql.Append("City=@City,");
            //strSql.Append("Address=@Address,");
            //strSql.Append("Sex=@Sex,");
            //strSql.Append("UserFace=@UserFace,");
            //strSql.Append("Company=@Company,");
            //strSql.Append("Tel=@Tel");
            //strSql.Append(" where id=@id");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Email", SqlDbType.NVarChar,50),
            //        new SqlParameter("@QQ", SqlDbType.NVarChar,50),
            //        new SqlParameter("@City", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Address", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Sex", SqlDbType.Int,4),
            //        new SqlParameter("@UserFace", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Company", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Tel", SqlDbType.NVarChar,50),
            //        new SqlParameter("@id", SqlDbType.Int,4)};
            //parameters[0].Value = model.PassWord;
            //parameters[1].Value = model.Email;
            //parameters[2].Value = model.QQ;
            //parameters[3].Value = model.City;
            //parameters[4].Value = model.Address;
            //parameters[5].Value = model.Sex;
            //parameters[6].Value = model.UserFace;
            //parameters[7].Value = model.Company;
            //parameters[8].Value = model.Tel;
            //parameters[9].Value = model.id;

            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }


        #endregion  Method
    }
}

