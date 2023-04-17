using Microsoft.AspNetCore.Mvc;
using Oishi.Data.Models;
using Oishi.Data.Providers;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ExternalProviderController : ControllerBase
    {
        private ExternalProviderRepository _externalProvider;

        public ExternalProviderController(Data.Contexts.DatabaseContext dbContext)
        {
            _externalProvider = new ExternalProviderRepository (dbContext);
        }

        [HttpGet]
        public ExternalProvider[] Get()
        {
            return _externalProvider.Get().ToArray();
        }

        [HttpGet]
        public ExternalProvider? GetFirst(int id) 
        {
            return _externalProvider.GetFirst(id);
        }

        [HttpGet]
        public ExternalProvider Insert(int id, string name, string endPoint)
        {
            ExternalProvider externalProvider = new ExternalProvider()
            {
                Id = id,
                Name = name,
                EndpointUrl = endPoint
            };
            return _externalProvider.Insert(externalProvider);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _externalProvider.Delete(id);
        }
    }
}
