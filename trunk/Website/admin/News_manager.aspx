<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminNotAJAX.Master" AutoEventWireup="true"
    CodeBehind="News_manager.aspx.cs" Inherits="Website.admin.News_manager" %>
<%@ Register Namespace="CKEditor.NET" Assembly="CKEditor.NET" TagPrefix="ck" %>
<%@ Register TagPrefix="koutny" Namespace="Koutny.Web.UI.WebControls" Assembly="Koutny.WebControls.DropDownGroupableList.Net2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Text" runat="server">
    <style type="text/css">
        .TextLeft
        {
            width: 15%;
        }
    </style>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var sPage = "ctl00_ctl00_ContentPlaceHolder_Main_ContentPlaceHolder_Text_";

        function confirmDelete() {
            return confirm("Bạn có muốn xóa tin này không?");
        }

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

        function check_Data() {
            var bOk = true;
            $("#SP_Title").css('display', 'none');
            $("#SP_Description").css('display', 'none');

            if ($("#" + sPage + "TB_Title").val() == "") {
                $("#SP_Title").css('display', 'inline');
                bOk = false;
            }

            if ($("#" + sPage + "TB_Description").val() == "") {
                $("#SP_Description").css('display', 'inline');                
                bOk = false;
            }
            if (!bOk) {
                $("#" + sPage + "LB_Error").html("<b>hãy kiểm tra lại</b><br>");
                document.getElementById("TBL_Detail").scrollIntoView();
                return false;
            }
            $("#" + sPage + "LB_Error").text("");
            return true;
        }

        function setPosition() {
            $("#DIV_Process").offset({ top: parseInt($("#TBL_Main")[0].offsetHeight + 200), left: parseInt($("#aspnetForm")[0].offsetWidth) / 2 });
        }

        $(document).ready(function() {
            setPosition();
        });

        function SetFocus() {
            window.setTimeout("SetFocus_();", 100);
        }

        function SetFocus_(){
            document.getElementById("TBL_Detail").scrollIntoView();
            $("#" + sPage + "TB_Title").focus();
        }
    </script>

    <div id="TBL_Main" style="padding-top: 15px">
        <span style="color: #0099FF; font-weight: bold; font-size: larger">Chọn loại tin:</span>
        <span style="padding-left: 10px">
            <%--<asp:DropDownList ID="DDL_CategoryType" runat="server" Width="220px" AutoPostBack="True"
                OnSelectedIndexChanged="DDL_CategoryType_SelectedIndexChanged" />--%>                
            <koutny:DropDownGroupableList ID="DDL_CategoryType1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_CategoryType1_SelectedIndexChanged">
		    </koutny:DropDownGroupableList>
        </span><span style="display: none">
            <asp:ImageButton ID="IMGBT_Load" runat="server" Height="0px" OnClick="IMGBT_Load_Click"
                Width="0px" /></span>
    </div>
    <div style="margin: 6px; border: #c0c0c0 1px solid; width: 100%">
        <div style="padding: 6px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                        Width="100%" runat="server" BackColor="White" BorderColor="#16538C" BorderStyle="Solid"
                        BorderWidth="1px" CellPadding="3" AllowPaging="True" PageSize="20" 
                        AllowSorting="True" onpageindexchanging="GridView1_PageIndexChanging">
                        <RowStyle BackColor="White" ForeColor="Black" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#2360A4" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DEEAF3" ForeColor="Black" />
                        <Columns>
                            <asp:TemplateField HeaderText="Tiêu đề">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LBT_Edit_Title" runat="server" CausesValidation="false" CommandName="BT_Edit"  CommandArgument='<%# Bind("pk_ID") %>'
                                        Text='<%# Bind("s_Title") %>' />                            
                                </ItemTemplate>
                                <ItemStyle Width="16%" HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mô tả">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LBT_Edit_Description" runat="server" CausesValidation="false" CommandName="BT_Edit"  CommandArgument='<%# Bind("pk_ID") %>'
                                        Text='<%# Bind("s_Description") %>' />                                     
                                </ItemTemplate>
                                <ItemStyle Width="40%" HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="s_FullName" HeaderText="Người tạo">
                                <ItemStyle Width="8%" HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="d_DateCreated" HeaderText="Ngày tạo">
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SortField" HeaderText="STT">
                                <ItemStyle Width="7%" />
                            </asp:BoundField>
                            <asp:CheckBoxField DataField="Active" HeaderText="Active">
                                <ItemStyle Width="7%" />
                            </asp:CheckBoxField>
                            <asp:TemplateField HeaderText="Sửa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("pk_ID") %>'
                                        CommandName="BT_Edit" ImageUrl="~/admin/Images/edit-icon.gif" Text="edit" />
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="LBT_Delete" runat="server" CausesValidation="false" CommandName="BT_Delete"
                                        CommandArgument='<%# Bind("pk_ID") %>' OnClientClick="javascript:return confirmDelete();"
                                        Text="Xóa" ImageAlign="AbsMiddle" ImageUrl="~/admin/Images/delete-icon.gif">
                                    </asp:ImageButton>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <b>Chưa có dữ liệu</b>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <input type="hidden" id="HD_Page" runat="server" value="0" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="IMGBT_Load" EventName="Click" />
                    <%--<asp:AsyncPostBackTrigger ControlID="DDL_CategoryType" EventName="SelectedIndexChanged" />--%>
                    <asp:AsyncPostBackTrigger ControlID="DDL_CategoryType1" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div style="padding: 6px" align="left">
            <asp:Button ID="BT_Add" runat="server" Text="Add" Width="55px" OnClick="BT_Add_Click"
                CssClass="button" />&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LB_Messenger" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div style="padding: 6px" runat="server" id="DIV_1">
                <fieldset style="width: 99%; padding-right: 6px; padding-left: 6px; padding-bottom: 6px;
                    padding-top: 6px">
                    <legend>
                        <asp:Label ID="LB_TitleType" runat="server" Text="Thêm/Sửa thông tin tin tức"></asp:Label></legend>
                    <input id="HD_ID" type="hidden" value="0" runat="server" />                    
                    <table id="TBL_Detail" border="0" cellpadding="0" cellspacing="2" width="100%" style="border: #c0c0c0 1px solid;">
                        <tr><td colspan="2" align="left">
                            <asp:Label ID="LB_Error" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
                        <tr>
                                <td class="TextLeft" width="15%" align="left">
                                    Tiêu đề tin:
                                </td>
                            <td align="left">
                                <asp:TextBox ID="TB_Title" runat="server" MaxLength="100" Width="300px"></asp:TextBox><span
                                    id="SP_Title" style="display: none; color: Red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left">
                                mô tả:&nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TB_Description" runat="server" MaxLength="500" Rows="6" TextMode="MultiLine"
                                    Width="50%"></asp:TextBox><span id="SP_Description" style="display: none; color: Red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left" valign="top">
                                Ảnh bài viết
                            </td>
                            <td align="left" valign="middle">
                                <asp:Image ID="IMG" runat="server" ImageUrl="~/Images/NoImage.jpg" Width="150px" />
                                <div>
                                    <br />
                                    <input type="hidden" runat="server" id="HD_IMG" value="" />
                                    <asp:Button ID="BT_IMG" runat="server" Text="Load Image" CssClass="button" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left">
                                Sắp xếp thứ tự:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TB_Sort" runat="server" MaxLength="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left">
                                Active:
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="CB_Active" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left" valign="top">
                                Nội dung:
                            </td>
                            <td align="left">
                                <ck:CKEditorControl runat="server" BasePath="../Content/ckeditor" ID="Content" FilebrowserBrowseUrl="../Content/ckfinder/ckfinder.html"
                                    Height="500px" Width="96%"></ck:CKEditorControl>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding: 6px">
                                <asp:Button ID="BT_Save" runat="server" Text="Save" Width="65px" 
                                    OnClick="BT_Save_Click" CssClass="button" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BT_Add" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BT_Save" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div style="display: block; left: 100px; top: 250px; z-index: 100; position: absolute;"
        id="DIV_Process">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" DynamicLayout="true">
            <ProgressTemplate>
                <asp:Image ID="IMG_XMLProcess" Width="40px" runat="Server" ImageUrl="~/Images/loading.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>
