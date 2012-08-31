using System;
using G9.Entity;

namespace WebsiteV2.UserControl.TinTuc
{
    public partial class TinNoiBat : System.Web.UI.UserControl
    {
        public NewsInfo oItem = null;
        protected string sContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(oItem!=null)
            {
                sContent = Website.App_Code.Controls.News.News.Build_TinNoibat(oItem);
            }
        }
    }
}