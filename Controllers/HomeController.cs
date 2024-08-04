using Microsoft.AspNetCore.Mvc;
using proyecto_final_prog2.Web.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using proyecto_final_prog2.Application;
using proyecto_final_prog2.Domain.Entities;
using Microsoft.AspNetCore.OutputCaching;

namespace proyecto_final_prog2.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IApiClient _client;

        public HomeController(ILogger<HomeController> logger, IApiClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            return View(_client);
        }

        [ResponseCache(NoStore = true, Duration = 0, Location = ResponseCacheLocation.None)]
        public IActionResult Test_btn()
        {
            //_logger.LogInformation("Hello world!");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
