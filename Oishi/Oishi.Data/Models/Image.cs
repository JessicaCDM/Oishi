using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Oishi.Data.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string SourceImage { get; set; }
        public int AdvertisementId { get; set; }

        public Advertisement? Advertisement { get; set; }
    }
}
