using CaseEnUygun.Helper;
using CaseEnUygun.Models;
using CaseEnUyhun.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CaseEnUyhun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ICalcute _calcute;

        public HomeController(ILogger<HomeController> logger, ICalcute calcute)
        {
            _logger = logger;
            _calcute = calcute;

        }

        public IActionResult Index()
        {
            List<Mission> dev1;
            List<Mission> dev2;
            List<Mission> dev3;
            List<Mission> dev4;
            List<Mission> dev5;
            int hafta;
            var a= _calcute.CalcuteStatus(out dev1,out dev2,out dev3,out dev4,out dev5,out hafta);
            ViewBag.hafta = hafta;
            ViewBag.dev1 = dev1;
            ViewBag.dev2 = dev2;
            ViewBag.dev3 = dev3;
            ViewBag.dev4 = dev4;
            ViewBag.dev5 = dev5;

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

    }
}
