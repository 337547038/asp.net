using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Model
{
    public partial class UserGroupModel
    {
        public UserGroupModel()
        { }
        #region Model
        private int _id;
        private string _groupname;
        private string _powerlist;
        private string _descript;
        private int _showonreg;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 会员组名称
        /// </summary>
        public string GroupName
        {
            set { _groupname = value; }
            get { return _groupname; }
        }
        /// <summary>
        /// 权限
        /// </summary>
        public string PowerList
        {
            set { _powerlist = value; }
            get { return _powerlist; }
        }
        /// <summary>
        /// 组简介
        /// </summary>
        public string Descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
        /// <summary>
        /// 是否允许注册0为允许
        /// </summary>
        public int ShowOnReg
        {
            set { _showonreg = value; }
            get { return _showonreg; }
        }
        #endregion Model

    }
}


