using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private Data.Providers.Subcategory _subcategoryProvider;
        
        public SubcategoryController(Data.Contexts.DatabaseContext db)
        {
            _subcategoryProvider = new Data.Providers.Subcategory(db);
        }

        [HttpGet]
        public Data.Models.Subcategory[] Get()
        {
            return _subcategoryProvider.Get().ToArray();
        }

        [HttpGet]
        public Data.Models.Subcategory? GetFirst(int id)
        {
            return _subcategoryProvider.GetFirst(id);
        }

        [HttpGet]
        public Data.Models.Subcategory Insert(string description, int category)
        {
            Data.Models.Subcategory newSubcategory = new Data.Models.Subcategory()
            {
                Description = description,
                CategoryId = category,
            };

            return _subcategoryProvider.Insert(newSubcategory);
        }

        [HttpGet]
        public Data.Models.Subcategory? Update(int id, string description, int category)
        {
            Data.Models.Subcategory newSubcategory = new Data.Models.Subcategory()
            {
                Id= id,
                Description = description,
                CategoryId = category,

            };

            return _subcategoryProvider.Update(newSubcategory);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _subcategoryProvider.Delete(id);
        }
    }
}
