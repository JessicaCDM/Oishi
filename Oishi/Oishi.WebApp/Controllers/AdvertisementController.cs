﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oishi.Shared.ViewModels.Advertisement;
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

				// Get User ID if login is done
				int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

				Shared.ViewModels.Advertisement.AdvertisementSearchViewModel searchModel = new Shared.ViewModels.Advertisement.AdvertisementSearchViewModel()
				{
					FavoriteUserAccountId = userId,
					SubCategoryId = id
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
		public async Task<IActionResult> Product(int? id)
		{
			Shared.ViewModels.Advertisement.ProductViewModel model = new Shared.ViewModels.Advertisement.ProductViewModel();

			Shared.ViewModels.Category.CategoryViewModel[] categories = null;
			using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
			{
				string? apiResponse = await webAPIProvider.Get($"Category/Get");
				if (apiResponse != null)
					categories = JsonConvert.DeserializeObject<Shared.ViewModels.Category.CategoryViewModel[]>(apiResponse);
			}
			if (categories != null)
			{
				model.Categories = categories;
				return View(model);
			}

			throw new Exception();
		}
		// GET Advertisement/Create
		public async Task<IActionResult> Create()
		{
			Shared.ViewModels.Advertisement.CreateViewModel model = new Shared.ViewModels.Advertisement.CreateViewModel();

			Shared.ViewModels.Category.CategoryViewModel[] categories = null;
			using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
			{
				string? apiResponse = await webAPIProvider.Get("Category/Get");
				if (apiResponse != null)
					categories = JsonConvert.DeserializeObject<Shared.ViewModels.Category.CategoryViewModel[]>(apiResponse);
			}
			if (categories != null)
			{
				model.Subcategories = categories.SelectMany(c => c.SubCategories).ToArray();
				return View(model);
			}
			throw new Exception();
		}

		// POST Advertisement/Create
		[HttpPost]
		public async Task<IActionResult> Create(Shared.ViewModels.Advertisement.CreateViewModel model)
		{
            Shared.ViewModels.Category.CategoryViewModel[] categories = null;
            using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
			{
				string? response = await webAPIProvider.Post($"Advertisement/Insert", model);
				System.Diagnostics.Debug.WriteLine(response);
				if (ViewData != null)
				{
					ViewData["Success"] = "Anúncio criado com sucesso!";
				}

                string? apiResponse = await webAPIProvider.Get("Category/Get");
                if (apiResponse != null)
                    categories = JsonConvert.DeserializeObject<Shared.ViewModels.Category.CategoryViewModel[]>(apiResponse);
            }
            if (categories != null)
            {
                model.Subcategories = categories.SelectMany(c => c.SubCategories).ToArray();
                return View(model);
            }
            throw new Exception();
        }

		// GET Advertisement/Edit?Id=123

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

		// POST Advertisement/Update?Id=123
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

