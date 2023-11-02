
using Microsoft.AspNetCore.Mvc;

namespace RequestApplication.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
