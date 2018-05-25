using System;
using System.Collections.Generic;
using System.Text;
using GL.Utility;
using GL.Model;
using GL.Dal;
using System.Data;
namespace GL.Bll
{
    /// <summary>
    /// AdminBll
    /// </summary>
    public partial class AdminBll
    {
        private readonly GL.Dal.AdminDal dal = new GL.Dal.AdminDal();
        public AdminBll()
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
            return dal.ExistName(UserName);
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
            return dal.ExistName(UserName, UserPassWord);
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
            return dal.CheckLogin(ModelPower);
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
            return dal.UpdateLogin(LastLoginIP, UserName);
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
            return dal.Updatepsd(PassWord, UserName);
        }

        #endregion

        #region 增加一条记录
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GL.Model.AdminModel model)
        {
           return dal.Add(model);
        }
        #endregion

        #region 更新一条记录
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GL.Model.AdminModel model)
        {
            return dal.Update(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GL.Model.AdminModel GetModel(int id)
        {

            return dal.GetModel(id);
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
            return dal.Getid(UserName);
        }
        #endregion

        #endregion  Method
    }
}