using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Entity;

namespace Website.UserControl
{
    public partial class user : System.Web.UI.UserControl
    {
        protected string sContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo user = (UserInfo)Session["user"];
            if (user != null)
            {
                sContent = string.Format("<a href=\"/user/profile.aspx\">{0}</a>", user.sFullName);
                sContent += string.Format(" | <a href=\"/user/logout.aspx\">thoát</a>");
            }
            else
            {
                sContent = "<a href=\"/user/login.aspx\">Đăng nhập</a> | <a href=\"/user/register.aspx\">Đăng ký</a>";
            }
        }
    }
}