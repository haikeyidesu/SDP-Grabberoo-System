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
            // create a new order with pending state
            MenuItem beverageMenuItem = new BeverageMenuItem(selectedMenuItem.Name, selectedMenuItem.Description, selectedMenuItem.Price);
            OrderItem orderItem = new BeverageOrderItem(beverageMenuItem, quantity);

            return orderItem;
        }
    }
}
