<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true"
    CodeBehind="profile.aspx.cs" Inherits="Website.user.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUser" runat="server">
    <div>
        <span class="LableText">Tên đăng nhập:</span> <span>
            <asp:TextBox ID="TB_Username" runat="server" Width="150px" ReadOnly="True" /></span>
    </div>
    <div class="RowUser">
        <span class="LableText">Tên đầy đủ:</span> <span>
            <asp:TextBox ID="TB_Fullname" runat="server" Width="150px" MaxLength="30" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="hãy nhập tên đầy đủ"
                ControlToValidate="TB_Fullname">*</asp:RequiredFieldValidator>
        </span>
    </div>
    <div class="RowUser">
        <span class="LableText">Email:</span> <span>
            <asp:TextBox ID="TB_Email" runat="server" MaxLength="100" Width="150px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="hãy nhập địa chỉ email"
                ControlToValidate="TB_Email">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không đúng định dạng"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TB_Email">*</asp:RegularExpressionValidator>
    </div>
    <div class="RowUser">
        <span class="LableText">Điện thoại:</span> <span>
            <asp:TextBox ID="TB_Phone" runat="server" MaxLength="12" Width="150px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Hãy nhập số điện thoại"
                ControlToValidate="TB_Email">*</asp:RequiredFieldValidator>
        </span>
    </div>
    <div class="RowUser">
        <span class="LableText">Công ty:</span> <span>
            <asp:TextBox ID="TB_Company" runat="server" MaxLength="100" Width="150px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="hãy nhập tên công ty"
                ControlToValidate="TB_Company">*</asp:RequiredFieldValidator>
        </span>
    </div>
    <div class="RowUser">
        <span class="LableText">Địa chỉ:</span> <span>
            <asp:TextBox ID="TB_Address" runat="server" MaxLength="100" Width="150px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="hãy nhập địa chỉ"
                ControlToValidate="TB_Address">*</asp:RequiredFieldValidator>
        </span>
    </div>
    <div class="RowUser">
        <span class="LableText">Trang chủ:</span> <span>
            <asp:TextBox ID="TB_HomePage" runat="server" MaxLength="100" Width="150px" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TB_HomePage"
                ErrorMessage="địa chỉ link không chính xác" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?">*</asp:RegularExpressionValidator></span>
    </div>
    <div class="RowUser" style="padding-left: 115px">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Label ID="LB_Msg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="RowUser" style="padding-left: 150px">
        <asp:Button ID="BT_Save" runat="server" Text="Lưu" Width="65px" OnClick="BT_Change_Click" /></div>
</asp:Content>
