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
    public partial class List_SanPham : System.Web.UI.Page
    {
        protected string sContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var oList = ServiceFactory.GetInstanceProduct().GetAll();
                if (oList != null)
                {
                    sContent = Website.App_Code.Controls.SanPham.Sanpham.BuildContentListItem(oList);
                }
            }
            Title = "G9VietNam - Sản phẩm";
            MetaTag("description", "Phần mềm kế toán | Phần mềm kế toán Doanh nghiệp | Phần mềm kế toán Hành chính sự nghiệp | Phần mềm kế toán miễn phí | Phần mềm quản trị Nguồn nhân lực | Công ty cổ phần G9 Việt Nam");
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
