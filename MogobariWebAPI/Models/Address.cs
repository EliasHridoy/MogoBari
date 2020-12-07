using System;
using System.Collections.Generic;

namespace MogobariWebAPI.Models
{
    public partial class Address
    {
        public Address()
        {
            Customer = new HashSet<Customer>();
            Store = new HashSet<Store>();
            Vendor = new HashSet<Vendor>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateOnUtc { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Store> Store { get; set; }
        public virtual ICollection<Vendor> Vendor { get; set; }
    }
}