using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal abstract class OrderItemFactory
    {
        // creates an OrderItem with the given parameters
        // OrderItem can be Food, Beverage or Condiment (Decorator)
        public abstract OrderItem CreateOrderItem(MenuItem selectedMenuItem, int quantity);
    }
}
