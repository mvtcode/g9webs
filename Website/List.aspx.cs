using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using G9.Entity;
using G9.Web.Utility;

namespace Website
{
    public partial class List : System.Web.UI.Page
    {
        protected string sTitle = "";
        protected string sContent = "";
        protected string sPhantrang = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            int iType = ConvertUtility.ToInt32(Request.QueryString["ID"]);
            int iPage = ConvertUtility.ToInt32(Request.QueryString["page"]);
            int iTotal=0;
            List<NewsInfo> oList = ServiceFactory.GetInstanceNews().GetListStartRow(iType, iPage, 10, 0,out iTotal);
            if (oList != null)
            {
                if (oList.Count > 0)
                {
                    sContent = App_Code.Controls.News.News.BuildContentListNews(oList);
                    sTitle=oList[0].fk_CategoryName;
                    Title = oList[0].fk_CategoryName;
                    sPhantrang = BuildPagerType(iTotal, 10, iPage, "phantrangtintuc", "chonphantrang", 5,iType);
                }
            }
            Title += sTitle + " - G9VietNam";
        }

        public static string BuildPagerType(int totalrecord, int irecordofpage, int pageindex, string className, string classActive, int rshow,int iType)
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
                sb.AppendFormat("<a href='/list.aspx?ID={0}&page={1}'>‹‹</a>",iType, 0);
            }
            if (pageindex >= 1)
                sb.AppendFormat("<a href='/list.aspx?ID={0}&page={1}'>‹</a>",iType, pageindex - 1);
            for (var i = loopstart; i < loopend; i++)
            {
                if (pageindex == i)
                {
                    sb.AppendFormat("<a class='{2}' href='/list.aspx?ID={0}&page={1}'>",iType, i, classActive);
                }
                else
                {
                    sb.AppendFormat("<a href='/list.aspx?ID={0}&page={1}'>",iType, i);
                }
                sb.Append((i + 1).ToString());
                sb.Append("</a>");
            }
            if (pageindex <= numberpage - 2)
            {
                sb.AppendFormat("<a href='/list.aspx?ID={0}&page={1}' >›</a>",iType, pageindex + 1);
            }
            if (iend)
                sb.AppendFormat("<a href='/list.aspx?ID={0}&page={1}'>››</a>",iType, numberpage - 1);

            sb.Append("</p></div>");
            return sb.ToString();
        }
    }
}
