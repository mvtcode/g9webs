<%@ Page Title="Tạo tài khoản - G9" Language="C#" MasterPageFile="~/News.master" AutoEventWireup="true"
    CodeBehind="register.aspx.cs" Inherits="Website.user.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNews" runat="server">
    <form runat="server">
    <div style="padding-top: 15px;padding-bottom: 15px; text-align: center; font-weight: bold; font-size: 12px">Tạo tài khoản mới</div>
    <div class="RowUser">
        <span class="LableText">Tên đăng nhập:</span> <span>
            <asp:TextBox ID="TB_Username" runat="server" Width="150px" /></span>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TB_Username"
            ErrorMessage="hãy nhập tên đăng nhập">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TB_Username"
            ErrorMessage="Tên đăng nhập là các chữ in thường và số, chiều dài 4-20 ký tự"
            ValidationExpression="[a-z][a-z0-9]{4,20}">*</asp:RegularExpressionValidator>
    </div>
    <div class="RowUser">
        <span class="LableText">Tên đầy đủ:</span> <span>
            <asp:TextBox ID="TB_Fullname" runat="server" Width="150px" MaxLength="30" /></span>
        <span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Hãy nhập tên đầy đủ"
                ControlToValidate="TB_Fullname">*</asp:RequiredFieldValidator>
        </span>
    </div>
    <div class="RowUser">
        <span class="LableText">Mật khẩu:</span> <span>
            <asp:TextBox ID="TB_Password" runat="server" TextMode="Password" Width="150px" /></span>
        <span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="hãy nhập mật khẩu mới"
                ControlToValidate="TB_Password">*</asp:RequiredFieldValidator>
        </span>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TB_Password"
            ControlToValidate="TB_configpass" EnableViewState="False" 
            ErrorMessage="Mật khẩu mới và xác nhận mật khẩu phải giống nhau">*</asp:CompareValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="TB_Password" ErrorMessage="mật khẩu phải từ 6 - 30 ký tự" 
            ValidationExpression=".{6,30}">*</asp:RegularExpressionValidator>
    </div>
    <div class="RowUser">
        <span class="LableText">Xác nhận mật khẩu:</span> <span>
            <asp:TextBox ID="TB_configpass" runat="server" TextMode="Password" Width="150px" /></span>
        <span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="hãy nhập xác nhận mật khẩu"
                ControlToValidate="TB_configpass">*</asp:RequiredFieldValidator>
        </span>
    </div>
    <div class="RowUser">
        <span class="LableText">Email:</span> <span>
            <asp:TextBox ID="TB_Email" runat="server" MaxLength="100" Width="150px" /></span>
        <span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="hãy nhập email"
                ControlToValidate="TB_Email">*</asp:RequiredFieldValidator>
        </span>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không đúng định dạng"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TB_Email">*</asp:RegularExpressionValidator>
    </div>
    <div class="RowUser">
        <span class="LableText">Điện thoại:</span> <span>
            <asp:TextBox ID="TB_Phone" runat="server" MaxLength="12" Width="150px" /></span>
        <span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Hãy nhập số điện thoại"
                ControlToValidate="TB_Phone">*</asp:RequiredFieldValidator>
        </span>
    </div>
    <div class="RowUser">
        <span class="LableText">Công ty:</span> <span>
            <asp:TextBox ID="TB_Company" runat="server" MaxLength="100" Width="150px" /></span>
        <span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Hãy nhập tên công ty"
                ControlToValidate="TB_Company">*</asp:RequiredFieldValidator>
        </span>
    </div>
    <div class="RowUser">
        <span class="LableText">Địa chỉ:</span> <span>
            <asp:TextBox ID="TB_Address" runat="server" MaxLength="100" Width="150px" /></span>
        <span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="hãy nhập địa chỉ"
                ControlToValidate="TB_Address">*</asp:RequiredFieldValidator>
        </span>
    </div>
    <div class="RowUser">
        <span class="LableText">Trang chủ:</span> <span>
            <asp:TextBox ID="TB_HomePage" runat="server" MaxLength="100" Width="150px" /></span>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TB_HomePage"
            ErrorMessage="địa chỉ link không chính xác" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?">*</asp:RegularExpressionValidator>
    </div>
    <div class="RowUser" style="padding-left: 115px">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Label ID="LB_Msg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="RowUser" style="padding-left: 150px;padding-bottom: 15px">
        <asp:Button ID="BT_Save" runat="server" Text="Lưu" Width="65px" OnClick="BT_Change_Click" /></div>
    </form>
</asp:Content>
