<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Banner.ascx.cs" Inherits="Website.UserControl.Banner" %>
<%@ Register src="user.ascx" tagname="user" tagprefix="uc1" %>
<div class="header" style="width: 100%;height: 110px;">
    <div class="logo">
        <img src="/Images/Logo.png" />
    </div>
    <uc1:user ID="user1" runat="server" />
    <div style="float: left;padding-top: 40px"><h1>CÔNG TY CỔ PHẦN ĐẦU TƯ THƯƠNG MẠI G9 VIỆT NAM</h1></div>
    <div class="clear"></div>
</div>
