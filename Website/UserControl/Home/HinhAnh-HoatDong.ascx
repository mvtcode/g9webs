<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HinhAnh-HoatDong.ascx.cs"
    Inherits="Website.UserControl.Home.HinhAnh_HoatDong" %>
<%--
<div class="ProductVideoPrevewTitle">
    Hình ảnh, hoạt động</div>
<div class="ProductVideoPrevew">

    <script>
        str1 = "http://www.youtube.com/watch?v=sxkOFsFgE0c&feature=related";
        str2 = "http://www.youtube.com/watch?v=";
        n = str1.indexOf(str2);
        if (str1.indexOf(str2) == 0) {
            if (str1.indexOf("&amp;") == -1) {
                str = str1.substring(str2.length, str1.length);
            }
            else {
                str = str1.substring(str2.length, str1.indexOf("&amp;"));
            }
            document.write('<center><object width="95%">');
            document.write('<param name="movie" value="http://www.youtube.com/v/' + str + '&amp;ap=%2526fmt=22&amp;hl=en&amp;fs=1&amp;"></param>');
            document.write('<param name="allowFullScreen" value="true"></param>');
            document.write('<param name="allowscriptaccess" value="always"></param>');
            document.write('<embed src="http://www.youtube.com/v/' + str + '&amp;ap=%2526fmt=22&amp;hl=en&amp;fs=1&amp;" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="95%"></embed>');
            document.write('</object></center>');
        } else {
            document.write("<br><center><font color=#ff0000>[<b>admin</b>:</font> <font color=00ff00>link video youtube lỗi, h&#227;y kiểm tra lại</font><font color=ff0000>]</font></center><br>");
        }
    </script>

</div>
<div class="ProductVideoPrevewList">
    <div>
        <ul class="playlist">
            <li><span>1 </span><a href="#"
                title="Khách hàng nói về Hisoft" class="_playItem">Khách hàng nói về Hisoft</a></li>
            <li><span>2 </span><a href="#"
                title="Lễ ký hợp đồng" class="_playItem">Lễ ký hợp đồng</a></li>
            <li><span>3 </span><a href="#"
                title="Lễ cắt băng khánh thành" class="_playItem">Lễ cắt băng khánh thành</a></li>
        </ul>
    </div>
</div>--%>
<div class="Content-hinhanh-hoatdong">
    <a href="/tuyen-dung/Default.aspx"><img width="250" src="/Images/Tuyendung.jpg" /></a>
    <a href="/List.aspx?ID=4"><img width="250" src="/Images/Vanbanphapluat.jpg" style="margin-top: 15px;" /></a>
</div>
