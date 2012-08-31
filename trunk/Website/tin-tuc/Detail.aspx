<%@ Page Title="" Language="C#" MasterPageFile="~/News.master" AutoEventWireup="true"
    CodeBehind="Detail.aspx.cs" Inherits="hisoft.Detail_News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNews" runat="server">
    <div id="chitiettinbao" style="padding-top: 10px;">
        <h2>
            <%=sTitle%></h2>
        <div class="noidung_chitiet">
            <strong><%= sDescription%></strong>
            <p>
                <%=sContent%>
            </p>
        </div>
        <%=sOther%>
    </div>
</asp:Content>
