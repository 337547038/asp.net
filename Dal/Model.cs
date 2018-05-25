using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;

namespace GL.Dal
{
    /// <summary>
    /// 数据访问类:ModelDal
    /// </summary>
    public partial class ModelDal
    {
        public ModelDal()
        { }
        #region  Method
        /// <summary>
        /// 是否存在同名记录
        /// </summary>
        /// <param name="ExistsName">检查存在的名字</param>
        /// <param name="Field">检查字段</param>
        /// <returns></returns>
        public bool ExistsName(string ExName, string Field)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from GL_Model");
            strSql.Append(" where " + Field + "=@ExName");
            SqlParameter[] parameters = new SqlParameter[]{
					//new SqlParameter("@Field", SqlDbType.NVarChar,50),
                    new SqlParameter("@ExName",ExName),
                    new SqlParameter("@Field",Field),
};


            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.ModelModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_Model(");
            strSql.Append("ModelName,ModelTable,ItemName,ItemUnit,ModeContent,ModelLock,ModelType,ModelClassLayer)");
            strSql.Append(" values (");
            strSql.Append("@ModelName,@ModelTable,@ItemName,@ItemUnit,@ModeContent,@ModelLock,@ModelType,@ModelClassLayer)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ModelName", SqlDbType.NVarChar,50),
					new SqlParameter("@ModelTable", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemUnit", SqlDbType.NVarChar,50),
					
					new SqlParameter("@ModeContent", SqlDbType.NText),
					new SqlParameter("@ModelLock", SqlDbType.Int,4),
					new SqlParameter("@ModelType", SqlDbType.Int,4),
					new SqlParameter("@ModelClassLayer", SqlDbType.Int,4)};
            parameters[0].Value = model.ModelName;
            parameters[1].Value = model.ModelTable;
            parameters[2].Value = model.ItemName;
            parameters[3].Value = model.ItemUnit;
           
            parameters[4].Value = model.ModeContent;
            parameters[5].Value = model.ModelLock;
            parameters[6].Value = model.ModelType;
            parameters[7].Value = model.ModelClassLayer;

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
        public bool Update(GL.Model.ModelModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Model set ");
            strSql.Append("ModelName=@ModelName,");
            strSql.Append("ItemName=@ItemName,");
            strSql.Append("ItemUnit=@ItemUnit,");
            strSql.Append("ModeContent=@ModeContent,");
            strSql.Append("ModelLock=@ModelLock,");
            strSql.Append("ModelClassLayer=@ModelClassLayer");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@ModelName", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@ModeContent", SqlDbType.NText),
					new SqlParameter("@ModelLock", SqlDbType.Int,4),
					new SqlParameter("@ModelClassLayer", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.ModelName;
            parameters[1].Value = model.ItemName;
            parameters[2].Value = model.ItemUnit;
           
            parameters[3].Value = model.ModeContent;
            parameters[4].Value = model.ModelLock;
            parameters[5].Value = model.ModelClassLayer;
            parameters[6].Value = model.id;

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
		public GL.Model.ModelModel GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,ModelName,ModelTable,ItemName,ItemUnit,ModeContent,ModelLock,ModelType,ModelClassLayer from GL_Model ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			GL.Model.ModelModel model=new GL.Model.ModelModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public GL.Model.ModelModel DataRowToModel(DataRow row)
		{
			GL.Model.ModelModel model=new GL.Model.ModelModel();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ModelName"]!=null)
				{
					model.ModelName=row["ModelName"].ToString();
				}
				if(row["ModelTable"]!=null)
				{
					model.ModelTable=row["ModelTable"].ToString();
				}
				if(row["ItemName"]!=null)
				{
					model.ItemName=row["ItemName"].ToString();
				}
				if(row["ItemUnit"]!=null)
				{
					model.ItemUnit=row["ItemUnit"].ToString();
				}
				
				
				if(row["ModeContent"]!=null)
				{
					model.ModeContent=row["ModeContent"].ToString();
				}
				if(row["ModelLock"]!=null && row["ModelLock"].ToString()!="")
				{
					model.ModelLock=int.Parse(row["ModelLock"].ToString());
				}
				if(row["ModelType"]!=null && row["ModelType"].ToString()!="")
				{
					model.ModelType=int.Parse(row["ModelType"].ToString());
				}
		
				if(row["ModelClassLayer"]!=null && row["ModelClassLayer"].ToString()!="")
				{
					model.ModelClassLayer=int.Parse(row["ModelClassLayer"].ToString());
				}
				
			}
			return model;
		}



        #endregion  Method
    }
}

