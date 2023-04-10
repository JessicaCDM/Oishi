﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        [StringLength(48)]
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; } 

        public ICollection<Advertisement> Advertisements { get; set; }

    }
}
