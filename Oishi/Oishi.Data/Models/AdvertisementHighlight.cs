using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oishi.Data.Models
{
    public class AdvertisementHighlight
    {
        [Key]
        public int AdvertisementId { get; set; }

        [Key]
        public int HighLightTypeId { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal AmountTax { get; set; }

        public Advertisement Advertisement { get; set; }
        public HighlightType HighlightType { get; set; }

    }
}
