using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;
using G9.Entity;
using G9.Impl;

namespace Website.admin
{
    public partial class admin_add : System.Web.UI.Page
    {
        private int _adminID;
        private bool _isEdit = false;

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

                txtUsername.Text = "";
                txtPass.Text = "";

                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != string.Empty)
                {
                    if (Utility.IsInteger(Request.QueryString["ID"]))
                    {
                        _adminID = int.Parse(Request.QueryString["ID"]);
                        //_isEdit = true;
                        EditData();
                        RequiredFieldValidator2.Enabled = false;
                        RequiredFieldValidator3.Enabled = false;
                    }
                }


            }

            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != string.Empty)
            {
                if (Utility.IsInteger(Request.QueryString["ID"]))
                {
                    _adminID = int.Parse(Request.QueryString["ID"]);
                    _isEdit = true;
                    //EditData();
                }
            }

            lblMsg.Text = "";
        }

        private void EditData()
        {
            try
            {
                AdminImpl obj = new AdminImpl();
                DataTable dt = obj.SelectOne(_adminID);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                    return;
                }
                else
                {
                    AdminInfo item = obj.GetAdmin(dt)[0];
                    txtUsername.Text = item.Username;
                    txtUsername.ReadOnly = true;

                    txtFullName.Text = item.FullName;
                    chkLogin.Checked = item.IsLogin == 1;
                }
            }
            catch
            {
                Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                return;
            }
        }

        private bool checkPassEqualSoVaChu(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] > 47 && str[i] < 58)
                {
                    return true;
                }
            }
            return false;
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            if (!UserRightImpl.CheckRightAdminnistrator().UserEdit)
            {
                Response.Redirect(Utility.UrlRoot + Config.PathNotRight, false);
                return;
            }

            string mk = txtPass.Text;
            string reMk = txtRePass.Text;

            if (txtUsername.Text.Trim().Contains(" "))
            {
                lblMsg.Text = "Tên đăng nhập không được chứa khoảng trống.";
                lblMsg.Visible = true;
                return;
            }
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != string.Empty)
            {
                if (!mk.Equals(""))
                {
                    if (mk.Length < 6 || mk.Length > 20)
                    {
                        lblMsg.Text = "Mật khẩu từ 6 đến 20 ký tự.";
                        lblMsg.Visible = true;
                        return;
                    }

                    if (!checkPassEqualSoVaChu(mk))
                    {
                        lblMsg.Text = "Mật khẩu phải bao gồm cả số và chữ.";
                        lblMsg.Visible = true;
                        return;
                    }
                }
            }
            else
            {
                if (mk.Length < 6 || mk.Length > 20)
                {
                    lblMsg.Text = "Mật khẩu từ 6 đến 20 ký tự.";
                    lblMsg.Visible = true;
                    return;
                }

                if (!checkPassEqualSoVaChu(mk))
                {
                    lblMsg.Text = "Mật khẩu phải bao gồm cả số và chữ.";
                    lblMsg.Visible = true;
                    return;
                }
            }

            if (mk.StartsWith(" ") || mk.EndsWith(" "))
            {
                lblMsg.Text = "Mật khẩu không được bao gồm khoảng trắng ở đầu và cuối.";
                lblMsg.Visible = true;
                return;
            }


            if (!mk.Equals(reMk))
            {
                lblMsg.Text = "Nhập lại mật khẩu chưa đúng.";
                lblMsg.Visible = true;
                return;
            }




            string pattern = @"([a-z|A-Z|\d]+)$";
            Regex myRegex = new Regex(pattern);
            Match match = myRegex.Match(mk);
            Match mathUsername = myRegex.Match(txtUsername.Text.Trim());

            if (!mathUsername.Success)
            {
                lblMsg.Text = "Tên đăng nhập không được chứa ký tự đặc biệt.";
                lblMsg.Visible = true;
                return;
            }

            try
            {
                AdminInfo item = new AdminInfo();

                item.Username = txtUsername.Text.Trim().ToLower();

                item.FullName = txtFullName.Text;
                item.Status = 1;
                item.IsLogin = Convert.ToInt16(chkLogin.Checked ? 1 : 0);
                AdminImpl obj = new AdminImpl();

                if (_isEdit)
                {
                    item.ID = _adminID;

                    if (!mk.Equals(""))
                    {
                        if (!match.Success)
                        {
                            lblMsg.Text = "Mật khẩu chứa những ký tự không hợp lệ, xin kiểm tra lại.";
                            lblMsg.Visible = true;
                            return;
                        }

                        item.Password = txtPass.Text.Trim();//Sercurity.Encrypt.MD5Admin(txtPass.Text.Trim() + txtUsername.Text.ToLower().Trim());
                    }
                    else
                    {
                        DataTable dt = obj.SelectOne(_adminID);
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                            return;
                        }
                        else
                        {
                            AdminInfo item2 = obj.GetAdmin(dt)[0];

                            item.Password = item2.Password;
                        }
                    }

                    obj.Update(item);
                }
                else
                {
                    if (!match.Success)
                    {
                        lblMsg.Text = "Mật khẩu chứa những ký tự không hợp lệ, xin kiểm tra lại.";
                        lblMsg.Visible = true;
                        return;
                    }

                    item.Password = txtPass.Text.Trim();

                    obj.Insert(item);
                }

                Response.Redirect("admin_manager.aspx", false);
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Tên đăng nhập đã tồn tại. Bạn hãy chọn một tên đăng nhập khác";
            }
        }
    }
}
