using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Models
{
    public class UserExternalLogin
    {
        [Key]
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int ExternalProviderId { get; set; }


        public UserAccount UserAccount { get; set; }
        public ExternalProvider ExternalProvider { get; set; }

    }
}
