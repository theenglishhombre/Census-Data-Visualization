<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PieChart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Black Or African American</h2>
    <img src="/chart" />
    <div>
      <% foreach (var m in ViewData.Model) 
       { %> 
 
        Black: <% = m.Black_Or_African_American %> 
        <br /> 
         
    <% } %> 
 
 </div>
 <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>
