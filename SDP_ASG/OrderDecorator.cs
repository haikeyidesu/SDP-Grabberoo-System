using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal abstract class OrderDecorator : OrderItem
    {
        public abstract override string getDescription();
        public abstract override double getTotalPrice();
    }
}
