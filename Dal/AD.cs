using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;
using GL.Model;
namespace GL.Dal
{
    public partial class ADDal
    {
        public ADDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.ADModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_AD(");
            strSql.Append("ADtitle,Tid,IsAD,ADtype,ADhttpurl,ADcontents,ADurl,Px,ADheight,ADwidth,ADShowHide)");
            strSql.Append(" values (");
            strSql.Append("@ADtitle,@Tid,@IsAD,@ADtype,@ADhttpurl,@ADcontents,@ADurl,@Px,@ADheight,@ADwidth,@ADShowHide)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ADtitle", SqlDbType.NVarChar,50),
					new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@IsAD", SqlDbType.Int,4),
					new SqlParameter("@ADtype", SqlDbType.Int,4),
					new SqlParameter("@ADhttpurl", SqlDbType.NVarChar,100),
					new SqlParameter("@ADcontents", SqlDbType.NText),
					new SqlParameter("@ADurl", SqlDbType.NVarChar,50),
					new SqlParameter("@Px", SqlDbType.Int,4),
					new SqlParameter("@ADheight", SqlDbType.Int,4),
					new SqlParameter("@ADwidth", SqlDbType.Int,4),
					new SqlParameter("@ADShowHide", SqlDbType.Int,4)};
            parameters[0].Value = model.ADtitle;
            parameters[1].Value = model.Tid;
            parameters[2].Value = model.IsAD;
            parameters[3].Value = model.ADtype;
            parameters[4].Value = model.ADhttpurl;
            parameters[5].Value = model.ADcontents;
            parameters[6].Value = model.ADurl;
            parameters[7].Value = model.Px;
            parameters[8].Value = model.ADheight;
            parameters[9].Value = model.ADwidth;
            parameters[10].Value = model.ADShowHide;

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
        public bool Update(GL.Model.ADModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_AD set ");
            strSql.Append("ADtitle=@ADtitle,");
            strSql.Append("Tid=@Tid,");
            strSql.Append("ADtype=@ADtype,");
            strSql.Append("ADhttpurl=@ADhttpurl,");
            strSql.Append("ADcontents=@ADcontents,");
            strSql.Append("ADurl=@ADurl,");
            strSql.Append("Px=@Px,");
            strSql.Append("ADheight=@ADheight,");
            strSql.Append("ADwidth=@ADwidth,");
            strSql.Append("ADShowHide=@ADShowHide");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@ADtitle", SqlDbType.NVarChar,50),
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@ADtype", SqlDbType.Int,4),
					new SqlParameter("@ADhttpurl", SqlDbType.NVarChar,100),
					new SqlParameter("@ADcontents", SqlDbType.NText),
					new SqlParameter("@ADurl", SqlDbType.NVarChar,50),
					new SqlParameter("@Px", SqlDbType.Int,4),
					new SqlParameter("@ADheight", SqlDbType.Int,4),
					new SqlParameter("@ADwidth", SqlDbType.Int,4),
					new SqlParameter("@ADShowHide", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.ADtitle;
            parameters[1].Value = model.Tid;
            parameters[2].Value = model.ADtype;
            parameters[3].Value = model.ADhttpurl;
            parameters[4].Value = model.ADcontents;
            parameters[5].Value = model.ADurl;
            parameters[6].Value = model.Px;
            parameters[7].Value = model.ADheight;
            parameters[8].Value = model.ADwidth;
            parameters[9].Value = model.ADShowHide;
            parameters[10].Value = model.id;

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
        public GL.Model.ADModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ADtitle,Tid,IsAD,ADtype,ADhttpurl,ADcontents,ADurl,Px,ADheight,ADwidth,ADShowHide from GL_AD ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            GL.Model.ADModel model = new GL.Model.ADModel();
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
        public GL.Model.ADModel DataRowToModel(DataRow row)
        {
            GL.Model.ADModel model = new GL.Model.ADModel();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ADtitle"] != null)
                {
                    model.ADtitle = row["ADtitle"].ToString();
                }
                if (row["Tid"] != null && row["Tid"].ToString() != "")
                {
                    model.Tid = int.Parse(row["Tid"].ToString());
                }
                if (row["IsAD"] != null && row["IsAD"].ToString() != "")
                {
                    model.IsAD = int.Parse(row["IsAD"].ToString());
                }
                if (row["ADtype"] != null && row["ADtype"].ToString() != "")
                {
                    model.ADtype = int.Parse(row["ADtype"].ToString());
                }
                if (row["ADhttpurl"] != null)
                {
                    model.ADhttpurl = row["ADhttpurl"].ToString();
                }
                if (row["ADcontents"] != null)
                {
                    model.ADcontents = row["ADcontents"].ToString();
                }
                if (row["ADurl"] != null)
                {
                    model.ADurl = row["ADurl"].ToString();
                }
                if (row["Px"] != null && row["Px"].ToString() != "")
                {
                    model.Px = int.Parse(row["Px"].ToString());
                }
                if (row["ADheight"] != null && row["ADheight"].ToString() != "")
                {
                    model.ADheight = int.Parse(row["ADheight"].ToString());
                }
                if (row["ADwidth"] != null && row["ADwidth"].ToString() != "")
                {
                    model.ADwidth = int.Parse(row["ADwidth"].ToString());
                }
                if (row["ADShowHide"] != null && row["ADShowHide"].ToString() != "")
                {
                    model.ADShowHide = int.Parse(row["ADShowHide"].ToString());
                }
               
            }
            return model;
        }

        #endregion  BasicMethod

    }
}


