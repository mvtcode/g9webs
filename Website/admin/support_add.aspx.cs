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
    public partial class support_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginAdmin.IsLoginAdmin();

            if (!UserRightImpl.CheckRightAdminnistrator().UserEdit)
            {
                Response.Redirect(Utility.UrlRoot + Config.PathNotRight, false);
                return;
            }

            if (!IsPostBack)
            {
                lblMsg.Text = "";

                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != string.Empty)
                {
                    EditData();
                }
            }
        }

        private void EditData()
        {
            try
            {
                SupportImpl obj = new SupportImpl();
                SupportInfo item = obj.GetInfo(int.Parse(Request.QueryString["ID"]));

                if (item == null)
                {
                    Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                    return;
                }
                else
                {
                    txtName.Text = item.s_Name;
                    txtEmail.Text = item.s_Email;
                    txtMobile.Text = item.s_Mobile;
                    txtSkype.Text = item.s_Skype;
                    txtYahoo.Text = item.s_Yahoo;
                }
            }
            catch
            {
                Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                return;
            }
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            if (!UserRightImpl.CheckRightAdminnistrator().UserEdit)
            {
                Response.Redirect(Utility.UrlRoot + Config.PathNotRight, false);
                return;
            }

            try
            {
                int userID = 0;

                SupportImpl obj = new SupportImpl();
                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != string.Empty)
                {
                    try
                    {
                        userID = int.Parse(Request.QueryString["ID"]);

                        SupportInfo item = obj.GetInfo(userID);

                        if (item == null)
                        {
                            Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                            return;
                        }
                        else
                        {
                            item.s_Name = txtName.Text;
                            item.s_Email = txtEmail.Text;
                            item.s_Mobile = txtMobile.Text;
                            item.s_Skype = txtSkype.Text;
                            item.s_Yahoo = txtYahoo.Text;
                            obj.Update(item);
                            //Delete cache
                            CacheController.GetListSupport_Delete();
                        }
                    }
                    catch
                    {
                        Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                        return;
                    }
                }
                else
                {
                    SupportInfo item = new SupportInfo();
                    item.s_Name = txtName.Text;
                    item.s_Email = txtEmail.Text;
                    item.s_Mobile = txtMobile.Text;
                    item.s_Skype = txtSkype.Text;
                    item.s_Yahoo = txtYahoo.Text;

                    obj.Insert(item);
                    //Delete cache
                    CacheController.GetListSupport_Delete();
                }
                Response.Redirect("support_manager.aspx", false);
            }
            catch
            {
                lblMsg.Text = "Tên người hỗ trợ đã tồn tại. Bạn chạy chọn một tên khác";
            }
        }
    }
}
