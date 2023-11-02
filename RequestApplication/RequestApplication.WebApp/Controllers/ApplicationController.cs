using Microsoft.AspNetCore.Mvc;
using RequestApplication.Services.Dto;
using RequestApplication.Services.Services;

namespace RequestApplication.WebApp.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ILogger<ApplicationController> _logger;
        public ApplicationController(ILogger<ApplicationController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(
            [FromServices] ApplicationService service)
        {
            ViewBag.Applications = await service.GetAsync();
            _logger.LogInformation($"Got applications {DateTime.UtcNow.ToLongTimeString()}");
            return View();
        }
    }
}
