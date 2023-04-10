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
    public class AdvertisementStatus
    {
        [Key]
        public int Id { get; set; }

        [StringLength(32)]
        public string Code { get; set; }


        public ICollection<Advertisement> Advertisements { get; set; }

    }
}
