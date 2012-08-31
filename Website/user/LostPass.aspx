<%@ Page Title="Thông tin tài khoản - G9 Việt Nam" Language="C#" MasterPageFile="~/News.master" AutoEventWireup="true" CodeBehind="LostPass.aspx.cs" Inherits="Website.user.LostPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNews" runat="server">
    <form id="Form1" runat="server">
    <div style="text-align: center">
        <div style="padding-top: 15px; text-align: center; font-weight: bold; font-size: 12px">Gửi lại thông tin Password</div>
        <div style="padding-top: 15px">
            <span style="text-align: right;display: inline-block;width: 80px">Tài khoản:</span> <span>
                <asp:TextBox ID="username" runat="server" AutoCompleteType="Disabled" 
                Width="150px" /></span>
            <span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="hãy nhập tên tài khoản đăng nhập"
                    ControlToValidate="username">*</asp:RequiredFieldValidator>
            </span>
        </div>
        <div class="RowUser">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <asp:Label ID="LB_Msg" runat="server" ForeColor="Red"></asp:Label>
            </div>
        <div class="RowUser" style="padding-bottom: 15px">
            <asp:Button ID="BT_Login" runat="server" Text="Gửi" Width="65px" 
                OnClick="BT_Login_Click" /></div>
    </div>
    </form>
</asp:Content>
