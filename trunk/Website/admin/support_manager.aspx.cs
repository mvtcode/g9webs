using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Caching;
using G9.Core;
using G9.Core.Provider;
using G9.Entity;
using G9.Impl;

namespace Website.admin
{
    public partial class support_manager : System.Web.UI.Page
    {
        private bool flagRowHeader = true;

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
                var obj = new SupportImpl();
                List<SupportInfo> dt = obj.getListSupportInfo(5);

                //dt.DefaultView.Sort = sortString;

                grvView.DataSource = dt;
                grvView.DataBind();

                ltThongBao.Text = "<font color='red'>Có " + dt.Count + " thông tin được tìm thấy.</font>";
            }
            catch
            {
                Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                return;
            }
        }

        private void RowDataBound(GridViewRowEventArgs e)
        {
            int x = e.Row.DataItemIndex;

            if (e.Row.DataItemIndex != -1)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();

                e.Row.Cells[1].Text = "<a href=\"support_add.aspx?ID=" + grvView.DataKeys[e.Row.RowIndex].Value + "\">" +
                                      e.Row.Cells[1].Text + "</a>";
            }
        }

        private void PageIndexChanging(GridViewPageEventArgs e)
        {
            grvView.PageIndex = e.NewPageIndex;
            BindGird();
            //search(Convert.ToInt32(ddlNewType.Text), txtTim.Text.Trim());
            //BindGird(int.Parse(ddlNewType.Text), 0);        
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
                var obj = new SupportImpl();
                foreach (GridViewRow row in grvView.Rows)
                {
                    var status = (CheckBox)row.Cells[2].FindControl("StatusCheck");

                    if (status.Checked)
                    {
                        int ID = int.Parse(grvView.DataKeys[i].Value.ToString());
                        obj.Delete(ID);
                        //Delete cache
                        CacheController.GetListSupport_Delete();
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
            CacheController.GetListSupport_Delete();//delete cache

            //        BindGird(int.Parse(ddlNewType.Text), 0);
        }

        protected void btThemMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("support_add.aspx", false);
        }
    }
}
