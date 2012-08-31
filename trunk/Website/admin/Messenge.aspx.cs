using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LicSystem.Core;
using App_Code;

namespace Website.admin
{
    public partial class Messenge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Grid();
                SetAttribute();
            }
        }

        private void SetAttribute()
        {
            DIV_1.Style["display"] = "none";
            BT_Save.Attributes.Add("onclick", "javascript:return check_Data();");
        }

        private void Load_Grid()
        {
            //int categoryId = UntilityFunction.IntegerForNull(DDL_CategoryType1.SelectedValue);
            GridView1.DataSource = ServiceFactory.GetInstanceNews().GetAllNewsByType(categoryId);
            GridView1.DataBind();
        }

        protected void BT_Add_Click(object sender, EventArgs e)
        {
            //if (!UserRightImpl.CheckRightAdminnistrator().UserDelete)
            //{
            //    return;
            //}
            DIV_1.Style["display"] = "block";
            HD_ID.Value = "0";
            TB_Title.Text = "";
            TB_Description.Text = "";
            HD_IMG.Value = "";
            IMG.ImageUrl = "~/Images/NoImage.jpg";
            TB_Sort.Text = "";
            CB_Active.Checked = true;
            Content.Text = "";
            //SetFocus()
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "SetFocus()", true);
        }

        protected void BT_Save_Click(object sender, EventArgs e)
        {
            int id = UntilityFunction.IntegerForNull(HD_ID.Value);
            int categoryId = UntilityFunction.IntegerForNull(DDL_CategoryType1.SelectedValue);
            int iUser = UntilityFunction.IntegerForNull(Session["userID"]);
            var oAdmin = ((AdminInfo)Session[Constant.SessionNameAccountAdmin]);
            if (id > 0)
            {
                var oNews = new NewsInfo()
                {
                    pk_Id = id,
                    s_Title = TB_Title.Text,
                    s_Description = TB_Description.Text,
                    s_Image = HD_IMG.Value,
                    s_Content = Content.Text,
                    SortField = UntilityFunction.IntegerForNull(TB_Sort.Text.Replace(",", "")),
                    Active = CB_Active.Checked
                };
                int i = ServiceFactory.GetInstanceNews().Update(oNews);
                LB_Messenger.Text = i > 0 ? "Cập nhật thành công" : "Có lỗi phát sinh";
            }
            else
            {
                var oNews = new NewsInfo()
                {
                    s_Title = TB_Title.Text,
                    s_Description = TB_Description.Text,
                    s_Image = HD_IMG.Value,
                    s_Content = Content.Text,
                    fk_UserId = UntilityFunction.IntegerForNull(oAdmin.ID),
                    s_FullName = (oAdmin == null) ? "" : UntilityFunction.StringForNull(oAdmin.FullName),
                    fk_CategoryId = categoryId,
                    fk_CategoryName = UntilityFunction.StringForNull(ServiceFactory.GetInstanceCategoryType().GetInfo(categoryId).s_CategoryName),
                    SortField = UntilityFunction.IntegerForNull(TB_Sort.Text.Replace(",", "")),
                    Active = CB_Active.Checked
                };
                int i = ServiceFactory.GetInstanceNews().Insert(oNews);
                LB_Messenger.Text = i > 0 ? "Thêm mới thành công" : "Có lỗi phát sinh";
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

            if (currentCommand == "BT_Delete")
            {
                Delete(id);
            }
        }

        private void Detail(int id)
        {
            //if (!UserRightImpl.CheckRightAdminnistrator().UserEdit)
            //{
            //    return;
            //    //Response.Redirect(Utility.UrlRoot + Config.PathNotRight, false);
            //}
            DIV_1.Style["display"] = "block";
            NewsInfo o = ServiceFactory.GetInstanceNews().GetInfo(id);
            if (o != null)
            {
                HD_ID.Value = o.pk_Id.ToString();
                TB_Title.Text = o.s_Title;
                TB_Description.Text = o.s_Description;
                HD_IMG.Value = o.s_Image;
                IMG.ImageUrl = GetPathImgThumb(o.s_Image);
                TB_Sort.Text = o.SortField.ToString();
                CB_Active.Checked = o.Active;
                Content.Text = o.s_Content;
                //SetFocus()
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "focus", "SetFocus()", true);
            }
        }

        private void Delete(int id)
        {
            //if (!UserRightImpl.CheckRightAdminnistrator().UserDelete)
            //{
            //    return;
            //}
            int i = ServiceFactory.GetInstanceNews().Delete(id);
            LB_Messenger.Text = i > 0 ? "Đã xóa bản ghi" : "Có lỗi phát sinh";
            DIV_1.Style["display"] = "none";
            Load_Grid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}
