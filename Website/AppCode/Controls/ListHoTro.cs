using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App_Code.Caching;
using G9.Entity;
using System.Text;
/// <summary>
/// Summary description for ListHoTro
/// </summary>
namespace App_Code.Controls
{
    public class ListHoTro
    {
        public static string BuildContentListSupport(List<SupportInfo> oList)
        {
            var oData = CacheController.GetListHoTro();
            if (oData != null) return oData.ToString();

            var sb = new StringBuilder();
            int i = 0;
            foreach (SupportInfo o in oList)
            {
                sb.AppendFormat(
                    i%2 == 0
                        ? "<a href=\"YMSGR:SendIM?{0}\" title=\"{1}\"><img alt=\"\" src=\"http://opi.yahoo.com/online?u={0}&t=1&m=g\" class=\"yahoo\"></a>"
                        : "<a href=\"YMSGR:SendIM?{0}\" title=\"{1}\"><img alt=\"\" src=\"http://opi.yahoo.com/online?u={0}&t=1&m=g\" class=\"yahoo hotrocuoi\"></a>",
                    o.s_Yahoo,o.s_Name);
                i++;
            }
            string s=sb.ToString();
            CacheController.GetListHoTro(s);
            return s;
        }
    }
}
