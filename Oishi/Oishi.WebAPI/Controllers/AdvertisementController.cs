﻿using Microsoft.AspNetCore.Mvc;
using Oishi.Shared.ViewModels.Advertisement;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private Data.Providers.Advertisement _advertisementProvider;

        public AdvertisementController(Data.Contexts.DatabaseContext db)
        {
            _advertisementProvider = new Data.Providers.Advertisement(db);
        }

        [HttpGet]
        public Data.Models.Advertisement[] Get()
        {
            return _advertisementProvider.Get().ToArray();
        }

        [HttpPost]
        public Data.Models.Advertisement[] GetFiltered(AdvertisementSearchViewModel model)
        {
            return _advertisementProvider.GetFiltered(model).ToArray();
        }

        [HttpGet]
        public Data.Models.Advertisement? GetFirst(int id, int? favoriteUserAccountId)
        {
            return _advertisementProvider.GetFirstById(id, favoriteUserAccountId);
        }

        [HttpPost]
        public Data.Models.Advertisement Insert(CreateViewModel model)
        {
            Data.Models.Advertisement newAdvertisement = new Data.Models.Advertisement()
            {
                Title = model.Title,
                Description= model.Description,
                Price = model.Price,
                AdvertisementStatus = Shared.Enums.AdvertisementStatus.ToApprove,
                UserAccountId = 3,
                MunicipalityOrCityId = model.MunicipalityOrCityId,
                SubcategoryId = model.SubcategoryId,

            };
            
            // newAdvertisement = _advertisementProvider.Insert(newAdvertisement);

            return _advertisementProvider.Insert(newAdvertisement);
        }

        [HttpPost]
        public Data.Models.Advertisement? Update(CreateViewModel model)
        {
            Data.Models.Advertisement newAdvertisement = new Data.Models.Advertisement()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                AdvertisementStatus = Shared.Enums.AdvertisementStatus.ToApprove,
                MunicipalityOrCityId = model.MunicipalityOrCityId,
            };


            return _advertisementProvider.Update(newAdvertisement);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _advertisementProvider.Delete(id);
        }
    }
}
