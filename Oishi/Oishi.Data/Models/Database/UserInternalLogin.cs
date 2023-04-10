using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Oishi.Data.Models.Database
{
    public class UserInternalLogin
    {
        [Key]
        public int UserAccountId { get; set; }
        [StringLength(128)]
        public string PasswordHash { get; set; }
        [StringLength(128)]
        public string ConfirmationToken { get; set; }
        [StringLength(128)]
        public string? RecoveryToken { get; set; }


        public UserAccount UserAccount { get; set; }


    }
}
