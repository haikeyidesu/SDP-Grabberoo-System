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
            Console.WriteLine($"Successfully created {orderItem.getName()} Order Item x {orderItem.getQuantity()} \nTotal Cost: ${orderItem.getTotalPrice():N2} (Each {orderItem.getName()} costs ${orderItem.getIndividualPrice():N2})");

            return orderItem;
        }
    }
}
