using Microsoft.EntityFrameworkCore;
using Oishi.Data.Contexts;

namespace Oishi.Data.Providers
{
    public class Advertisement : IProvider<Models.Advertisement>
    {
        private Contexts.DatabaseContext _db;

        public Advertisement(DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.Advertisement> Get()
        {
            return _db.Advertisements
                .Include(x => x.Subcategory)
                .Include(x => x.MunicipalityOrCity)
                .ToList();
        }

        public List<Models.Advertisement> GetFiltered(Shared.ViewModels.Advertisement.AdvertisementSearchViewModel model)
        {
            IQueryable<Models.Advertisement> advertisements = _db.Advertisements
                .Include(x => x.Subcategory)
                .Include(x => x.MunicipalityOrCity);


            if (model.FavoriteUserAccountId.HasValue)
            {
                advertisements = advertisements.Include(x => x.Favorites.Where(x => x.UserAccountId == model.FavoriteUserAccountId));
            }

            if (model.IsHighlighted)
            {
                advertisements = advertisements.Where(x => x.AdvertisementHighlights.Any());
            }

            if (model.SubCategoryId.HasValue)
            {
                advertisements = advertisements.Where(x => x.SubcategoryId == model.SubCategoryId);
            }

            if (!string.IsNullOrEmpty(model.Search))
            {
                advertisements = advertisements.Where(x => x.Title == model.Search);
            }

            if (model.NumberOfRows.HasValue)
            {
                advertisements = advertisements.Take(model.NumberOfRows.Value);
            }

            return advertisements.OrderByDescending(x => x.StartDate).ToList();
        }

        public Models.Advertisement? GetFirstById(int id)
        {
            return _db.Advertisements.FirstOrDefault(x => x.Id == id);
        }

        public Models.Advertisement Insert(Models.Advertisement item)
        {
            item.StartDate= DateTime.Now;
            item.EndDate= DateTime.Now.AddMonths(1);
            item.AdvertisementStatus = Shared.Enums.AdvertisementStatus.ToApprove;
            _db.Advertisements.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Models.Advertisement? Update(Models.Advertisement item)
        {
            Models.Advertisement? advertisementToUpdate = _db.Advertisements.FirstOrDefault(x => x.Id == item.Id);
            if (advertisementToUpdate != null)
            {
                advertisementToUpdate.Title = item.Title;
                advertisementToUpdate.EndDate= DateTime.Now.AddMonths(1);
                advertisementToUpdate.AdvertisementStatus = Shared.Enums.AdvertisementStatus.ToApprove;
                advertisementToUpdate.Description = item.Description;
                advertisementToUpdate.Price= item.Price;
                advertisementToUpdate.LastUpdateDate = DateTime.Now;
                advertisementToUpdate.MunicipalityOrCity= item.MunicipalityOrCity;
                _db.SaveChanges();
            }

            return advertisementToUpdate;
        }

        public bool Delete(int id)
        {
            Models.Advertisement? advertisementToDelete = _db.Advertisements.FirstOrDefault(x => x.Id == id);
            if (advertisementToDelete != null)
            {
                _db.Advertisements.Remove(advertisementToDelete);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
