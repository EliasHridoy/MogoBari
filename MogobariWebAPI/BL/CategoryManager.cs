using Microsoft.EntityFrameworkCore;
using MogobariWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL
{
    public class CategoryManager
    {
        private readonly Mogobari_dbContext _context;

        public CategoryManager()
        {
            _context = new Mogobari_dbContext();
        }

        public async Task<List<Category>> Get()
        {
            return await _context.Category.ToListAsync();
        }


        public async Task<Category> Get(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return null;
            }

            return category;
        }

        /// <summary>
        /// Get Method for update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Category> Update(int id)
        {
            return await Get(id); ///Get method is called
        }

        public async Task<bool> Update(int id, Category category)
        {
           
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public void Create()
        {
            //pass
        }
        public async Task<Category> Create(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> Delete(int id)
        {
            Category cat = await Get(id);
            return cat;
        }

        /// <summary>
        /// DeleteConfirm Delete method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteConfirm(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }

    }
}
