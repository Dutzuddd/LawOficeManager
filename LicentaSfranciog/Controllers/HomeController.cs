using LicentaSfranciog.Data;
using LicentaSfranciog.Helpers;
using LicentaSfranciog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LicentaSfranciog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDAL _idal;

        public HomeController(ILogger<HomeController> logger, IDAL idal)
        {
            _logger = logger;
            _idal = idal;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONSString(_idal.GetLocatii());
            ViewData["Evenimente"] = JSONListHelper.GetEventListJSONString(_idal.GetEvenimente());
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}