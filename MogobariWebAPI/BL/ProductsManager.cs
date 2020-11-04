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
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
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

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
