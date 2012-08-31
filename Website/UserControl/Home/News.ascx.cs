using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using G9.Entity;

namespace Website.UserControl.Home
{
    public partial class News : System.Web.UI.UserControl
    {
        public int iCategoryType;
        protected string sContent="";
        public string sType = "List.aspx";
        public string sDetail = "News.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List <NewsInfo> oList = ServiceFactory.GetInstanceNews().SelectTopNews(iCategoryType, 1);
                if(oList!=null)
                {
                    if(oList.Count>0)
                    {
                        sContent = App_Code.Controls.Home.News.BuildNews(oList[0], sType, sDetail);
                    }
                }
            }
        }
    }
}