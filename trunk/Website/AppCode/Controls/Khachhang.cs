using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App_Code.Caching;
using G9.Entity;
using System.Text;
using G9.Core;

/// <summary>
/// Summary description for Khachhang
/// </summary>
namespace App_Code.Controls
{
    public class Khachhang
    {
        public static string BuildListCustomer(List<CustomerInfo> oList)
        {
            #if !DEBUG
                var oData = CacheController.GetListCus();
                if (oData != null) return oData.ToString();
            #endif

            var sb = new StringBuilder();
            foreach (CustomerInfo o in oList)
            {

                string sLink = o.s_Homepage;
                if (!(sLink.StartsWith("http://") || sLink.StartsWith("https://")))
                {
                    sLink = "http://" + sLink;
                }
                sb.AppendFormat("<td><a target=\"_blank\" href=\"{0}\"><img alt=\"\" border=\"0\" width=\"70px\" src=\"{1}\"></a></td>", sLink, GetPathImgThumb(o.s_Logo));
            }
            string s=sb.ToString();
            #if !DEBUG
                CacheController.GetListCus(s);
            #endif
            return s;
        }

        private static string GetPathImgThumb(string s)
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
    }
}

