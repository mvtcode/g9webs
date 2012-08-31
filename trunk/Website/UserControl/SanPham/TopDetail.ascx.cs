using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using App_Code;
using G9.Web.Utility;

namespace Website.UserControl.SanPham
{
    public partial class Detail : System.Web.UI.UserControl
    {
        protected string sContent = "";
        public int iID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var oItem = ServiceFactory.GetInstanceProduct().GetProductInfo(iID);
                if (oItem != null)
                {
                    sContent = Website.App_Code.Controls.SanPham.Sanpham.BuildContentTopDetail(oItem);
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