using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MogobariWebAPI.BL;
using MogobariWebAPI.Models;
using MogobariWebAPI.Models.ViewModels;

namespace MogobariWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly Mogobari_dbContext _context;
        private readonly VendorManager _vendorManager;
        private readonly AddressManager _addressManager;

        public VendorsController()
        {
            _context = new Mogobari_dbContext();
            _vendorManager = new VendorManager();
            _addressManager = new AddressManager();
        }

        // GET: api/Vendors
        [HttpGet]
        public ActionResult<IEnumerable<Vendor>> GetVendor()
        {
            return _vendorManager.GetVendors();
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public ActionResult<Vendor> GetVendor(string number)
        {
            var vendor = _vendorManager.GetVendor(number);

            if (vendor == null)
            {
                return NotFound();
            }


            return vendor;
        }



        // PUT: api/Vendors/Update/5
        [HttpGet("Update/{number}")]
        public ActionResult<VendorDetailsViewModel> Update(string number)
        {
            VendorDetailsViewModel vendorDetails = new VendorDetailsViewModel();


            vendorDetails.vendor = _vendorManager.Update(number);

            if (vendorDetails.vendor == null)
            {
                return NotFound();
            }


            vendorDetails.address = _context.Address.Find(vendorDetails.vendor.AddressId);

            return vendorDetails;
        }

        // PUT: api/Vendors/Update/5
        [HttpPut("Update/{number}")]
        public ActionResult<VendorDetailsViewModel> Update(string number,
            VendorDetailsViewModel vendorDetails)
        {
            if (number != vendorDetails.vendor.MobileNumber)
            {
                return BadRequest();
            }

            /// if customer not exit notfound
            if (!_vendorManager.VendorExists(number))
            {
                return NotFound();
            }

            if (vendorDetails.EnableVendorAddress == true)
            {
                if (vendorDetails.vendor.AddressId == null)
                {
                    int addresssId = _addressManager.Create(vendorDetails.address);
                    if (addresssId == -1)
                        return NotFound();

                    vendorDetails.vendor.AddressId = addresssId; // new entry
                    vendorDetails.address.Id = addresssId;
                }
                else
                {
                    bool success = _addressManager.Update(vendorDetails.address);
                    if (!success)
                        return NotFound();

                }
            }


            if (!_vendorManager.Update(number, vendorDetails))
            {
                return NotFound(); // faild
            }




            return vendorDetails;
        }



        // Get: api/Vendors/Register
        [HttpGet("Register")]
        public ActionResult<string> Register()
        {
            return "Register customer get method called";
        }

        // POST: api/Vendors/Register
        [HttpPost("Register")]
        public ActionResult<Vendor> Register(Vendor vendor)
        {
            /// if customer already exists badreq
            if (_vendorManager.VendorExists(vendor.MobileNumber))
            {
                return BadRequest();
            }
            Vendor saveVen = _vendorManager.Register(vendor);
            if (saveVen == null)
            {
                return BadRequest();
            }

            return saveVen;

        }

        //Get: api/Vendors/number
        [HttpGet("Delete/{number}")]
        public ActionResult<Vendor> Delete(string number)
        {
            Vendor vendor = _vendorManager.Delete(number);

            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }

        // DELETE: api/Vendors/Delete/01818789852
        [HttpDelete("Delete/{number}")]
        public ActionResult<bool> DeleteConfirm(string number)
        {
            return _vendorManager.DeleteConfirm(number);
        }

        private bool VendorExists(int id)
        {
            return _context.Vendor.Any(e => e.Id == id);
        }
    }
}
