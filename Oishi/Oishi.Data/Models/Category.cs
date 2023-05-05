using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Oishi.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(48)]
        public string Description { get; set; }

        public ICollection<Subcategory>? SubCategories { get; set; }

    }
}
