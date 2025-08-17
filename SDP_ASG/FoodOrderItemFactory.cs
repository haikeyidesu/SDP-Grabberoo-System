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
            MenuItem foodMenuItem = new FoodMenuItem(selectedMenuItem.Name, selectedMenuItem.Description, selectedMenuItem.Price);
            OrderItem orderItem = new FoodOrderItem(foodMenuItem, quantity);

            // display successful creation of FoodOrderItem
            Console.WriteLine($"Successfully created {orderItem.getName()} Order Item x {orderItem.getQuantity()} \nTotal Cost: ${orderItem.getCost():N2} (Each {orderItem.getName()} costs ${orderItem.Price:N2})");

            return orderItem;
        }
    }
}
