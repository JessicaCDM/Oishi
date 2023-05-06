using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Construction;
using Newtonsoft.Json;
using Oishi.Shared.ViewModels.Account;
using Oishi.Shared.ViewModels.Advertisement;
using System.Configuration;
using System.Reflection;

namespace Oishi.WebApp.Controllers
{
    public class AdvertisementController : Controller
    {
        private string _OishiWebApiAddress;
        public AdvertisementController(IConfiguration configuration)
        {
            _OishiWebApiAddress = configuration.GetValue<string>("OishiWebApiAddress");
        }
        public IActionResult Index()
        {
            return View();
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
            return View("Edit", model);
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
