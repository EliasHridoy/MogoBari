using Microsoft.EntityFrameworkCore;
using MogobariWebAPI.Models;
using MogobariWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL
{
    public class OrderManager
    {
        private readonly Mogobari_dbContext _context;

        public OrderManager()
        {
            _context = new Mogobari_dbContext();
        }


        public async Task<List<Order>> GetOrder()
        {
            return await _context.Order
                            .Include(a=>a.OrderItem)
                            .ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            var order = await _context.Order
                                        .Where(o=>o.Id == id)
                                        .Include(a=>a.OrderItem).FirstOrDefaultAsync();

            return order;
        }

        /// <summary>
        /// Get method for Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderViewModel> Update(int id)
        {
            OrderViewModel orderView = new OrderViewModel();

            orderView.order = await _context.Order.FindAsync(id);
            orderView.orderItemList = await _context.OrderItem.Where(o => o.OrderId == id).ToListAsync();

            return orderView;            
        }


        /// <summary>
        /// Put method for update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderViewModel"></param>
        /// <returns></returns>
        public async Task<bool> Update(int id, OrderViewModel orderViewModel)
        {
            if(!OrderExists(id))
            {
                return false;
            }


            _context.Entry(orderViewModel.order).State = EntityState.Modified;
            foreach(var ord in orderViewModel.orderItemList)
            {
                if(!OrderItemExists(ord.Id))
                {
                    return false;
                }

                _context.Entry(ord).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }



        public void Create()
        {
            //pass
        }

        /// <summary>
        /// Create method for post
        /// </summary>
        /// <param name="orderViewModel"></param>
        /// <returns></returns>
        public async Task<OrderViewModel> Create(OrderViewModel orderViewModel)
        {
            foreach(var ord in orderViewModel.orderItemList)
            {
                orderViewModel.order.OrderItem.Add(ord);
            }

            _context.Order.Add(orderViewModel.order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                return null;
            }

            return orderViewModel;
        }





        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }

        private bool OrderItemExists(int id)
        {
            return _context.OrderItem.Any(e => e.Id == id);
        }

    }
}