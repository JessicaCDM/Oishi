using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Oishi.Data.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [StringLength(16)]
        public string Code { get; set; }


        public ICollection<UserAccount>? UserAccounts { get; set; }

    }
}
