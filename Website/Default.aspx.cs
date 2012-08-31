using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace hisoft
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                News1.iCategoryType = 1;//hoạt động kinh doanh
                News2.iCategoryType = 2;//văn bản pháp luật
                News3.iCategoryType = 3;//tin nội bộ
                News4.iCategoryType = 4;//van ban phap luat
                //News4.sType = "tuyen-dung";
                //News4.sDetail = "tuyen-dung";
                MetaTag("description",
                        "Phần mềm Quản lý bán hàng - Phần mềm quản lý thuốc - Phần mềm kế toán - www.g9vietnam.com.vn");
            }
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
