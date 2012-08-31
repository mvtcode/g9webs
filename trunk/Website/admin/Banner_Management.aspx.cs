using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using G9.Core;
using G9.Entity;
using G9.Impl;

namespace Website.admin
{
    public partial class Banner_Management : System.Web.UI.Page
    {
        private string sFolder = "/Images/Banner/";
        protected void Page_Load(object sender, EventArgs e)
        {
            var objAdmin = (AdminInfo)Session[Constant.SessionNameAccountAdmin];

            if (objAdmin == null)
            {
                Response.Redirect(Utility.UrlRoot + Config.LoginAdmin, true);
            }

            LB_Msg.Text = "";
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("size");
            dt.Columns.Add("length");
            dt.Columns.Add("date");

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Server.MapPath(sFolder));
            foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
            {
                string sf = f.FullName.ToUpper();
                if (sf.EndsWith(".JPG") || sf.EndsWith(".PNG") || sf.EndsWith(".GIF"))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromFile(f.FullName);
                    if (image != null)
                    {
                        DataRow dr = dt.Rows.Add();
                        dr["name"] = sFolder + f.Name;
                        dr["size"] = image.Width.ToString() + " x " + image.Height.ToString();
                        dr["length"] = UntilityFunction.ShowCappacityFile(f.Length); 
                        dr["date"] = f.LastWriteTime;
                    }
                    image.Dispose();
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            string sFile = UntilityFunction.StringForNull(e.CommandArgument.ToString());
            if (currentCommand == "BT_Delete")
            {
                sFile = Server.MapPath(sFile);
                System.IO.File.Delete(sFile);
                LB_Msg.Text = "xóa file thành công!";
                LoadData();
            }
            if (currentCommand == "BT_Set")
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(Server.MapPath("/CSS/banner.css"), false, Encoding.UTF8);
                writer.WriteLine(@".header{{background: url({0}) no-repeat center;}}", sFile);
                writer.Close();
                LB_Msg.Text = "Set ok!";
            }
        }

        protected void ASPxUploadControl1_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            string filePath = Server.MapPath(sFolder + e.UploadedFile.FileName);
            string sf = e.UploadedFile.FileName.ToUpper();
            if (sf.EndsWith(".JPG") || sf.EndsWith(".PNG") || sf.EndsWith(".GIF"))
            {
                e.UploadedFile.SaveAs(filePath);
                e.CallbackData = "/Download.aspx?file=" + e.UploadedFile.FileName;
                LoadData();
            }
        }

        protected void bt_NoImage_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(Server.MapPath("/CSS/banner.css"), false, Encoding.UTF8);
            writer.WriteLine(@".header{}");
            writer.Close();
            LB_Msg.Text = "Xóa backgroud thành công!";
        }
    }
}
