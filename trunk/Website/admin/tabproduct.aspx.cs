using System;
using System.Web.UI.WebControls;
using App_Code;
using G9.Core;
using G9.Entity;
using G9.Impl;
using G9.Web.Utility;

namespace Website.admin
{
    public partial class tabproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var objAdmin = (AdminInfo)Session[Constant.SessionNameAccountAdmin];
            if (objAdmin == null)
            {
                Response.Redirect(Utility.UrlRoot + Config.LoginAdmin, true);
            }

            int iProduct = UntilityFunction.IntegerForNull(Request.QueryString["ID"]);
            if (!IsPostBack)
            {
                Load_DDLProduct();
                if (DDL_Products.Items.Count > 0)
                {
                    DDL_Products.SelectedValue = iProduct.ToString();
                    Load_Grid();
                }
                SetAttribute();
            }
        }

        private void SetAttribute()
        {
            DIV_1.Style["display"] = "none";
            BT_Save.Attributes.Add("onclick", "javascript:return check_Data();");
        }

        private void Load_DDLProduct()
        {
            DDL_Products.DataSource = ServiceFactory.GetInstanceProduct().GetAll();
            DDL_Products.DataTextField = "s_Name";
            DDL_Products.DataValueField = "pk_ID";
            DDL_Products.DataBind();
        }

        private void Load_Grid()
        {
            int ProductsId = UntilityFunction.IntegerForNull(DDL_Products.SelectedValue);
            GridView1.DataSource = ServiceFactory.GetInstanceProductDetail().GetAllByProduct(ProductsId);
            GridView1.DataBind();
        }

        protected void DDL_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            DIV_1.Style["display"] = "none";
            Load_Grid();
        }

        protected void BT_Save_Click(object sender, EventArgs e)
        {
            int id = UntilityFunction.IntegerForNull(HD_ID.Value);

            //int iUser = UntilityFunction.IntegerForNull(Session["userID"]);
            //var oAdmin = ((AdminInfo)Session[Constant.SessionNameAccountAdmin]);

            if (id > 0)
            {
                var oProductDetail = new ProductDetailInfo()
                {
                    id = id,
                    sFile = HD_File.Value,
                    sContent = HtmlUtility.FillterHtmlTag(Content.Text, "script|frameset|frame|iframe|meta|link|style").Replace("id=", "name=").Replace("ID=", "name=")
                };
                int i = ServiceFactory.GetInstanceProductDetail().Update(oProductDetail);
                LB_Messenger.Text = i > 0 ? "Cập nhật thành công" : "Có lỗi phát sinh";
            }
            DIV_1.Style["display"] = "none";
            Load_Grid();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int id = UntilityFunction.IntegerForNull(e.CommandArgument.ToString());

            if (currentCommand == "BT_Edit")
            {
                Detail(id);
            }
        }

        private void Detail(int id)
        {
            if (!UserRightImpl.CheckRightAdminnistrator().UserEdit)
            {
                return;
            }
            DIV_1.Style["display"] = "block";
            var o = ServiceFactory.GetInstanceProductDetail().GetProductDetailInfo(id);
            if (o != null)
            {
                HD_ID.Value = o.id.ToString();
                TB_Title.Text = o.sTitle;
                Content.Text = o.sContent;
                HD_File.Value = o.sFile;
                //LB_File.Text = o.sFile;
                if (TB_Title.Text.ToLower() != "download")
                {
                    TR_Upload_File.Visible = false;
                }
                else
                {
                    TR_Upload_File.Visible = true;
                }
            }
        }

        protected void ASPxUploadControl1_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            string filePath = Server.MapPath("~/App_Data/" + e.UploadedFile.FileName);
            e.UploadedFile.SaveAs(filePath);
            e.CallbackData = "/Download.aspx?file=" + e.UploadedFile.FileName;
            HD_File.Value = "/Download.aspx?file=" + e.UploadedFile.FileName;
            //e.UploadedFile.FileBytes.Length;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.Cells.Count>1)
            {
                e.Row.Cells[1].Text =LeftString(e.Row.Cells[1].Text,300);
            }
        }

        private string LeftString(string s,int iNum)
        {
            if (s.Length < iNum) return s;
            return s.Substring(0, iNum);
        }
    }
}
