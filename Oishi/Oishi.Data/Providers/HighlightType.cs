using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Providers
{
    public class HighlightType : IProvider<Models.HighlightType>
    {
        private Contexts.DatabaseContext _db;

        public HighlightType(Contexts.DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.HighlightType> Get()
        {
            return _db.HighlightTypes.ToList();
        }

        public Models.HighlightType? GetFirstById(int id)
        {
            return _db.HighlightTypes.FirstOrDefault(x => x.Id == id);
        }

        public Models.HighlightType Insert(Models.HighlightType item)
        {
            _db.HighlightTypes.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Models.HighlightType? Update(Models.HighlightType item)
        {
            Models.HighlightType? highlightTypeToUpdate = _db.HighlightTypes.FirstOrDefault(x => x.Id == item.Id);
            if (highlightTypeToUpdate != null)
            {               
                highlightTypeToUpdate.Description = item.Description;
                highlightTypeToUpdate.Price= item.Price;
                highlightTypeToUpdate.Days = item.Days;
   
                
                _db.SaveChanges();
            }

            return highlightTypeToUpdate;
        }

        public bool Delete(int id)
        {
            Models.HighlightType? highlightTypeToDelete = _db.HighlightTypes.FirstOrDefault(x => x.Id == id);
            if (highlightTypeToDelete != null)
            {
                _db.HighlightTypes.Remove(highlightTypeToDelete);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
