using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class FoodOrderItemFactory : OrderItemFactory
    {
        public override OrderItem CreateOrderItem(MenuItem selectedMenuItem, int quantity)
        {
            // create a new order with pending state
            FoodMenuItem foodMenuItem = new FoodMenuItem(selectedMenuItem.Name, selectedMenuItem.Description, selectedMenuItem.Price);
            OrderItem orderItem = new FoodOrderItem(foodMenuItem, quantity);

            return orderItem;
        }
    }
}
