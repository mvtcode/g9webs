<%@ Page Title="" Language="C#" MasterPageFile="~/News.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="hisoft.List_News" %>
<%@ Register src="../UserControl/News/TinNoiBat.ascx" tagname="TinNoiBat" tagprefix="uc1" %>
<%@ Register src="../UserControl/News/TinMoiNhat.ascx" tagname="TinMoiNhat" tagprefix="uc2" %>
<%@ Register src="../UserControl/News/TinDoc.ascx" tagname="TinDoc" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNews" runat="server">
    <div class="boxtinkinhtenoibat">
        <div class="tinnoibatnhat">            
            <uc1:tinnoibat ID="TinNoiBat1" runat="server" />            
        </div>
        <div class="tinmoinhat">            
            <uc2:tinmoinhat ID="TinMoiNhat1" runat="server" />            
        </div>
    </div>
    <div class="clear" id="trangtin"></div>
    <uc4:tindoc ID="TinDoc1" runat="server" />
</asp:Content>
