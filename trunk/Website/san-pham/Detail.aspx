<%@ Page Title="" Language="C#" MasterPageFile="~/News.master" AutoEventWireup="true"
    CodeBehind="Detail.aspx.cs" Inherits="hisoft.Detail_Sanpham" %>
<%@ Register src="../UserControl/SanPham/Tab.ascx" tagname="Tab" tagprefix="uc3" %>
<%@ Register src="../UserControl/SanPham/other.ascx" tagname="other" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNews" runat="server">
    <link href="../CSS/tab.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $(".tabContents").hide(); // Ẩn toàn bộ nội dung của tab
            $(".tabContents:first").show(); // Mặc định sẽ hiển thị tab1

            $("#tabtitle ul li a").click(function() { //Khai báo sự kiện khi click vào một tab nào đó
                var activeTab = $(this).attr("href");
                $("#tabtitle ul li a").removeClass("active");
                $(this).addClass("active");
                $(".tabContents").hide();
                $(activeTab).fadeIn();
            });
        });
    </script>
    <%=sContent%>
    <uc3:Tab ID="Tab1" runat="server" />
    <uc4:other ID="other1" runat="server" />
</asp:Content>
