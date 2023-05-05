using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oishi.Data.Models
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }

        [StringLength(64)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public Shared.Enums.AdvertisementStatus AdvertisementStatus { get; set; }
        public int UserAccountId { get; set; }
        public int MunicipalityOrCityId { get; set; }
        [NotMapped]
        public string MunicipalityOrCityName => MunicipalityOrCity.Name;
        public int SubcategoryId { get; set; }
        [NotMapped]
        public string SubcategoryDescription => Subcategory.Description;


        public ICollection<AdvertisementHighlight>? AdvertisementHighlights { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
        public ICollection<Message>? Messages { get; set; }
        public UserAccount? UserAccount { get; set; }
        public MunicipalityOrCity? MunicipalityOrCity { get; set; }
        public Subcategory? Subcategory { get; set; }
    }
}
