using Microsoft.EntityFrameworkCore;

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

        public List<Models.Favorite> GetFiltered(int? userAccountId)
        {
            IQueryable<Models.Favorite> favorites = _db.Favorites
                .Include(x => x.Advertisement).ThenInclude(x => x.MunicipalityOrCity)
                .Include(x => x.Advertisement).ThenInclude(x => x.Subcategory);

            if (userAccountId.HasValue)
            {
                favorites = favorites.Where(x => x.UserAccountId == userAccountId);
            }

            return favorites.ToList();
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

        // Returns true if favorite added, returns false if favorite removed
        public bool Toggle(int userAccountId, int advertisementId)
        {
            bool result = false;

            if (_db.Favorites.Any(x => x.UserAccountId == userAccountId && x.AdvertisementId == advertisementId))
            {
                _db.Favorites.Remove(_db.Favorites.FirstOrDefault(x => x.UserAccountId == userAccountId && x.AdvertisementId == advertisementId));
                result = false;
            }
            else
            {
                _db.Favorites.Add(new Models.Favorite()
                {
                    AdvertisementId = advertisementId,
                    UserAccountId = userAccountId,
                    Date = DateTime.Now
                });
                result = true;
            }

            _db.SaveChanges();

            return result;
        }
    }
}
