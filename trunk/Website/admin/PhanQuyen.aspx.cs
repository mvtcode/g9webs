using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;
using G9.Entity;
using G9.Impl;

namespace Website.admin
{
    public partial class PhanQuyen : System.Web.UI.Page
    {
        private int _adminID;
        private DataTable _dtRight;



        protected void Page_Load(object sender, EventArgs e)
        {
            LoginAdmin.IsLoginAdmin();

            if (!UserRightImpl.CheckRightAdminnistrator().UserEdit)
            {
                Response.Redirect(Utility.UrlRoot + Config.PathNotRight, false);
                return;
            }

            if (Page.Request["ID"] == null)
            {
            }
            else
            {
                _adminID = int.Parse(Page.Request["ID"]);
            }
            if (!IsPostBack)
            {
                BindDropDownList();
                BindGrid(0);
            }
        }

        private void BindDropDownList()
        {
            try
            {
                AdminImpl obj = new AdminImpl();

                DataTable dt = obj.SelectAll();

                DataRow dr = dt.NewRow();
                dr["ID"] = "0";
                dr["Username"] = "[ Chọn Username ]";

                dt.Rows.InsertAt(dr, 0);

                ddlUser.DataSource = dt;
                ddlUser.DataValueField = "ID";
                ddlUser.DataTextField = "Username";
                ddlUser.DataBind();

                ddlMenu.Items.Add("Menu cấp 1");
                ddlMenu.Items.Add("Menu cấp 2");
            }
            catch
            {
                Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                return;
            }
        }

        private void BindGrid(int type)
        {
            try
            {
                UserRightImpl obj = new UserRightImpl();
                if (_adminID == 0)
                    _adminID = int.Parse(ddlUser.Text.ToString());
                _dtRight = obj.GetQuyenByAdminID(_adminID, type);

                grvView.DataSource = _dtRight;
                grvView.DataBind();

                SetUserRight();
            }
            catch
            {
                Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                return;
            }
        }

        private void RowDataBound(GridViewRowEventArgs e)
        {
            var x = e.Row.DataItemIndex;

            if (e.Row.DataItemIndex != -1)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
            }

        }

        private void SetUserRight()
        {
            int menuIndex = ddlMenu.SelectedIndex;
            for (var i = 0; i < _dtRight.Rows.Count; i++)
            {
                var row = grvView.Rows[i];

                var chkRead = (CheckBox)row.FindControl("chkRead");
                var chkEdit = (CheckBox)row.FindControl("chkEdit");
                var chkDelete = (CheckBox)row.FindControl("chkDelete");

                if ((bool)_dtRight.Rows[i]["UserRead"])
                    chkRead.Checked = true;
                if (menuIndex == 1)
                {
                    chkEdit.Visible = true;
                    chkDelete.Visible = true;
                    if ((bool)_dtRight.Rows[i]["UserEdit"])
                        chkEdit.Checked = true;
                    if ((bool)_dtRight.Rows[i]["UserDelete"])
                        chkDelete.Checked = true;
                }
                else
                {
                    chkEdit.Visible = false;
                    chkDelete.Visible = false;
                }
            }
        }

        private void PageIndexChanging(GridViewPageEventArgs e)
        {
            grvView.PageIndex = e.NewPageIndex;
            BindGrid(0);
        }


        protected void grvView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                RowDataBound(e);
            }
            catch
            {
                Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                return;
            }
        }

        protected void grvView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PageIndexChanging(e);
        }

        protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(ddlMenu.SelectedIndex);
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            _adminID = int.Parse(ddlUser.Text.ToString());
            BindGrid(ddlMenu.SelectedIndex);
        }

        protected void btPhanQuyen_Click(object sender, EventArgs e)
        {
            if (!UserRightImpl.CheckRightAdminnistrator().UserEdit)
            {

                Response.Redirect(Utility.UrlRoot + Config.PathNotRight, false);
                return;
            }
            if (ddlUser.Text.Equals("0"))
            {
                lbMess.Text = "<p><font color='red'>Bạn phải chọn username phân quyền trước.</font></p>";
                return;
            }
            try
            {
                int menuIndex = ddlMenu.SelectedIndex;
                int i = 0;
                UserRightImpl obj = new UserRightImpl();
                foreach (GridViewRow row in grvView.Rows)
                {
                    var chkRead = (CheckBox)row.FindControl("chkRead");
                    var chkEdit = (CheckBox)row.FindControl("chkEdit");
                    var chkDelete = (CheckBox)row.FindControl("chkDelete");

                    UserRightInfo item = new UserRightInfo();

                    item.MenuID = int.Parse(grvView.DataKeys[row.RowIndex].Value.ToString());
                    if (_adminID == 0)
                        _adminID = int.Parse(ddlUser.Text.ToString());
                    item.AdminID = _adminID;

                    item.UserRead = chkRead.Checked;
                    if (menuIndex == 1)
                    {
                        item.UserEdit = chkEdit.Checked;
                        item.UserDelete = chkDelete.Checked;
                    }
                    else
                    {
                        item.UserEdit = true;
                        item.UserDelete = true;
                    }
                    UserRightInfo item2 = obj.GetRightByMenuAndAdmin(item.MenuID, item.AdminID);
                    if (item2 != null)
                    {
                        item.ID = item2.ID;
                        obj.Update(item);
                    }
                    else
                    {
                        obj.Insert(item);
                    }

                }
            }
            catch
            {
                Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                return;
            }
        }
    }
}
