using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MogobariWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL
{
    public class CustomerManager
    {
        private readonly Mogobari_dbContext _context;

        public CustomerManager()
        {
            _context = new Mogobari_dbContext();
        }


        public List<Customer> GetCustomers()
        {
            return _context.Customer
                            .Include(cus=>cus.Address)
                            .ToList();
        }
        public Customer GetCustomer(string number)
        {
            Customer  customer =   _context.Customer
                                        .Include(cus=>cus.Address)
                                        .Where(cus=>cus.MobileNumber == number).FirstOrDefault();

            return customer;
        }


        public void RegisterCustomer()
        {
            return;
        }


        public Customer RegisterCustomer(Customer customer)
        {
            #region default value
            customer.Active = true;
            customer.Deleted = false;
            customer.CreatedOn = DateTime.Now;
            customer.LastLogin = DateTime.Now;
            customer.IsSystemAccount = false;
            #endregion

            _context.Customer.Add(customer);
            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                    return null;
            }
            return customer;
        }


        /// <summary>
        /// Get method for update
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Customer</returns>
        public Customer Update(string number)
        {

            var cunstomer =  _context.Customer
                                 .Where(cus => cus.MobileNumber == number)
                                 .FirstOrDefault();
             
            return cunstomer;

        }

        /// <summary>
        /// Update method for update
        /// </summary>
        /// <param name="number"></param>
        /// <param name="customer"></param>
        /// <returns>bool</returns>
        public bool Update(string number, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
               return false;
            }

            return true;

        }

        /// <summary>
        /// Get for Delete method
        /// </summary>
        /// <param name="MobileNumber"></param>
        /// <returns></returns>
        public Customer Delete(string MobileNumber)
        {
            return GetCustomer(MobileNumber); ///Calling Getcustomer method for customer
        }

        public bool DeleteConfirm(string MobileNumber)
        {
            if (!CustomerExists(MobileNumber))
            {
                return false;
            }

            Customer customer = GetCustomer(MobileNumber);
            _context.Customer.Remove(customer);
            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                return false;
            }

            return true ;
        }


        public bool CustomerExists(string MobileNumber)
        {
            return  _context.Customer
                            .Where(cus=>cus.Deleted==false)
                            .Any(e => e.MobileNumber == MobileNumber);

        }



    }
}
