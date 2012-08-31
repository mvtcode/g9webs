<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminNotAJAX.Master" AutoEventWireup="true"
    CodeBehind="newtype_manager.aspx.cs" Inherits="Website.admin.newtype_manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Text" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr valign="top">
            <td>
                <table cellpadding="1" cellspacing="1" border="0" class="text">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 5px; text-align: left">
                <asp:Literal ID="ltThongBao" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="center" style="width: 35%; text-align: left">
                            <asp:Button ID="Button1" runat="server" CssClass="button" Text="    Thêm mới    "
                                OnClick="btThemMoi_Click" />
                        </td>
                        <td align="right" style="width: 65%; text-align: left">
                            <asp:Button ID="Button2" runat="server" CssClass="button" Text="Xóa" OnClick="btDelete_Click"
                                Width="40px" 
                                OnClientClick="javascript:{ return confirm('Bạn có muốn xóa loại tin được chọn?');}" 
                                Visible="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr valign="top">
            <td style="text-align: center">
                <asp:GridView ID="grvView" runat="server" AutoGenerateColumns="False" Width="40%"
                    DataKeyNames="pk_ID" BackColor="White" BorderColor="#16538C" BorderStyle="Solid"
                    BorderWidth="1px" CellPadding="3" GridLines="Both" AllowPaging="True" PageSize="50"
                    AllowSorting="True" OnRowDataBound="grvView_RowDataBound" OnPageIndexChanging="grvView_PageIndexChanging">
                    <RowStyle BackColor="White" ForeColor="Black" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#2360A4" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#DEEAF3" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="5%" HeaderText="STT" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Center"></asp:TemplateField>
                        <asp:BoundField DataField="s_CategoryName" HeaderText="Tên loại tin" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Chọn">
                            <ItemTemplate>
                                <asp:CheckBox ID="StatusCheck" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="center" style="width: 35%; text-align: left">
                            <asp:Button ID="Button3" runat="server" CssClass="button" Text="    Thêm mới    "
                                OnClick="btThemMoi_Click" />
                        </td>
                        <td align="right" style="width: 65%; text-align: left">
                            <asp:Button ID="Button4" runat="server" CssClass="button" Text="Xóa" OnClick="btDelete_Click"
                                Width="40px" OnClientClick="javascript:{ return confirm('Bạn có muốn xóa loại tin được chọn?');}" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
