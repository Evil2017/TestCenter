using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TestDemo.Models;

namespace TestDemo.Controllers
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
        public IActionResult Res_In_Edit()
        {
            return View();
        }
        public IActionResult Res_Out_Edit()
        {
            return View();
        }
        public IActionResult ResDayReport()
        {
            return View();
        }
        public IActionResult ResEdit()
        {
            return View();
        }
        public IActionResult ResIN()
        {
            return View();


        }
        public IActionResult ResINDayReport()
        {
            return View();
        }
        public IActionResult ResINList()
        {
            return View();
        }
        public IActionResult ResINMouthReport()
        {
            return View();

        }
        public IActionResult ResList()
        {
            return View();

        }
        public IActionResult ResOut()
        {
            return View();

        }
        public IActionResult ResOutDayReport()
        {
            return View();

        }
        public IActionResult ResOutList()
        {
            return View();

        }
        public IActionResult ResOutMonthReport()
        {
            return View();


        }
        public IActionResult ResOutUseList()
        {
            return View();

        }
        public IActionResult ResRepDate()
        {
            return View();

        }
        public IActionResult ResRepMonth()
        {
            return View();

        }
        public IActionResult ResStockDayReport()
        {
            return View();

        }
        public IActionResult ResStockList()
        {
            return View();

        }
        public IActionResult ResStockMonthReport()
        {
            return View();

        }
        public IActionResult ResStockReport()
        {
            return View();

        }
        public IActionResult ResType()
        {
            return View();

        }
        public IActionResult ResUse()
        {
            return View();

        }
        public IActionResult ResUseAdd()
        {
            return View();

        }
        public IActionResult ResUseAdd1()
        {
            return View();

        }
        public IActionResult ResUseDayReport()
        {
            return View();

        }
        public IActionResult ResUseList()
        {
            return View();

        }
        public IActionResult ResUseMonthReport()
        {
            return View();

        }
        public IActionResult StroageAll()
        {
            return View();

        }
        public IActionResult UseEidt()
        {
            return View();

        }
    }
}
