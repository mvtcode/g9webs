using System;
using System.IO;
using App_Code.Caching;
using G9.Core;
using G9.Entity;
using G9.Impl;
using G9.Web.Utility;
using App_Code.Controler;

namespace Website.admin
{
    public partial class customer_add : System.Web.UI.Page
    {
        private static string s_img = "";

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

                IMG.Attributes.Add("onclick", "javascript:return ShowPupup();");
                BT_IMG.Attributes.Add("onclick", "javascript:return ShowPupup();");
                //BindDDL();

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
                var obj = new CustomerImpl();
                CustomerInfo item = obj.GetInfo(int.Parse(Request.QueryString["ID"]));

                if (item == null)
                {
                    Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                    return;
                }
                txtName.Text = item.s_CustomerName;
                txtEmail.Text = item.s_Email;
                txtAddress.Text = item.s_Address;
                txtMobile.Text = item.s_Mobile;
                txtHomepage.Text = item.s_Homepage;
                //s_img = item.s_Logo;
                HD_IMG.Value = item.s_Logo;
                IMG.ImageUrl = GetPathImgThumb(item.s_Logo);
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

                var obj = new CustomerImpl();
                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != string.Empty)
                {
                    try
                    {
                        userID = int.Parse(Request.QueryString["ID"]);
                        CustomerInfo item = obj.GetInfo(userID);

                        if (item == null)
                        {
                            Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                            return;
                        }
                        var objAdmin = (AdminInfo)Session[Constant.SessionNameAccountAdmin];

                        //string imgName = IMGName();

                        item.s_CustomerName = txtName.Text;
                        item.s_Email = txtEmail.Text;
                        item.s_Address = txtAddress.Text;
                        item.s_Mobile = txtMobile.Text;
                        item.s_Homepage = txtHomepage.Text;
                        item.s_Logo = UntilityFunction.StringForNull(HD_IMG.Value);

                        obj.Update(item);
                        //Delete cache
                        CacheController.GetListCus_Delete();
                    }
                    catch
                    {
                        Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                        return;
                    }
                }
                else
                {
                    var item = new CustomerInfo();
                    item.s_CustomerName = txtName.Text;
                    item.s_Email = txtEmail.Text;
                    item.s_Address = txtAddress.Text;
                    item.s_Mobile = txtMobile.Text;
                    item.s_Homepage = txtHomepage.Text;
                    item.s_Logo = UntilityFunction.StringForNull(HD_IMG.Value);// IMGName();

                    obj.Insert(item);
                    //Delete cache
                    CacheController.GetListCus_Delete();
                }
                Response.Redirect("customer_manager.aspx", false);
            }
            catch
            {
                lblMsg.Text = "Tên khách hàng. Bạn chạy chọn một tên khác";
            }
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

        //private string IMGName()
        //{
        //    string path274165 = Server.MapPath("~/" + ImageController.sImg274165);
        //    string path607305 = Server.MapPath("~/" + ImageController.sImg607305);
        //    string path150 = Server.MapPath("~/" + ImageController.sImg150auto);
        //    string imgName = Path.GetFileNameWithoutExtension(fUpload.PostedFile.FileName);
        //    if (!string.IsNullOrEmpty(imgName) && !imgName.Equals(s_img))
        //    {
        //        byte[] byteIMG = ResizeImage.ReadFully(fUpload.PostedFile.InputStream);
        //        //Image size 607x305
        //        ResizeImage.Process(byteIMG, path607305 + imgName + ".jpg", 607, 305,
        //                            90, true);
        //        //Size 619x280
        //        ResizeImage.Process(byteIMG, path274165 + imgName + ".jpg", 274, 165, 90,
        //                            true);
        //        //Size 150xauto
        //        ResizeImage.Process(byteIMG, path150 + imgName + ".jpg", 152, 103,
        //                            90, true);
        //    }
        //    else
        //    {
        //        imgName = string.IsNullOrEmpty(s_img) ? "Default" : s_img;
        //    }
        //    return imgName;
        //}
    }
}
