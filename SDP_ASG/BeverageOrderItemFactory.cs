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
            // create order item with beverage menu item
            MenuItem beverageMenuItem = new BeverageMenuItem(selectedMenuItem.Name, selectedMenuItem.Description, selectedMenuItem.Price);
            OrderItem orderItem = new BeverageOrderItem(beverageMenuItem, quantity);

            // display successful creation of FoodOrderItem
            Console.WriteLine($"Successfully created {orderItem.getName()} Order Item x {orderItem.getQuantity()} \nTotal Cost: ${orderItem.getCost():N2} (Each {orderItem.getName()} costs ${orderItem.Price:N2})");

            return orderItem;
        }
    }
}
