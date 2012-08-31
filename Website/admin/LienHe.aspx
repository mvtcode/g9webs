<%@ Page Title="" Language="C#" MasterPageFile="~/admin/master_default.master" AutoEventWireup="true" CodeBehind="LienHe.aspx.cs" Inherits="Website.admin.LienHe" %>
<%@ Register Namespace="CKEditor.NET" Assembly="CKEditor.NET" TagPrefix="ck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <div style="margin:0px auto;width: 800px">
        <ck:CKEditorControl runat="server" BasePath="../Content/ckeditor" ID="Content" FilebrowserBrowseUrl="../Content/ckfinder/ckfinder.html"
                                    Height="240px" Width="100%"></ck:CKEditorControl>
    </div>
    <div style="padding: 15px 0px">
        <asp:Button ID="BT_Save" runat="server" Text="Save" Width="65px" 
                                    OnClick="BT_Save_Click" CssClass="button" />
    </div>
</asp:Content>
