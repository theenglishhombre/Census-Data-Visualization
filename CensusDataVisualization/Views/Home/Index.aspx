<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<CensusDataVisualization.Models.SF1_00003>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
    <div>

 
      
</div> 
<div id="bottomLinks">
<%= Html.ActionLink("Black Or African American", "Black_Or_African_American") %> 
<%= Html.ActionLink("White", "Black_Or_African_American") %>
</div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>
