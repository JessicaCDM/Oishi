using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oishi.Shared.ViewModels.Advertisement;
using Oishi.Shared.ViewModels.Category;
using System.Security.Claims;

namespace Oishi.WebApp.Controllers
{
	public class AdvertisementController : Controller
	{
		private string _OishiWebApiAddress;


		public AdvertisementController(IConfiguration configuration)
		{
			_OishiWebApiAddress = configuration.GetValue<string>("OishiWebApiAddress");
		}

		public async Task<IActionResult> Index(int? id, string? searchString)
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

				// Get User ID if login is done
				int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

				Shared.ViewModels.Advertisement.AdvertisementSearchViewModel searchModel = new Shared.ViewModels.Advertisement.AdvertisementSearchViewModel()
				{
					FavoriteUserAccountId = userId,
					SubCategoryId = id,
					Search = searchString
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

        // GET Advertisement/Detail/5
        public async Task<IActionResult> Detail(int id)
		{
			Shared.ViewModels.Advertisement.AdvertisementViewModel model = new Shared.ViewModels.Advertisement.AdvertisementViewModel();

			using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
            {
                string? apiResponse;
                // Get User ID if login is done
                if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
				{
					apiResponse = await webAPIProvider.Get($"Advertisement/GetFirst?id={id}&favoriteUserAccountId={userId}");
                }
				else
                {
                    apiResponse = await webAPIProvider.Get($"Advertisement/GetFirst?id={id}");
                }

				if (apiResponse != null)
                    model = JsonConvert.DeserializeObject<Shared.ViewModels.Advertisement.AdvertisementViewModel>(apiResponse);
			}
			if (model != null)
			{
				return View(model);
			}

			throw new Exception();
		}

		// GET Advertisement/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST Advertisement/Create
		[HttpPost]
		public async Task<IActionResult> Create(Shared.ViewModels.Advertisement.CreateViewModel model)
		{
			using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
			{
				string? response = await webAPIProvider.Post($"Advertisement/Insert", model);
				System.Diagnostics.Debug.WriteLine(response);

				ViewData["Success"] = "Anúncio criado com sucesso!";
			}

			return View();
		}

		// GET Advertisement/Edit/5

		public async Task<IActionResult> Edit(int id)
		{
			Shared.ViewModels.Advertisement.CreateViewModel? model = null;
			using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
			{
				string? response = await webAPIProvider.Get($"Advertisement/GetFirst?id={id}");
				if (response != null)
					model = JsonConvert.DeserializeObject<Shared.ViewModels.Advertisement.CreateViewModel>(response);
			}
			ViewData["EditView"] = true;

			if (model == null)
			{
				throw new Exception("Houve um erro");
			}
			return View("Edit", model);
		}

		// POST Advertisement/Update
		[HttpPost]
		public async Task<IActionResult> Edit(CreateViewModel model)
		{
			using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
			{
				string? response = await webAPIProvider.Post($"Advertisement/Update", model);
				System.Diagnostics.Debug.WriteLine(response);

				if (response != null)
				{
					ViewData["Success"] = "Anúncio editado com sucesso!";
				}
				else
				{
					throw new Exception("Erro!");
				}
			}
			return View();
		}
	}
}

