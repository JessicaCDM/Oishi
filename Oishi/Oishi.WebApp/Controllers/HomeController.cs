using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oishi.WebApp.Models;
using System.Diagnostics;
using System.Security.Claims;

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

        public async Task<IActionResult> Index(int? id)
        {
            Shared.ViewModels.HighlightsHomePage.HightlightsViewModel model = new Shared.ViewModels.HighlightsHomePage.HightlightsViewModel();

            Shared.ViewModels.Category.CategoryViewModel[] categories = null;
            using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
            {
                string? apiResponse = await webAPIProvider.Get($"Category/Get");
                if (apiResponse != null)
                    categories = JsonConvert.DeserializeObject<Shared.ViewModels.Category.CategoryViewModel[]>(apiResponse);
            }

            Shared.ViewModels.Advertisement.AdvertisementViewModel[] advertisements = null;
            using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
            {
                string? apiResponse;

                // Get User ID if login is done
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

                Shared.ViewModels.Advertisement.AdvertisementSearchViewModel searchModel = new Shared.ViewModels.Advertisement.AdvertisementSearchViewModel()
                {
                    FavoriteUserAccountId = userId,
                    SubCategoryId = id,
                    NumberOfRows = 12
                };

                apiResponse = await webAPIProvider.Post($"Advertisement/GetFiltered", searchModel);

                if (apiResponse != null)
                    advertisements = JsonConvert.DeserializeObject<Shared.ViewModels.Advertisement.AdvertisementViewModel[]>(apiResponse);
            }

            if (categories != null && advertisements != null)
            {
                model.Categories = categories;
                model.Advertisements = advertisements;
                return View(model);
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