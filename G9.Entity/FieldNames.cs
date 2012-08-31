using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G9.Entity
{
    public class FieldNames
    {
        /// <summary>
        /// Field names of table Admin.
        /// </summary>
        public class Admin
        {
            public const string ID = "ID";
            public const string Username = "Username";
            public const string Password = "Password";
            public const string FullName = "FullName";
            public const string Status = "Status";
            public const string IsLogin = "IsLogin";
        }
        
        /// <summary>
        /// Field names of table Menu.
        /// </summary>
        public class Menu
        {
            public const string ID = "ID";
            public const string STT = "STT";
            public const string ParentID = "ParentID";
            public const string Name = "Name";
            public const string Name2 = "Name2";
            public const string Name3 = "Name3";
            public const string Link = "Link";
        }
       
        /// <summary>
        /// Field names of table UserRight.
        /// </summary>
        public class UserRight
        {
            public const string ID = "ID";
            public const string MenuID = "MenuID";
            public const string AdminID = "AdminID";
            public const string UserRead = "UserRead";
            public const string UserEdit = "UserEdit";
            public const string UserDelete = "UserDelete";
        }
        
    }
}
