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
    public partial class changepass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/default.aspx");
            }
        }

        protected void BT_Change_Click(object sender, EventArgs e)
        {
            UserInfo user = (UserInfo)Session["user"];
            if(user!=null)
            {
                if(!ServiceFactory.GetInstanceUser().CheckPass(user.id,OldPass.Text))
                {
                    LB_Msg.Text = "Mật khẩu cũ không chính xác";
                    return;
                }
                int i = ServiceFactory.GetInstanceUser().ChangePass(user.id, NewPass.Text);
                LB_Msg.Text = i > 0 ? "Cập nhật thành công" : "Có lỗi phát sinh";
            }
        }
    }
}
