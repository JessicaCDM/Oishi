using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MunicipalityOrCityController : ControllerBase
    {
        private Data.Providers.MunicipalityOrCity _municipalityOrCityProvider;
        
        public MunicipalityOrCityController(Data.Contexts.DatabaseContext db)
        {
            _municipalityOrCityProvider = new Data.Providers.MunicipalityOrCity(db);
        }

        [HttpGet]
        public Data.Models.MunicipalityOrCity[] Get()
        {
            return _municipalityOrCityProvider.Get().ToArray();
        }

        [HttpGet]
        public Data.Models.MunicipalityOrCity? GetFirst(int id)
        {
            return _municipalityOrCityProvider.GetFirstById(id);
        }

        [HttpGet]
        public Data.Models.MunicipalityOrCity Insert(string name, int region)
        {
            Data.Models.MunicipalityOrCity newMunicipalityOrCity = new Data.Models.MunicipalityOrCity()
            {
                Name = name,
                RegionId = region,
            };

            return _municipalityOrCityProvider.Insert(newMunicipalityOrCity);
        }

        [HttpGet]
        public Data.Models.MunicipalityOrCity? Update(int id, string name, int region)
        {
            Data.Models.MunicipalityOrCity newMunicipalityOrCity = new Data.Models.MunicipalityOrCity()
            {
                Id      = id,
                Name    = name,
                RegionId  = region,

            };

            return _municipalityOrCityProvider.Update(newMunicipalityOrCity);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _municipalityOrCityProvider.Delete(id);
        }
    }
}
