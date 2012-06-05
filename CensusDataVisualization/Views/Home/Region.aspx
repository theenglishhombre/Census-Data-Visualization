<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CensusDataVisualization.Models.SF1_00003>" %>

<asp:Content ID="ContentScripts" ContentPlaceHolderID="ScriptContent" runat="server">
<script type="text/javascript">

    $(function () {
        $("#chart").hide();
        var $dropdown = $("#MainContent_ddlFrequency");
        $dropdown.change(function () {
            var value = $dropdown.val();
            Show(value);
        });
    });

    function Show(value) {
        if (value == "show") {
            show_visibility("PieChart");

        }
        else if (value == "hide") {
            hide_visibility("PieChart");
        }

    }

    function hide_visibility(classname) { $("." + classname).hide("slow"); }
    function show_visibility(classname) { $("." + classname).show("slow"); }

    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PieChart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Geographic Region</h2>
    <form id="form" runat="server">
        <div id="ddlFrequencyDiv" class="topSpace">
            <asp:DropDownList ID="ddlFrequency" runat="server">
                <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                <asp:ListItem Text="Show Graph" Value="show"></asp:ListItem>
                <asp:ListItem Text="Hide Graph" Value="hide"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
    <div id="chart" class="PieChart"> 
        <img src="/Home/ChartView/<%: Model.LOGRECNO %>" alt="Chart" /> 
    </div>
</asp:Content>
