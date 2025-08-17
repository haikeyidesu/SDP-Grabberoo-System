using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class FoodOrderItem : OrderItem
    {
        public FoodOrderItem(MenuItem menuItem, int quantity)
        {
            this.menuItem = menuItem;
            this.quantity = quantity;
        }
    }
}
