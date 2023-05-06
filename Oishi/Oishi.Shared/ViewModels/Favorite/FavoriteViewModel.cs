namespace Oishi.Shared.ViewModels.Favorite
{
    public class FavoriteViewModel
    {
        public int UserAccountId { get; set; }
        public int AdvertisementId { get; set; }

        public ViewModels.Advertisement.AdvertisementViewModel? Advertisement { get; set; }
    }
}
