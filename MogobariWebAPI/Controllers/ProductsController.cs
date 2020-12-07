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
    public class ProductsController : ControllerBase
    {
        private readonly ProductsManager _productsManager;

        public ProductsController()
        {
            _productsManager = new ProductsManager();
        }

        // GET: api/Products
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _productsManager.Get() ;
        }

        // GET: api/Products/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productsManager.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Get Product by category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("GetByCategory/{categoryId}")]
        public async Task<ActionResult<List<Product>>> GetByCategory(int categoryId)
        {
            List<Product> products = await _productsManager.GetProductsByCategory(categoryId);

            return products;
        }


        /// <summary>
        /// Get Product by Vendor
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        [HttpGet("GetByVendor/{vendorId}")]
        public async Task<ActionResult<List<Product>>> GetByVendor(int vendorId)
        {
            List<Product> products = await _productsManager.GetProductsByVendor(vendorId);

            return products;
        }



        /// <summary>
        /// Get for Update method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Update/{id}")]
        public async Task<ActionResult<Product>> Update(int id)
        {
            var product = await _productsManager.Update(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("Update/   {id}")]
        public async Task<ActionResult<Product>> Update(int id, Product product)
        {
                if (id != product.Id)
                {
                    return BadRequest();
            }

            Product newProduct = await _productsManager.Update(id, product);

            return newProduct;
        }



        [HttpGet("Create")]
        public ActionResult<string> Create()
        {
            _productsManager.Create();
            return "Create method from Category called";
        }


        // POST: api/Categories
        [HttpPost("Create")]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            Product newProduct = await _productsManager.Create(product);

            return CreatedAtAction("Get", new { id = newProduct.Id }, newProduct);
        }


        [HttpGet("Delete/{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await _productsManager.Delete(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteConfirm(int id)
        {
            return await _productsManager.DeleteConfirm(id);
        }

    }
}