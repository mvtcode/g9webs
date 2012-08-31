<%@ Page Title="Công ty cổ phần đầu tư thương mại G9 Việt Nam - Phần mềm Quản lý bán hàng - Phần mềm quản lý thuốc - Phần mềm kế toán - www.g9vietnam.com.vn" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="hisoft.Default1" %>

<%@ Register Src="UserControl/Home/Slider.ascx" TagName="Slider" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Home/LienHe.ascx" TagName="LienHe" TagPrefix="uc2" %>
<%@ Register Src="UserControl/Home/News.ascx" TagName="News" TagPrefix="uc3" %>
<%@ Register Src="UserControl/Home/SanPham.ascx" TagName="SanPham" TagPrefix="uc4" %>
<%@ Register Src="UserControl/Home/HinhAnh-HoatDong.ascx" TagName="HinhAnh" TagPrefix="uc5" %>
<%@ Register Src="UserControl/Home/Visited.ascx" TagName="Visited" TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/default-slider.css" rel="stylesheet" type="text/css" />
    <link href="CSS/nivo-slider.css" rel="stylesheet" type="text/css" />
    <link href="CSS/style-slider.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery.nivo.slider.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="AdsTop">
        <div class="PicAdsTop">
            <uc1:Slider ID="Slider1" runat="server" />
        </div>
        <div class="HelpInfo">
            <uc2:LienHe ID="LienHe1" runat="server" />
        </div>
    </div>
    <div class="AdsNews">
        <div class="NewsBox">
            <uc3:News ID="News1" runat="server" />
        </div>
        <div class="NewsBox">
            <uc3:News ID="News2" runat="server" />
        </div>
        <div class="NewsBox">
            <uc3:News ID="News3" runat="server" />
        </div>
        <div class="NewsBox" style="border-right: none">
            <uc3:News ID="News4" runat="server" />
        </div>
    </div>
    <div class="ProductBox">
        <div class="ProductPrevewBox">
            <div class="ProductPrevewTitle">
                Sản phẩm</div>
            <div class="ProductPrevewDetail">
                <uc4:SanPham ID="SanPham1" runat="server" />
            </div>
        </div>
        <div class="ProductAndVisited">
            <div class="ProductVideoPrevewBox">
                <uc5:HinhAnh ID="HinhAnh1" runat="server" />
            </div>
            <div class="VisitedBox">
                <div class="VisitedTitle">
                    Thống kê truy cập</div>
                <div class="VisitedDetail">
                    <uc6:Visited ID="Visited1" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
