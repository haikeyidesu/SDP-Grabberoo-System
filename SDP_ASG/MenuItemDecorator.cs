using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal abstract class MenuItemDecorator : OrderItem
    {
        public abstract override string getDescription();
        public abstract override double getCost();
    }
}
