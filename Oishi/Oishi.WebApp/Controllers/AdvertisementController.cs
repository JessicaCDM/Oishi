using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Newtonsoft.Json;
using Oishi.Shared.ViewModels.Account;


namespace Oishi.WebApp.Controllers
{
    public class AdvertisementController : Controller
    {
        private string _OishiWebApiAddress;

        public AdvertisementController(IConfiguration configuration)
        {
            _OishiWebApiAddress = configuration.GetValue<string>("OishiWebApiAddress");
        }

        public async Task<IActionResult> Index(int? id)
        {
            Shared.ViewModels.Advertisement.AdvertisementIndexViewModel model = new Shared.ViewModels.Advertisement.AdvertisementIndexViewModel();

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
                if (id.HasValue)
                {
                    // TODO: Replace '3' with the real UserAccountId
                    apiResponse = await webAPIProvider.Get($"Advertisement/GetFiltered?subCategoryId={id}&favoriteUserAccountId={3}");
                }
                else
                {
                    // TODO: Replace '3' with the real UserAccountId
                    apiResponse = await webAPIProvider.Get($"Advertisement/GetFiltered?favoriteUserAccountId={3}");
                }
                
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

        public IActionResult Create()
        {
            return View();
        }
    }
}
