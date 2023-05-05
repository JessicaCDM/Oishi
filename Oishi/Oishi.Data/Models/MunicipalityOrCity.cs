using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Oishi.Data.Models
{
    public class MunicipalityOrCity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(56)]
        public string Name { get; set; }
        public int RegionId { get; set; }


        public Region Region { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }

    }
}
