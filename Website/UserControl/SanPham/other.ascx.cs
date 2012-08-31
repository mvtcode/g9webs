using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;

namespace Website.UserControl.SanPham
{
    public partial class other : System.Web.UI.UserControl
    {
        public int iCurent = 0;
        protected string sContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var oItem = ServiceFactory.GetInstanceProduct().GetAll();
                if (oItem != null)
                {
                    sContent = Website.App_Code.Controls.SanPham.Sanpham.BuildOtherList(oItem,iCurent);
                }
            }
        }
    }
}