using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using App_Code.Caching;
using G9.Core;
using G9.Entity;
using G9.Impl;

namespace Website.admin
{
    public partial class newtype_add : System.Web.UI.Page
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
                CategoryTypeImpl obj = new CategoryTypeImpl();
                CategoryTypeInfo item = obj.GetInfo(int.Parse(Request.QueryString["ID"]));

                if (item == null)
                {
                    Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                    return;

                }
                else
                {
                    txtName.Text = item.s_CategoryName;
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

                CategoryTypeImpl obj = new CategoryTypeImpl();
                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != string.Empty)
                {
                    try
                    {
                        userID = int.Parse(Request.QueryString["ID"]);


                        CategoryTypeInfo item = obj.GetInfo(userID);

                        if (item == null)
                        {
                            Response.Redirect(Utility.UrlRoot + Config.PathError, false);
                            return;
                        }
                        else
                        {
                            item.s_CategoryName = txtName.Text;
                            obj.Update(item);

                            //reset cache
                            DeleteCache(item.pk_ID);
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
                    CategoryTypeInfo item = new CategoryTypeInfo();
                    item.s_CategoryName = txtName.Text;

                    obj.Insert(item);

                    //reset cache
                    DeleteCache(item.pk_ID);
                }
                Response.Redirect("newtype_manager.aspx", false);
            }
            catch
            {
                lblMsg.Text = "Tên loại tin đã tồn tại. Bạn chạy chọn một tên khác";
            }
        }

        private void DeleteCache(int iType)
        {
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
    }
}
