using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Models.Database
{
    public class ExternalProvider
    {
        [Key]
        public int Id { get; set; }

        [StringLength(48)]
        public string Name { get; set; }

        [StringLength(255)]
        public string EndpointUrl { get; set; }

        public ICollection<UserExternalLogin> UserExternalLogins { get; set; }
    }
}
