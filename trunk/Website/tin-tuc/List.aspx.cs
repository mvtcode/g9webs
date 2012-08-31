using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using App_Code;

namespace hisoft
{
    public partial class List_News : System.Web.UI.Page
    {
        private int iType = 5;//tin tức
        protected void Page_Load(object sender, EventArgs e)
        {
            var oList = ServiceFactory.GetInstanceNews().SelectTopNews(iType, 5);
            if (oList != null)
            {
                if (oList.Count > 0)
                {
                    TinNoiBat1.oItem = oList[0];//tin 1 là tin nổi bật

                    oList.RemoveAt(0);
                    if (oList.Count > 0)
                    {
                        TinMoiNhat1.oList = oList;
                    }
                }


            }

            MetaTag("description", "tin tức G9");
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
