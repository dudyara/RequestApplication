using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<List<RequestDto>>> Get(
            [FromServices] RequestService service)
        {
            var result = await service.GetAsync();
            _logger.LogInformation($"Got requests {DateTime.UtcNow.ToLongTimeString()}");
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<RequestDto>> Get(
            [FromQuery] long id,
            [FromServices] RequestService service)
        {
            var result = await service.GetById(id);
            _logger.LogInformation($"Got request {id} {DateTime.UtcNow.ToLongTimeString()}");
            return result;
        }

        [HttpDelete]
        public async Task<long> Delete(
            [FromQuery] long id,
            [FromServices] RequestService service)
        {
            long result = await service.DeleteAsync(id);
            _logger.LogInformation($"Deleted request { id } { DateTime.UtcNow.ToLongTimeString()}");
            return result;
        }

        [HttpPut]
        public async Task<ActionResult<RequestDto>> Update(
            [FromBody] RequestDto dto,
            [FromServices] RequestService service)
        {
            var result = await service.UpdateAsync(dto);
            _logger.LogInformation($"Updated request { dto.Id } { DateTime.UtcNow.ToLongTimeString()}");
            return result;
        }
    }
}