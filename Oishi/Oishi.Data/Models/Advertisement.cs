using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        public int SubcategoryId { get; set; }


        public UserAccount UserAccount { get; set; }
        public MunicipalityOrCity MunicipalityOrCity { get; set; }
        public Subcategory Subcategory { get; set; }
        public ICollection<AdvertisementHighlight>? AdvertisementHighlights { get; set; }

        public ICollection<Image>? Images { get; set; }
    }
}
