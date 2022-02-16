using bidersGo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Business.Abstract;

namespace bidersGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DenemeViewSync()
        {
            List<LineChartData> chartData = new List<LineChartData>
            {
                new LineChartData { xValue = new DateTime(2005, 01, 01), yValue = 21, yValue1 = 28 },
                new LineChartData { xValue = new DateTime(2006, 01, 01), yValue = 24, yValue1 = 44 },
                new LineChartData { xValue = new DateTime(2007, 01, 01), yValue = 36, yValue1 = 48 },
                new LineChartData { xValue = new DateTime(2008, 01, 01), yValue = 38, yValue1 = 50 },
                new LineChartData { xValue = new DateTime(2009, 01, 01), yValue = 54, yValue1 = 66 },
                new LineChartData { xValue = new DateTime(2010, 01, 01), yValue = 57, yValue1 = 78 },
                new LineChartData { xValue = new DateTime(2011, 01, 01), yValue = 70, yValue1 = 84 },
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class LineChartData
        {
            public DateTime xValue;
            public double yValue;
            public double yValue1;
        }
    }
}
