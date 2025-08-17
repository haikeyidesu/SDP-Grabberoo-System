using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class HotSauce : OrderDecorator
    {
        private OrderItem orderItem;

        public HotSauce(OrderItem orderItem)
        {
            this.orderItem = orderItem;
        }

        public override string getDescription()
        {
            return $"({orderItem.getDescription()}) with hot sauce";
        }

        public override double getTotalPrice()
        {
            return orderItem.getTotalPrice() + 0.80;
        }
    }
}
