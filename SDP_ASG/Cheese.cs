using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class Cheese : MenuItemDecorator
    {
        private OrderItem orderItem;

        public Cheese(OrderItem orderItem)
        {
            this.orderItem = orderItem;
        }

        public override string getName()
        {
            return orderItem.getName();
        }

        public override string getDescription()
        {
            return orderItem.getDescription() + " with cheese";
        }

        public override double getCost()
        {
            return orderItem.getCost() + 1.20;
        }

        public override int getQuantity()
        {
            return orderItem.getQuantity();
        }
    }
}
