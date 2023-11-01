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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<List<ApplicationDto>>> Get(
            [FromServices] ApplicationService service)
        {
            var result = await service.GetAsync();
            _logger.LogInformation($"Got applications {DateTime.UtcNow.ToLongTimeString()}");
            return result;
        }
    }
}
