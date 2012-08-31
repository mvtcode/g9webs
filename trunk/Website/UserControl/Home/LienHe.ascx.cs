using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website.UserControl.Home
{
    public partial class LienHe : System.Web.UI.UserControl
    {
        protected string sContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader read = new System.IO.StreamReader(Server.MapPath("/template/lienhe.txt"));
            sContent = read.ReadToEnd();
            read.Close(); 
        }
    }
}