using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Models.Database
{
    public class EmailValidationStatus
    {
        [Key]
        public int Id { get; set; }
        public bool IsValid { get; set; }

        public ICollection<UserAccount> UserAccounts { get; set; }
    }
}
