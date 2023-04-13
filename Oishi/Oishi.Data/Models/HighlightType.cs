using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Models
{
    public class HighlightType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(48)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal Price { get; set; }

        public byte Days { get; set; }

        public ICollection<AdvertisementHighlight>? AdvertisementHighlights { get; set; }

    }
}
