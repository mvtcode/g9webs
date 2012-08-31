<%@ Page Title="" Language="C#" MasterPageFile="~/admin/master_default.master" AutoEventWireup="true" CodeBehind="tabproduct.aspx.cs" Inherits="Website.admin.tabproduct" %>
<%@ Register Namespace="CKEditor.NET" Assembly="CKEditor.NET" TagPrefix="ck" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">

    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script language="javascript">
        function uploadComplate(s,e) {
            $("#ctl00_ContentPlaceHolder_Main_HD_File").val(e.callbackData);
            $("#ctl00_ContentPlaceHolder_Main_LB_File").text(e.callbackData); 
        }
        function check_Data() {
            return true;
        }
        function setPosition() {
            $("#DIV_Process").offset({ top: parseInt($("#TBL_Main")[0].offsetHeight + 250), left: parseInt($("#aspnetForm")[0].offsetWidth) / 2 });
        }
        $(document).ready(function() {
            setPosition();
        });
    </script>
    <div id="TBL_Main" style="padding-top: 15px">
        <span style="color: #0099FF; font-weight: bold; font-size: larger">Chọn sản phẩm:</span>
        <span style="padding-left: 10px">
            <asp:DropDownList ID="DDL_Products" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="DDL_Products_SelectedIndexChanged" />               
        </span><span style="display: none">
            </span>
    </div>
    <div style="margin: 6px; border: #c0c0c0 1px solid; width: 100%">
        <div style="padding: 6px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                        Width="100%" runat="server" BackColor="White" BorderColor="#16538C" BorderStyle="Solid"
                        BorderWidth="1px" CellPadding="3" AllowPaging="True" PageSize="20" 
                        AllowSorting="True" onrowdatabound="GridView1_RowDataBound">
                        <RowStyle BackColor="White" ForeColor="Black" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#2360A4" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DEEAF3" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="sTitle" HeaderText="Tab">
                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sContent" HeaderText="Nội dung">
                                <ItemStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sFile" HeaderText="File">
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Sửa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("id") %>'
                                        CommandName="BT_Edit" ImageUrl="~/admin/Images/edit-icon.gif" Text="edit" />
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <b>Chưa có dữ liệu</b>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="IMGBT_Load" EventName="Click" />--%>
                    <%--<asp:AsyncPostBackTrigger ControlID="DDL_CategoryType" EventName="SelectedIndexChanged" />--%>
                    <asp:AsyncPostBackTrigger ControlID="DDL_Products" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div style="padding: 6px" align="left">
            <asp:Label ID="LB_Messenger" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div style="padding: 6px" runat="server" id="DIV_1">
                <fieldset style="width: 99%; padding-right: 6px; padding-left: 6px; padding-bottom: 6px;
                    padding-top: 6px">
                    <legend>
                        <asp:Label ID="LB_TitleType" runat="server" Text="Quản lý tab sản phẩm"></asp:Label></legend>
                    <input id="HD_ID" type="hidden" value="0" runat="server" />                    
                    <input type="hidden" id="HD_File" runat="server" value="" />
                    <table id="TBL_Detail" border="0" cellpadding="0" cellspacing="2" width="100%" style="border: #c0c0c0 1px solid;">
                        <tr><td colspan="2" align="left" style="height: 21px">
                            <asp:Label ID="LB_Error" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
                        <tr>
                                <td class="TextLeft" width="15%" align="left">
                                    Tab:
                                </td>
                            <td align="left">
                                <asp:TextBox ID="TB_Title" runat="server" MaxLength="100" Width="300px" 
                                    Enabled="False" ReadOnly="True"></asp:TextBox><span
                                    id="SP_Title" style="display: none; color: Red">*</span>
                            </td>
                        </tr>
                        <tr style="margin-top: 15px" id="TR_Upload_File" runat="server">
                            <td class="TextLeft" align="left" valign="top">
                                File download
                            </td>
                            <td align="left" valign="middle">
                                <asp:Button ID="BT_IMG" runat="server" Text="Chọn file" CssClass="button" />
                                <br/>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left" valign="top">
                                Nội dung:
                            </td>
                            <td align="left">
                                <ck:CKEditorControl runat="server" BasePath="../Content/ckeditor" ID="Content" FilebrowserBrowseUrl="../Content/ckfinder/ckfinder.html"
                                    Height="600px" Width="96%"></ck:CKEditorControl>
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
            <%--<asp:AsyncPostBackTrigger ControlID="BT_Add" EventName="Click" />--%>
            <asp:AsyncPostBackTrigger ControlID="BT_Save" EventName="Click" />
            <%--<asp:AsyncPostBackTrigger ControlID="ASPxUploadControl1" EventName="FileUploadComplete" />--%>
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
