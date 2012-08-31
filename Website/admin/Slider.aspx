﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/master_default.master" AutoEventWireup="true" CodeBehind="Slider.aspx.cs" Inherits="Website.admin.Slider" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script language="javascript">
        function uploadComplate(s, e) {
            location.reload(true);
        }
        function confirmDelete() {
            return confirm("Bạn có muốn xóa bức ảnh này không?");
        }
    </script>

    <div style="margin: 0px auto; width: 900px; border: 1px solid #AAAAAA; font-weight: 700;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
            Width="100%" runat="server" BackColor="White" BorderColor="#16538C" BorderStyle="Solid"
            BorderWidth="1px" CellPadding="3" PageSize="20">
            <RowStyle BackColor="White" ForeColor="Black" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#2360A4" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DEEAF3" ForeColor="Black" />
            <Columns>
                <asp:TemplateField HeaderText="Hình ảnh">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Width="100%" ImageUrl='<%# Eval("name") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle Height="110px" Width="40%" />
                </asp:TemplateField>
                <asp:BoundField DataField="size" HeaderText="File size">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="length" HeaderText="Dung lượng">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="date" HeaderText="Ngày tạo" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm:ss}">
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
                <b>Chưa có ảnh nào</b>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div style="padding-top: 15px">
        <asp:Label ID="LB_Msg" runat="server" ForeColor="Red"></asp:Label></div>
    <div style="padding-top: 15px">
        <div style="color: #0066FF">
            <b>Tải thêm ảnh</b></div>
        <div style="width: 400px;margin: 0px auto">
            <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" ShowProgressPanel="True"
                ShowUploadButton="True" Width="400px" AddUploadButtonsHorizontalPosition="Right"
                OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                <ClientSideEvents FileUploadComplete="uploadComplate" />
                <CancelButton Text="Hủy">
                </CancelButton>
                <UploadButton Text="Tải lên">
                </UploadButton>
                <BrowseButton Text="Chọn file">
                </BrowseButton>
            </dx:ASPxUploadControl>
        </div>
        <div>
            <b><span style="color: #FF0000">File ảnh định dạng *jpg, *.gif,*.png</span><br 
                style="color: #FF0000" />
            <span style="color: #FF0000">kích thước file: 680 x 200 </span></b>
        </div>
    </div>
</asp:Content>
