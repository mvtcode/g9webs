<%@ Page Title="" Language="C#" MasterPageFile="~/admin/master_default.master" AutoEventWireup="true"
    CodeBehind="Error.aspx.cs" Inherits="Website.admin.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" class="text" id="tblContent">
        <tr valign="top">
            <td style="padding: 0px 5px 0px 5px" valign="top">
                <table style="width: 100%;" cellspacing="0" cellpadding="0" border="0">
                    <tr style="height: 23px">
                        <td style="width: 9px">
                            <img alt="" style="border: 0px" src="images/top_left.gif" />
                        </td>
                        <td style="background-image: url('images/bg_top.gif'); padding-left: 5px; color: #ffffff">
                            <strong>
                                <asp:Literal ID="lbTitleMain" runat="server" Text="System Error"></asp:Literal></strong>
                        </td>
                        <td style="width: 9px">
                            <img alt="" style="border: 0px" src="images/top_right.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td style="background-image: url('images/bg_left.gif')">
                        </td>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="background-color: #ffffff">
                                <tr valign="top">
                                    <td style="padding-left: 10px; padding-right: 10px">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align: left">
                                            <tr>
                                                <td style="height: 20px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Hiện tại server đạng bận, xin vui lòng truy vấn lại sau."></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: middle; height: 25px">
                                                    <asp:HyperLink ID="Hyperlink1" runat="server" CssClass="ms-toolbar" NavigateUrl="javascript:history.go(-1);">
									<img alt="" src="Images/back.gif" height="16" width="16" border="0" />																
									                Trở lại trang cũ
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 50px">
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
                        </td>
                        <td style="background-image: url('images/bg_right.gif')">
                        </td>
                    </tr>
                    <tr style="height: 13px">
                        <td style="width: 9px">
                            <img alt="" style="border: 0px" src="images/bottom_left.gif" />
                        </td>
                        <td style="background-image: url('images/bg_bottom.gif'); padding-top: 3px; padding-left: 5px;
                            color: #ffffff">
                        </td>
                        <td style="width: 9px">
                            <img alt="" style="border: 0px" src="images/bottom_right.gif" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
