using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;
using G9.Entity;

namespace Website.admin
{
    public partial class Thoat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.LogEvent(((AdminInfo)Session[Constant.SessionNameAccountAdmin]).Username + " đăng xuất quản trị thành công.", System.Diagnostics.EventLogEntryType.Information);
            Session[Constant.SessionNameAccountAdmin] = null;
            //Response.Redirect(Utility.UrlRoot + Config.LoginAdmin, true);
            Response.Redirect("Login.aspx");
        }
    }
}
