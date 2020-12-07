using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MogobariWebAPI.Models;

namespace MogobariWebAPI.Models.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            order = new Order();
            orderItemList = new List<OrderItem>();
        }

        public Order order { get; set; }
        public List<OrderItem> orderItemList { get; set; }
    }
}