<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminNotAJAX.Master" AutoEventWireup="true" CodeBehind="Messenge.aspx.cs" Inherits="Website.admin.Messenge" %>
<%@ Register Namespace="CKEditor.NET" Assembly="CKEditor.NET" TagPrefix="ck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Text" runat="server">
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
                                <ItemStyle Width="36%" HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="d_DateCreated" HeaderText="Ngày tạo">
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StartDate" HeaderText="Ngày Bắt đầu">
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EndDate" HeaderText="Ngày kết thúc">
                            <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="s_FullName" HeaderText="Người tạo">
                                <ItemStyle Width="9%" HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:CheckBoxField DataField="Active" HeaderText="Active">
                                <ItemStyle Width="5%" />
                            </asp:CheckBoxField>
                            <asp:TemplateField HeaderText="Sửa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("pk_ID") %>'
                                        CommandName="BT_Edit" ImageUrl="~/admin/Images/edit-icon.gif" Text="edit" />
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="LBT_Delete" runat="server" CausesValidation="false" CommandName="BT_Delete"
                                        CommandArgument='<%# Bind("pk_ID") %>' OnClientClick="javascript:return confirmDelete();"
                                        Text="Xóa" ImageAlign="AbsMiddle" ImageUrl="~/admin/Images/delete-icon.gif">
                                    </asp:ImageButton>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
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
                                <asp:TextBox ID="TB_Description" runat="server" MaxLength="200" Rows="6" TextMode="MultiLine"
                                    Width="50%"></asp:TextBox><span id="SP_Description" style="display: none; color: Red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left" valign="top">
                                Ngày bắt đầu:
                            </td>
                            <td align="left" valign="middle">
                                <div>

                                    <asp:TextBox ID="TB_StartDate" runat="server" MaxLength="10"></asp:TextBox>

                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left">
                                Ngày kết thúc:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TB_EndDate" runat="server" MaxLength="6"></asp:TextBox>
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
                                    Height="400px" Width="96%"></ck:CKEditorControl>
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
</asp:Content>
