using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;

namespace Website
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("/default.aspx");
            }
        }

        protected void BT_Login_Click(object sender, EventArgs e)
        {
            var user = ServiceFactory.GetInstanceUser().CheckLogin(username.Text,password.Text);
            if(user==null)
            {
                LB_Msg.Text = "username hoặc mật khẩu không đúng";
            }
            else
            {
                Session["user"] = user;
                string sUrl = Request.QueryString["url"];
                if(sUrl!=null)
                {
                    Response.Redirect(sUrl);
                }
                else
                {
                    Response.Redirect("/default.aspx");
                }
            }
        }
    }
}
