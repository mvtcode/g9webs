using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;
using G9.Entity;
using G9.Impl;

namespace Website.admin
{
    public partial class contact_answer : System.Web.UI.Page
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

                //BindDDL();

                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != string.Empty)
                {
                    EditData();
                }
                else
                {
                    Response.Redirect("contact_manager.aspx");
                }
            }
        }

        private void EditData()
        {
            try
            {
                ContactImpl obj = new ContactImpl();
                ContactInfo item = obj.GetContactByID(int.Parse(Request.QueryString["ID"]));

                if (item == null)
                {
                    Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                    return;

                }
                else
                {
                    txtAdress.Text = item.s_Address;
                    txtAnswer.Text = string.Empty;
                    Content.Text = item.s_Content;
                    txtCompany.Text = item.s_Company;
                    txtEmail.Text = item.s_Email;
                    txtFax.Text = item.s_Fax;
                    txtName.Text = item.s_Name;
                    txtPhone.Text = item.s_Phone;
                    txtTitle.Text = item.s_Title;
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
                Utility.SendEmail(txtEmail.Text, "Re: " + txtTitle.Text, txtAnswer.Text, string.Empty, Config.UsernameSendMail, Config.PassSendMail);
                Response.Redirect("contact_manager.aspx", false);
            }
            catch
            {
                lblMsg.Text = "Có lỗi xảy ra";
            }
        }
    }
}
