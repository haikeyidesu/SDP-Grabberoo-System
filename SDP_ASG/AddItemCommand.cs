using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class AddItemCommand : Command
    {
        private OrderItem item;
        private Order order;

        public AddItemCommand(OrderItem item, Order order)
        {
            this.item = item;
            this.order = order;
        }

        public void execute()
        {
            order.AddItem(item);
            Console.WriteLine($"{item.Quantity}x {item.Name} added to order.");
        }

        public void undo()
        {
            order.RemoveItem(item);
            Console.WriteLine($"{item.Quantity}x {item.Name} removed from order.");
        }
    }
}
