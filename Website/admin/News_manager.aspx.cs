using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using App_Code.Caching;
using G9.Core;
using G9.Entity;
using G9.Impl;
using G9.Web.Utility;

namespace Website.admin
{
    public partial class News_manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_DDLType();
                Load_Grid();
                SetAttribute();
            }
        }

        private void Load_DDLType()
        {
            var oList = ServiceFactory.GetInstanceCategoryType().GetAllCategory();
            if (oList != null)
            {
                for (int i = 0; i < oList.Count; i++)
                {
                    if (oList[i].ParentID == 0)
                    {
                        if(oList[i].IsContent==false)
                            DDL_CategoryType1.Items.AddItem(oList[i].s_CategoryName, oList[i].pk_ID.ToString());
                    }
                    else
                    {
                        string sGroup = "Group_" + oList[i].ParentID.ToString();
                        if (oList[i - 1].ParentID != oList[i].ParentID)
                        {
                            var oType = ServiceFactory.GetInstanceCategoryType().GetInfo(oList[i].ParentID);
                            DDL_CategoryType1.Items.AddGroup(oType.s_CategoryName, sGroup);
                        }
                        DDL_CategoryType1.Items.AddItem(oList[i].s_CategoryName, oList[i].pk_ID.ToString(), sGroup);
                    }
                }
            }

            //DDL_CategoryType.DataSource = oList;
            //DDL_CategoryType.DataTextField = "s_CategoryName";
            //DDL_CategoryType.DataValueField = "pk_ID";
            //DDL_CategoryType.DataBind();
        }

        private void SetAttribute()
        {
            DIV_1.Style["display"] = "none";
            BT_IMG.Attributes.Add("onclick", "javascript:return ShowPupup();");
            //TB_Sort.Attributes.Add("onkeypress", "javascript:return EnsureIntegerKeyEntry(this.value,event);");
            TB_Sort.Attributes.Add("onkeyup", "javascript:FormatNum(this, 0);");
            BT_Save.Attributes.Add("onclick", "javascript:return check_Data();");
            IMG.Attributes.Add("onclick", "javascript:return ShowPupup();");
        }

        private void Load_Grid()
        {
            //int categoryId = UntilityFunction.IntegerForNull(DDL_CategoryType.SelectedValue);
            int categoryId = UntilityFunction.IntegerForNull(DDL_CategoryType1.SelectedValue);
            GridView1.DataSource = ServiceFactory.GetInstanceNews().GetAllNewsByType(categoryId);
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
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
        protected void IMGBT_Load_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            HD_Page.Value = "0";
            Load_Grid();
        }
        protected void BT_Add_Click(object sender, EventArgs e)
        {
            if (!UserRightImpl.CheckRightAdminnistrator().UserDelete)
            {
                return;
            }
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "SetFocus()", true);
        }
        protected void BT_Save_Click(object sender, EventArgs e)
        {
            int id = UntilityFunction.IntegerForNull(HD_ID.Value);
            //int categoryId = UntilityFunction.IntegerForNull(DDL_CategoryType.SelectedValue);
            int categoryId = UntilityFunction.IntegerForNull(DDL_CategoryType1.SelectedValue);
            int iUser = UntilityFunction.IntegerForNull(Session["userID"]);
            var oAdmin = ((AdminInfo)Session[Constant.SessionNameAccountAdmin]);
            if (id > 0)
            {
                var oNews = new NewsInfo()
                {
                    pk_Id = id,
                    s_Title =HtmlUtility.StripTagsRegex(TB_Title.Text),
                    s_Description = HtmlUtility.StripTagsRegex(TB_Description.Text),
                    s_Image = HD_IMG.Value,
                    s_Content =HtmlUtility.FillterHtmlTag(Content.Text, "script|frameset|frame|iframe|meta|link|style").Replace("id=","name=").Replace("ID=","name="),
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
                    s_Title = HtmlUtility.StripTagsRegex(TB_Title.Text),
                    s_Description = HtmlUtility.StripTagsRegex(TB_Description.Text),
                    s_Image = HD_IMG.Value,
                    s_Content = HtmlUtility.FillterHtmlTag(Content.Text, "script|frameset|frame|iframe|meta|link|style").Replace("id=", "name=").Replace("ID=", "name="),
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

            //delete cache
            DeleteCache(id);
        }

        private void Detail(int id)
        {
            if (!UserRightImpl.CheckRightAdminnistrator().UserEdit)
            {
                return;
                //Response.Redirect(Utility.UrlRoot + Config.PathNotRight, false);
            }
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
            if (!UserRightImpl.CheckRightAdminnistrator().UserDelete)
            {
                return;
            }
            int i = ServiceFactory.GetInstanceNews().Delete(id);
            LB_Messenger.Text = i > 0 ? "Đã xóa bản ghi" : "Có lỗi phát sinh";
            DIV_1.Style["display"] = "none";
            Load_Grid();
            DeleteCache(id);
        }

        //protected void DDL_CategoryType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DIV_1.Style["display"] = "none";
        //    HD_Page.Value = "0";
        //    Load_Grid();
        //}

        protected void DDL_CategoryType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DIV_1.Style["display"] = "none";
            HD_Page.Value = "0";
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

        private void DeleteCache(int id)
        {
            //int iType = UntilityFunction.IntegerForNull(DDL_CategoryType.SelectedValue);
            int iType = UntilityFunction.IntegerForNull(DDL_CategoryType1.SelectedValue);

            CacheController.GetNews_Delete(id);

            //GetListNews(int oType)
            CacheController.GetListNews_Delete1(iType);

            //GetListNews(int oType, int iCurent)
            var oList = ServiceFactory.GetInstanceNews().GetAllNewsByType(iType);
            foreach (var newsInfo in oList)
            {
                //GetListNews(int oType, int iCurent)
                CacheController.GetListNews_Delete2(iType, newsInfo.pk_Id);

                //GetListNewsOtherColumn(int oType, int column,int iCurent)
                CacheController.GetListNewsOtherColumn_Delete(iType, newsInfo.pk_Id);
            }

            //GetListNewsColumn(int oType,int column)
            CacheController.GetListNewsColumn_Delete(iType);

            //GetListTronGoi(int oType)
            CacheController.GetListTronGoi_Delete(iType);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Load_Grid();
        }
    }
}
