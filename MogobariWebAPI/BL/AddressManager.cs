using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MogobariWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL
{
    public class AddressManager
    {
        private readonly Mogobari_dbContext _context;
        public AddressManager()
        {
            _context = new Mogobari_dbContext();
        }


        public Address Get(int id)
        {
            return _context.Address.Find(id);
        }

        public int Create(Address address)
        {
            #region comment
            //Address newAddrs = new Address()
            //{
            //    FirstName = address.FirstName,
            //    LastName = address.LastName,
            //    Email = address.Email,
            //    Company = address.Company,
            //    Country = address.Country,
            //    City = address.City,
            //    Address1 = address.Address1,
            //    PostalCode = address.PostalCode,
            //    PhoneNumber = address.PhoneNumber,
            //    CreateOnUtc = DateTime.Now
            //};
            //Address newAddrs = new Address();
            //newAddrs.Email = "hotmail.com";
            //newAddrs.PhoneNumber = "56465646";
            //newAddrs.CreateOnUtc = DateTime.Now;
            #endregion

            if (address != null )
            {
                _context.Address.Add(address);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    return -1;
                }

            }
            return address.Id;
        }

        public bool Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;

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
    }
}
