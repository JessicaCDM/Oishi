using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdvertisementHighlightController : ControllerBase
    {
        private Data.Providers.AdvertisementHighlight _advertisementHighlightProvider;
        
        public AdvertisementHighlightController(Data.Contexts.DatabaseContext db)
        {
            _advertisementHighlightProvider = new Data.Providers.AdvertisementHighlight(db);
        }

        [HttpGet]
        public Data.Models.AdvertisementHighlight[] Get()
        {
            return _advertisementHighlightProvider.Get().ToArray();
        }

        [HttpGet]
        public Data.Models.AdvertisementHighlight? GetFirst(int advertisementId, int hightLightTypeId)
        {
            return _advertisementHighlightProvider.GetFirst(advertisementId, hightLightTypeId);
        }

        [HttpGet]
        public Data.Models.AdvertisementHighlight Insert(int advertisementId, int hightLightTypeId, decimal amount, decimal amountTax)
        {
            Data.Models.AdvertisementHighlight newAdvertisementHighlight = new Data.Models.AdvertisementHighlight()
            {
                AdvertisementId= advertisementId,
                HighLightTypeId= hightLightTypeId,
                Amount= amount,
                AmountTax= amountTax,

            };

            return _advertisementHighlightProvider.Insert(newAdvertisementHighlight);
        }

        [HttpGet]
        public bool Delete(int advertisementId, int hightLightTypeId)
        {
            return _advertisementHighlightProvider.Delete(advertisementId, hightLightTypeId);
        }
    }
}
