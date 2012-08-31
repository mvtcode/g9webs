using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G9.Core;

namespace G9.Entity
{
    public class AdminInfo
    {
        #region Members
        public int ID {get;set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public Int16 Status { get; set; }
        public Int16 IsLogin { get; set; }
        #endregion

        #region Constructor
        public AdminInfo()
        {
            this.ID = Utility.InitializeInteger;
            this.Username = Utility.InitializeString;
            this.Password = Utility.InitializeString;
            this.FullName = Utility.InitializeString;
            this.Status = 0;
            this.IsLogin = 0;
        }
        #endregion
    }

    public class MenuInfo
    {
        #region Members
        public int ID { get; set; }
        public int STT { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Link { get; set; }
        #endregion

        #region Constructor
        public MenuInfo()
        {
            this.ID = Utility.InitializeInteger;
            this.STT = Utility.InitializeInteger;
            this.ParentID = Utility.InitializeInteger;
            this.Name = Utility.InitializeString;
            this.Name2 = Utility.InitializeString;
            this.Name3 = Utility.InitializeString;
            this.Link = Utility.InitializeString;
        }
        #endregion

    }

    public class UserRightInfo
    {
        #region Members
        public int ID { get; set; }
        public int MenuID { get; set; }
        public int AdminID { get; set; }
        public bool UserRead { get; set; }
        public bool UserEdit { get; set; }
        public bool UserDelete { get; set; }
        #endregion

        #region Constructor
        public UserRightInfo()
        {
            this.ID = Utility.InitializeInteger;
            this.MenuID = Utility.InitializeInteger;
            this.AdminID = Utility.InitializeInteger;
            this.UserRead = Utility.InitializeBool;
            this.UserEdit = Utility.InitializeBool;
            this.UserDelete = Utility.InitializeBool;
        }
        #endregion

    }
}
