<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Visited.ascx.cs" Inherits="Website.UserControl.Home.Visited" %>
<div style="color: #225ba8; size: 12px; font-weight: bold;text-align: left;padding:6px 10px 10px 10px">
    <div>
        <img src="/Images/users_online.png" /> Số người online: <%=Application["CurrentUsers"] %>
    </div>
    <div>
        <img src="/Images/people.png" /> Thành viên: <%=iMember %>
    </div>
    <div>
        <img src="/Images/forum_stats.png" /> Lượt truy cập: <%=Application["count_visit"] %>
    </div>
    <div>
        <img src="/Images/NewUser.png" /> Thành viên mới: <%=sNewMember%>
    </div>
</div>
