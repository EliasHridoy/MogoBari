using Microsoft.EntityFrameworkCore;
using MogobariWebAPI.Models;
using MogobariWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL
{
    public class VendorManager
    {
        private readonly Mogobari_dbContext _context;

        #region constructor
        public VendorManager()
        {
            _context = new Mogobari_dbContext();
        }
        #endregion


        public List<Vendor> GetVendors()
        {
            return _context.Vendor.ToList();
        }


        public Vendor GetVendor(string number)
        {
            Vendor vendor = _context.Vendor
                                        .Include(cus => cus.Address)
                                        .Where(cus => cus.MobileNumber == number)
                                        .FirstOrDefault();

            return vendor;
        }


        public void Register()
        {
            return;
        }


        public Vendor Register(Vendor vendor)
        {
            #region default value
            vendor.Active = true;
            vendor.Deleted = false;
            
            //vendor.CreatedOn = DateTime.Now;
            //vendor.LastLogin = DateTime.Now;
            //vendor.IsSystemAccount = false;
            #endregion

            _context.Vendor.Add(vendor);
            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }
            return vendor;
        }


        public Vendor Update(string number)
        {

            var vendor = _context.Vendor
                                 .Include(cus => cus.AddressId)
                                 .Where(cus => cus.MobileNumber == number)
                                 .FirstOrDefault();

            return vendor;

        }

        public bool Update(string number, VendorDetailsViewModel vendorDetails)
        {
            _context.Entry(vendorDetails.vendor).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;

        }


        public Vendor Delete(string MobileNumber)
        {
            return GetVendor(MobileNumber); ///Calling GetVendor method for vendor
        }

        public bool DeleteConfirm(string MobileNumber)
        {
            if (!VendorExists(MobileNumber))
            {
                return false;
            }

            Vendor vendor = GetVendor(MobileNumber);
            _context.Vendor.Remove(vendor);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }



        public bool VendorExists(string MobileNumber)
        {
            return _context.Vendor
                            .Where(cus => cus.Deleted == false)
                            .Any(e => e.MobileNumber == MobileNumber);
        }



    }
}
