using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.Models.ViewModels
{
    public class VendorDetailsViewModel
    {
        public VendorDetailsViewModel()
        {
            vendor = new Vendor();
            address = new Address();
        }
        public Vendor vendor { get; set; }
        public bool EnableVendorAddress { get; set; } = true;
        public Address address { get; set; }
    }
}
