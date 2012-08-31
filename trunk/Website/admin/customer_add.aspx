<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminNotAJAX.Master" AutoEventWireup="true" CodeBehind="customer_add.aspx.cs" Inherits="Website.admin.customer_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Text" runat="server">
    <script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var sPage = "ctl00_ContentPlaceHolder_Main_";

        function ShowPupup() {
            var newWin = window.open("UploadImage.aspx?URL=" + $("#" + sPage + "HD_IMG").val(), "PopupWin", "width=644px, height=400px, status=yes,scrollbars=yes");
            newWin.focus();
            return false;
        }
        
        function Load_Image(url, thumb) {
            $("#" + sPage + "HD_IMG").val(url);
            if (url != "") {
                $("#" + sPage + "IMG").attr("src", thumb);
            }
            else {
                $("#" + sPage + "IMG").attr("src", "");
            }
        }
    </script>
        
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr><td style="height:25px"></td></tr>  
        <tr>           
            <td style="width:15%; text-align:right; padding-right:10px">
                Tên khách hàng
            </td>
            <td style="width:20%; text-align:left">
               <asp:TextBox ID="txtName" runat="server" MaxLength="200" Width="450px"></asp:TextBox>       
            </td>
            <td style="width:20%; text-align:left">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Tiêu đề tin không được trống"></asp:RequiredFieldValidator>
            </td>
            <td style="width:15%"></td>
        </tr>        
        <tr><td style="height:10px"></td></tr>
        <tr>
            <td style="width:15%; text-align:right; padding-right:10px">
                Địa chỉ
            </td>
            <td style="width:20%; text-align:left">
                <asp:TextBox ID="txtAddress" runat="server" Width="450px" 
                    Wrap="true"></asp:TextBox>
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr> 
        <tr><td style="height:10px; width: 15%;"></td></tr>
        <tr>            
            <td style="width:15%; text-align:right; padding-right:10px">
                Email
            </td>
            <td style="width:20%; text-align:left">
                <asp:TextBox ID="txtEmail" runat="server"  Width="450px" 
                     Wrap="true"></asp:TextBox>
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr> 
        <tr><td style="height:10px; width: 15%;"></td></tr>
        <tr>            
            <td style="width:15%; text-align:right; padding-right:10px">
                Mobile
            </td>
            <td style="width:20%; text-align:left">
                <asp:TextBox ID="txtMobile" runat="server"  Width="450px" 
                     Wrap="true"></asp:TextBox>
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr> 
        <tr><td style="height:10px; width: 15%;"></td></tr>
        <tr>            
            <td style="width:15%; text-align:right; padding-right:10px">
                Homepage
            </td>
            <td style="width:20%; text-align:left">
                <asp:TextBox ID="txtHomepage" runat="server"  Width="450px" 
                     Wrap="true"></asp:TextBox>
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr> 
        <tr><td style="height:10px; width: 15%;"></td></tr>        
        <tr>            
            <td style="width:15%; text-align:right; padding-right:10px">
                Ảnh đại diện
            </td>
            <td style="width:20%; text-align:left">
                <asp:Image ID="IMG" runat="server" ImageUrl="~/Images/NoImage.jpg" Width="150px" />
                <div>
                    <br />
                    <input type="hidden" runat="server" id="HD_IMG" value="" />
                    <asp:Button ID="BT_IMG" runat="server" Text="Load Image" CssClass="button" />
                </div>
                <%--<input runat="server" id="fUpload" type="file" />--%>
            </td>
            <td style="width:20%; text-align:left">                
            </td>
            <td style="width:15%"></td>
        </tr> 
        <tr><td style="height:10px; width: 15%;"></td></tr>        
        <tr><td colspan="2">
            <asp:Button ID="btSubmit" CssClass="button" runat="server" Text="Lưu" OnClick="btSubmit_Click" />
            &nbsp; &nbsp;&nbsp;&nbsp;    
        </td>
        <td></td>
        <td></td>
        </tr>
        <tr><td style="height:10px"></td></tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr><td style="height:25px"></td></tr>
    </table>
</asp:Content>
