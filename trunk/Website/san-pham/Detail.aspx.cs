using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using App_Code;
using G9.Web.Utility;

namespace hisoft
{
    public partial class Detail_Sanpham : System.Web.UI.Page
    {
        protected string sContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string sTitle = "";
            int id = ConvertUtility.ToInt32(Request.QueryString["ID"]);
            if (!IsPostBack)
            {
                var oItem = ServiceFactory.GetInstanceProduct().GetProductInfo(id);
                if (oItem != null)
                {
                    sContent = Website.App_Code.Controls.SanPham.Sanpham.BuildContentTopDetail(oItem);
                    sTitle = oItem.s_Name;
                    MetaTag("description", oItem.s_Description);
                }
                Tab1.iProduct = id;
                other1.iCurent = id;
            }

            Page.Title = sTitle + " - G9VietNam";
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
