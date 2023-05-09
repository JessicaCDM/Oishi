using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private Data.Providers.Category _categoryProvider;

        public CategoryController(Data.Contexts.DatabaseContext db)
        {
            _categoryProvider = new Data.Providers.Category(db);
        }

        [HttpGet]
        public Data.Models.Category[] Get()
        {
            return _categoryProvider.Get().ToArray();
        }

        [HttpGet]
        public Data.Models.Category? GetFirst(int id)
        {
            return _categoryProvider.GetFirstById(id);
        }

        [HttpGet]
        public Data.Models.Category Insert(string description)
        {
            Data.Models.Category newCategory = new Data.Models.Category()
            {
                Description = description,
            };

            return _categoryProvider.Insert(newCategory);
        }

        [HttpGet]
        public Data.Models.Category? Update(int id, string description)
        {
            Data.Models.Category newCategory = new Data.Models.Category()
            {
                Id = id,
                Description = description,
            };

            return _categoryProvider.Update(newCategory);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _categoryProvider.Delete(id);
        }

    }
}
