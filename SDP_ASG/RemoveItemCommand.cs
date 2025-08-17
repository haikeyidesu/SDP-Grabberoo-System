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
            item.RemoveItem();
            Console.WriteLine($"{item.Quantity}x {item.Name} removed from order.");
        }

        public void undo()
        {
        }
    }
}
