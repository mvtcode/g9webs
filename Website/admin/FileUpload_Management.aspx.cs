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
    public partial class FileUpload_Management : System.Web.UI.Page
    {
        private string sFolder = "/App_Data/";
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
            dt.Columns.Add("length");
            dt.Columns.Add("date");

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Server.MapPath(sFolder));
            foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
            {

                DataRow dr = dt.Rows.Add();
                dr["name"] = f.Name;
                dr["length"] = UntilityFunction.ShowCappacityFile(f.Length);
                dr["date"] = f.LastWriteTime;

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
                sFile = Server.MapPath(sFolder + sFile);
                System.IO.File.Delete(sFile);
                LB_Msg.Text = "xóa file thành công!";
                LoadData();
            }
        }

        protected void ASPxUploadControl1_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            string filePath = Server.MapPath(sFolder + e.UploadedFile.FileName);
            e.UploadedFile.SaveAs(filePath);
            e.CallbackData = "/Download.aspx?file=" + e.UploadedFile.FileName;
            LoadData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                if(e.Row.RowIndex>=0)
                e.Row.Cells[1].Text ="/download.aspx?file=" + e.Row.Cells[1].Text;
            }
        }
    }
}
