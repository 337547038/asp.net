using System;
using System.Collections.Generic;
using System.Text;
using GL.Utility;
using System.Data;
using System.Data.SqlClient;

namespace GL.Dal
{
    public partial class ClassDal
    {
        public ClassDal()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.ClassModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GL_Class(");
            strSql.Append("ModelId,ClassName,ClassType,ParentId,ClassLayer,Px,SeoTitle,SeoKeyWord,SeoDescription,ClassIntro,Hide,ClassPic,AddDate,Languagen,Contents,InputA,InputUser,AllowComment)");
            strSql.Append(" values (");
            strSql.Append("@ModelId,@ClassName,@ClassType,@ParentId,@ClassLayer,@Px,@SeoTitle,@SeoKeyWord,@SeoDescription,@ClassIntro,@Hide,@ClassPic,@AddDate,@Languagen,@Contents,@InputA,@InputUser,@AllowComment)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ModelId", SqlDbType.Int,4),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassType", SqlDbType.Int,4),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@Px", SqlDbType.Int,4),
					new SqlParameter("@SeoTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@SeoKeyWord", SqlDbType.NVarChar,150),
					new SqlParameter("@SeoDescription", SqlDbType.NVarChar,250),
					new SqlParameter("@ClassIntro", SqlDbType.NVarChar,250),
					new SqlParameter("@Hide", SqlDbType.Int,4),
					new SqlParameter("@ClassPic", SqlDbType.NVarChar,50),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@Languagen", SqlDbType.Int,4),
					new SqlParameter("@Contents", SqlDbType.NText),
					new SqlParameter("@InputA", SqlDbType.Int,4),
					new SqlParameter("@InputUser", SqlDbType.Int,4),
                    new SqlParameter("@AllowComment", SqlDbType.Int,4)
                                       };
            parameters[0].Value = model.ModelId;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.ClassType;
            parameters[3].Value = model.ParentId;
            parameters[4].Value = model.ClassLayer;
            parameters[5].Value = model.Px;
            parameters[6].Value = model.SeoTitle;
            parameters[7].Value = model.SeoKeyWord;
            parameters[8].Value = model.SeoDescription;
            parameters[9].Value = model.ClassIntro;
            parameters[10].Value = model.Hide;
            parameters[11].Value = model.ClassPic;
            parameters[12].Value = model.AddDate;
            parameters[13].Value = model.Languagen;
            parameters[14].Value = model.Contents;
            parameters[15].Value = model.InputA;
            parameters[16].Value = model.InputUser;
            parameters[17].Value = model.AllowComment;
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
        public bool Update(GL.Model.ClassModel model)
        {
            BasePage.CheckSerialnumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Class set ");
            //strSql.Append("ModelId=@ModelId,");
            strSql.Append("ClassName=@ClassName,");
            strSql.Append("ClassType=@ClassType,");
            //strSql.Append("ParentId=@ParentId,");
            //strSql.Append("ClassLayer=@ClassLayer,");
            strSql.Append("Px=@Px,");
            strSql.Append("SeoTitle=@SeoTitle,");
            strSql.Append("SeoKeyWord=@SeoKeyWord,");
            strSql.Append("SeoDescription=@SeoDescription,");
            strSql.Append("ClassIntro=@ClassIntro,");
            strSql.Append("Hide=@Hide,");
            strSql.Append("ClassPic=@ClassPic,");
            strSql.Append("Languagen=@Languagen,");
            strSql.Append("Contents=@Contents,");
            strSql.Append("InputA=@InputA,");
            strSql.Append("InputUser=@InputUser,");
            strSql.Append("AllowComment=@AllowComment");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					//new SqlParameter("@ModelId", SqlDbType.Int,4),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassType", SqlDbType.Int,4),
					//new SqlParameter("@ParentId", SqlDbType.Int,4),
					//new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@Px", SqlDbType.Int,4),
					new SqlParameter("@SeoTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@SeoKeyWord", SqlDbType.NVarChar,150),
					new SqlParameter("@SeoDescription", SqlDbType.NVarChar,250),
					new SqlParameter("@ClassIntro", SqlDbType.NVarChar,250),
					new SqlParameter("@Hide", SqlDbType.Int,4),
					new SqlParameter("@ClassPic", SqlDbType.NVarChar,50),
					//new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@Languagen", SqlDbType.Int,4),
					new SqlParameter("@Contents", SqlDbType.NText),
					new SqlParameter("@InputA", SqlDbType.Int,4),
					new SqlParameter("@InputUser", SqlDbType.Int,4),
                    new SqlParameter("@AllowComment", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            //parameters[0].Value = model.ModelId;
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.ClassType;
            //parameters[3].Value = model.ParentId;
            //parameters[4].Value = model.ClassLayer;
            parameters[2].Value = model.Px;
            parameters[3].Value = model.SeoTitle;
            parameters[4].Value = model.SeoKeyWord;
            parameters[5].Value = model.SeoDescription;
            parameters[6].Value = model.ClassIntro;
            parameters[7].Value = model.Hide;
            parameters[8].Value = model.ClassPic;      
            parameters[9].Value = model.Languagen;
            parameters[10].Value = model.Contents;
            parameters[11].Value = model.InputA;
            parameters[12].Value = model.InputUser;
            parameters[13].Value = model.AllowComment;
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
        /// 批量更新seo
        /// </summary>
        public bool Updateseo(GL.Model.ClassModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GL_Class set ");
            strSql.Append("SeoKeyWord=@SeoKeyWord,");
            strSql.Append("SeoDescription=@SeoDescription,");
            strSql.Append("SeoTitle=@SeoTitle");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@SeoKeyWord", SqlDbType.NVarChar,150),
					new SqlParameter("@SeoDescription", SqlDbType.NVarChar,250),
                    new SqlParameter("@SeoTitle", SqlDbType.NVarChar,80),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.SeoKeyWord;
            parameters[1].Value = model.SeoDescription;
            parameters[2].Value = model.SeoTitle;
            parameters[3].Value = model.id;

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
        public GL.Model.ClassModel GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ModelId,ClassName,ClassType,ParentId,ClassLayer,Px,SeoTitle,SeoKeyWord,SeoDescription,ClassIntro,Hide,ClassPic,AddDate,Languagen,Contents,InputA,InputUser,AllowComment from GL_Class ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            GL.Model.ClassModel model = new GL.Model.ClassModel();
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
        public GL.Model.ClassModel DataRowToModel(DataRow row)
        {
            GL.Model.ClassModel model = new GL.Model.ClassModel();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ModelId"] != null && row["ModelId"].ToString() != "")
                {
                    model.ModelId = int.Parse(row["ModelId"].ToString());
                }
                if (row["ClassName"] != null)
                {
                    model.ClassName = row["ClassName"].ToString();
                }
                if (row["ClassType"] != null && row["ClassType"].ToString() != "")
                {
                    model.ClassType = int.Parse(row["ClassType"].ToString());
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["ClassLayer"] != null && row["ClassLayer"].ToString() != "")
                {
                    model.ClassLayer = int.Parse(row["ClassLayer"].ToString());
                }
                if (row["Px"] != null && row["Px"].ToString() != "")
                {
                    model.Px = int.Parse(row["Px"].ToString());
                }
                if (row["SeoTitle"] != null)
                {
                    model.SeoTitle = row["SeoTitle"].ToString();
                }
                if (row["SeoKeyWord"] != null)
                {
                    model.SeoKeyWord = row["SeoKeyWord"].ToString();
                }
                if (row["SeoDescription"] != null)
                {
                    model.SeoDescription = row["SeoDescription"].ToString();
                }
                if (row["ClassIntro"] != null)
                {
                    model.ClassIntro = row["ClassIntro"].ToString();
                }
                if (row["Hide"] != null && row["Hide"].ToString() != "")
                {
                    model.Hide = int.Parse(row["Hide"].ToString());
                }
                if (row["ClassPic"] != null)
                {
                    model.ClassPic = row["ClassPic"].ToString();
                }
                
                if (row["AddDate"] != null && row["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(row["AddDate"].ToString());
                }
                if (row["Languagen"] != null && row["Languagen"].ToString() != "")
                {
                    model.Languagen = int.Parse(row["Languagen"].ToString());
                }
                if (row["Contents"] != null)
                {
                    model.Contents = row["Contents"].ToString();
                }
                if (row["InputA"] != null && row["InputA"].ToString() != "")
                {
                    model.InputA = int.Parse(row["InputA"].ToString());
                }
                if (row["InputUser"] != null && row["InputUser"].ToString() != "")
                {
                    model.InputUser = int.Parse(row["InputUser"].ToString());
                }
                if (row["AllowComment"] != null && row["AllowComment"].ToString() != "")
                {
                    model.AllowComment = int.Parse(row["AllowComment"].ToString());
                }

            }
            return model;
        }

        /// <summary>
        /// 获得数据列表(仅显示系统栏目)
        /// </summary>
        public DataTable GetListTree(int modelid, int ParentId, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM GL_Class where ModelId=" + modelid + "");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by Languagen asc, Px desc,id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //复制结构
            DataTable newData = oldData.Clone();
            //调用迭代组合成DAGATABLE
            GetChannelChild(oldData, newData, ParentId, modelid);//顶级栏目从0开始
            return newData;
        }

        /// <summary>
        /// 从内存中取得所有下级栏目列表（自身迭代）
        /// </summary>
        private void GetChannelChild(DataTable oldData, DataTable newData, int ParentId, int modelid)
        {
            DataRow[] dr = oldData.Select("ParentId=" + ParentId);//
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["Id"] = int.Parse(dr[i]["Id"].ToString());
                row["ClassName"] = dr[i]["ClassName"].ToString();
                row["ParentId"] = int.Parse(dr[i]["ParentId"].ToString());
                row["ClassType"] = dr[i]["ClassType"].ToString();
                row["ClassLayer"] = int.Parse(dr[i]["ClassLayer"].ToString());
                row["Px"] = int.Parse(dr[i]["Px"].ToString());
                row["Languagen"] = dr[i]["Languagen"].ToString();
                row["Modelid"] = int.Parse(dr[i]["Modelid"].ToString());
                row["InputA"] = int.Parse(dr[i]["InputA"].ToString());
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChannelChild(oldData, newData, int.Parse(dr[i]["Id"].ToString()), modelid);
            }
        }
    }
}