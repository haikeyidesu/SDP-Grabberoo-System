using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class RemoveItemCommand : Command
    {
        private OrderItem item;
        private Order order;

        public RemoveItemCommand(OrderItem item, Order order)
        {
            this.item = item;
            this.order = order;
        }

        public void execute()
        {
            order.RemoveItem(item);
            Console.WriteLine($"{item.Quantity}x {item.Name} removed from order.");
        }

        public void undo()
        {
            order.AddItem(item);
            Console.WriteLine($"{item.Quantity}x {item.Name} added to order.");
        }
    }
}
