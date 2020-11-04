using System;
using System.Collections.Generic;

namespace MogobariWebAPI.Models
{
    public partial class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public int? PictureId { get; set; }
        public int? AddressId { get; set; }
        public string AdminComment { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string MetaDescription { get; set; }
        public string MobileNumber { get; set; }

        public virtual Address Address { get; set; }
    }
}
