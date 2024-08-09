using Microsoft.AspNetCore.Mvc;
using proyecto_final_prog2.Application;
using proyecto_final_prog2.Infrastructure.Models;

namespace proyecto_final_prog2.Web.Controllers
{
    public class ColumnController : Controller
    {
        private readonly ILogger<ColumnController> _logger;
        private readonly IApiClient _client;

        public ColumnController(ILogger<ColumnController> logger, IApiClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateColumn(ColumnModel columnModel)
        {
            if (columnModel == null)
            {
                return RedirectToAction("Index", controllerName: "Home");
            }
            if (ModelState.IsValid){
                await _client.CreateColumn(columnModel);
            }
            return RedirectToAction("Index", controllerName:"Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteColumn(int column_id)
        {
            if (ModelState.IsValid)
            {
                await _client.DeleteColumn(column_id);
            }
            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}
