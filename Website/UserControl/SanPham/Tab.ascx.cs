using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;

namespace Website.UserControl.SanPham
{
    public partial class Tab : System.Web.UI.UserControl
    {
        public int iProduct = 0;
        protected string sContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var oList = ServiceFactory.GetInstanceProductDetail().GetAllByProduct(iProduct);
                if (oList != null)
                {
                    sContent = Website.App_Code.Controls.SanPham.Sanpham.BuildTab(oList);
                }
            }
        }
    }
}