<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Website.UserControl.Menu" %>
<%@ Register src="Search.ascx" tagname="Search" tagprefix="uc1" %>
<div id="navTop" style="MARGIN-BOTTOM: 20px;">
    <ul style="float: left">
        <li><a href="/Default.aspx"  rel="trang-chu"><span <%if(sPath=="~/default.aspx") Response.Write("class=\"active\"");%>>Trang chủ</span ></a></li>
        <li><a href="/cong-ty/default.aspx" rel="gioi-thieu"><span <%if(sPath.StartsWith("~/cong-ty/")) Response.Write("class=\"active\"");%>>Công ty</span></a></li>
        <li><a href="/san-pham/List.aspx" rel="gioi-thieu"><span <%if(sPath.StartsWith("~/san-pham/")) Response.Write("class=\"active\"");%>>Sản phẩm</span></a></li>
        <li><a href="/tuyen-dung/Default.aspx" rel="tuyen-dung"><span <%if(sPath.StartsWith("~/tuyen-dung/")) Response.Write("class=\"active\"");%>>Tuyển dụng</span></a></li>
    </ul>
    <div id="search">
        <uc1:Search ID="Search1" runat="server" />
    </div>
    <div style="clear: left;"></div>
</div>