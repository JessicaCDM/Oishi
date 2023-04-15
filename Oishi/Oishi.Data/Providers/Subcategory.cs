using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Providers
{
    public class Subcategory : IProvider<Models.Subcategory>
    {
        private Contexts.DatabaseContext _db;

        public Subcategory(Contexts.DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.Subcategory> Get()
        {
            return _db.Subcategories.ToList();
        }

        public Models.Subcategory? GetFirst(int id)
        {
            return _db.Subcategories.FirstOrDefault(x => x.Id == id);
        }

        public Models.Subcategory Insert(Models.Subcategory item)
        {
            _db.Subcategories.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Models.Subcategory? Update(Models.Subcategory item)
        {
            Models.Subcategory? subcategoryToUpdate = _db.Subcategories.FirstOrDefault(x => x.Id == item.Id);
            if (subcategoryToUpdate != null)
            {
                subcategoryToUpdate.Description = item.Description;
                subcategoryToUpdate.CategoryId = item.CategoryId;
                _db.SaveChanges();
            }

            return subcategoryToUpdate;
        }

        public bool Delete(int id)
        {
            Models.Subcategory? subcategoryToDelete = _db.Subcategories.FirstOrDefault(x => x.Id == id);
            if (subcategoryToDelete != null)
            {
                _db.Subcategories.Remove(subcategoryToDelete);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
