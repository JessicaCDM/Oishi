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
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [StringLength(16)]
        public string Code { get; set; }


        public ICollection<UserAccount> UserAccounts { get; set; }

    }
}
