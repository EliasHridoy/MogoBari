using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MogobariWebAPI.BL.Interface;
using MogobariWebAPI.Models;
using MogobariWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL
{
    public class CustomerManager: ICustomerManager
    {
        private readonly Mogobari_dbContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenManager _tokenManager;

        public CustomerManager(IMapper mapper, ITokenManager tokenManager)
        {
            _context = new Mogobari_dbContext();
            _mapper = mapper;
            _tokenManager = tokenManager;
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


        public CustomerWithToken RegisterCustomer(CustomerRegisterViewModel customerRegister)
        {
            CustomerPassword customerPassword = new CustomerPassword();
            var customer = _mapper.Map<CustomerRegisterViewModel, Customer>(customerRegister);

            #region default value
            customer.Active = true;
            customer.Deleted = false;
            customer.CreatedOn = DateTime.Now;
            customer.LastLogin = DateTime.Now;
            customer.IsSystemAccount = false;
            #endregion


            byte[] hash, salt;
            _tokenManager.GenerateHash(customerRegister.Password, out hash, out salt);
            customerPassword.PasswordHash = hash;
            customerPassword.PasswordSalt = salt;
            customerPassword.CreatedOnUtc = DateTime.UtcNow;
            customer.CustomerPassword.Add(customerPassword);

            

            _context.Customer.Add(customer);
            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                    return null;
            }
            var customerWithToken = _mapper.Map<Customer, CustomerWithToken>(customer);

            customerWithToken.AccessToken = _tokenManager.GenerateAccessToken(customerWithToken.Id);

            return customerWithToken;
        }



        public async Task<CustomerWithToken> Login(Login login)
        {

            var user = await _context.Customer
                                        .Where(u => u.Email == login.Email)
                                        .Include(cs => cs.CustomerPassword)
                                        .FirstOrDefaultAsync();
            
            bool res=false;
            ICollection<CustomerPassword> customerPassword = user.CustomerPassword;

            foreach(var pass in customerPassword)
            {
                byte[] hash, salt;
                hash = pass.PasswordHash;
                salt = pass.PasswordSalt;

                res = _tokenManager.ValidateHash(login.Password, hash, salt);
            }
            

            if (user != null && res)
            {

                //RefreshToken refreshToken = GenerateRefreshToken();
                //user.RefreshTokens.Add(refreshToken);
                //await _context.SaveChangesAsync();

                var customerWithToken = _mapper.Map<Customer, CustomerWithToken>(user);

                customerWithToken.AccessToken = _tokenManager.GenerateAccessToken(user.Id);
                //userWithToken.RefreshToken = refreshToken.Token;

                return customerWithToken;
            }

            return null;
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
