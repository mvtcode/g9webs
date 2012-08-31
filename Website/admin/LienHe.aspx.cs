using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;
using G9.Entity;
using G9.Web.Utility;

namespace Website.admin
{
    public partial class LienHe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var objAdmin = (AdminInfo)Session[Constant.SessionNameAccountAdmin];
            if (objAdmin == null)
            {
                Response.Redirect(Utility.UrlRoot + Config.LoginAdmin, true);
            }

            if(!IsPostBack)
            {
                System.IO.StreamReader read = new System.IO.StreamReader(Server.MapPath("/template/lienhe.txt"));
                Content.Text = read.ReadToEnd();
                read.Close(); 
            }
        }

        protected void BT_Save_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(Server.MapPath("/template/LienHe.txt"),false, Encoding.UTF8);
            writer.WriteLine(HtmlUtility.FillterHtmlTag(Content.Text, "script|embed|object|frameset|frame|iframe|meta|link|style"));
            writer.Close();
        }
    }
}
