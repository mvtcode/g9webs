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

namespace Website.cong_ty
{
    public partial class _default : System.Web.UI.Page
    {
        protected string sTitle = "";
        protected string sDescription = "";
        protected string sContent = "";
        protected string sOther = "";
        private int iType = 5;//cong ty
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["ID"]);
            NewsInfo oItem = ServiceFactory.GetInstanceNews().GetInfo(id);

            if (oItem != null)
            {
                sTitle = oItem.s_Title;
                sDescription = oItem.s_Description;
                sContent = oItem.s_Content;

                var oList = ServiceFactory.GetInstanceNews().SelectTopNews(iType, 10);
                if (oList != null)
                {
                    sOther = App_Code.Controls.News.News.BuildContentOtherItem(oList, id, "cong-ty/default.aspx");
                }
            }
            else
            {
                var oList = ServiceFactory.GetInstanceNews().SelectTopNews(iType, 10);
                if (oList != null)
                {
                    if (oList.Count > 0)
                    {
                        sTitle = oList[0].s_Title;
                        sDescription = oList[0].s_Description;
                        sContent = oList[0].s_Content;
                        MetaTag("description", oList[0].s_Description);
                        sOther = App_Code.Controls.News.News.BuildContentOtherItem(oList, oList[0].pk_Id, "cong-ty");
                    }
                }
            }
        }

        private void MetaTag(string sName, string sContent)
        {
            HtmlMeta PagemetaTag = new HtmlMeta();
            PagemetaTag.Name = sName;
            PagemetaTag.Content = sContent.Length > 300 ? sContent.Substring(0, 300) : sContent;
            Header.Controls.Add(PagemetaTag);
        }
    }
}
