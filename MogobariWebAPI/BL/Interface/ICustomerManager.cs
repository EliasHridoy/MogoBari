using MogobariWebAPI.Models;
using MogobariWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL.Interface
{
    public interface ICustomerManager
    {

        List<Customer> GetCustomers();
        Customer GetCustomer(string number);
        void RegisterCustomer();
        CustomerWithToken RegisterCustomer(CustomerRegisterViewModel customerRegister);
        Task<CustomerWithToken> Login(Login login);
        Customer Update(string number);
        bool Update(string number, Customer customer);
        Customer Delete(string MobileNumber);
        bool DeleteConfirm(string MobileNumber);
        bool CustomerExists(string MobileNumber);



    }
}
