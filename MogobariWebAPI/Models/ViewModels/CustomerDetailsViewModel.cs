using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.Models.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public CustomerDetailsViewModel()
        {
            customer = new Customer();
            address = new Address();
        }
        public Customer customer { get; set; }
        public bool EnableCustomerAddress { get; set; } = false;
        public Address address { get; set; }
    }
}
