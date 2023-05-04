﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Shared.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public List<SubCategoryViewModel> SubCategories { get; set; }
    }
}
