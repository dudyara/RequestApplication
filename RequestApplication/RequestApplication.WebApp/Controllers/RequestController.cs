using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RequestApplication.Services.Dto;
using RequestApplication.Services.Services;

namespace RequestApplication.WebApp.Controllers
{
    public class RequestController : Controller
    {
        private readonly ILogger<RequestController> _logger;

        public RequestController(ILogger<RequestController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(
            [FromServices] RequestService service)
        {
            ViewBag.Requests = await service.GetAsync();
            _logger.LogInformation($"Got requests {DateTime.UtcNow.ToLongTimeString()}");
            return View();
        }

        [HttpGet]
        [Route("Request/Add")]
        public async Task<IActionResult> Add(
            [FromServices] ApplicationService service)
        {
            var apps = await service.GetAsync();
            ViewBag.Apps = new SelectList(apps, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Route("Request/Add")]
        public async Task<IActionResult> Add(
            [FromServices] RequestService service,
            RequestDto dto)
        {
            await service.AddAsync(dto);
            _logger.LogInformation($"Added request { dto.Name } {DateTime.UtcNow.ToLongTimeString()}");
            return Redirect("~/Request/Index");
        }

        [HttpGet]
        [Route("Request/Edit/{id}")]
        public async Task<IActionResult> Edit(
            [FromServices] RequestService requestService,
            [FromServices] ApplicationService appService,
            long id)
        {
            var dto = await requestService.GetById(id);
            var apps = await appService.GetAsync();
            ViewBag.Apps = new SelectList(apps, "Id", "Name", dto.ApplicationId);
            return View(dto);
        }

        [HttpPost]
        [Route("Request/Edit/{id}")]
        public async Task<IActionResult> Edit(
            [FromServices] RequestService requestService,
            RequestDto dto)
        {
            await requestService.UpdateAsync(dto);
            _logger.LogInformation($"Edit request { dto.Id } {DateTime.UtcNow.ToLongTimeString()}");
            return Redirect("~/Request/Index/");
        }

        [Route("Request/Delete/{id}")]
        public async Task<IActionResult> Delete(
            long id,
            [FromServices] RequestService service)
        {
            await service.DeleteAsync(id);
            _logger.LogInformation($"Deleted request { id } { DateTime.UtcNow.ToLongTimeString()}");
            return Redirect("~/Request/Index/");
        }
    }
}