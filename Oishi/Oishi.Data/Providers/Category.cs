using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Oishi.Data.Providers
{
    public class Category : IProvider<Models.Category>
    {
        private Contexts.DatabaseContext _db;

        public Category(Contexts.DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.Category> Get()
        {
            return _db.Categories.Include(x => x.SubCategories).ToList();
        }

        public Models.Category? GetFirstById(int id)
        {
            return _db.Categories.FirstOrDefault(x => x.Id == id);
        }

        public Models.Category Insert(Models.Category item)
        {
            _db.Categories.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Models.Category? Update(Models.Category item)
        {
            Models.Category? categoryToUpdate = _db.Categories.FirstOrDefault(x => x.Id == item.Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Description = item.Description;
                _db.SaveChanges();
            }

            return categoryToUpdate;
        }

        public bool Delete(int id)
        {
            Models.Category? categoryToDelete = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryToDelete != null)
            {
                _db.Categories.Remove(categoryToDelete);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
