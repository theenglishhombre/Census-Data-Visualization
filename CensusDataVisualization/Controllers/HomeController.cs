using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CensusDataVisualization.Models;

namespace CensusDataVisualization.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        Census2010Entities _db;

        public HomeController()
        {
            _db = new Census2010Entities();

        }
        
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            //ViewData.Model = _db.SF1_00003.ToList();
            
            //fix this -> learn linq syntax
            IList<SF1_00003> modelItems = _db.SF1_00003.ToList();
            List<SF1_00003> model = new List<SF1_00003>();

            for (int i = 6; i < 21; i++)
            {
                model.Add(modelItems[i]);
            }

            ViewData.Model = model;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
