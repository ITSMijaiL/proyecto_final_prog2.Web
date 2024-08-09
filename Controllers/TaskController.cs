using Microsoft.AspNetCore.Mvc;
using proyecto_final_prog2.Application;
using proyecto_final_prog2.Infrastructure.Models;

namespace proyecto_final_prog2.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;

        private readonly IApiClient _client;

        public TaskController(ILogger<TaskController> logger, IApiClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTask(TaskModel taskModel, string currCol)
        {
            //Console.WriteLine($"XD: {currCol}");
            //return RedirectToAction("Index", controllerName: "Home");
            if (taskModel == null)
            {
                return RedirectToAction("Index", controllerName: "Home");
            }
            if (ModelState.IsValid)
            {
                await _client.CreateTask(taskModel, currCol);
            }
            return RedirectToAction("Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTask(int task_id, TaskModel taskModel)
        {
            if (taskModel == null)
            {
                return RedirectToAction("Index", controllerName: "Home");
            }
            if (ModelState.IsValid)
            {
                await _client.UpdateTask(task_id, taskModel);
            }
            return RedirectToAction("Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTask(int task_id)
        {
            if (ModelState.IsValid)
            {
                await _client.DeleteTask(task_id);
            }
            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}
