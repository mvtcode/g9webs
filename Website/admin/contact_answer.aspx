<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminNotAJAX.Master" AutoEventWireup="true" CodeBehind="contact_answer.aspx.cs" Inherits="Website.admin.contact_answer" %>
<%@ Register Namespace="CKEditor.NET" Assembly="CKEditor.NET" TagPrefix="ck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Text" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr><td style="height:25px"></td></tr>   
        <tr>           
            <td style="width:15%; text-align:right; padding-right:10px">
                Name
            </td>
            <td style="width:20%; text-align:left">
               <asp:TextBox ID="txtName" runat="server" MaxLength="200" Width="450px"></asp:TextBox>       
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr>        
        <tr><td style="height:10px"></td></tr>
        <tr>           
            <td style="width:15%; text-align:right; padding-right:10px">
                Email
            </td>
            <td style="width:20%; text-align:left">
               <asp:TextBox ID="txtEmail" runat="server" MaxLength="200" Width="450px"></asp:TextBox>       
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr>        
        <tr><td style="height:10px"></td></tr>
        <tr>           
            <td style="width:15%; text-align:right; padding-right:10px">
                Adress
            </td>
            <td style="width:20%; text-align:left">
               <asp:TextBox ID="txtAdress" runat="server" MaxLength="200" Width="450px"></asp:TextBox>       
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr>        
        <tr><td style="height:10px"></td></tr>
        <tr>           
            <td style="width:15%; text-align:right; padding-right:10px">
                Company
            </td>
            <td style="width:20%; text-align:left">
               <asp:TextBox ID="txtCompany" runat="server" MaxLength="200" Width="450px"></asp:TextBox>       
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr>        
        <tr><td style="height:10px"></td></tr>
        <tr>           
            <td style="width:15%; text-align:right; padding-right:10px">
                Phone
            </td>
            <td style="width:20%; text-align:left">
               <asp:TextBox ID="txtPhone" runat="server" MaxLength="200" Width="450px"></asp:TextBox>       
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr>        
        <tr><td style="height:10px"></td></tr>
        <tr>           
            <td style="width:15%; text-align:right; padding-right:10px">
              Fax
            </td>
            <td style="width:20%; text-align:left">
               <asp:TextBox ID="txtFax" runat="server" MaxLength="200" Width="450px"></asp:TextBox>       
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr>        
        <tr><td style="height:10px"></td></tr>
         <tr>           
            <td style="width:15%; text-align:right; padding-right:10px">
              Tiêu đề
            </td>
            <td style="width:20%; text-align:left">
               <asp:TextBox ID="txtTitle" runat="server" MaxLength="200" Width="450px"></asp:TextBox>       
            </td>
            <td style="width:20%; text-align:left">
            </td>
            <td style="width:15%"></td>
        </tr>        
        <tr><td style="height:10px"></td></tr>
        <tr>            
            <td style="width:19%; text-align:right;padding-right:10px">
                Nội dung             </td>
            <td style="text-align:left" colspan="2">               
            </td>
            <td style="width:20%; text-align:left">                
            </td>
            <td style="width:15%"></td>
        </tr>        
        <tr>            
            <td colspan="4" style="width:19%; text-align:right;padding-right:10px">
               <ck:CKEditorControl runat="server" BasePath="../Content/ckeditor" ID="Content" FilebrowserBrowseUrl="../Content/ckfinder/ckfinder.html"
                            Height="300px" Width="100%"></ck:CKEditorControl>
            </td>             
        </tr>        
        <tr><td style="height:10px"></td></tr>
        <tr>            
            <td style="width:19%; text-align:right;padding-right:10px">
                Trả lời             </td>
            <td style="text-align:left" colspan="2">               
            </td>
            <td style="width:20%; text-align:left">                
            </td>
            <td style="width:15%"></td>
        </tr>        
        <tr>            
            <td colspan="4" style="width:19%; text-align:right;padding-right:10px">
               <ck:CKEditorControl runat="server" BasePath="../Content/ckeditor" ID="txtAnswer" FilebrowserBrowseUrl="../Content/ckfinder/ckfinder.html"
                            Height="300px" Width="100%"></ck:CKEditorControl>
            </td>             
        </tr>        
        <tr><td style="height:10px"></td></tr>
        <tr><td colspan="2">
            <asp:Button ID="btSubmit" CssClass="button" runat="server" Text="Trả lời" OnClick="btSubmit_Click" />
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
