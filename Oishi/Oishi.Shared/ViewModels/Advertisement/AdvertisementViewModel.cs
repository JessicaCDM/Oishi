using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oishi.Shared.ViewModels.Category;

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
    }
}
