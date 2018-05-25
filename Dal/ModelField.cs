using System;
using System.Collections.Generic;
using System.Text;
using GL.Utility;
using System.Data;
using System.Data.SqlClient;

namespace GL.Dal
{
    public partial class ModelFieldDal
    {
        public ModelFieldDal()
        { }
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.ModelFieldModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_ModelField(");
            strSql.Append("Modeid,FieldName,FieldName2,FieldType,FieldIntro,FieldIsNull,FieldPx,FieldOnOff,FieldVaules)");
            strSql.Append(" values (");
            strSql.Append("@Modeid,@FieldName,@FieldName2,@FieldType,@FieldIntro,@FieldIsNull,@FieldPx,@FieldOnOff,@FieldVaules)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Modeid", SqlDbType.Int,4),
					new SqlParameter("@FieldName", SqlDbType.NVarChar,50),
					new SqlParameter("@FieldType", SqlDbType.Int,4),
					new SqlParameter("@FieldIntro", SqlDbType.NVarChar,200),
					new SqlParameter("@FieldIsNull", SqlDbType.Int,4),
					new SqlParameter("@FieldPx", SqlDbType.Int,4),
					new SqlParameter("@FieldOnOff", SqlDbType.Int,4),
                    new SqlParameter("@FieldName2", SqlDbType.NVarChar,50),
                    new SqlParameter("@FieldVaules",SqlDbType.NVarChar,150)};
            parameters[0].Value = model.Modeid;
            parameters[1].Value = model.FieldName;
            parameters[2].Value = model.FieldType;
            parameters[3].Value = model.FieldIntro;
            parameters[4].Value = model.FieldIsNull;
            parameters[5].Value = model.FieldPx;
            parameters[6].Value = model.FieldOnOff;
            parameters[7].Value = model.FieldName2;
            parameters[8].Value = model.FieldVaules;

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
        public bool Update(GL.Model.ModelFieldModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_ModelField set ");
            strSql.Append("Modeid=@Modeid,");
            // strSql.Append("FieldName=@FieldName,");
            strSql.Append("FieldName2=@FieldName2,");
            //  strSql.Append("FieldType=@FieldType,");
            strSql.Append("FieldIntro=@FieldIntro,");
            strSql.Append("FieldIsNull=@FieldIsNull,");
            strSql.Append("FieldPx=@FieldPx,");
            strSql.Append("FieldOnOff=@FieldOnOff,");
            strSql.Append("FieldVaules=@FieldVaules");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@Modeid", SqlDbType.Int,4),
					//new SqlParameter("@FieldName", SqlDbType.NVarChar,50),
                    new SqlParameter("@FieldName2", SqlDbType.NVarChar,50),
				//	new SqlParameter("@FieldType", SqlDbType.Int,4),
					new SqlParameter("@FieldIntro", SqlDbType.NVarChar,200),
					new SqlParameter("@FieldIsNull", SqlDbType.Int,4),
					new SqlParameter("@FieldPx", SqlDbType.Int,4),
					new SqlParameter("@FieldOnOff", SqlDbType.Int,4),
                    new SqlParameter("FieldVaules",SqlDbType.NVarChar,150),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Modeid;
            // parameters[1].Value = model.FieldName;
            parameters[1].Value = model.FieldName2;
            // parameters[2].Value = model.FieldType;
            parameters[2].Value = model.FieldIntro;
            parameters[3].Value = model.FieldIsNull;
            parameters[4].Value = model.FieldPx;
            parameters[5].Value = model.FieldOnOff;
            parameters[6].Value = model.FieldVaules;
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.ModelFieldModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Modeid,FieldName,FieldName2,FieldType,FieldIntro,FieldIsNull,FieldPx,FieldOnOff,FieldVaules from GL_ModelField ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            GL.Model.ModelFieldModel model = new GL.Model.ModelFieldModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Modeid"] != null && ds.Tables[0].Rows[0]["Modeid"].ToString() != "")
                {
                    model.Modeid = int.Parse(ds.Tables[0].Rows[0]["Modeid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FieldName"] != null && ds.Tables[0].Rows[0]["FieldName"].ToString() != "")
                {
                    model.FieldName = ds.Tables[0].Rows[0]["FieldName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FieldName2"] != null && ds.Tables[0].Rows[0]["FieldName2"].ToString() != "")
                {
                    model.FieldName2 = ds.Tables[0].Rows[0]["FieldName2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FieldType"] != null && ds.Tables[0].Rows[0]["FieldType"].ToString() != "")
                {
                    model.FieldType = int.Parse(ds.Tables[0].Rows[0]["FieldType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FieldIntro"] != null && ds.Tables[0].Rows[0]["FieldIntro"].ToString() != "")
                {
                    model.FieldIntro = ds.Tables[0].Rows[0]["FieldIntro"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FieldIsNull"] != null && ds.Tables[0].Rows[0]["FieldIsNull"].ToString() != "")
                {
                    model.FieldIsNull = int.Parse(ds.Tables[0].Rows[0]["FieldIsNull"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FieldPx"] != null && ds.Tables[0].Rows[0]["FieldPx"].ToString() != "")
                {
                    model.FieldPx = int.Parse(ds.Tables[0].Rows[0]["FieldPx"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FieldOnOff"] != null && ds.Tables[0].Rows[0]["FieldOnOff"].ToString() != "")
                {
                    model.FieldOnOff = int.Parse(ds.Tables[0].Rows[0]["FieldOnOff"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FieldVaules"] != null && ds.Tables[0].Rows[0]["FieldVaules"].ToString() != "")
                {
                    model.FieldVaules = ds.Tables[0].Rows[0]["FieldVaules"].ToString();
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

