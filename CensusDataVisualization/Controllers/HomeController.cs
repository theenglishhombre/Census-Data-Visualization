using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CensusDataVisualization.Models;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.IO;
using System.Web.UI;
using CensusDataVisualization.Helpers;


namespace CensusDataVisualization.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        ICensusDataRepository censusDataRepository;

        private Font font = new Font("Trebuchet MS", 14, FontStyle.Bold);
        private Color color = Color.FromArgb(26, 59, 105);

        #region Constructors
        public HomeController() : this(new CensusDataRepository())
        { }

        public HomeController(ICensusDataRepository repository)
        {
            censusDataRepository = repository;
        }
        #endregion

        public ActionResult Index(int? page)
        {
            const int pageSize = 25;

            IQueryable<SF1_00003> regions = censusDataRepository.FindAllRegionsOrderByPopulationDesc();

            var paginatedRegions = new PaginatedList<SF1_00003>(regions, page ?? 0, pageSize);

            return View(paginatedRegions);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Region(int? id)
        {
            SF1_00003 region = censusDataRepository.GetRegion(id.GetValueOrDefault(1));

            return View(region);
        }

        public ActionResult ChartView(int? id)
        {
            SF1_00003 firstArea = censusDataRepository.GetRegion(id.GetValueOrDefault(1));

            Chart Chart2 = new Chart()
            {
                Width = 800,
                Height = 296,
                RenderType = RenderType.BinaryStreaming,
                Palette = ChartColorPalette.BrightPastel,
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderWidth = 2,
                BorderColor = color
            };

            Chart2.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            Chart2.Titles.Add(new Title("Population Race Breakdown", Docking.Top, font, color));
            Chart2.ChartAreas.Add("Race");
            Chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
            Chart2.ChartAreas[0].Area3DStyle.Inclination = 45;
            Chart2.ChartAreas[0].Area3DStyle.Rotation = 90;
            Chart2.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Simplistic;
            Chart2.Legends.Add("Legend");

            Series pieChartSeries = new Series("Series1");
            pieChartSeries.ChartType = SeriesChartType.Pie;

            pieChartSeries.Points.AddXY("White", firstArea.P0030002);
            pieChartSeries.Points.AddXY("African-America", firstArea.Black_Or_African_American);
            pieChartSeries.Points.AddXY("American Indian", firstArea.P0030004);
            pieChartSeries.Points.AddXY("Asian", firstArea.P0030005);
            pieChartSeries.Points.AddXY("Native Hawaiian", firstArea.P0030006);
            pieChartSeries.Points.AddXY("Other", firstArea.P0030007);
            pieChartSeries.Points.AddXY("Mixed", firstArea.P0030008);

            Chart2.Series.Add(pieChartSeries);

            // Stream the image to the browser
            MemoryStream stream = new MemoryStream();
            Chart2.SaveImage(stream, ChartImageFormat.Png);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream.ToArray(), "image/png");
        }
    }
}
