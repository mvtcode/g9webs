using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;
using G9.Impl;

namespace Website.admin
{
    public partial class MessengerRight : System.Web.UI.Page
    {
        public string UrlRoot = Utility.UrlRoot + "admin/";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginAdmin.IsLoginAdmin();
        }
    }
}
