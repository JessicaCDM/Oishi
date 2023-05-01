using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebApp.Controllers
{
    public class AdvertisementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
