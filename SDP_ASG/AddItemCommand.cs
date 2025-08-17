using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class AddItemCommand : Command
    {
        OrderItem item;

        public AddItemCommand(OrderItem item)
        {
            this.item = item;
        }

        public void execute()
        {
            item.AddItem();
        }

        public void undo()
        {
            item.RemoveItem();
        }
    }
}
