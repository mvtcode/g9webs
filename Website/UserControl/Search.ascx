<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="Website.UserControl.Search" %>
<form action="/search.aspx" method="get">
<input type="text" value="Từ khóa tìm kiếm" onblur="if (this.value=='') this.value='Từ khóa tìm kiếm'"
    onfocus="if (this.value=='Từ khóa tìm kiếm') this.value='';" class="texttimkiem"
    name="word" />
<button type="submit" class="nuttimkiem">
    <img src="/Images/search.png" style="background: transparent;" /></button>
</form>
