using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oishi.WebApp.Models;
using System.Configuration;
using System.Diagnostics;

namespace Oishi.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string _OishiWebApiAddress;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _OishiWebApiAddress = configuration.GetValue<string>("OishiWebApiAddress");
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Shared.ViewModels.Category.CategoryViewModel[] categories = null;
            using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
            {
                string? apiResponse = await webAPIProvider.Get($"Category/Get");
                if (apiResponse != null)
                    categories = JsonConvert.DeserializeObject<Shared.ViewModels.Category.CategoryViewModel[]>(apiResponse);
            }

            if (categories != null)
            {
                return View(categories);
            }

            throw new Exception();
        }
        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Us()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}