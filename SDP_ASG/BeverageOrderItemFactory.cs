using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class BeverageOrderItemFactory : OrderItemFactory
    {
        public override OrderItem CreateOrderItem(MenuItem selectedMenuItem, int quantity)
        {
            BeverageMenuItem beverageMenuItem = new BeverageMenuItem(selectedMenuItem.Name, selectedMenuItem.Description, selectedMenuItem.Price);
            OrderItem orderItem = new FoodOrderItem(beverageMenuItem, quantity);

            // display successful creation of BeverageOrderItem
            Console.WriteLine($"Successfully created {orderItem.Name} Order Item x {orderItem.Quantity} \nTotal Cost: ${orderItem.TotalPrice:N2} (Each {orderItem.Name} costs ${orderItem.Price:N2})");

            return orderItem;
        }
    }
}
