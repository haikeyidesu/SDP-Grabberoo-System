using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class LessIce : OrderDecorator
    {
        private OrderItem orderItem;

        public LessIce(OrderItem orderItem)
        {
            this.orderItem = orderItem;
        }

        public override string getDescription()
        {
            return $"{orderItem.getDescription()} (less ice)";
        }

        public override double getTotalPrice()
        {
            return orderItem.getTotalPrice() + 0.80;
        }
    }
}
