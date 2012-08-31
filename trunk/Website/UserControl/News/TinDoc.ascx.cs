using System;
using System.Collections.Generic;
using System.Text;
using App_Code;
using G9.Entity;
using G9.Web.Utility;

namespace WebsiteV2.UserControl.TinTuc
{
    public partial class TinDoc : System.Web.UI.UserControl
    {
        public int iType = 8;
        protected string sContent = "";
        protected string sPhantrang = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int iPage = ConvertUtility.ToInt32(Request.QueryString["Page"]);
            int iTotal;
            List<NewsInfo> oList = ServiceFactory.GetInstanceNews().GetList_StartRow(iType, iPage,5, 6, out iTotal);
            if (oList != null)
            {
                sContent = Website.App_Code.Controls.News.News.Build_TinDoc(oList);
                sPhantrang = BuildPagerType(iTotal, 5, iPage, "phantrangtintuc", "chonphantrang", 5);
            }
        }

        public static string BuildPagerType(int totalrecord, int irecordofpage, int pageindex, string className, string classActive, int rshow)
        {
            var sb = new StringBuilder();
            int numberpage;

            if (totalrecord % irecordofpage == 0)
                numberpage = totalrecord / irecordofpage;
            else
                numberpage = (totalrecord / irecordofpage) + 1;

            if (numberpage == 1)
                return "";

            int loopend;
            int loopstart;
            var istart = false;
            var iend = false;
            if (pageindex == 0)
            {
                loopstart = 0;
                loopend = numberpage > (rshow - 1) ? rshow : numberpage;
                if (numberpage > rshow)
                    iend = true;
            }
            else
            {
                if (pageindex < numberpage - (rshow - 1) && pageindex != 0)
                {
                    loopstart = pageindex - 1;
                    loopend = pageindex + (rshow - 1);
                    iend = true;
                    if (pageindex > 1)
                    {
                        istart = true;
                    }
                }
                else
                {
                    if (numberpage - rshow > 0)
                    {
                        loopstart = numberpage - rshow;
                        istart = true;
                        loopend = numberpage;
                    }
                    else
                    {
                        loopstart = 0;
                        loopend = numberpage;
                    }
                }
            }

            sb.AppendFormat("<div class=\"{0}\"><p>", className);
            if (istart)
            {
                sb.AppendFormat("<a href='/tin-tuc/{0}#trangtin'>‹‹</a>", 0);
            }
            if (pageindex >= 1)
                sb.AppendFormat("<a href='/tin-tuc/{0}#trangtin'>‹</a>", pageindex - 1);
            for (var i = loopstart; i < loopend; i++)
            {
                if (pageindex == i)
                {
                    sb.AppendFormat("<a class='{1}' href='/tin-tuc/{0}#trangtin'>", i, classActive);
                }
                else
                {
                    sb.AppendFormat("<a href='/tin-tuc/{0}#trangtin'>", i);
                }
                sb.Append((i + 1).ToString());
                sb.Append("</a>");
            }
            if (pageindex <= numberpage - 2)
            {
                sb.AppendFormat("<a href='/tin-tuc/{0}#trangtin' >›</a>", pageindex + 1);
            }
            if (iend)
                sb.AppendFormat("<a href='/tin-tuc/{0}#trangtin'>››</a>", numberpage - 1);

            sb.Append("</p></div>");
            return sb.ToString();
        }
    }
}