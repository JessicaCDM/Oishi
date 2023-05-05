using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private Data.Providers.Region _regionProvider;
        
        public RegionController(Data.Contexts.DatabaseContext db)
        {
            _regionProvider = new Data.Providers.Region(db);
        }

        [HttpGet]
        public Data.Models.Region[] Get()
        {
            return _regionProvider.Get().ToArray();
        }

        [HttpGet]
        public Data.Models.Region? GetFirst(int id)
        {
            return _regionProvider.GetFirstById(id);
        }

        [HttpGet]
        public Data.Models.Region Insert(string name)
        {
            Data.Models.Region newRegion = new Data.Models.Region()
            {
                Name = name,
            };

            return _regionProvider.Insert(newRegion);
        }

        [HttpGet]
        public Data.Models.Region? Update(int id, string name)
        {
            Data.Models.Region newRegion = new Data.Models.Region()
            {
                Id      = id,
                Name    = name,
            };

            return _regionProvider.Update(newRegion);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _regionProvider.Delete(id);
        }
    }
}
