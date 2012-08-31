<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminNotAJAX.Master" AutoEventWireup="true"
    CodeBehind="newtype_add.aspx.cs" Inherits="Website.admin.newtype_add" %>

<%@ Register Namespace="CKEditor.NET" Assembly="CKEditor.NET" TagPrefix="ck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Text" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 15%; text-align: right; padding-right: 10px">
                Tên loại tin
            </td>
            <td style="width: 20%; text-align: left">
                <asp:TextBox ID="txtName" runat="server" MaxLength="200" Width="450px"></asp:TextBox>
            </td>
            <td style="width: 20%; text-align: left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Tiêu đề tin không được trống"></asp:RequiredFieldValidator>
            </td>
            <td style="width: 15%">
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btSubmit" CssClass="button" runat="server" Text="Lưu" OnClick="btSubmit_Click" />
                &nbsp; &nbsp;&nbsp;&nbsp;
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 25px">
            </td>
        </tr>
    </table>
</asp:Content>
