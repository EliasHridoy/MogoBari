﻿using System;
using System.Collections.Generic;

namespace MogobariWebAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PriceRanges { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }
        public int? PictureId { get; set; }
        public bool? ShowOnHomepage { get; set; }
        public bool? IncludeInTopMenu { get; set; }
        public bool? LimitedToStores { get; set; }
        public bool? Published { get; set; }
        public bool? Deleted { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
