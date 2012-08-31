<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImageProduct.aspx.cs" Inherits="Website.admin.UploadImageProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>    
    <style type="text/css">
        .apDiv {
	        margin:6px 6px auto auto;
	        padding:6px;
	        width:100px;
	        height: 120px;
	        float:left;
	        border:#c0c0c0 1px solid;
	        overflow:hidden;        	
        }
        .divContent
        {
	        width: auto;
	        height: auto;
	        background:	white;
	        padding:5px;
	        margin:0 auto;      
	        
        }
    </style>
    <script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function SelectImage(sName,thumb) {
            if (sName != "") {
                if (opener) {                    
                    opener.Load_Image(sName,thumb);
                    window.close();
                    opener.focus();
                }
            }
        }
        function winclose() {
            window.close();
            return false;
        }

        function CheckURL() {
            $("#SP_URL").css('display', 'inline');
            if ($("#TB_URL").val() == "") {
                $("#SP_URL").css('display', 'inline');
            }
            else {
                SelectImage($("#TB_URL").val(), $("#TB_URL").val());
            }
            return false;
        }

        function TB_URL_Keypress(e) {
            var kCode = e.keyCode ? e.keyCode : e.charCode;
            //var kChar = String.fromCharCode(kCode);
            if(kCode == 13){
                $("#BT_Select").click();
            }
        }
    </script>
</head>
<body style="margin:6px">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="2" cellspacing="0">
            <tr>
                <td width="150" style="white-space:nowrap">Thêm ảnh từ máy tính:</td>
                <td style="padding-left: 10px;" width="100%">
                    <asp:FileUpload ID="File_Upload"
            runat="server" Width="380px" /></td>
                <td style="padding-left: 10px"><asp:Button ID="BT_Upload" runat="server" Text="Upload" Width="55px" OnClick="BT_Upload_Click" /></td>
            </tr>
            <tr>
                <td style="white-space:nowrap">Hoặc chọn địa chỉ ảnh:</td>
                <td style="padding-left: 10px"><asp:TextBox ID="TB_URL" runat="server" 
                        Width="380px"/><span id="SP_URL"
                                        style="display: none; color: Red"> *</span></td>
                <td style="padding-left: 10px"><asp:Button ID="BT_Select" runat="server" Text="OK" Width="55px" /></td>
            </tr>
        </table>
    </div>
    <div><hr /></div>
    <div id="FileContent" runat="server"></div>
    </form>
</body>
</html>

