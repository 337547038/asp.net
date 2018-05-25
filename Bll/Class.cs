using System;
using System.Collections.Generic;
using System.Text;
using GL.Model;
using System.Data;
using GL.Utility;
using System.Web;
using System.Web.UI.WebControls;

namespace GL.Bll
{
    public class ClassBll : System.Web.UI.Page
    {
        private readonly GL.Dal.ClassDal dal = new GL.Dal.ClassDal();
        public ClassBll()
        { }
        #region  Method
       
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.ClassModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.ClassModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 批量更新seo
        /// </summary>
        public bool Updateseo(GL.Model.ClassModel model)
        {
            return dal.Updateseo(model);
        }
        #region 更新指定字段的多条记录

       
        #endregion
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.ClassModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListTree(int modelid, int ParentId, string strWhere)
        {
            return dal.GetListTree(modelid, ParentId, strWhere);
        }
        

        /// <summary>
        /// 绑定类别DropDownList控制
        /// </summary>
        /// <param name="parentId">父类ID</param>
        /// /// <param name="firstItemTxt">第一项显示的文字</param>
        /// <param name="modelid">模型ID</param>
        /// <param name="ddl">要绑定的DropDownList控件</param>
        protected void ClassTreeBind(int parentId, string firstItemTxt, int modelid, DropDownList ddl,string strwhere)
        {
            //DtCms.BLL.Channel cbll = new DtCms.BLL.Channel();
            //DataTable dt = cbll.GetList(parentId, kindId);
            ClassBll cbll = new ClassBll();
            DataTable dt = cbll.GetListTree(modelid, parentId, strwhere);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(firstItemTxt, ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["Id"].ToString();
                int ClassLayer = int.Parse(dr["ClassLayer"].ToString());
                string Title = dr["ClassName"].ToString().Trim();
                

                if (ClassLayer == 1)
                {

                    ddl.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "—" + Title;
                    Title = BasePage.StringOfChar(ClassLayer - 1, "—") + Title;
                    ddl.Items.Add(new ListItem(Title, Id));
                }
            }
        }

        /// <summary>
        /// 绑定类别select下拉
        /// </summary>
        /// <param name="parentId">父ID</param>
        /// <param name="firstItemTxt">下拉第一项选项显示的文字，可为空</param>
        /// <param name="modelid">模型ID</param>
        /// <param name="selectname">seclect下拉名用于发送值,表单</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="selectvalue">select默认值，用于修改时绑定初始值，可为空</param>
        /// /// <param name="selectvalue">select下拉样式，可为空</param>
        /// <returns></returns>
        public string GetClassSelect(int parentId, string firstItemTxt, int modelid, string selectname, string strwhere, string selectvalue,string cssstyle)
        {
            string selecthtml = "<select name=\"" + selectname + "\" id=\"" + selectname + "\" class=\"" + cssstyle + "\">\n";
            string select = "";
            if (!String.IsNullOrEmpty(firstItemTxt))
            {
                selecthtml += "<option value=\"\">" + firstItemTxt + "</option>\n";
            }
            ClassBll cbll = new ClassBll();
            DataTable dt = cbll.GetListTree(modelid, parentId, strwhere);
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["Id"].ToString();
                int ClassLayer = int.Parse(dr["ClassLayer"].ToString());
                string Title = dr["ClassName"].ToString().Trim();
                int InputA = int.Parse(dr["InputA"].ToString());
                if (InputA == 1)
                {
                    selecthtml += "<optgroup label=\"" + Title + "\"></optgroup>\n";
                }
                else
                {
                    if (selectvalue == Id)
                    {
                        select = "selected=\"selected\"";
                    }
                    else
                    {
                        select = "";
                    }
                    if (ClassLayer != 1)
                    {
                        Title = BasePage.StringOfChar(ClassLayer - 1, "——") + Title;
                    }
                    selecthtml += "<option value=\"" + Id + "\" " + select + ">" + Title + "</option>\n";
                }
            }
            selecthtml += "</select>";
            return selecthtml;
        }
        #endregion  Method
    }
}

