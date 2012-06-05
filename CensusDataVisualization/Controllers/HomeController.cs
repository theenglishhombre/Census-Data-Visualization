using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CensusDataVisualization.Models;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.IO;


namespace CensusDataVisualization.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        Census2010Entities _db;
        private Font font = new Font("Trebuchet MS", 14, FontStyle.Bold);
        private Color color = Color.FromArgb(26, 59, 105);

        public HomeController()
        {
            _db = new Census2010Entities();
        }
        
        public ActionResult Index()
        {
            ViewData["Message"] = "Census Data Visualization";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Black_Or_African_American()
        {
            //
            ////ViewData.Model = _db.SF1_00003.ToList();
            ////fix this -> learn linq syntax
            //IList<SF1_00003> modelItems = _db.SF1_00003.ToList();
            //List<SF1_00003> model = new List<SF1_00003>();

            //for (int i = 6; i < 21; i++)
            //{
            //    model.Add(modelItems[i]);
            //}

            //ViewData.Model = model;

            //return View();


            ////////////////////////
            // Define the Data ... this simple example is just a list of values from 0 to 50
            List<float> values = new List<float>();
            for (int i = 0; i < 50; i++)
            {
                values.Add(i);
            }

            // Define the Chart
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
            Chart2.Titles.Add(new Title("Do The Wave!", Docking.Top, font, color));
            Chart2.ChartAreas.Add("Waves");
            Chart2.Legends.Add("Legend");

            //Bind the model data to the chart
            var series1 = Chart2.Series.Add("Sin");
            var series2 = Chart2.Series.Add("Cos");

            foreach (int value in values)
            {
                series1.Points.AddY((float)Math.Sin(value * .5) * 100f);
            }

            foreach (int value in values)
            {
                series2.Points.AddY((float)Math.Cos(value * .5) * 100f);
            }

            // Stream the image to the browser
            MemoryStream stream = new MemoryStream();
            Chart2.SaveImage(stream, ChartImageFormat.Png);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream.ToArray(), "image/png");
        }
    }
}
