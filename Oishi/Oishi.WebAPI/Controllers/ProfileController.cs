using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private Data.Providers.Profile _profileProvider;
        
        public ProfileController(Data.Contexts.DatabaseContext db)
        {
            _profileProvider = new Data.Providers.Profile(db);
        }

        [HttpGet]
        public Data.Models.Profile[] Get()
        {
            return _profileProvider.Get().ToArray();
        }

        [HttpGet]
        public Data.Models.Profile? GetFirst(int id)
        {
            return _profileProvider.GetFirstById(id);
        }

        [HttpGet]
        public Data.Models.Profile Insert(string code)
        {
            Data.Models.Profile newProfile = new Data.Models.Profile()
            {
                Code = code,
            };

            return _profileProvider.Insert(newProfile);
        }

        [HttpGet]
        public Data.Models.Profile? Update(int id, string code)
        {
            Data.Models.Profile newProfile = new Data.Models.Profile()
            {
                Id= id,
                Code = code,
            };

            return _profileProvider.Update(newProfile);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _profileProvider.Delete(id);
        }
    }
}
