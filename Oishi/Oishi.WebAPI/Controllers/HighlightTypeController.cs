using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HighlightTypeController : ControllerBase
    {
        private Data.Providers.HighlightType _highlightTypeProvider;
        
        public HighlightTypeController(Data.Contexts.DatabaseContext db)
        {
            _highlightTypeProvider = new Data.Providers.HighlightType(db);
        }

        [HttpGet]
        public Data.Models.HighlightType[] Get()
        {
            return _highlightTypeProvider.Get().ToArray();
        }

        [HttpGet]
        public Data.Models.HighlightType? GetFirst(int id)
        {
            return _highlightTypeProvider.GetFirstById(id);
        }

        [HttpGet]
        public Data.Models.HighlightType Insert(string description, decimal price, byte days)
        {
            Data.Models.HighlightType newHighlightType = new Data.Models.HighlightType()
            {
                Description = description,
                Price = price,
                Days = days

            };

            return _highlightTypeProvider.Insert(newHighlightType);
        }

        [HttpGet]
        public Data.Models.HighlightType? Update(int id, string description, decimal price, byte days)
        {
            Data.Models.HighlightType newHighlightType = new Data.Models.HighlightType()
            {
                Id= id,
                Description = description,
                Price = price,
                Days = days,

             

            };

            return _highlightTypeProvider.Update(newHighlightType);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _highlightTypeProvider.Delete(id);
        }
    }
}
