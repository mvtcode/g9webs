<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/admin/master_default.master" AutoEventWireup="true"
    CodeBehind="UserMessenge.aspx.cs" Inherits="Website.admin.UserMessenge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var sPage = "ctl00_ctl00_ContentPlaceHolder_Main_ContentPlaceHolder_Text_";
        function check_Data() {
            //return false;
        }
        function confirmDelete() {
            return confirm("Bạn có muốn xóa người dùng này không?");
        }
        function SetFocus(obj) {
            //alert(obj);
            window.setTimeout("SetFocus_('" + obj + "');", 100);
        }

        function SetFocus_(obj) {
            document.getElementById("TBL_Detail").scrollIntoView();
            //$("#" + sPage + "TB_Username").focus();
            $("#" + obj).focus();
        }
    </script>
    <div style="color: #0099FF; font-weight: bold; font-size: larger; float: left">
        Quản trị người dùng tin nhắn:</div>
    <div style="clear: both; margin: 6px; border: #c0c0c0 1px solid; width: 100%">
        <div style="padding: 6px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GV_User" runat="server" AutoGenerateColumns="False" Width="100%"
                        runat="server" BackColor="White" BorderColor="#16538C" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="3" AllowPaging="True" PageSize="20" AllowSorting="True" 
                        onpageindexchanging="GV_User_PageIndexChanging" 
                        onrowcommand="GV_User_RowCommand">
                        <RowStyle BackColor="White" ForeColor="Black" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#2360A4" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DEEAF3" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="sUsername" HeaderText="Username">
                            </asp:BoundField>
                            <asp:BoundField DataField="sFullname" HeaderText="Fullname">
                            </asp:BoundField>
                            <asp:BoundField DataField="sEmail" HeaderText="Email" />
                            <asp:BoundField DataField="sMobile" HeaderText="Mobile" />
                            <asp:BoundField DataField="sAddress" HeaderText="Address" />
                            <asp:BoundField DataField="sCompany" HeaderText="Company" />
                            <asp:BoundField DataField="sHomepage" HeaderText="HomePage" />
                            <asp:BoundField DataField="createdate" HeaderText="Create Date" />
                            <asp:CheckBoxField DataField="Active" HeaderText="Active">
                                <ItemStyle Width="7%" />
                            </asp:CheckBoxField>
                            <%--<asp:TemplateField HeaderText="Sửa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("id") %>'
                                        CommandName="BT_Edit" ImageUrl="~/admin/Images/edit-icon.gif" Text="edit" />
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="LBT_Delete" runat="server" CausesValidation="false" CommandName="BT_Delete"
                                        CommandArgument='<%# Bind("id") %>' OnClientClick="javascript:return confirmDelete();"
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
                    <div style="margin: 10px">
                        <asp:Label ID="LB_Messenger" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></div>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="BT_Add" EventName="Click" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div style="padding: 6px" runat="server" id="DIV_1">
                <fieldset style="width: 99%; padding-right: 6px; padding-left: 6px; padding-bottom: 6px;
                    padding-top: 6px">
                    <legend>
                        <asp:Label ID="LB_TitleType" runat="server" Text="Thêm/Sửa thông người dùng"></asp:Label></legend>
                    <input id="HD_ID" type="hidden" value="0" runat="server" />
                    <table id="TBL_Detail" border="0" cellpadding="0" cellspacing="2" width="100%" style="border: #c0c0c0 1px solid;">
                        <tr>
                            <td colspan="2" align="left">
                                <asp:Label ID="LB_Error" runat="server" Text="" ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" width="15%" align="left">
                                Tên đăng nhập:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TB_Username" runat="server" MaxLength="30" Width="150px"></asp:TextBox><span
                                    id="SP_Title" style="display: none; color: Red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left">
                                Phân quyền:&nbsp;
                            </td>
                            <td align="left">                                
                                <asp:DropDownList ID="DDL_Role" runat="server" Width="150px">
                                </asp:DropDownList><span id="SP_Description" style="display: none; color: Red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left" valign="top">
                                Password:
                            </td>
                            <td align="left" valign="middle">
                                <div>
                                    <asp:TextBox ID="TB_Password" runat="server" MaxLength="30" Width="150px"></asp:TextBox>
                                    <br />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left">
                                Họ tên:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TB_Fullname" runat="server" MaxLength="30" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TextLeft" align="left">
                                Email:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TB_Email" runat="server" MaxLength="30" Width="150px"></asp:TextBox>
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
                        <%--<tr>
                            <td colspan="2" style="padding: 6px">
                                <asp:Button ID="BT_Save" runat="server" Text="Save" Width="65px" OnClick="BT_Save_Click"
                                    CssClass="button" />
                            </td>
                        </tr>--%>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="BT_Add" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BT_Save" EventName="Click" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
