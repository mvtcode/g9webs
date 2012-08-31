using System;
using App_Code;

namespace Website.UserControl.Home
{
    public partial class SanPham : System.Web.UI.UserControl
    {
        protected string sContent = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
               var oList = ServiceFactory.GetInstanceProduct().SelectNewProducts(4);
               if(oList!=null)
               {
                   sContent=App_Code.Controls.SanPham.Sanpham.BuildContentListHomeItem(oList);
               }
           }
        }
    }
}