using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;

namespace Website
{
    public partial class Download : System.Web.UI.Page
    {
        protected string sContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/user/login.aspx?url=" + Server.HtmlEncode(Request.RawUrl), true);
            }

            string sFolder = "/App_Data/";
            string fName = UntilityFunction.StringForNull(Request.QueryString["file"]);
            if(fName=="") return;
            string sFullPath = Server.MapPath(sFolder + fName);
            if(!File.Exists(sFullPath))
            {
                sContent = "không tìn thấy file bạn yêu cầu";
                return;
            }

            FileInfo fi = new FileInfo(sFullPath);
            long sz = fi.Length;
            Response.ClearContent();
            Response.ContentType = MimeType(Path.GetExtension(sFullPath));
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", fName));
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.TransmitFile(sFullPath);
            Response.End();
        }

        public static string MimeType(string Extension)
        {
            string mime = "application/octetstream";
            if (string.IsNullOrEmpty(Extension))
                return mime;
            string ext = Extension.ToLower();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (rk != null && rk.GetValue("Content Type") != null)
                mime = rk.GetValue("Content Type").ToString();
            return mime;
        } 
    }
}
