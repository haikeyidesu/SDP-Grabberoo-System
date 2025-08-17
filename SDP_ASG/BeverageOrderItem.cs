using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    class BeverageOrderItem : OrderItem
    {
        public BeverageOrderItem(MenuItem menuItem, int quantity)
        {
            this.menuItem = menuItem;
            this.quantity = quantity;
        }
    }
}
