using Oishi.Shared.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Shared.ViewModels.HighlightsHomePage
{
    public class HightlightsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
        public string SubCategoryDescription { get; set; }     
        public string Description { get; set; }

        public List<SubCategoryViewModel> SubCategories { get; set; }
        public Oishi.Shared.ViewModels.Category.CategoryViewModel[] Categories { get; set; }
        public Oishi.Shared.ViewModels.Advertisement.AdvertisementViewModel[] Advertisements { get; set; }
        public ICollection<Favorite.FavoriteViewModel>? Favorites { get; set; } = new List<Favorite.FavoriteViewModel>();
    }
}
