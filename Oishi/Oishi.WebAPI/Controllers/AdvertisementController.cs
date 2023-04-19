using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Oishi.Data.Models;

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

        [HttpGet]
        public Data.Models.Advertisement? GetFirst(int id)
        {
            return _advertisementProvider.GetFirst(id);
        }

        [HttpGet]
        public Data.Models.Advertisement Insert(string title, string description, decimal price, int userAccount, int municipalityOrCity, int subCategory)
        {
            Data.Models.Advertisement newAdvertisement = new Data.Models.Advertisement()
            {
                Title = title,
                Description = description,
                Price = price,
                AdvertisementStatus = Data.Enums.AdvertisementStatus.ToApprove,
                UserAccountId = userAccount,
                MunicipalityOrCityId = municipalityOrCity,
                SubcategoryId = subCategory,

            };

            // newAdvertisement = _advertisementProvider.Insert(newAdvertisement);

            return _advertisementProvider.Insert(newAdvertisement);
        }

        [HttpGet]
        public Data.Models.Advertisement? Update(int id, string title, string description, decimal price, int municipalityOrCity)
        {
            Data.Models.Advertisement newAdvertisement = new Data.Models.Advertisement()
            {
                Id = id,
                Title = title,
                Description = description,
                Price = price,
                AdvertisementStatus = Data.Enums.AdvertisementStatus.ToApprove,
                MunicipalityOrCityId = municipalityOrCity,
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
