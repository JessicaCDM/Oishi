using System.ComponentModel.DataAnnotations;

namespace Oishi.Data.Models
{
    public class ExternalProvider
    {
        [Key]
        public int Id { get; set; }

        [StringLength(48)]
        public string Name { get; set; }

        [StringLength(255)]
        public string EndpointUrl { get; set; }

        public ICollection<UserExternalLogin>? UserExternalLogins { get; set; }
    }
}
