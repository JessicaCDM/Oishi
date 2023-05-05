using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private Data.Providers.Favorite _favoriteProvider;
        
        public FavoriteController(Data.Contexts.DatabaseContext db)
        {
            _favoriteProvider = new Data.Providers.Favorite(db);
        }

        [HttpGet]
        public Data.Models.Favorite[] Get()
        {
            return _favoriteProvider.Get().ToArray();
        }

        [HttpGet]
        public Data.Models.Favorite? GetFirst(int userAccountId, int advertisementId)
        {
            return _favoriteProvider.GetFirst(userAccountId, advertisementId);
        }

        [HttpGet]
        public Data.Models.Favorite Insert(int userAccountId, int advertisementId)
        {
            Data.Models.Favorite newFavorite = new Data.Models.Favorite()
            {
                UserAccountId= userAccountId,
                AdvertisementId= advertisementId
            };

            return _favoriteProvider.Insert(newFavorite);
        }

        [HttpGet]
        public bool Delete(int userAccountId, int advertisementId)
        {
            return _favoriteProvider.Delete(userAccountId, advertisementId);
        }

        [HttpGet]
        public bool Toggle(int userAccountId, int advertisementId)
        {
            return _favoriteProvider.Toggle(userAccountId, advertisementId);
        }
    }
}
