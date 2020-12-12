using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MogobariWebAPI.Models;
using MogobariWebAPI.BL;
using MogobariWebAPI.Models.ViewModels;
using AutoMapper;
using MogobariWebAPI.BL.Interface;

namespace MogobariWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        private readonly ICustomerManager _customerManager;
        private readonly AddressManager _addressManager;
        private readonly Mogobari_dbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(IMapper mapper, ICustomerManager customerManager)
        {
            _customerManager = customerManager;
            _addressManager = new AddressManager();
            _context = new Mogobari_dbContext();
            _mapper = mapper;
        }
        


        // GET: api/Customers
        [HttpGet("Get")]
        public  ActionResult<IEnumerable<Customer>> Get()
        {
            //            List<CustomerDetailsViewModel> customerDetailsList = new List<CustomerDetailsViewModel>();

            List<Customer> customers = _customerManager.GetCustomers();
            //List<Customer> customers = await _context.Customer
            //                    .Include(cus => cus.Address)
            //                    .ToListAsync();



            return customers;
        }

        // GET: api/Customers/01818789852
        [HttpGet("Get/{number}")]
        public ActionResult<Customer> Get(string number)
        {
            var customer = _customerManager.GetCustomer(number);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        
        // PUT: api/Customers/5
        [HttpGet("Update/{number}")]
        public ActionResult<CustomerDetailsViewModel> Update(string number)
        {
           CustomerDetailsViewModel customerDetails = new CustomerDetailsViewModel();


            customerDetails.customer =   _customerManager.Update(number);
            
            if(customerDetails.customer == null)
            {
                return NotFound();
            }


            customerDetails.address = _context.Address.Find(customerDetails.customer.AddressId);

            return customerDetails;
        }

        // PUT: api/Customers/5
        [HttpPut("Update/{number}")]
        public  ActionResult<CustomerDetailsViewModel> Update(string number,
            CustomerDetailsViewModel customerDetails)
        {
            if (number != customerDetails.customer.MobileNumber)
            {
                return BadRequest();
            }

            /// if customer not exit notfound
            if (!_customerManager.CustomerExists(number))
            {
                return NotFound();
            }

            if (customerDetails.EnableCustomerAddress == true)
            {
                if(customerDetails.customer.AddressId==null)
                {
                   int addresssId = _addressManager.Create(customerDetails.address);
                    if (addresssId == -1)
                        return NotFound();

                    customerDetails.customer.AddressId = addresssId; // new entry
                    customerDetails.address.Id = addresssId;
                }
                else
                {
                   // customerDetails.address.Id = customerDetails.customer.AddressId;
                   bool success = _addressManager.Update(customerDetails.address);
                    if (!success)
                        return NotFound();
                        
                }
            }
            

            if (!_customerManager.Update(number, customerDetails.customer))
            {
                return NotFound(); // faild
            }


            

            return customerDetails;
        }

                

        // Get: api/Customers/Register
        [HttpGet("Register")]
        public ActionResult<string> Register()
        {
            return "Register customer get method called";
        }

        // POST: api/Customers
        [HttpPost("Register")]
        public  ActionResult<CustomerWithToken> Register([FromForm]CustomerRegisterViewModel customerRegister)
        {
            /// if customer already exists badreq
            if (_customerManager.CustomerExists(customerRegister.MobileNumber))
            {
                return BadRequest();
            }

            CustomerWithToken savedCus = _customerManager.RegisterCustomer(customerRegister);
            if (savedCus == null)
            {
                return BadRequest();
            }

            return savedCus;

        }


        // POST: api/Customers
        [HttpPost("Login")]
        public async Task<ActionResult<CustomerWithToken>> Login([FromBody] Login login)
        {
            var customerWithToken = await _customerManager.Login(login);

            if(customerWithToken == null)
            {
                return NotFound();
            }

            return customerWithToken;
        }


        // GET: api/Customers/Delete/01818789852
        [HttpGet("Delete/{number}")]
        public ActionResult<Customer> Delete(string number)
        {
            var customer = _customerManager.Delete(number);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // DELETE: api/Customers/Delete/01818789852
        [HttpDelete("Delete/{number}")]
        public  ActionResult<bool> DeleteConfirm(string number)
        {
            return _customerManager.DeleteConfirm(number);

            
        }
        
    }
}
