<%@ Page Title="Đăng nhập - G9 Việt Nam" Language="C#" MasterPageFile="~/News.master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="Website.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNews" runat="server">
    <form runat="server">
    <div style="text-align: center">
        <div style="padding-top: 15px; text-align: center; font-weight: bold; font-size: 12px">Đăng nhập</div>
        <div style="padding-top: 15px">
            <span style="text-align: right;display: inline-block;width: 80px">Tài khoản:</span> <span>
                <asp:TextBox ID="username" runat="server" AutoCompleteType="Disabled" /></span>
            <span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="hãy nhập mật khẩu cũ"
                    ControlToValidate="password">*</asp:RequiredFieldValidator>
            </span>
        </div>
        <div class="RowUser">
            <span style="text-align: right;display: inline-block;width: 80px">Mật khẩu:</span> <span>
                <asp:TextBox ID="password" runat="server" TextMode="Password" /></span> <span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="hãy nhập mật khẩu mới"
                        ControlToValidate="username">*</asp:RequiredFieldValidator>
                </span>
        </div>
        <div class="RowUser" style="padding-left: 115px">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Label ID="LB_Msg" runat="server" ForeColor="Red"></asp:Label>
    </div>
        <div class="RowUser" style="padding-bottom: 15px">
            <asp:Button ID="BT_Login" runat="server" Text="Đăng nhập" Width="85px" OnClick="BT_Login_Click" /></div>
    </div>
    <div style="text-align: center;padding-bottom: 15px" class="RowUser">
        <a href="LostPass.aspx">Quên mật khẩu</a> | <a href="register.aspx">Đăng ký tài khoản</a></div>
    </form>
</asp:Content>
