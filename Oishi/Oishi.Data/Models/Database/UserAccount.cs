using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Models.Database
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [StringLength(48)]
        public string Username { get; set; }

        [StringLength(320)]
        public string Email { get; set; }

        [StringLength(13)]
        public string? Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        public DateTime? LastLogin { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        public DateTime DateCreated { get; set; }

        public Enums.UserAccountStatus UserAccountStatus { get; set; }

        public int ProfileId { get; set; }
        public int EmailValidationStatusId { get; set; }


        public ICollection<UserExternalLogin>? UserExternalLogins { get; set; }
        public UserInternalLogin? UserInternalLogin { get; set; }

        public Profile Profile { get; set; }

        public EmailValidationStatus EmailValidationStatus { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }



    }
}
