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
    public partial class master_default : System.Web.UI.MasterPage
    {
        private const int _itemW = 100;
        public string UrlRoot = Utility.UrlRoot + "admin/";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Track Visitors
            //string ipAddress = IpAddress();
            //string hostName = Dns.GetHostByAddress(ipAddress).HostName;
            //StreamWriter wrtr = new StreamWriter(Server.MapPath("Log") + @"\VisitAdmin_" + DateTime.Now.Year + (DateTime.Now.Month.ToString().Length == 1 ? "" + ("0" + DateTime.Now.Month) : "" + DateTime.Now.Month) + (DateTime.Now.Day.ToString().Length == 1 ? "" + ("0" + DateTime.Now.Day) : "" + DateTime.Now.Day) + ".log", true);
            //wrtr.WriteLine(DateTime.Now.ToString() + " | " + ipAddress + " | " + hostName + " | " + Request.Url.ToString());
            //wrtr.Close();

            if (!IsPostBack)
            {
                if (Session[Constant.SessionNameAccountAdmin] == null && Request.Url.DnsSafeHost.Equals("localhost"))
                //if (Session[Constant.SessionNameAccountAdmin] == null)
                {
                    var objAdmin = new AdminInfo();
                    objAdmin.FullName = "Administrator";
                    objAdmin.ID = 1;
                    objAdmin.IsLogin = 1;
                    objAdmin.Status = 2;
                    objAdmin.Username = "Administrator";
                    Session[Constant.SessionNameAccountAdmin] = objAdmin;
                }
            }
        }

        private string IpAddress()
        {
            string strIpAddress;
            strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIpAddress == null)
                strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
            return strIpAddress;
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            Page.Title = "..:G9 - Content Management System:..";

            var linkTag = new Literal();
            linkTag.Text =
                string.Format(
                    @"<link href=""{0}css/layout.css"" rel=""stylesheet"" type=""text/css"" />
                    <link href=""{0}css/css.css"" rel=""stylesheet"" type=""text/css"" />
                    <link href=""{0}css/style_repeater.css"" rel=""stylesheet"" type=""text/css"" />
                    <link href=""{0}css/paper.css"" rel=""stylesheet"" type=""text/css"" />
                    ",UrlRoot);

            Page.Header.Controls.Add(linkTag);

            if (Session[Constant.SessionNameAccountAdmin] == null ||
                Session[Constant.SessionNameAccountAdmin].ToString() == string.Empty)
            {
                return;
            }
            ltlUserID.Text = ((AdminInfo)Session[Constant.SessionNameAccountAdmin]).Username;
            hlChangePwd.InnerText = "Đổi mật khẩu";
            hlChangePwd.HRef = UrlRoot + "ChangePass.aspx";
            hlSignOut.InnerText = "Thoát";
            //hlSignOut.HRef = DBConfig.LoginURL + "?act=out";
            hlSignOut.HRef = UrlRoot + "Logout.aspx";

            if (!IsPostBack)
            {
                var obj = new UserRightImpl();

                var objAdmin = (AdminInfo)Session[Constant.SessionNameAccountAdmin];

                DataTable dt;
                if (objAdmin.Status == 2)
                {
                    dt = obj.GetFullParentMenu();
                }
                else
                {
                    dt = obj.GetParentMenuByAdminID(objAdmin.ID);
                }

                string sCurr = Request.Url.AbsoluteUri;

                int appID = 0;

                string linkCur = sCurr.Substring(sCurr.LastIndexOf("/") + 1);

                appID = UserRightImpl.GetParentID(linkCur);

                string sHtml = string.Empty;
                bool bSelected = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                    string caption = dt.Rows[i]["Name"].ToString();

                    string link = Utility.UrlRoot + Config.PathAdmin + dt.Rows[i]["Link"];

                    if (!bSelected & (id == appID))
                    {
                        sHtml += "<td style=\"width: 4px; height: 20px\" class=\"spacerTab\">&nbsp;</td>";
                        sHtml += "<td id='left" + i +
                                 "' style=\"width: 4px; height: 20px\" valign=\"top\" class=\"selTabLeft\">";
                        sHtml += "<img alt=\"\" style=\"border:0px\" src=\"" + UrlRoot +
                                 "css/selectedTab_leftCorner.gif\" width=\"4\" height=\"3\" alt=\"\" /></td>";
                        sHtml += "<td style=\"width:" + _itemW +
                                 "px; height: 20px;\" align=\"center\" nowrap valign=\"middle\" class=\"selTabCenter\" >" +
                                 caption + "</td>";
                        sHtml += "<td id='right" + i +
                                 "' style=\"width: 4px; height: 20px\" align=\"right\" valign=\"top\" class=\"selTabRight\">";
                        sHtml += "<img src=\"" + UrlRoot +
                                 "css/selectedTab_rightCorner.gif\" width=\"4\" height=\"3\" alt=\"\" style=\"border:0px\" /></td>";
                        bSelected = true;
                    }
                    else
                    {
                        sHtml += "<td style=\"width: 4px; height: 20px\" class=\"spacerTab\">&nbsp;</td>";
                        sHtml += "<td id='left" + i +
                                 "' style=\"width: 4px; height: 20px\" valign=\"top\" class=\"deSTabLeft\">";
                        sHtml += "<img src=\"" + UrlRoot +
                                 "css/unSelectedTab_leftCorner.gif\" width=\"4\" height=\"3\" alt=\"\" style=\"border:0px\" /></td>";
                        sHtml += "<td style=\"width:" + _itemW +
                                 "px; height: 20px;cursor:hand;cursor:pointer;\" align=\"center\" nowrap valign=\"middle\" class=\"deSTabCenter\" onclick='window.location = \"" +
                                 link + "\"' onmouseover=\"this.className='hoverTabCenter';document.getElementById('left" +
                                 i + "').className='hoverTabLeft';document.getElementById('right" + i +
                                 "').className='hoverTabRight';\" onmouseout=\"this.className='deSTabCenter';document.getElementById('left" +
                                 i + "').className='deSTabLeft';document.getElementById('right" + i +
                                 "').className='deSTabRight';\" onkeypress=\"__keyPress(event, '" + link + "');\">" +
                                 caption + "</td>";
                        sHtml += "<td id='right" + i +
                                 "' style=\"width: 4px; height: 20px\" align=\"right\" valign=\"top\" class=\"deSTabRight\">";
                        sHtml += "<img src=\"" + UrlRoot +
                                 "css/unSelectedTab_rightCorner.gif\" style=\"width: 4px; height: 3px; border: 0px\" alt=\"\" /></td>";
                    }
                }
                ltlMenu.Text = sHtml;
            }
        }
    }
}
