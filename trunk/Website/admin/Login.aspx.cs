using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;
using G9.Entity;
using G9.Impl;

namespace Website.admin
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constant.SessionNameAccountAdmin] != null && Session[Constant.SessionNameAccountAdmin].ToString() != string.Empty)
            {
                if (Request.QueryString["URL"] != null)
                    Response.Redirect("http://" + HttpUtility.UrlDecode(Request["URL"]), false);
                else
                    Response.Redirect("News_manager.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUsername.Text.Trim().ToLower();
                string pass = txtPassword.Text;
                AdminInfo item = LoginAdmin.fLoginAdmin(user, pass);
                if (item != null && item.IsLogin == 1)
                {
                    Utility.LogEvent(txtUsername.Text + " đăng nhập quản trị thành công.", System.Diagnostics.EventLogEntryType.Information);
                    Session[Constant.SessionNameAccountAdmin] = item;
                    //Response.Redirect("News_manager.aspx");

                    if (Request.QueryString["URL"] != null)
                        Response.Redirect("http://" + HttpUtility.UrlDecode(Request["URL"]), false);
                    else
                        //Response.Redirect(Utility.UrlRoot + Config.PathAdmin, false);
                        Response.Redirect("News_manager.aspx");
                }
                else
                {
                    Session[Constant.SessionNameAccountAdmin] = string.Empty;
                    lblMsg.Text = "Lỗi nhập tài khoản hoặc mật khẩu!";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Lỗi nhập tài khoản hoặc mật khẩu!";
            }
        }
    }
}
