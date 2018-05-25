using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GL.Utility;

namespace GL.Dal
{
    public partial class UserGroupDal
	{
        public UserGroupDal()
		{}
		#region  Method
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GL.Model.UserGroupModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GL_UserGroup(");
			strSql.Append("GroupName,PowerList,Descript,ShowOnReg)");
			strSql.Append(" values (");
			strSql.Append("@GroupName,@PowerList,@Descript,@ShowOnReg)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@PowerList", SqlDbType.NVarChar,50),
					new SqlParameter("@Descript", SqlDbType.NVarChar,250),
					new SqlParameter("@ShowOnReg", SqlDbType.Int,4)};
			parameters[0].Value = model.GroupName;
			parameters[1].Value = model.PowerList;
			parameters[2].Value = model.Descript;
			parameters[3].Value = model.ShowOnReg;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(GL.Model.UserGroupModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GL_UserGroup set ");
			strSql.Append("GroupName=@GroupName,");
			strSql.Append("PowerList=@PowerList,");
			strSql.Append("Descript=@Descript,");
			strSql.Append("ShowOnReg=@ShowOnReg");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@PowerList", SqlDbType.NVarChar,50),
					new SqlParameter("@Descript", SqlDbType.NVarChar,250),
					new SqlParameter("@ShowOnReg", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.GroupName;
			parameters[1].Value = model.PowerList;
			parameters[2].Value = model.Descript;
			parameters[3].Value = model.ShowOnReg;
			parameters[4].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public GL.Model.UserGroupModel GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,GroupName,PowerList,Descript,ShowOnReg from GL_UserGroup ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			GL.Model.UserGroupModel model=new GL.Model.UserGroupModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GroupName"]!=null && ds.Tables[0].Rows[0]["GroupName"].ToString()!="")
				{
					model.GroupName=ds.Tables[0].Rows[0]["GroupName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PowerList"]!=null && ds.Tables[0].Rows[0]["PowerList"].ToString()!="")
				{
					model.PowerList=ds.Tables[0].Rows[0]["PowerList"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Descript"]!=null && ds.Tables[0].Rows[0]["Descript"].ToString()!="")
				{
					model.Descript=ds.Tables[0].Rows[0]["Descript"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ShowOnReg"]!=null && ds.Tables[0].Rows[0]["ShowOnReg"].ToString()!="")
				{
					model.ShowOnReg=int.Parse(ds.Tables[0].Rows[0]["ShowOnReg"].ToString());
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

