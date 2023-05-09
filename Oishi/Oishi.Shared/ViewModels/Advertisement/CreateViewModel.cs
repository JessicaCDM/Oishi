using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oishi.Shared.ViewModels.Advertisement
{
    public class CreateViewModel
    {
        public int Id { get; set; }

        [DisplayName("Insira título")]
        [Required(ErrorMessage = "Insira um título")]
        [StringLength(64)]
        public string Title { get; set; }

        [DisplayName("Insira uma descrição")]
        [Required(ErrorMessage = "Insira uma descrição")]
        [StringLength(1000)]
        public string Description { get; set; }

        [DisplayName("Insira um preço")]
        [Required(ErrorMessage = "Insira um preço")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }
        public int UserAccountId { get; set; }
        public int MunicipalityOrCityId { get; set; }
        public int SubcategoryId { get; set; }
    }
}
