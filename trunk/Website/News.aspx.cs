using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using App_Code;
using G9.Entity;
using G9.Web.Utility;

namespace Website
{
    public partial class News : System.Web.UI.Page
    {
        protected string sContent = "";
        protected string sDescription = "";
        protected string sOther = "";
        protected string sTitle = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["ID"]);
            NewsInfo oItem = ServiceFactory.GetInstanceNews().GetInfo(id);
            if (oItem != null)
            {
                sTitle = oItem.s_Title;
                sDescription = oItem.s_Description;
                sContent = oItem.s_Content;

                MetaTag("description", oItem.s_Description);
                List<NewsInfo> oList = ServiceFactory.GetInstanceNews().SelectTopNews(oItem.fk_CategoryId, 10);
                if (oList != null)
                {
                    sOther = App_Code.Controls.News.News.BuildContentOtherItem(oList, id, "news.aspx");
                }
            }
            Title = sTitle + " - G9VietNam";
        }

        private void MetaTag(string sName, string sContent)
        {
            var PagemetaTag = new HtmlMeta();
            PagemetaTag.Name = sName;
            PagemetaTag.Content = sContent.Length > 300 ? sContent.Substring(0, 300) : sContent;
            Header.Controls.Add(PagemetaTag);
        }
    }
}
