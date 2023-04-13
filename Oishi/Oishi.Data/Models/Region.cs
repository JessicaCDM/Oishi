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
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [StringLength(48)]
        public string Name { get; set; }


        public ICollection<MunicipalityOrCity> MunicipalityOrCities { get; set; }

    }
}
