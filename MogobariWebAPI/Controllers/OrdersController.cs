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
    public class OrdersController : ControllerBase
    {
        private readonly Mogobari_dbContext _context;
        private readonly OrderManager _orderManager;

        public OrdersController()
        {
            _context = new Mogobari_dbContext();
            _orderManager = new OrderManager();
        }

        // GET: api/Orders
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _orderManager.GetOrder();
        }

        // GET: api/Orders/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderManager.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }


        /// <summary>
        /// Get for Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("Update/{id}")]
        public async Task<ActionResult<OrderViewModel>> Update(int id)
        {
            OrderViewModel orderView = await _orderManager.Update(id);
            if(orderView.order==null && orderView.orderItemList==null)
            {
                return NotFound();
            }

            return orderView;
        }



        // PUT: api/Orders/5
        [HttpPut("Update/{id}")]
        public async Task<ActionResult<bool>> Update(int id, OrderViewModel orderViewModel)
        {
            if (id !=   orderViewModel.order.Id)
            {
                return BadRequest();
            }

            return await _orderManager.Update(id, orderViewModel);
        }



        [HttpGet("Create")]
        public ActionResult<string> Create()
        {
            _orderManager.Create();
            return "Get create method called";
        }

        // POST: api/Orders
        [HttpPost("Create")]
        public async Task<ActionResult<OrderViewModel>> Create(OrderViewModel orderViewModel)
        {
            var newOrder = await _orderManager.Create(orderViewModel);

            if(newOrder == null)
            {
                return NotFound();
            }

            return orderViewModel;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

    }
}