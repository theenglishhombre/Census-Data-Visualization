<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CensusDataVisualization.Helpers.PaginatedList<CensusDataVisualization.Models.SF1_00003>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Census Data Region Selection
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Select a Census Region</h2>

    <div>
        <ul class="regions">
            <% foreach (var region in Model) { %>
        
                <li>     
                    <%: Html.ActionLink(region.LOGRECNO.ToString(), "Region", new { id = region.LOGRECNO })%>
                    , Total Population
                    <strong><%: region.White_Alone.ToString()%></strong>
                </li>
        
            <% } %>
        </ul>
    </div> 

    <div id="bottomLinks">
    </div>
</asp:Content>
