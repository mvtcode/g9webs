using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website.UserControl
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected string sPath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            sPath = Page.AppRelativeVirtualPath.ToLower();
        }
    }
}