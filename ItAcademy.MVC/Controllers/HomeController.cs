using ItAcademy.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ItAcademy.MVC.Filters;
using Microsoft.AspNetCore.Authorization;

namespace ItAcademy.MVC.Controllers
{
    //[TestResourceFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //[TestResourceFilter(12, )]
        [TypeFilter(typeof(TestResourceFilter), Arguments = [12])]
        //[ServiceFilter(typeof(TestResourceFilter))]
        [ResultFilter]
        public async Task<IActionResult> IndexAsync()
        {
            _logger.LogInformation("hello");
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        [CacheResourceFilter]
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
