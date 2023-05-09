using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Shared.ViewModels.Advertisement
{
	public class AdvertisementSearchViewModel
	{
        public int? SubCategoryId { get; set; }
        public int? FavoriteUserAccountId { get; set; }
        public bool IsHighlighted { get; set; }
        public int? NumberOfRows { get; set; }
    }
}
