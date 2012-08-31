using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website.admin
{
    public partial class UploadFile : System.Web.UI.Page
    {
        private string sFolder = "/App_Data/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
    }
    private void LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("length");
            dt.Columns.Add("date");

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Server.MapPath(sFolder));
            foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
            {

                DataRow dr = dt.Rows.Add();
                dr["name"] = f.Name;
                dr["length"] = f.Length + " Byte";
                dr["date"] = f.LastWriteTime;

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
}
