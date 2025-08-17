using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class MoreIce : OrderDecorator
    {
        private OrderItem orderItem;

        public MoreIce(OrderItem orderItem)
        {
            this.orderItem = orderItem;
        }

        public override string getDescription()
        {
            return $"{orderItem.getDescription()} (more ice)";
        }

        public override double getTotalPrice()
        {
            return orderItem.getTotalPrice() + 0.80;
        }
    }
}
