using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Entity;

namespace WebsiteV2.UserControl.TinTuc
{
    public partial class TinMoiNhat : System.Web.UI.UserControl
    {
        public List<NewsInfo> oList = null;
        protected string sContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(oList!=null)
            {
                sContent = Website.App_Code.Controls.News.News.Build_TinMoi(oList);
            }
        }
    }
}