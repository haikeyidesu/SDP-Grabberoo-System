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

        public RemoveItemCommand(OrderItem item)
        {
            this.item = item;
        }

        public void execute()
        {
            item.RemoveItem();
        }

        public void undo()
        {
        }
    }
}
