using Microsoft.AspNetCore.Mvc;
using proyecto_final_prog2.Application;
using proyecto_final_prog2.Infrastructure.Models;

namespace proyecto_final_prog2.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ILogger<TagController> _logger;

        private readonly IApiClient _client;

        public TagController(ILogger<TagController> logger, IApiClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LinkTag(int task_id, int tag_id)
        {
            //Console.WriteLine($"Selected tag: {tag_id}");
            //return RedirectToAction("Index", controllerName: "Home");
            if (ModelState.IsValid)
            {
                await _client.LinkTag(task_id, tag_id);
            }
            return RedirectToAction("Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnlinkTag(int task_id, int tag_id)
        {
            if (ModelState.IsValid)
            {
                await _client.UnlinkTag(task_id, tag_id);
            }
            return RedirectToAction("Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTag(TagModel tagModel)
        {
            if (ModelState.IsValid)
            {
                await _client.CreateTag(tagModel);
            }
            return RedirectToAction("Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTag(int tag_id, TagModel tagModel)
        {
            if (ModelState.IsValid)
            {
                await _client.UpdateTag(tag_id, tagModel);
            }
            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}
