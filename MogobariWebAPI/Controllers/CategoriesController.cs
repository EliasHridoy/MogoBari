using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MogobariWebAPI.BL;
using MogobariWebAPI.Models;

namespace MogobariWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryManager _categoryManager;


        public CategoriesController()
        {
            _categoryManager = new CategoryManager();
        }


        // GET: api/Categories/Get
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _categoryManager.Get(); 
        }

        // GET: api/Categories/Get/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryManager.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        
        //Get : Update
        [HttpGet("Update/{id}")]
        public async Task<ActionResult<Category>> Update(int id) 
        {
            return await _categoryManager.Update(id);
        }
        

        // PUT: api/Categories/5
        [HttpPut("Update/{id}")]
        public async Task<ActionResult<bool>> Update(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

           return await _categoryManager.Update(id, category);            
        }


        /// <summary>
        /// Get for Create method
        /// </summary>
        /// <param> </param>
        /// <returns></returns>
        [HttpGet("Create")] 
        public ActionResult<string> Create()
        {
            _categoryManager.Create();
            return "Create method from Category called";
        }


        // POST: api/Categories
        [HttpPost("Create")]
        public async Task<ActionResult<Category>> Create(Category category)
        {
            Category newCategory = await _categoryManager.Create(category);

            return CreatedAtAction("GetCategory", new { id = newCategory.Id }, newCategory);
        }


        [HttpGet("Delete/{id}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            Category cat = await _categoryManager.Delete(id);
            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }


        // DELETE: api/Categories/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<bool>> DeleteConfirm(int id)
        {
            bool success = await _categoryManager.DeleteConfirm(id);            
            return success;
        }
        
    }
}
