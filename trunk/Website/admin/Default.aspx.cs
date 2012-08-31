using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;

namespace Website.admin
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constant.SessionNameAccountAdmin] != null && Session[Constant.SessionNameAccountAdmin].ToString() != string.Empty)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("News_manager.aspx");
            }
        }
    }
}
