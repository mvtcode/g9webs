using System;
using System.Collections.Generic;
using App_Code;
using G9.Entity;

namespace Website.UserControl.Home
{
    public partial class Visited : System.Web.UI.UserControl
    {
        protected int iMember = 0;
        protected string sNewMember = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                iMember = ServiceFactory.GetInstanceUser().CountUser();
                List<UserInfo> oList = ServiceFactory.GetInstanceUser().GetNew(1);
                if(oList!=null)
                {
                    if(oList.Count>0)
                    {
                        sNewMember = oList[0].sUsername;
                    }
                }
            }
        }
    }
}