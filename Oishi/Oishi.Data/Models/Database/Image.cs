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
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string SrcImage { get; set; }
        public int AdvertisementId { get; set; }

        public Advertisement Advertisement { get; set; }

    }
}
