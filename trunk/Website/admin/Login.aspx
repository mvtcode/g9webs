<%@ Page Title="" Language="C#" MasterPageFile="~/admin/master_default.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Website.admin.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script type="text/javascript">
        var page = "ctl00_ContentPlaceHolder_Main_";
        $(document).ready(function() {
            $("#" + page + "txtUsername").focus();
        });        
    </script>

    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="text-align: center">   
        <tr><td colspan="5" style="text-align:center">
        <h3>Đăng nhập hệ thống</h3>
        </td></tr>
        <tr>
            <td style="width:35%"></td>
            <td style="width:10%; text-align:right">
                Tên đăng nhập
            </td>
            <td style="width:20%">
                <asp:TextBox ID="txtUsername" runat="server" MaxLength="30" Width="180px" 
                    AutoCompleteType="Disabled"></asp:TextBox>
            </td>
            <td style="width:20%">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Chưa nhập tên tài khoản"></asp:RequiredFieldValidator>
            </td>
            <td style="width:15%"></td>
        </tr>
        <tr><td style="height:10px"></td></tr>
        <tr>
            <td></td>
            <td style="text-align:right">
               Mật khẩu
            </td>
            <td>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" MaxLength="30" Width="180px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Chưa nhập mật khẩu"></asp:RequiredFieldValidator>
            </td>
            <td></td>
        </tr>
        <tr><td style="height:10px"></td></tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Button CssClass="button" ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />
            </td>
        </tr>
        <tr><td style="height:10px"></td></tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr><td style="height:10px"></td></tr>        
    </table>
</asp:Content>
