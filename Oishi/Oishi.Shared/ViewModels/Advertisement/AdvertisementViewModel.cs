namespace Oishi.Shared.ViewModels.Advertisement
{
    public class AdvertisementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
        public int SubcategoryId { get; set; }
        public string SubCategoryDescription { get; set; }
        public int ParentCategoryId { get; set; }
        public string ParentCategoryDescription { get; set; }
        public string MunicipalityOrCityName { get; set; }

        public ICollection<Favorite.FavoriteViewModel>? Favorites { get; set; } = new List<Favorite.FavoriteViewModel>();
    }
}
