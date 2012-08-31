<%@ Page Title="" Language="C#" MasterPageFile="~/News.master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="Website.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNews" runat="server">
    <div style="color: #333333; padding: 10px 10px 10px 0px">
        <h2>
            <%=sTitle %></h2>
    </div>
    <%=sContent%>
    <div class="clear">
    </div>
    <%=sPhantrang%>
</asp:Content>
