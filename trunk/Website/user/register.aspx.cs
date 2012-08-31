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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("/default.aspx");
            }
        }

        protected void BT_Change_Click(object sender, EventArgs e)
        {
            if (TB_Username.Text.Length >= 4 && TB_Username.Text.Length <= 20 && TB_Password.Text.Length >= 6 && TB_Password.Text.Length <= 30)
            {
                if(ServiceFactory.GetInstanceUser().CheckExist(TB_Username.Text)>0)
                {
                    LB_Msg.Text = "Tài khoản đã tồn tại, bạn hãy chọn tài khoản khác";
                    return;
                }
                UserInfo newUser = new UserInfo
                {
                    sUsername = TB_Username.Text.Trim(),
                    sPassword = TB_Password.Text.Trim(),
                    sAddress = TB_Address.Text,
                    sCompany = TB_Company.Text,
                    sEmail = TB_Email.Text,
                    sFullName = TB_Fullname.Text,
                    sMobile = TB_Phone.Text,
                    sHomepage = TB_HomePage.Text
                };
                int i = ServiceFactory.GetInstanceUser().Insert(newUser);
                if (i > 0)
                {
                    LB_Msg.Text = "Tài khoản đã được tạo thành công";
                    newUser = ServiceFactory.GetInstanceUser().GetUser(newUser.sUsername);
                    Session["user"] = newUser;
                    //
                    Response.Redirect("/user/Complete.htm");
                }
                else
                {
                    Session.Clear();
                    LB_Msg.Text = "Xin lỗi máy chủ đang bận!";
                }
            }
            else
            {
                LB_Msg.Text = "thông tin đăng ký không phù hợp";
            }
        }
    }
}
