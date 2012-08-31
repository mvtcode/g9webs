<%@ Page Title="" Language="C#" MasterPageFile="~/admin/master_default.master" AutoEventWireup="true"
    CodeBehind="product_manager.aspx.cs" Inherits="Website.admin.product_manager" %>

<%@ Register Namespace="CKEditor.NET" Assembly="CKEditor.NET" TagPrefix="ck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <style>
        .phantrang
        {
            color:White;
            background-color:#61a0e6;
            margin-top: 10px;
        }
        .phantrang a
        { text-decoration: none;
        	}
        .table_bangbentrai tr
        {   
        	height:30px;     	
        	}
        .table_bangbentrai tr td a
        {   
        	text-decoration:none;        		
        	padding-left:10px;        	
        	}		
        .table_bangbentrai tr td
        {   
        	
        	}	
        .phantrang a:hover
        {   
        	text-decoration:underline;
        	}	
        .so
        {
            padding:5px 5px;      
            color:#0000FF;
            font-weight:bold;
        }
        .truoc
        {
        	font-size:20px;  
        	color:#0000FF;
            font-weight:bold;    	
        	}
        .chon
        {
            color: White;
            font-weight: bold;
        }
        .Page
        {
            color: White;
        }
    </style>

    <script src="../js/jquery.min.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        var sPage = "ctl00_ContentPlaceHolder_Main_";
        function confirmDelete(id) {
            if (confirm("Bạn có muốn xóa sản phẩm này không?")) {
                $("#" + sPage + "DIV_2").css('display', 'none');
                HideMessenger();
                $("#" + sPage + "HD_ID").val(id);
                $("#" + sPage + "IMGBT_Delete").click();
                return true;
            }
            else
                return false;
        }

        function Edit(id) {
            $("#" + sPage + "HD_ID").val(id);
            $("#" + sPage + "IMGBT_Edit").click();
        }

        function HideMessenger() {
            $("#" + sPage + "LB_Messenger").text("");
        }

        function CheckData() {
            $("#" + sPage + "LB_Error").html("");

            $("#SP_Name").css('display', 'none');
            $("#SP_Description").css('display', 'none');
            var sMSG = "";
            if ($("#" + sPage + "TB_Name").val() == "") {
                $("#SP_Name").css('display', 'inline');
                sMSG += "<br>&nbsp;&nbsp;Tên sản phẩm";
            }
            if ($("#" + sPage + "TB_Description").val() == "") {
                $("#SP_Description").css('display', 'inline');
                sMSG += "<br>&nbsp;&nbsp;thông tin tả sản phẩm";
            }
            if (sMSG != "") {
                $("#" + sPage + "LB_Error").html("<b>Hãy kiểm tra lại:</b>" + sMSG);

                document.getElementById("TBL_Detail").scrollIntoView();
                return false;
            }

            $("#" + sPage + "IMGBT_Save").click();
            return false;
            //return true;
        }

        function ShowPupup() {
            var newWin = window.open("UploadImage.aspx?type=product&URL=" + $("#" + sPage + "HD_IMG").val(), "PopupWin", "width=644px, height=400px, status=yes,scrollbars=yes");
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

        function page(iPage, sType) {
            if (sType == "type") {
                $("#" + sPage + "HD_PageType").val(iPage);
                $("#" + sPage + "IMGBT_PageType").click();
            }
            if (sType == "product") {
                $("#" + sPage + "HD_Page").val(iPage);
                $("#" + sPage + "IMGBT_Page").click();
            }        
        }

        function setPosition() {
            $("#DIV_Process").offset({ top: parseInt($("#TBL_Main")[0].offsetHeight) / 2, left: parseInt($("#TBL_Main")[0].offsetLeft + $("#TBL_Main")[0].offsetWidth - 100) / 2 + 200 });
        }

        $(document).ready(function() {
            setPosition();
        });

        function SetFocus(i) {
            if (i == 1) {
                window.setTimeout("_SetFocusType();", 100);
            }
            else {
                window.setTimeout("_SetFocus();", 100);
            }
        }

        function _SetFocusType() {
            document.getElementById("TBL_Detail").scrollIntoView();
            $("#" + sPage + "TB_ProductNameType").focus();
        }
    </script>

    <table id="TBL_Main" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center">
                <%-- Thông tin sản phẩm--%>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="height: auto" valign="top">
                                    <table style="width: 100%;" cellspacing="0" cellpadding="0" border="0px">
                                        <tr>
                                            <td style="width: 24px;" valign="top" align="right">
                                                <img alt="" style="border: 0px" src="images/goc.gif" />
                                            </td>
                                            <td align="left" style="background-image: url(images/canhtren.gif)">
                                                &nbsp;
                                            </td>
                                            <td style="width: 24px;" valign="top" align="right">
                                                <img alt="" style="border: 0px" src="images/goc2.gif" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-left: 4px solid #3B78AE;">
                                            </td>
                                            <td>
                                                <table cellspacing="0" cellpadding="4" border="0" style="background-color: White;
                                                    border-color: #16538C; border-width: 1px; border-style: Solid; width: 100%; border-collapse: collapse;" id="GV_Product">
                                                    <tbody class="table_bangbentrai">
                                                        <tr style="background-color: rgb(35, 96, 164); font-weight: bold; color: White;">
                                                            <td scope="col">
                                                                Hình ảnh
                                                            </td>
                                                            <td scope="col">
                                                                Tên sản phẩm
                                                            </td>
                                                            <td scope="col">
                                                                Mô tả
                                                            </td>
                                                            <td scope="col">
                                                                Giá
                                                            </td>
                                                            <td scope="col">
                                                                Thứ tự
                                                            </td>
                                                            <td scope="col">
                                                                Ngày tạo
                                                            </td>
                                                            <td scope="col">
                                                                Quản lý Tab
                                                            </td>
                                                            <td scope="col">
                                                                Active
                                                            </td>
                                                            <td scope="col">
                                                                Sửa
                                                            </td>
                                                            <td scope="col">
                                                                Xóa
                                                            </td>
                                                        </tr>
                                                        <%=sProducHTML%>
                                                    </tbody>
                                                </table>
                                                <%=sPage %>
                                            </td>
                                            <td style="border-right: 4px solid #3B78AE;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="border-bottom: 2px solid #3B78AE;">
                                                <div style="float: left;">
                                                    <img alt="" style="border: 0px" src="images/goc1.gif" /></div>
                                                <div style="float: right;">
                                                    <img alt="" style="border: 0px" src="images/goc3.gif" /></div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding:6px 6px 6px 0px" align="left">
                                    <asp:Button ID="BT_Add" runat="server" Text="Add" Width="65px" OnClick="BT_Add_Click"
                                        CssClass="button" />
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="LB_Messenger" runat="server" Text=""></asp:Label>
                                    <input type="hidden" id="HD_Page" name="HD_Page" runat="server" value="" />
                                    <input type="hidden" id="HD_ID" name="HD_ID" runat="server" value="" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BT_Add" EventName="Click" />
                        <%--<asp:AsyncPostBackTrigger ControlID="BT_Save" EventName="Click" />--%>
                        <asp:AsyncPostBackTrigger ControlID="IMGBT_Edit" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="IMGBT_Delete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="padding: 6px 6px 6px 6px;" align="left">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div id="DIV_2" runat="server">
                            <fieldset style="width: 99%; padding-right: 6px; padding-left: 6px; padding-bottom: 6px;
                                padding-top: 6px">
                                <legend>
                                    <asp:Label ID="LB_Title" runat="server" Text="Thêm/Sửa thông tin sản phẩm"></asp:Label></legend>
                                <table id="TBL_Detail" border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse"
                                    width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="LB_Error" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Tên sản phẩm:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TB_Name" runat="server" MaxLength="200" Width="300px"></asp:TextBox><span
                                                id="SP_Name" style="display: none; color: Red">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mô tả:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TB_Description" runat="server" MaxLength="300" Width="50%" Rows="6"
                                                TextMode="MultiLine"></asp:TextBox><span id="SP_Description" style="display: none;
                                                    color: Red">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Hình ảnh:
                                        </td>
                                        <td>
                                            <%--<asp:FileUpload ID="FU_Image" runat="server" />--%>
                                            <asp:Image ID="IMG" runat="server" Width="150px" ImageUrl="~/Images/NoImage.jpg" />
                                            <div>
                                                <input type="hidden" runat="server" id="HD_IMG" value="" /><br />
                                                <asp:Button ID="BT_IMG" runat="server" Text="Load Image" CssClass="button" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Giá:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TB_Price" runat="server" MaxLength="15" Width="120px" CssClass=""></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Thứ tự:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TB_SortField" runat="server" MaxLength="6" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Active:
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="CB_Active" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            Nội dung:
                                        </td>
                                        <td>
                                            <ck:CKEditorControl runat="server" BasePath="../Content/ckeditor" ID="Content" FilebrowserBrowseUrl="../Content/ckfinder/ckfinder.html"
                                                Height="500px" Width="90%"></ck:CKEditorControl>
                                            <asp:Localize ID="Localize1" runat="server"></asp:Localize>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="padding-top: 10px">
                                            <asp:Button ID="BT_Save" runat="server" Text="Save" Width="65px"
                                                CssClass="button" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <%--<asp:AsyncPostBackTrigger ControlID="BT_Save" EventName="Click" />--%>
                        <%--<asp:AsyncPostBackTrigger ControlID="BT_AddType" EventName="Click" />--%>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="display: none">
                <%--<asp:ImageButton ID="IMGBT_EditType" runat="server" OnClick="IMGBT_EditType_Click" />--%>
                <%--<asp:ImageButton ID="IMGBT_DeleteType" runat="server" OnClick="IMGBT_DeleteType_Click" />--%>
                <%--<asp:ImageButton ID="IMGBT_DetailType" runat="server" OnClick="IMGBT_DetailType_Click" />--%>
                <asp:ImageButton ID="IMGBT_Edit" runat="server" OnClick="IMGBT_Edit_Click" />
                <asp:ImageButton ID="IMGBT_Delete" runat="server" OnClick="IMGBT_Delete_Click" />
                <asp:ImageButton ID="IMGBT_Save" runat="server" onclick="IMGBT_Save_Click" />
                <%--<asp:ImageButton ID="IMGBT_PageType" runat="server" 
                    onclick="IMGBT_PageType_Click" />--%>
                <asp:ImageButton ID="IMGBT_Page" runat="server" onclick="IMGBT_Page_Click" 
                    style="width: 14px" />
            </td>
        </tr>
    </table>
    <div style="display: block; left: 100px; top: 200px; z-index: 100; position: absolute;"
        id="DIV_Process">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" DynamicLayout="true">
            <ProgressTemplate>
                <asp:Image ID="IMG_XMLProcess" Width="40px" runat="Server" ImageUrl="~/Images/loading.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>
