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
            Console.WriteLine("Creating a new order in Pending state...");

            // create a new order with pending state
            FoodMenuItem foodMenuItem = new FoodMenuItem(selectedMenuItem.Name, selectedMenuItem.Description, selectedMenuItem.Price);
            OrderItem orderItem = new OrderItem(foodMenuItem, quantity);

            return orderItem;
        }
    }
}
