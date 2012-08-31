using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using G9.Core;
using G9.Entity;
using G9.Impl;

namespace Website.admin
{
    public partial class UserMessenge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var objAdmin = (AdminInfo)Session[Constant.SessionNameAccountAdmin];
            if (objAdmin == null)
            {
                Response.Redirect(Utility.UrlRoot + Config.LoginAdmin, true);
            }

            if (!IsPostBack)
            {
                //Load_DDLType();
                DIV_1.Style["display"] = "none";
                Load_Grid();
                //SetAttribute();
            }
        }

        //private void Load_DDLType()
        //{
        //    DDL_Role.DataSource = ServiceFactory.GetInstanceRole().GetAll();
        //    DDL_Role.DataTextField = "s_RoleName";
        //    DDL_Role.DataValueField = "pk_Id";
        //    DDL_Role.DataBind();
        //}

        //private void SetAttribute()
        //{
        //    DIV_1.Style["display"] = "none";
        //    BT_Save.Attributes.Add("onclick", "javascript:return check_Data();");

        //    //BT_IMG.Attributes.Add("onclick", "javascript:return ShowPupup()");
        //    //TB_Sort.Attributes.Add("onkeypress", "javascript:return EnsureIntegerKeyEntry(this.value,event);");
        //    //TB_Sort.Attributes.Add("onkeyup", "javascript:FormatNum(this, 0);");
        //    //IMG.Attributes.Add("onclick", "javascript:return ShowPupup();");
        //}

        private void Load_Grid()
        {
            GV_User.DataSource = ServiceFactory.GetInstanceUser().GetListUser();
            GV_User.DataBind();
        }

        protected void BT_Add_Click(object sender, EventArgs e)
        {
            //if (!UserRightImpl.CheckRightAdminnistrator().UserDelete)
            //{
            //    return;
            //}
            DIV_1.Style["display"] = "block";
            HD_ID.Value = "0";

            TB_Username.Text = "";
            DDL_Role.SelectedValue = "2";
            TB_Password.Text = "";
            TB_Fullname.Text = "";
            TB_Email.Text = "";
            CB_Active.Checked = true;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "SetFocus('" + TB_Username.ClientID + "')", true);
        }

        //protected void BT_Save_Click(object sender, EventArgs e)
        //{
        //    int id = UntilityFunction.IntegerForNull(HD_ID.Value);
        //    //int categoryId = UntilityFunction.IntegerForNull(DDL_CategoryType1.SelectedValue);
        //    //int iUser = UntilityFunction.IntegerForNull(Session["userID"]);
        //    //var oAdmin = ((AdminInfo)Session[Constant.SessionNameAccountAdmin]);
        //    int iRole = UntilityFunction.IntegerForNull(DDL_Role.SelectedValue);
        //    if (id > 0)
        //    {
        //        UserInfo oUser = new UserInfo()
        //        {
        //            pk_ID = id,
        //            s_Username = TB_Username.Text,
        //            s_FullName = TB_Fullname.Text,
        //            fk_Role = iRole,
        //            s_RoleName = ServiceFactory.GetInstanceRole().GetRoleById(iRole) == null ? "" : ServiceFactory.GetInstanceRole().GetRoleById(iRole).s_RoleName,
        //            s_Email = TB_Email.Text,
        //            s_Password = TB_Password.Text,
        //            active= CB_Active.Checked
        //        };
        //        int i = ServiceFactory.GetInstanceUser().Update(oUser);
        //        LB_Messenger.Text = i > 0 ? "Cập nhật thành công" : "Có lỗi phát sinh";
        //    }
        //    else
        //    {
        //        UserInfo oUser = new UserInfo()
        //        {
        //            s_Username = TB_Username.Text,
        //            s_FullName = TB_Fullname.Text,
        //            fk_Role = iRole,
        //            s_RoleName = ServiceFactory.GetInstanceRole().GetRoleById(iRole) == null ? "" : ServiceFactory.GetInstanceRole().GetRoleById(iRole).s_RoleName,
        //            s_Email = TB_Email.Text,
        //            s_Password = TB_Password.Text,
        //            active = CB_Active.Checked
        //        };
        //        int i = ServiceFactory.GetInstanceUser().Insert(oUser);
        //        LB_Messenger.Text = i > 0 ? "Thêm mới thành công" : "Có lỗi phát sinh";
        //    }
        //    DIV_1.Style["display"] = "none";
        //    Load_Grid();
        //}

        protected void GV_User_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int id = UntilityFunction.IntegerForNull(e.CommandArgument.ToString());

            if (currentCommand == "BT_Edit")
            {
                //Detail(id);
            }

            if (currentCommand == "BT_Delete")
            {
                Delete(id);
            }
        }

        protected void GV_User_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_User.PageIndex = e.NewPageIndex;
            Load_Grid();
        }

        //private void Detail(int id)
        //{
        //    //if (!UserRightImpl.CheckRightAdminnistrator().UserEdit)
        //    //{
        //    //    return;
        //    //}
        //    DIV_1.Style["display"] = "block";
        //    UserInfo o = ServiceFactory.GetInstanceUser().GetUserID(id);
        //    if (o != null)
        //    {
        //        HD_ID.Value = o.id.ToString();
        //        TB_Username.Text = o.sUsername;
        //        //DDL_Role.SelectedValue =o.fk_Role.ToString();
        //        TB_Password.Text = "";
        //        TB_Fullname.Text = o.sFullName;
        //        TB_Email.Text = o.sEmail;
        //        CB_Active.Checked = o.active;
        //        //SetFocus()
        //        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "focus", "SetFocus()", true);
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "SetFocus('" + TB_Username.ClientID + "')", true);
        //    }
        //}

        private void Delete(int id)
        {
            //if (!UserRightImpl.CheckRightAdminnistrator().UserDelete)
            //{
            //    return;
            //}
            int i = ServiceFactory.GetInstanceUser().Delete(id);
            LB_Messenger.Text = i > 0 ? "Đã xóa bản ghi" : "Có lỗi phát sinh";
            DIV_1.Style["display"] = "none";
            Load_Grid();
        }
    }
}
