using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Providers
{
    public class Image : IProvider<Models.Image>
    {
        private Contexts.DatabaseContext _db;

        public Image(Contexts.DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.Image> Get()
        {
            return _db.Images.ToList();
        }

        public Models.Image? GetFirst(int id)
        {
            return _db.Images.FirstOrDefault(x => x.Id == id);
        }

        public Models.Image Insert(Models.Image item)
        {
            _db.Images.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Models.Image? Update(Models.Image item)
        {
            Models.Image? imageToUpdate = _db.Images.FirstOrDefault(x => x.Id == item.Id);
            if (imageToUpdate != null)
            {
                imageToUpdate.SourceImage = item.SourceImage;
                _db.SaveChanges();
            }

            return imageToUpdate;
        }

        public bool Delete(int id)
        {
            Models.Image? imageToDelete = _db.Images.FirstOrDefault(x => x.Id == id);
            if (imageToDelete != null)
            {
                _db.Images.Remove(imageToDelete); 
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
