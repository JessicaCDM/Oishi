using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Oishi.Data.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }

        [StringLength(48)]
        public string Description { get; set; }

        public int CategoryId { get; set; }


        public Category Category { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }

    }
}
