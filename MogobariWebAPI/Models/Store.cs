using System;
using System.Collections.Generic;

namespace MogobariWebAPI.Models
{
    public partial class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? VendorId { get; set; }
        public string CompanyName { get; set; }
        public int? AddressId { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyVat { get; set; }
        public bool? SslEnabled { get; set; }
        public int? DisplayOrder { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedUtc { get; set; }

        public virtual Address Address { get; set; }
    }
}