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

        // GET Advertisement/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
            {
                string? response = await webAPIProvider.Post($"Advertisement/Insert", model);
                System.Diagnostics.Debug.WriteLine(response);

                ViewData["Success"] = "Anúncio criado com sucesso!";
            }
                        
            return View();
        }

        // GET Advertisement/Update?Id=123

        public async Task<IActionResult> Edit(int id)
        {
            CreateViewModel? model = null;
            using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
            {
                string? response = await webAPIProvider.Get($"Advertisement/GetFirst?id={id}");
                if (response != null)
                    model = JsonConvert.DeserializeObject<CreateViewModel>(response);
            }
            ViewData["EditView"] = true;

            if (model == null)
            {
                throw new Exception("Houve um erro");
            }
            return View("Create", model);
        }

        // POST Advertisement/Update?Id=123
        [HttpPost]

        public async Task<IActionResult> Edit(CreateViewModel model)
        {
            using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
            {
                string? response = await webAPIProvider.Post($"Advertisement/Update", model);
                System.Diagnostics.Debug.WriteLine(response);

                ViewData["Success"] = "Anúncio editado com sucesso!";
            }

            return View();
        }







    }
}
