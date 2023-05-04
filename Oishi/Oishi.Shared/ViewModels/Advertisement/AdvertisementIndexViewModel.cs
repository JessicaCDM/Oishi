using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Shared.ViewModels.Advertisement
{
    public class AdvertisementIndexViewModel
    {
        public Oishi.Shared.ViewModels.Category.CategoryViewModel[] Categories { get; set; }
        public Oishi.Shared.ViewModels.Advertisement.AdvertisementViewModel[] Advertisements{ get; set; }

    }
}
