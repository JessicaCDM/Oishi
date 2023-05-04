namespace Oishi.Shared.ViewModels.Advertisement
{
    public class AdvertisementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
        public string SubCategoryDescription { get; set; }
        public string MunicipalityOrCityName { get; set; }

        public ICollection<Favorite.FavoriteViewModel>? Favorites { get; set; } = new List<Favorite.FavoriteViewModel>();
    }
}
