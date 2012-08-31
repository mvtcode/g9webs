<%@ Page Title="" Language="C#" MasterPageFile="~/News.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Website.tuyen_dung.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNews" runat="server">
    <div id="chitiettinbao" style="padding-top: 10px;padding-bottom: 8px">
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
    <%--
    <h2>
        <%=sTitle %></h2>
    <p>
        <span class="vitri">
            <%=sDescription %></span><br />
        <%=sContent %>
        <%=sOther %>--%>
</asp:Content>
