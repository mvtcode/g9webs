using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;
using G9.Impl;

namespace Website.admin
{
    public partial class contact_manager : System.Web.UI.Page
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
                ContactImpl obj = new ContactImpl();
                var dt = obj.GetListContactToDataTable();

                //dt.DefaultView.Sort = sortString;

                grvView.DataSource = dt;
                grvView.DataBind();

                ltThongBao.Text = "<font color='red'>Có " + dt.Rows.Count + " contacct được tìm thấy.</font>";
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

                e.Row.Cells[1].Text = "<a href=\"support_answer.aspx?ID=" + grvView.DataKeys[e.Row.RowIndex].Value + "\">" + e.Row.Cells[1].Text + "</a>";
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
                SupportImpl obj = new SupportImpl();
                foreach (GridViewRow row in grvView.Rows)
                {
                    var status = (CheckBox)row.Cells[2].FindControl("StatusCheck");

                    if (status.Checked)
                    {
                        int ID = int.Parse(grvView.DataKeys[i].Value.ToString());
                        obj.Delete(ID);
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
            //        BindGird(int.Parse(ddlNewType.Text), 0);
        }
    }
}
