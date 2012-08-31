<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="Website.admin.UploadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
            Width="100%" runat="server" BackColor="White" BorderColor="#16538C" BorderStyle="Solid"
            BorderWidth="1px" CellPadding="3" PageSize="20" 
            onrowdatabound="GridView1_RowDataBound">
            <RowStyle BackColor="White" ForeColor="Black" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#2360A4" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DEEAF3" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="File name">
                    <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="Link">
                    <ItemStyle Width="30%" />
                </asp:BoundField>
                <asp:BoundField DataField="length" HeaderText="Dung lượng">
                    <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="date" HeaderText="Ngày tạo">
                    <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="LBT_Delete" runat="server" CausesValidation="false" 
                            CommandArgument='<%# Eval("name") %>' CommandName="BT_Delete" 
                            ImageAlign="AbsMiddle" ImageUrl="~/admin/Images/delete-icon.gif" 
                            OnClientClick="javascript:return confirmDelete();" Text="Xóa" />
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                
            </Columns>
            <EmptyDataTemplate>
                <b>Không có file nào</b>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
