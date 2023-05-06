using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oishi.Data.Models
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
        public string? SourceImage { get; set; }
        public DateTime DateCreated { get; set; }

        public Shared.Enums.UserAccountStatus UserAccountStatus { get; set; }

        public int ProfileId { get; set; }

        [NotMapped]
        public Guid? ConfirmationToken => UserInternalLogin?.ConfirmationToken;

        [NotMapped]
        public string? Password => UserInternalLogin?.PasswordHash;



        public ICollection<UserExternalLogin>? UserExternalLogins { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
        public ICollection<Message>? ReceivedMessages { get; set; }
        public ICollection<Message>? SentMessages { get; set; }
        public UserInternalLogin? UserInternalLogin { get; set; }
        public Profile Profile { get; set; }

    }
}
