<%@ Page Title="Thay đổi mật khẩu - G9" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true"
    CodeBehind="changepass.aspx.cs" Inherits="Website.user.changepass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUser" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div style="padding-top: 15px;padding-bottom: 10px; text-align: center; font-weight: bold; font-size: 12px">Thay đổi mật khẩu</div>
            <div>
                <span class="LableText">Mật khẩu cũ:</span> <span>
                    <asp:TextBox ID="OldPass" runat="server" TextMode="Password" 
                    Width="150px" /></span> <span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="hãy nhập mật khẩu cũ"
                            ControlToValidate="OldPass">*</asp:RequiredFieldValidator>
                    </span>
            </div>
            <div class="RowUser">
                <span class="LableText">Mật khẩu mới:</span> <span>
                    <asp:TextBox ID="NewPass" runat="server" TextMode="Password" 
                    Width="150px" /></span> <span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="hãy nhập mật khẩu mới"
                            ControlToValidate="NewPass">*</asp:RequiredFieldValidator>
                    </span>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="NewPass" ControlToValidate="configpass" 
                    EnableViewState="False" 
                    ErrorMessage="Mật khẩu mới và xác nhận mật khẩu phải giống nhau">*</asp:CompareValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="NewPass" ErrorMessage="mật khẩu phải từ 6 - 30 ký tự" 
            ValidationExpression=".{6,30}">*</asp:RegularExpressionValidator>
            </div>
            <div class="RowUser">
                <span class="LableText">Xác nhận:</span> <span>
                    <asp:TextBox ID="configpass" runat="server" TextMode="Password" 
                    Width="150px" /></span> <span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="hãy nhập xác nhận mật khẩu"
                            ControlToValidate="configpass">*</asp:RequiredFieldValidator>
                    </span>
            </div>
            <div class="RowUser" style="padding-left: 115px">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <asp:Label ID="LB_Msg" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="RowUser" style="padding-left: 150px">
                <asp:Button ID="BT_Change" runat="server" Text="Lưu" Width="65px" OnClick="BT_Change_Click" /></div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BT_Change" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
