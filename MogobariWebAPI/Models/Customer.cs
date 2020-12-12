using System;
using System.Collections.Generic;

namespace MogobariWebAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerPassword = new HashSet<CustomerPassword>();
            RefreshTokenForCustomer = new HashSet<RefreshTokenForCustomer>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string EmailToRevalidate { get; set; }
        public string SystemName { get; set; }
        public int? BillingAddressId { get; set; }
        public string PhotoPath { get; set; }
        public int? AddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public bool? HasShoppingCartItems { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public bool IsSystemAccount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastLogin { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<CustomerPassword> CustomerPassword { get; set; }
        public virtual ICollection<RefreshTokenForCustomer> RefreshTokenForCustomer { get; set; }
    }
}
