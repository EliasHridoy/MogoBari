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
    public class StoresController : ControllerBase
    {
        private readonly Mogobari_dbContext _context;
        private readonly StoreManager _storeManager;

        public StoresController(Mogobari_dbContext context)
        {
            _context = context;
            _storeManager = new StoreManager();
        }

        // GET: api/Stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStore()
        {
            return await _storeManager.GetStores();
        }

        // GET: api/Stores/5
        [HttpGet("GetStore/{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            var store = await _storeManager.GetStore(id);

            if (store == null)
            {
                return NotFound();
            }

            return store;
        }




        [HttpGet("Register")]
        public void Register()
        {
            _storeManager.RegisterStore();
        }

        // POST: api/Stores
        [HttpPost("Register")]
        public async Task<ActionResult<Store>> RegisterStore(Store store)
        {

            await _storeManager.RegisterStore(store);
            if(store == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetStore", new { id = store.Id }, store);
        }



        // PUT: api/Stores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(int id, Store store)
        {
            if (id != store.Id)
            {
                return BadRequest();
            }

            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

      

        // DELETE: api/Stores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Store>> DeleteStore(int id)
        {
            var store = await _context.Store.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            _context.Store.Remove(store);
            await _context.SaveChangesAsync();

            return store;
        }

        private bool StoreExists(int id)
        {
            return _context.Store.Any(e => e.Id == id);
        }
    }
}