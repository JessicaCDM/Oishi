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
    public class Favorite
    {
        [Key]
        public int UserAccountId { get; set; }

        [Key]
        public int AdvertisementId { get; set; }

        public DateTime Date { get; set; }

        

        public Advertisement Advertisement { get; set; }
        public UserAccount UserAccount { get; set; }

    }
}
