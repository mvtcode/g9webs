using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using G9.Entity;

namespace Website.user
{
    public partial class profile : System.Web.UI.Page
    {
        private UserInfo user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (UserInfo)Session["user"];
            if(!IsPostBack)
            {
                if(user!=null)
                {
                    TB_Username.Text = user.sUsername;
                    TB_Address.Text = user.sAddress;
                    TB_HomePage.Text = user.sHomepage;
                    TB_Fullname.Text = user.sFullName;
                    TB_Email.Text = user.sEmail;
                    TB_Company.Text = user.sCompany;
                    TB_Phone.Text = user.sMobile;
                }
            }
        }

        protected void BT_Change_Click(object sender, EventArgs e)
        {
            user.sUsername = TB_Username.Text.Trim();
            user.sAddress = TB_Address.Text;
            user.sCompany = TB_Company.Text;
            user.sEmail = TB_Email.Text;
            user.sFullName = TB_Fullname.Text;
            user.sMobile = TB_Phone.Text;
            user.sHomepage = TB_HomePage.Text;
            int i = ServiceFactory.GetInstanceUser().Update(user);
            LB_Msg.Text = i > 0 ? "Cập nhật thành công" : "Có lỗi phát sinh";
            if (i > 0) Session["user"] = user;
        }
    }
}
