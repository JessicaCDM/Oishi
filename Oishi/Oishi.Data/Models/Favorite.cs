using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Oishi.Data.Models
{
    public class Favorite
    {
        [Key]
        public int UserAccountId { get; set; }

        [Key]
        public int AdvertisementId { get; set; }

        public DateTime Date { get; set; }

        

        public Advertisement? Advertisement { get; set; }
        public UserAccount? UserAccount { get; set; }

    }
}
