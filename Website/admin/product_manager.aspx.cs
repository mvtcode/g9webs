using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using App_Code;
using G9.Core;
using G9.Entity;
using App_Code.Caching;
using G9.Impl;
using G9.Web.Utility;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;
using RelaxFunx.Core.Utility;

namespace Website.admin
{
    public partial class product_manager : System.Web.UI.Page
    {
        //private string _FolderUpload;
        private string _PathImageShow;

        public static string sHTMLType = "";
        public static string sProducHTML = "";
        public static string sPageType = "";
        public static string sPage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //_FolderUpload = Config.PathProduct;
            _PathImageShow = Config.PathProductShow;
            if (!IsPostBack)
            {
                sPageType = "";
                sPage = "";
                SetAttribute();
                Load_Grid();
            }
            LB_Messenger.Text = "";
        }

        private void SetAttribute()
        {
            DIV_2.Style["display"] = "none";
            BT_Save.Attributes.Add("onclick", "javascript:return CheckData();");
            //TB_Price.Attributes.Add("onkeypress", "javascript:return EnsureIntegerKeyEntry(this.value,event);");
            //TB_Price.Attributes.Add("onkeyup", "javascript:FormatNum(this, 0);");
            //TB_SortField.Attributes.Add("onkeypress", "javascript:return EnsureIntegerKeyEntry(this.value,event);");
            BT_IMG.Attributes.Add("onclick", "javascript:return ShowPupup();");
            IMG.Attributes.Add("onclick", "javascript:return ShowPupup();");

            if (!UserRightImpl.CheckRightAdminnistrator().UserEdit)
            {
                BT_Add.Visible = false;
            }
        }

        #region Grid Detail

        //load grid
        private void Load_Grid()
        {
            int iPageIndex = UntilityFunction.IntegerForNull(HD_Page.Value);
            int iPageSize = UntilityFunction.IntegerForNull(Config.PageSizeAdmin);//get page size
            int iTotalRow;
            var oList = ServiceFactory.GetInstanceProduct().SelectListProducts( iPageIndex, iPageSize, out iTotalRow);
            sProducHTML = BuildContentListProduct(oList, UserRightImpl.CheckRightAdminnistrator().UserEdit);
            //Page
            sPage = HtmlUtility.BuildPagerScript(iTotalRow, iPageSize, iPageIndex, "Page", "chon", 5, "product");
        }

        //add
        protected void BT_Add_Click(object sender, EventArgs e)
        {
            DIV_2.Style["display"] = "block";
            LB_Title.Text = "Thêm sản phẩm mới";
            HD_ID.Value = "0";
            TB_Price.Text = "";
            TB_Name.Text = "";
            TB_Description.Text = "";
            HD_IMG.Value = "";
            IMG.ImageUrl = "~/Images/NoImage.jpg";
            TB_SortField.Text = "";
            CB_Active.Checked = true;
            Content.Text = "";
            //SetFocus()
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "SetFocus(2)", true);
        }

        //save
        //protected void BT_Save_Click(object sender, EventArgs e)
        //{
        //    int id = UntilityFunction.IntegerForNull(HD_ID.Value);
        //    int iType = Convert.ToInt32(HD_IDType.Value);
        //    string sType = ServiceFactory.GetInstanceIproductType().GetInfo(iType).s_ProductName;
        //    string sPathImage;
        //    string sImage;
        //    if (id == 0)
        //    {

        //        UploadImage(sType, TB_Name.Text, "", false, out sPathImage, out sImage);
        //        var oProduct = new ProductsInfo()
        //        {
        //            s_Name = TB_Name.Text,
        //            s_Description = TB_Description.Text,
        //            fk_ProductID = iType,
        //            s_ProductName = sType,
        //            f_Price = UntilityFunction.StringToDouble(TB_Price.Text),
        //            SortField = UntilityFunction.StringToInt(TB_SortField.Text),
        //            s_Image = sImage,
        //            s_Content = Content.Text,
        //            Active = CB_Active.Checked,
        //            sPath = sPathImage
        //        };
        //        int i = ServiceFactory.GetInstanceProduct().Insert((oProduct));
        //        LB_Messenger.Text = i > 0 ? "Thêm mới thành công" : "Có lỗi phát sinh";
        //    }
        //    else
        //    {
        //        var oItem = ServiceFactory.GetInstanceProduct().GetProductInfo(id);
        //        UploadImage(sType, TB_Name.Text, oItem.sPath, true, out sPathImage, out sImage);
        //        var oProduct = new ProductsInfo()
        //        {
        //            pk_ID = id,
        //            s_Name = TB_Name.Text,
        //            s_Description = TB_Description.Text,
        //            f_Price = UntilityFunction.StringToDouble(TB_Price.Text),
        //            SortField = UntilityFunction.StringToInt(TB_SortField.Text),
        //            Active = CB_Active.Checked,
        //            s_Image = sImage,
        //            s_Content = Content.Text,
        //            sPath = sPathImage
        //        };
        //        int i = ServiceFactory.GetInstanceProduct().Update(oProduct);
        //        LB_Messenger.Text = i > 0 ? "Sửa thông tin thành công" : "Có lỗi phát sinh";
        //    }
        //    DIV_2.Style["display"] = "none";
        //    Load_Grid();

        //    clearCache(iType);
        //}

        //command
        protected void IMGBT_Edit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int ID = UntilityFunction.IntegerForNull(HD_ID.Value);
            Load_Detail(ID);
        }

        protected void IMGBT_Delete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int ID = UntilityFunction.IntegerForNull(HD_ID.Value);
            Delete(ID);
            Load_Grid();
        }

        //detail
        private void Load_Detail(int ID)
        {
            var o = ServiceFactory.GetInstanceProduct().GetProductInfo(ID);
            if (o != null)
            {
                HD_ID.Value = o.pk_ID.ToString();
                TB_Name.Text = o.s_Name;
                TB_Description.Text = o.s_Description;
                HD_IMG.Value = o.s_Image;
                IMG.ImageUrl = GetPathImgThumb(o.s_Image);
                TB_SortField.Text = o.SortField.ToString();
                TB_Price.Text = string.Format("{0:N0}", o.f_Price);
                CB_Active.Checked = o.Active;
                Content.Text = o.s_Content;

            }
            else
            {
                HD_ID.Value = "0";
                TB_Name.Text = "";
                TB_Description.Text = "";
                //HD_IMG.Value = "";
                TB_SortField.Text = "0";
                CB_Active.Checked = false;
                Content.Text = "";
            }
            DIV_2.Style["display"] = "block";
            //SetFocus()
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "SetFocus(2)", true);
        }

        //delete
        private void Delete(int id)
        {
            var oItem = ServiceFactory.GetInstanceProduct().GetProductInfo(id);

            int i = ServiceFactory.GetInstanceProduct().Delete(id);
            LB_Messenger.Text = i > 0 ? "Đã xóa" : "Có lỗi phát sinh";
            DIV_2.Style["display"] = "none";

            //DELETE forder
            //if (oItem.sPath.Trim().Length > 0)
            //{
            //    string sPath = _FolderUpload + "\\" + oItem.sPath.Replace("/", "\\");
            //    if (System.IO.Directory.Exists(sPath)) //kiểm tra sự tồn tại của thư mục Type
            //    {
            //        System.IO.Directory.Delete(sPath, true);
            //    }
            //}
        }

        protected void IMGBT_Page_Click(object sender, ImageClickEventArgs e)
        {
            Load_Grid();
        }
        #endregion

        public string BuildContentListProduct(List<ProductsInfo> olist, bool bEdit)
        {
            var sb = new StringBuilder();
            int i = 0;
            foreach (ProductsInfo o in olist)
            {
                if (i % 2 != 0)
                {
                    sb.AppendFormat("<tr>");
                }
                else
                {
                    sb.AppendFormat("<tr style=\"background-color: rgb(222, 234, 243); color: Black;\">");
                }
                sb.AppendFormat("<td>" + ((o.s_Image == "") ? "&nbsp;" : "<img alt=\"\" src=\"" + _PathImageShow + "/" + o.s_Image + "\" width=\"60\" border=0 />") + "</td>");
                if (bEdit)
                {
                    sb.AppendFormat("<td align=\"left\"><a href=\"javascript:void(0)\" onclick=\"Edit({0});HideMessenger();\">{1}</a></td>", o.pk_ID, o.s_Name);
                    sb.AppendFormat("<td align=\"left\"><a href=\"javascript:void(0)\" onclick=\"Edit({0});HideMessenger();\">{1}</a></td>", o.pk_ID, o.s_Description);
                }
                else
                {
                    sb.AppendFormat("<td align=\"left\"><a href=\"javascript:void(0)\" onclick=\"HideMessenger();\">{0}</a></td>", o.s_Name);
                    sb.AppendFormat("<td align=\"left\"><a href=\"javascript:void(0)\" onclick=\"HideMessenger();\">{0}</a></td>", o.s_Description);
                }

                sb.AppendFormat("<td align=\"right\">{0:N0}</td>", o.f_Price);
                sb.AppendFormat("<td>{0}</td>", o.SortField);
                sb.AppendFormat("<td>{0:dd/MM/yyyy}</td>", o.d_CreateDate);
                sb.AppendFormat("<td><a href=\"tabproduct.aspx?ID={0}\">Edit Tab</a></td>", o.pk_ID);
                sb.AppendFormat("<td><input type=\"checkbox\" disabled=\"disabled\" {0}></td>", o.Active ? "checked" : "");
                if (bEdit)
                {
                    sb.AppendFormat("<td><a href=\"javascript:void(0)\" onclick=\"Edit({0});HideMessenger();\"><img alt=\"\" src=\"/admin/Images/edit-icon.gif\" border=\"0\"></a></td>", o.pk_ID);
                    sb.AppendFormat("<td><a href=\"javascript:void(0)\" onclick=\"javascript:return confirmDelete({0});\"><img alt=\"\" src=\"/admin/Images/delete-icon.gif\" border=\"0\"></a></td></tr>", o.pk_ID);
                }
                else
                {
                    sb.AppendFormat("<td><a href=\"javascript:void(0)\" onclick=\"HideMessenger();\"><img alt=\"\" src=\"/admin/Images/edit-icon.gif\" border=\"0\"></a></td>");
                    sb.AppendFormat("<td><a href=\"javascript:void(0)\" onclick=\"javascript:return false;\"><img alt=\"\" src=\"/admin/Images/delete-icon.gif\" border=\"0\"></a></td></tr>");
                }
                i++;
            }
            return sb.ToString();
        }

        protected void IMGBT_Save_Click(object sender, ImageClickEventArgs e)
        {
            int id = UntilityFunction.IntegerForNull(HD_ID.Value);
            if (id == 0)
            {
                var oProduct = new ProductsInfo()
                {
                    s_Name =HtmlUtility.StripTagsRegex(TB_Name.Text),
                    s_Description = HtmlUtility.StripTagsRegex(TB_Description.Text),
                    f_Price = UntilityFunction.StringToDouble(TB_Price.Text),
                    SortField = UntilityFunction.StringToInt(TB_SortField.Text),
                    s_Image = HD_IMG.Value,
                    s_Content = HtmlUtility.FillterHtmlTag(Content.Text, "script|frameset|frame|iframe|meta|link|style").Replace("id=", "name=").Replace("ID=", "name="),
                    Active = CB_Active.Checked
                };
                int i = ServiceFactory.GetInstanceProduct().Insert((oProduct));
                LB_Messenger.Text = i > 0 ? "Thêm mới thành công" : "Có lỗi phát sinh";
            }
            else
            {
                var oProduct = new ProductsInfo()
                {
                    pk_ID = id,
                    s_Name = HtmlUtility.StripTagsRegex(TB_Name.Text),
                    s_Description = HtmlUtility.StripTagsRegex(TB_Description.Text),
                    f_Price = UntilityFunction.StringToDouble(TB_Price.Text),
                    SortField = UntilityFunction.StringToInt(TB_SortField.Text),
                    Active = CB_Active.Checked,
                    s_Image = HD_IMG.Value,
                    s_Content = HtmlUtility.FillterHtmlTag(Content.Text, "script|frameset|frame|iframe|meta|link|style").Replace("id=", "name=").Replace("ID=", "name=")
                };
                int i = ServiceFactory.GetInstanceProduct().Update(oProduct);
                LB_Messenger.Text = i > 0 ? "Sửa thông tin thành công" : "Có lỗi phát sinh";
            }
            DIV_2.Style["display"] = "none";
            Load_Grid();
        }

        private string GetPathImgThumb(string s)
        {
            if (s == "")
            {
                return "~/Images/NoImage.jpg";
            }
            else
            {
                if (s.StartsWith("http://") || s.StartsWith("https://"))
                {
                    return s;
                }
                else
                {
                    return Config.GetPathImageThumb + s;
                }
            }
        }
    }
}
