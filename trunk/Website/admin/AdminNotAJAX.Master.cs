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
using Telerik.Web.UI;

namespace Website.admin
{
    public partial class AdminNotAJAX : System.Web.UI.MasterPage
    {
        public string UrlRoot = Utility.UrlRoot + "admin/";
        private RadPanelItem item;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            PanelMenu1.Items.Clear();

            string sCurr = Request.Url.AbsoluteUri;

            int appID = 0;

            string linkCur = sCurr.Substring(sCurr.LastIndexOf("/") + 1);

            linkCur = linkCur.Substring(0, linkCur.IndexOf(".aspx") + 5);

            appID = UserRightImpl.GetParentID(linkCur);

            var obj = new UserRightImpl();

            var objAdmin = (AdminInfo)Session[Constant.SessionNameAccountAdmin];

            if (objAdmin == null)
            {
                Response.Redirect(Utility.UrlRoot + Config.LoginAdmin, true);
            }

            DataTable dt;

            DataTable dtMain = obj.GetParentMenuByID(appID);

            dt = objAdmin.Status == 2 ? obj.GetFullMenuByParentID(appID) : obj.GetMenuByAdminIDAndParentID(objAdmin.ID, appID);

            ltTitleMenuLeft.Text = lbTitleMain.Text = dtMain.Rows[0]["Name2"].ToString();

            item = new RadPanelItem { Text = dtMain.Rows[0]["Name2"].ToString(), Value = "view", Expanded = true };

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item.Items.Add(new RadPanelItem(dt.Rows[i]["Name"].ToString(),
                                                Utility.UrlRoot + Config.PathAdmin + dt.Rows[i]["Link"]));

                if (sCurr.IndexOf(dt.Rows[i]["Link"].ToString()) != -1)
                {
                    lbTitleMain.Text = dt.Rows[i]["Name3"].ToString();
                }
                //   item.Items.Add(new RadPanelItem("Thêm mới người dùng", "~/admin_add.aspx?AppID=1"));
            }

            if (Request.QueryString["ID"] != null)
            {
                lbTitleMain.Text = lbTitleMain.Text.Replace("Thêm mới", "Sửa");
            }

            PanelMenu1.Items.Add(item);
        }
    }
}
