using Oishi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Providers
{
    public class Favorite 
    {
        private Contexts.DatabaseContext _db;

        public Favorite(Contexts.DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.Favorite> Get()
        {
            return _db.Favorites.ToList();
        }

        public Models.Favorite? GetFirst(int userAccountId, int advertisementId)
        {
            return _db.Favorites.FirstOrDefault(x => x.UserAccountId == userAccountId && x.AdvertisementId == advertisementId);
        }

        public Models.Favorite Insert(Models.Favorite item)
        {
            item.Date = DateTime.Now;
            _db.Favorites.Add(item);
            _db.SaveChanges();
            return item;
        }

        public bool Delete(int userAccountId, int advertisementId)
        {
            Models.Favorite? favoriteToDelete = _db.Favorites.FirstOrDefault(x => x.UserAccountId == userAccountId && x.AdvertisementId == advertisementId);
            if (favoriteToDelete != null)
            {
                _db.Favorites.Remove(favoriteToDelete);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
