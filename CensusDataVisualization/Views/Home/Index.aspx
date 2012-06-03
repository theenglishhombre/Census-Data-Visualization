<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<CensusDataVisualization.Models.SF1_00003>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
    <div>
    
        <% foreach (var m in ViewData.Model) 
       { %> 
 
        Black: <%= m.Black_Or_African_American %> 
        <br /> 
       <%-- Director: <%= m.Director %> 
        <br /> 
        <%= Html.ActionLink("Edit", "Edit", new { id = m.Id })%> 
        <%= Html.ActionLink("Delete", "Delete", new { id = m.Id })%> --%>
        
            <hr /> 
    <% } %> 
 
 
  <%--  <%= Html.ActionLink("Add Race", "Add") %> 
--%>
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>
