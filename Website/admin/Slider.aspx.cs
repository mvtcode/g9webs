using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;
using G9.Entity;

namespace Website.admin
{
    public partial class Slider : System.Web.UI.Page
    {
        private string sFolder = "/Uploads/slider/";
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
                CreateFile();
                LoadData();
            }
        }

        protected void ASPxUploadControl1_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            string filePath = Server.MapPath(sFolder + e.UploadedFile.FileName);
            string sf = e.UploadedFile.FileName.ToUpper();
            if (sf.EndsWith(".JPG") || sf.EndsWith(".PNG") || sf.EndsWith(".GIF"))
            {
                e.UploadedFile.SaveAs(filePath);
                e.CallbackData = e.UploadedFile.FileName;
                CreateFile();
            }
        }

        private void CreateFile()
        {
            string sContent = "";
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Server.MapPath(sFolder));
            foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
            {
                string sf = f.FullName.ToUpper();
                if (sf.EndsWith(".JPG") || sf.EndsWith(".PNG") || sf.EndsWith(".GIF"))
                {
                    sContent += string.Format("<img src=\"{0}\" alt=\"\" />", sFolder + f.Name);
                }
            }
            System.IO.StreamWriter writer = new System.IO.StreamWriter(Server.MapPath("/Uploads/slider/list.txt"), false, UnicodeEncoding.UTF8);
            writer.Write(sContent);
            writer.Close();
        }
    }
}
