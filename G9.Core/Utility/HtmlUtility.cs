using System.Text;
using System.Text.RegularExpressions;

namespace G9.Web.Utility
{
  public class HtmlUtility
    {
        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty, RegexOptions.Compiled);
        }

        static readonly Regex HtmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        public static string StripTagsRegexCompiled(string source)
        {
            return HtmlRegex.Replace(source, string.Empty);
        }
        /// <summary>
        /// Xóa các thẻ html có trong removeTags. 
        /// removeTags format: "script|embed|object|frameset|frame|iframe|meta|link|style|a"
        /// </summary>
        public static string FillterHtmlTag(string html, string removeTags)
        {
            /// removeTags format: script|embed|object|frameset|frame|iframe|meta|link|style
            string ret = Regex.Replace(html, @"</?(?i:" + removeTags + ")(.|\n)*?>", "");
            ret = ret.Replace("javascript", "");
            return ret;
        }
        /// <summary>
        /// Định dạng lại chuỗi keyword thành chuối không có dấu cách sau dấu phẩy và đưa về ký tự thường. VD: Tăng thanh Hà, Diễn viên -> ,tăng thanh hà,diễn viên,
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConvertKeyword(string source)
        {
            string[] arr;
            var sb = new StringBuilder();
            var result = "";

            if (source.Trim().Length > 0)
            {
                source.Replace(",,", "");
                source = source.Trim();

                if (source.StartsWith(","))
                {
                    source = source.Substring(1, (source.Length - 1) - source.IndexOf(","));
                }

                if (source.EndsWith(","))
                {
                    source = source.Substring(0, source.LastIndexOf(","));
                }

                arr = source.Split(',');

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i < arr.Length - 1)
                        sb.Append(arr[i].Trim().ToLower() + ",");
                    else
                        sb.Append(arr[i].Trim().ToLower());
                }

                sb.ToString().Replace(",,", "");

                if (sb.ToString().Trim().Length > 0)
                    result = "," + sb.ToString() + ",";

                return result;
            }

            return "";
        }
        public static string StripTagsCharArray(string source)
        {
            var array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public static string StripTagsSourceArray(string source)
        {
            var array = new char[source.Length];
            var arrayIndex = 0;
            var inside = false;

            var abc = source.Length - 1;
            for (var i = 0; i < source.Length; i++)
            {
                var let = source[i];
                if (let == '<')
                {
                    if (i < abc)
                    {
                        let = source[i + 1];
                        if (let == 's' || let == 'i' || let == 'f')
                        {
                            inside = true;
                            continue;
                        }
                    }
                }
                if (let == '>')
                {
                    inside = false;
                    //continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public static string StripTagsRegexAtt(string source)
        {
            return Regex.Replace(source,
                @"(<[\s\S]*?) on.*?\=(['""])[\s\S]*?\2([\s\S]*?>)",
                                  match => string.Concat(match.Groups[1].Value, match.Groups[3].Value), RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public static string BuildPagerNormal(int totalrecord, int irecordofpage, int pageindex, string className, string classActive, int rshow)
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

            sb.AppendFormat("<div class=\"phantrang\"><p>");
            if (istart)
            {
                sb.AppendFormat("<a class='truoc' href='?page={0}'>‹‹</a>", 0);
            }
            if (pageindex >= 1)
                sb.AppendFormat("<a class='truoc' href='?page={0}' >‹</a>", pageindex - 1);
            for (var i = loopstart; i < loopend; i++)
            {
                if (pageindex == i)
                {
                    sb.AppendFormat("<a class='so {1}' href='?page={0}'>", i, classActive);
                }
                else
                {
                    sb.AppendFormat("<a class='so {1}' href='?page={0}'>", i, "");
                }
                sb.Append((i + 1).ToString());
                sb.Append("</a>");
            }
            if (pageindex <= numberpage - 2)
            {
                sb.AppendFormat("<a class='truoc' href='?page={0}' >›</a>", pageindex + 1);
            }
            if (iend)
                sb.AppendFormat("<a href='?page={0}' class='truoc'>››</a>", numberpage - 1);


            sb.Append("</p>");
            sb.Append("</div>");

            return sb.ToString();
        }

        public static string BuildPager(int totalrecord, int irecordofpage, int pageindex, string divData, string className, string classActive, string url, string typeparam, int rshow)
        {
            var xparam = typeparam;
            var jscallback = string.Empty;
            var param = typeparam.Split(',');
            if (param.Length > 1)
            {
                xparam = param[0];
                jscallback = ',' + param[1];
            }

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

            sb.AppendFormat("<div class=\"blockpages\">");
            if (iend)
                sb.AppendFormat("<div class=\"p_pages\"><a href='javascript:void(0)' onclick=\"PagerCommon('{0}','{1}',{2},'{3}'{4})\"><div align=\"center\" class=\"padpages\">Trang Cuối</div></a></div>", url, xparam, numberpage - 1, divData, jscallback);
            if (pageindex <= numberpage - 2)
            {
                sb.AppendFormat("<div class=\"n_pages\"><a href='javascript:void(0)' onclick=\"PagerCommon('{0}','{1}',{2},'{3}'{4})\"><div align=\"center\" class=\"padpages\">Sau</div></a></div>", url, xparam, pageindex + 1, divData, jscallback);
            }
            sb.Append("<div class=\"listpages\">");
            for (var i = loopstart; i < loopend; i++)
            {
                if (pageindex == i)
                {
                    sb.AppendFormat("<a class='{4}' onclick=\"PagerCommon('{0}','{1}',{2},'{3}'{5})\" href='javascript:void(0)'>", url, xparam, i, divData, classActive, jscallback);
                }
                else
                {
                    sb.AppendFormat("<a class='{4}' onclick=\"PagerCommon('{0}','{1}',{2},'{3}'{5})\" href='javascript:void(0)'>", url, xparam, i, divData, "", jscallback);
                }
                sb.Append((i + 1).ToString());
                sb.Append("</a>");
            }
            sb.Append("</div>");
            if (pageindex >= 1)
                sb.AppendFormat("<div class=\"n_pages\"><a href='javascript:void(0)' onclick=\"PagerCommon('{0}','{1}',{2},'{3}'{4})\"><div align=\"center\" class=\"padpages\">Trước</div></a></div>", url, xparam, pageindex - 1, divData, jscallback);
            if (istart)
            {
                sb.AppendFormat("<div class=\"p_pages\"><a href='javascript:void(0)' onclick=\"PagerCommon('{0}','{1}',{2},'{3}'{4})\"><div align=\"center\" class=\"padpages\">Trang đầu</div></a></div>", url, xparam, 0, divData, jscallback);
            }

            sb.Append("<div style=\"clear: both;\"></div>");
            sb.Append("</div>");

            return sb.ToString();
        }
        public static string BuildPager(int totalrecord, int irecordofpage, int pageindex, string divData, string className, string classActive, string url, string typeparam, int rshow, bool boxnho)
        {
            var sb = new StringBuilder();
            int numberpage;

            if (totalrecord % irecordofpage == 0)
                numberpage = totalrecord / irecordofpage;
            else
                numberpage = (totalrecord / irecordofpage) + 1;

            if (numberpage > 1)
            {
                int loopend;
                int loopstart;
                if (pageindex == 0)
                {
                    loopstart = 0;
                    loopend = numberpage > (rshow - 1) ? rshow : numberpage;
                    if (numberpage > rshow);
                }
                else
                {
                    if (pageindex < numberpage - (rshow - 1) && pageindex != 0)
                    {
                        loopstart = pageindex - 1;
                        loopend = pageindex + (rshow - 1);
                        if (pageindex > 1)
                        {
                        }
                    }
                    else
                    {
                        if (numberpage - rshow > 0)
                        {
                            loopstart = numberpage - rshow;
                            loopend = numberpage;
                        }
                        else
                        {
                            loopstart = 0;
                            loopend = numberpage;
                        }
                    }
                }

                sb.AppendFormat("<div class=\"blockpages\">");
                if (pageindex <= numberpage - 2)
                {
                    sb.AppendFormat("<div class=\"n_pages\"><a href='javascript:void(0)' onclick=\"PagerCommon('{0}','{1}',{2},'{3}')\"><div align=\"center\" class=\"padpages\">Sau</div></a></div>", url, typeparam, pageindex + 1, divData);
                }
                sb.Append("<div class=\"listpages\">");
                for (var i = loopstart; i < loopend; i++)
                {
                    if (pageindex == i)
                    {
                        sb.AppendFormat("<a class='{4}' onclick=\"PagerCommon('{0}','{1}',{2},'{3}')\" href='javascript:void(0)'>", url, typeparam, i, divData, classActive);
                    }
                    else
                    {
                        sb.AppendFormat("<a class='{4}' onclick=\"PagerCommon('{0}','{1}',{2},'{3}')\" href='javascript:void(0)'>", url, typeparam, i, divData, "");
                    }
                    sb.Append((i + 1).ToString());
                    sb.Append("</a>");
                }
                sb.Append("</div>");
                if (pageindex >= 1)
                    sb.AppendFormat("<div class=\"n_pages\"><a href='javascript:void(0)' onclick=\"PagerCommon('{0}','{1}',{2},'{3}')\"><div align=\"center\" class=\"padpages\">Trước</div></a></div>", url, typeparam, pageindex - 1, divData);


                sb.Append("<div style=\"clear: both;\"></div>");
                sb.Append("</div>");
            }
            return sb.ToString();
        }

        public static string BuildPagerStyle2(int totalrecord, int irecordofpage, int pageindex, string divData, string className, string classActive, string url, string typeparam, int rshow)
        {
            var sb = new StringBuilder();
            int numberpage;

            if (totalrecord % irecordofpage == 0)
                numberpage = totalrecord / irecordofpage;
            else
                numberpage = (totalrecord / irecordofpage) + 1;

            if (numberpage > 1)
            {
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

                sb.AppendFormat("<div class=\"w685 mgb20\"><div class=\"fl bt_bottom11\"></div><div class=\"ds_bottom2 fl\"><div class=\"pagination\">");
                //sb.AppendFormat("<div class=\"w674\"><div class=\"fl bt_bottom11\"></div><div class=\"ds_bottom2 fl\"><div class=\"pagination\"><p>");
                if (istart)
                {
                    sb.AppendFormat("<a class=\"bt_nobg\" href='javascript:void(0)' onclick=\"PagerCommon('{0}','{1}',{2},'{3}')\"> Trang đầu </a>", url, typeparam, 0, divData);
                }
                for (var i = loopstart; i < loopend; i++)
                {
                    if (pageindex == i)
                    {
                        sb.AppendFormat("<span class='{0}'>", classActive);
                        sb.Append((i + 1).ToString());
                        sb.Append("</span>");
                    }
                    else
                    {
                        sb.AppendFormat("<a onclick=\"PagerCommon('{0}','{1}',{2},'{3}')\" href='javascript:void(0)'>", url, typeparam, i, divData);
                        sb.Append((i + 1).ToString());
                        sb.Append("</a>");
                    }
                }
                if (iend)
                {
                    sb.AppendFormat("<a class=\"bt_nobg\" href='javascript:void(0)' onclick=\"PagerCommon('{0}','{1}',{2},'{3}')\">Trang cuối </a>", url, typeparam, numberpage - 1, divData);
                }
                sb.Append("</div></div><div class=\"bt_bottom33 fl\"></div></div>");
            }
            return sb.ToString();
        }

        public static string BuildPagerScript(int totalrecord, int irecordofpage, int pageindex, string className, string classActive, int rshow,string sType)
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

            //sb.AppendFormat("<div class=\"phantrang\"><p>");
            sb.AppendFormat("<div class=\"phantrang\">");
            if (istart)
            {
                sb.AppendFormat("<a class='truoc' href='javascript:void(0)' onclick='javascript:page(\"{0}\",\"{1}\")'>‹‹</a>", 0, sType);
            }
            if (pageindex >= 1)
                sb.AppendFormat("<a class='truoc' href='javascript:void(0)' onclick='javascript:page(\"{0}\",\"{1}\")'>‹</a>", pageindex - 1,sType);
            for (var i = loopstart; i < loopend; i++)
            {
                if (pageindex == i)
                {
                    sb.AppendFormat("<a class='so {2}' href='javascript:void(0)' onclick='javascript:page(\"{0}\",\"{1}\")'>", i,sType, classActive);
                }
                else
                {
                    sb.AppendFormat("<a class='so {2}' href='javascript:void(0)' onclick='javascript:page(\"{0}\",\"{1}\")'>", i,sType, "");
                }
                sb.Append((i + 1).ToString());
                sb.Append("</a>");
            }
            if (pageindex <= numberpage - 2)
            {
                sb.AppendFormat("<a class='truoc' href='javascript:void(0)' onclick='javascript:page(\"{0}\",\"{1}\")' >›</a>", pageindex + 1,sType);
            }
            if (iend)
                sb.AppendFormat("<a href='javascript:void(0)' onclick='javascript:page(\"{0}\",\"{1}\")' class='truoc'>››</a>", numberpage - 1,sType);


            sb.Append("</p>");
            sb.Append("</div>");

            return sb.ToString();
        }

        /// <summary>
        /// Chặt xâu không bị đứt từ
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutWordLength(string str, int length)
        {
            string[] temp = str.Trim().Split(' ');
            string ret = "";

            if (temp.Length <= length)
            {
                ret = str;
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    ret += temp[i] + " ";
                }
                ret += "...";
            }
            return ret;
        }

        public static string SafeSqlLiteral(System.Object theValue, System.Object theLevel)
        {

            // intLevel represent how thorough the value will be checked for dangerous code
            // intLevel (1) - Do just the basic. This level will already counter most of the SQL injection attacks
            // intLevel (2) -   (non breaking space) will be added to most words used in SQL queries to prevent unauthorized access to the database. Safe to be printed back into HTML code. Don't use for usernames or passwords

            var strValue = (string)theValue;
            var intLevel = (int)theLevel;

            if (strValue == null)
            {
                return strValue;
            }
            if (intLevel > 0)
            {
                strValue = strValue.Replace("'", "''");
                strValue = strValue.Replace("'", "\\'");
                // Most important one! This line alone can prevent most injection attacks
                strValue = strValue.Replace("--", "");
                strValue = strValue.Replace("[", "[[]");
                strValue = strValue.Replace("%", "[%]");
            }
            if (intLevel > 1)
            {
                var myArray = new string[]
                                   {
                                       "xp_ ", "update ", "insert ", "select ", "drop ", "alter ", "create ", "rename "
                                       , "delete ", "replace "
                                   };
                var i = 0;
                var i2 = 0;
                var intLenghtLeft = 0;
                for (i = 0; i < myArray.Length; i++)
                {
                    var strWord = myArray[i];
                    var rx = new Regex(strWord, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    var matches = rx.Matches(strValue);
                    i2 = 0;
                    foreach (Match match in matches)
                    {
                        var groups = match.Groups;
                        intLenghtLeft = groups[0].Index + myArray[i].Length + i2;
                        strValue = strValue.Substring(0, intLenghtLeft - 1) + "&nbsp;" +
                                   strValue.Substring(strValue.Length - (strValue.Length - intLenghtLeft),
                                                      strValue.Length - intLenghtLeft);
                        i2 += 5;
                    }
                }
            }
            return strValue;
        }

        public static string FormatDataInsert(string input)
        {
            input = FillterHtmlTag(input, "script|embed|object|frameset|frame|iframe|meta|link|p|span|img|div|a|hr|style|font");
            input = StripTagsRegexAtt(input);
            return input;
        }
    }
}
