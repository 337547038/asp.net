using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;
using GL.Model;
using System.Web.Security;
namespace GL.Dal
{
    /// <summary>
    /// 数据访问类:AdminDal
    /// </summary>
    public partial class AdminDal
    {
        public AdminDal()
        { }
        #region  Method


        #region 用户名是否存在
        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public bool ExistName(string UserName)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select count(*) from GL_Admin ");
            strsql.Append(" where UserName=@UserName");
            SqlParameter[] parameters ={
                                          new SqlParameter("@UserName",SqlDbType.VarChar,50)
                                      };
            parameters[0].Value = UserName;
            return DbHelperSQL.Exists(strsql.ToString(), parameters);
        }
        #endregion

        #region 登录判断
        /// <summary>
        /// 登录判断
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPassWord">密码</param>
        /// <returns></returns>
        public bool ExistName(string UserName, string UserPassWord)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select count(*) from GL_Admin ");
            strsql.Append(" where UserName=@UserName ");
            strsql.Append(" and PassWord=@PassWord and locked=0");
            SqlParameter[] parameters ={
                                          new SqlParameter("@UserName",SqlDbType.VarChar,50),
                                          new SqlParameter("@PassWord",SqlDbType.VarChar,200)
                                      };
            parameters[0].Value = UserName;
            parameters[1].Value = UserPassWord;
            return DbHelperSQL.Exists(strsql.ToString(), parameters);
        }
        #endregion

        #region 验证是否登录及权限
        /// <summary>
        /// 验证是否登录及权限
        /// </summary>
        /// <param name="ModelPower">权限数组</param>
        /// <returns></returns>
        public string CheckLogin(string ModelPower)
        {
            string meg = "";
            if (!String.IsNullOrEmpty(Cookies.GetCookie("User_Name")))
            {
                string UserName = Cookies.GetCookie("User_Name").ToString();
                string CookieMD5UserName = Cookies.GetCookie("MD5Name").ToString();
                string UserId = Cookies.GetCookie("User_Id").ToString();
                string MD5UserName = FormsAuthentication.HashPasswordForStoringInConfigFile(UserId + UserName + "Cookies?", "MD5");
                if (CookieMD5UserName == MD5UserName)
                {
                    //判断权限
                    if (ModelPower == "no")//为no是表示该页登录即可
                    {
                        meg = "true";
                    }
                    else
                    {
                        if (BasePage.ArrayExist(Cookies.GetCookie("ModelPower"), ModelPower))
                        {
                            meg = "true";
                        }
                        else
                        {
                            meg = "您没有管理此内容的权限，请与管理员联系！";
                        }
                    }
                }
                else
                {
                    meg = "请不要非法操作！";
                }
            }
            else
            {
                meg = "您还没有登录或登录超时，请重新登录！"; 
            }
            return meg;
        }
        #endregion

        #region 更新登录信息
        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="LastLoginIP">最后登录IP</param>
        /// <param name="LoginTime">最后登录时间</param>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public bool UpdateLogin(string LastLoginIP, string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Admin set ");
            strSql.Append("LastLoginIP=@LastLoginIP,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("LoginTime=LoginTime+1");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,50),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@UserName",SqlDbType.NVarChar,50)};
            parameters[0].Value = LastLoginIP;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = UserName;

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

        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="PassWord"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool Updatepsd(string PassWord, string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Admin set ");
            strSql.Append("PassWord=@PassWord");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};
            parameters[0].Value = PassWord;
            parameters[1].Value = UserName;

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

        #region 增加一条记录
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.AdminModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_Admin(");
            strSql.Append("UserName,PassWord,Sex,Email,TelPhone,AddDate,LastLoginIP,LastLoginTime,Locked,ModelPower,LoginTime)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@PassWord,@Sex,@Email,@TelPhone,@AddDate,@LastLoginIP,@LastLoginTime,@Locked,@ModelPower,@LoginTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@TelPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,50),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@Locked", SqlDbType.Int,4),
					new SqlParameter("@ModelPower", SqlDbType.NVarChar,350),
					new SqlParameter("@LoginTime", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.TelPhone;
            parameters[5].Value = model.AddDate;
            parameters[6].Value = model.LastLoginIP;
            parameters[7].Value = model.LastLoginTime;
            parameters[8].Value = model.Locked;
            parameters[9].Value = model.ModelPower;
            parameters[10].Value = model.LoginTime;

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
        #endregion

        #region 更新一条记录
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.AdminModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Admin set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PassWord=@PassWord,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Email=@Email,");
            strSql.Append("TelPhone=@TelPhone,");
            //strSql.Append("AddDate=@AddDate,");
            //strSql.Append("LastLoginIP=@LastLoginIP,");
            //strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("Locked=@Locked,");
            strSql.Append("ModelPower=@ModelPower");
            //strSql.Append("LoginTime=@LoginTime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@TelPhone", SqlDbType.NVarChar,50),
					//new SqlParameter("@AddDate", SqlDbType.DateTime),
					//new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,50),
					//new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@Locked", SqlDbType.Int,4),
					new SqlParameter("@ModelPower", SqlDbType.NVarChar,350),
					//new SqlParameter("@LoginTime", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.TelPhone;
            //parameters[5].Value = model.AddDate;
            //parameters[6].Value = model.LastLoginIP;
            //parameters[7].Value = model.LastLoginTime;
            parameters[5].Value = model.Locked;
            parameters[6].Value = model.ModelPower;
           // parameters[7].Value = model.LoginTime;
            parameters[7].Value = model.id;

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


        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.AdminModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,UserName,PassWord,Sex,Email,TelPhone,AddDate,LastLoginIP,LastLoginTime,Locked,ModelPower,LoginTime from GL_Admin ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            GL.Model.AdminModel model = new GL.Model.AdminModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PassWord"] != null && ds.Tables[0].Rows[0]["PassWord"].ToString() != "")
                {
                    model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TelPhone"] != null && ds.Tables[0].Rows[0]["TelPhone"].ToString() != "")
                {
                    model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginIP"] != null && ds.Tables[0].Rows[0]["LastLoginIP"].ToString() != "")
                {
                    model.LastLoginIP = ds.Tables[0].Rows[0]["LastLoginIP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"] != null && ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Locked"] != null && ds.Tables[0].Rows[0]["Locked"].ToString() != "")
                {
                    model.Locked = int.Parse(ds.Tables[0].Rows[0]["Locked"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModelPower"] != null && ds.Tables[0].Rows[0]["ModelPower"].ToString() != "")
                {
                    model.ModelPower = ds.Tables[0].Rows[0]["ModelPower"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LoginTime"] != null && ds.Tables[0].Rows[0]["LoginTime"].ToString() != "")
                {
                    model.LoginTime = int.Parse(ds.Tables[0].Rows[0]["LoginTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,UserName,PassWord,Sex,Email,TelPhone,AddDate,LastLoginIP,LastLoginTime,Locked,ModelPower,LoginTime ");
            strSql.Append(" FROM GL_Admin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());

        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top">前几行</param>
        /// <param name="strWhere">获取条件</param>
        /// <param name="filedOrder">排列顺序</param>
        /// <returns></returns>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,UserName,PassWord,Sex,Email,TelPhone,AddDate,LastLoginIP,LastLoginTime,Locked,ModelPower,LoginTime ");
            strSql.Append(" FROM GL_Admin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 根据用户名取得实体ID，ModelPower，LoginTime，登录时用到
        /// <summary>
        /// 根据用户名取得实体ID，ModelPower，LoginTime，登录时用到
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public GL.Model.AdminModel Getid(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,UserName,ModelPower,LoginTime from GL_Admin ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)
};
            parameters[0].Value = UserName;

            GL.Model.AdminModel model = new GL.Model.AdminModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModelPower"] != null && ds.Tables[0].Rows[0]["ModelPower"].ToString() != "")
                {
                    model.ModelPower = ds.Tables[0].Rows[0]["ModelPower"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LoginTime"] != null && ds.Tables[0].Rows[0]["LoginTime"].ToString() != "")
                {
                    model.LoginTime = int.Parse(ds.Tables[0].Rows[0]["LoginTime"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #endregion  Method
    }
}

