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
            FoodMenuItem foodMenuItem = new FoodMenuItem(selectedMenuItem.Name, selectedMenuItem.Description, selectedMenuItem.Price);
            OrderItem orderItem = new OrderItem(foodMenuItem, quantity);

            // display successful creation of FoodOrderItem
            Console.WriteLine($"Successfully created {orderItem.Name} Order Item x {orderItem.Quantity} \nTotal Cost: ${orderItem.TotalPrice:N2} (Each {orderItem.Name} costs ${orderItem.Price:N2})");

            return orderItem;
        }
    }
}
