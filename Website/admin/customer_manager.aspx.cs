using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Caching;
using G9.Core;
using G9.Impl;

namespace Website.admin
{
    public partial class customer_manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginAdmin.IsLoginAdmin();

            if (!UserRightImpl.CheckRightAdminnistrator().UserRead)
            {
                Response.Redirect(Utility.UrlRoot + Config.PathNotRight, false);
                return;
            }

            if (!IsPostBack)
            {
                grvView.PageSize = int.Parse(Config.RecordPerPage);
                BindGird();
            }

        }

        private void BindGird()
        {
            try
            {
                CustomerImpl obj = new CustomerImpl();
                var list = obj.GetListCustomer();

                //dt.DefaultView.Sort = sortString;

                grvView.DataSource = list;
                grvView.DataBind();

                ltThongBao.Text = "<font color='red'>Có " + list.Count + " khách hàng được tìm thấy.</font>";
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

                e.Row.Cells[1].Text = "<a href=\"customer_add.aspx?ID=" + grvView.DataKeys[e.Row.RowIndex].Value + "\">" + e.Row.Cells[1].Text + "</a>";
            }
        }

        bool flagRowHeader = true;

        private void PageIndexChanging(GridViewPageEventArgs e)
        {
            grvView.PageIndex = e.NewPageIndex;
            BindGird();
        }


        protected void grvView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                RowDataBound(e);
            }
            catch (Exception ex)
            {
                Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                return;
            }
        }

        protected void grvView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PageIndexChanging(e);
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            if (!UserRightImpl.CheckRightAdminnistrator().UserDelete)
            {
                Response.Redirect(Utility.UrlRoot + Config.PathNotRight, false);
                return;
            }
            try
            {
                int i = 0;
                CustomerImpl obj = new CustomerImpl();
                foreach (GridViewRow row in grvView.Rows)
                {
                    var status = (CheckBox)row.Cells[2].FindControl("StatusCheck");

                    if (status.Checked)
                    {
                        int ID = int.Parse(grvView.DataKeys[i].Value.ToString());
                        obj.Delete(ID);
                        //delete cache
                        CacheController.GetListCus_Delete();
                    }

                    i++;
                }
            }
            catch
            {
                Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                return;
            }
            BindGird();
        }

        protected void btThemMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("customer_add.aspx", false);
        }
    }
}
