﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminNotAJAX.Master" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="Website.admin.ChangePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Text" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr><td style="height:25px"></td></tr>
        <tr>
            <td style="width:30%"></td>
            <td style="width:15%; text-align:right; padding-right:10px">
                Tên đăng nhập
            </td>
            <td style="width:20%; text-align:left">
                <asp:TextBox ID="txtUsername" runat="server" MaxLength="30" Width="180px"></asp:TextBox>
            </td>
            <td style="width:20%; text-align:left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Chưa nhập tên tài khoản"></asp:RequiredFieldValidator>
            </td>
            <td style="width:15%"></td>
        </tr>
        <tr><td style="height:5px"></td></tr>
        <tr>
            <td style="width:30%"></td>
            <td style="width:15%; text-align:right;padding-right:10px">
                Mật khẩu
            </td>
            <td style="width:20%; text-align:left">
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" MaxLength="30" Width="180px"></asp:TextBox>
            </td>
            <td style="width:20%; text-align:left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass"
                    ErrorMessage="Chưa nhập mật khẩu"></asp:RequiredFieldValidator>
            </td>
            <td style="width:15%"></td>
        </tr>
        <tr><td style="height:5px"></td></tr>
        <tr>
            <td style="width:30%"></td>
            <td style="width:15%; text-align:right;padding-right:10px">
                Nhập lại mật khẩu
            </td>
            <td style="width:20%; text-align:left">
                <asp:TextBox ID="txtRePass" TextMode="Password" runat="server" MaxLength="30" Width="180px"></asp:TextBox>
            </td>
            <td style="width:20%; text-align:left">                
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRePass"
                    ErrorMessage="Nhập lại mật khẩu chưa đúng"></asp:RequiredFieldValidator>           
            </td>
            <td style="width:15%"></td>
        </tr>
        <tr><td style="height:10px"></td></tr>
        <tr><td colspan="5">
            <asp:Button ID="btSubmit" CssClass="button" runat="server" Text="Lưu" OnClick="btSubmit_Click" />
            &nbsp; &nbsp;&nbsp;&nbsp;
            
        </td></tr>
        <tr><td style="height:10px"></td></tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr><td style="height:25px"></td></tr>
    </table>
</asp:Content>
