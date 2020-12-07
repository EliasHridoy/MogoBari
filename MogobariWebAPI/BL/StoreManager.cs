using Microsoft.EntityFrameworkCore;
using MogobariWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL
{
    public class StoreManager
    {
        private readonly Mogobari_dbContext _context;

        public StoreManager()
        {
            _context = new Mogobari_dbContext();
        }


        public async Task<List<Store>> GetStores()
        {
            return await _context.Store
                            .Include(cus => cus.Address)
                            .Where(s=>s.Active==true)
                            .ToListAsync();
        }
        public async Task<Store> GetStore(int id)
        {
            Store store = await _context.Store
                                        .Include(st => st.Address)
                                        .Where(s=>s.Id==id)
                                        .FirstAsync();

            return store;
        }


        public void RegisterStore()
        {
            return;
        }


        public async Task<Store> RegisterStore(Store store)
        {
           

             _context.Store.Add(store);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }
            return store;
        }


        /// <summary>
        // Get method for update
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Customer</returns>
        public Store Update(int id)
        {

            var store = _context.Store
                                 .Where(cus => cus.Id == id)
                                 .FirstOrDefault();

            return store;

        }

        /// <summary>
        /// Update method for update
        /// </summary>
        /// <param name="number"></param>
        /// <param name="customer"></param>
        /// <returns>bool</returns>
        public bool Update(int id, Store store)
        {
            _context.Entry(store).State = EntityState.Modified;

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
        public async Task<Store> Delete(int id)
        {
            Store store = await _context.Store
                                        .Include(st => st.Address)
                                        .Where(s => s.Id == id)
                                        .FirstAsync();

            return store;
        }

        public bool DeleteConfirm(int id)
        {
            if (!StoreExists(id))
            {
                return false;
            }

            Store store = _context.Store
                                        .Include(st => st.Address)
                                        .Where(s => s.Id == id)
                                        .FirstOrDefault(); ;
            _context.Store.Remove(store);
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


        public bool StoreExists(int id)
        {
            return _context.Store
                            //.Where(st => st.Deleted == false)
                            .Any(e => e.Id == id);

        }



    }
}
