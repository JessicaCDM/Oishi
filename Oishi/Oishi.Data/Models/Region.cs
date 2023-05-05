using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Oishi.Data.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [StringLength(48)]
        public string Name { get; set; }


        public ICollection<MunicipalityOrCity> MunicipalityOrCities { get; set; }

    }
}
