using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MogobariWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL
{
    public class ProductsManager
    {
        private readonly Mogobari_dbContext _context;

        public ProductsManager()
        {
            _context = new Mogobari_dbContext();
        }

        public async Task<List<Product>> Get()
        {
            var pro = await _context.Product
                                    .Include(pr => pr.ProductPictureMapping)
                                        .ThenInclude(pp => pp.Picture)
                                    .Where(pr=>pr.Deleted==false)
                                    .ToListAsync();
            return pro;
        }

        public async Task<Product> Get(int id)
        {
            var product = await _context.Product
                                        .Include(pr=>pr.ProductPictureMapping)
                                            .ThenInclude(pp=>pp.Picture)
                                        .Where(pr=>pr.Id==id &&
                                                   pr.Deleted == false)
                                        .FirstOrDefaultAsync();

            if (product == null)
            {
                return null;
            }

            return product;
        }

        /// <summary>
        /// Get Product by CategoryID
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            List<Product> products = await _context.Product
                                                .Where(p => p.CategoryId == categoryId &&
                                                        p.Deleted==false)
                                                .ToListAsync();

            return products;
        }

        /// <summary>
        /// Get products by vendor ID
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public async Task<List<Product>> GetProductsByVendor(int vendorId)
        {
            List<Product> products = await _context.Product
                                                .Include(p=>p.ProductPictureMapping)
                                                    .ThenInclude(p=>p.Picture)
                                                .Where(p => p.VendorId == vendorId &&
                                                        p.Deleted == false)
                                                .ToListAsync();

            return products;
        }

        public async Task<Product> Update(int id)
        {
            var product = await Get(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        /// <summary>
        /// HttpPut for Update method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> Update(int id, Product product)
        {

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return product;
        }


        public void Create()
        {
            //pass
        }
        public async Task<Product> Create(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }


        public async Task<Product> Delete(int id)
        {
            return await Get(id);
        }

        public async Task<bool> DeleteConfirm(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            product.Deleted = true;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                return false;
            }
            return true;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
