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
    public class MunicipalityOrCity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(56)]
        public string Name { get; set; }
        public int RegionId { get; set; }


        public Region Region { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }

    }
}
