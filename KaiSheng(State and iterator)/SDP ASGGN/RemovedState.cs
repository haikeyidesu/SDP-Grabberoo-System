using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASGGN
{
    internal class RemovedState : OrderStates
    {
        private Order order;
        public Order Order { get; set; }
        public RemovedState(Order order)
        { 
            this.Order = order;
        }
        public void PayOrder(bool payment)
        {
            Console.WriteLine("Order has been removed. Cannot pay for it.");
        }
        public void CancelOrder(bool orderCancellable)
        {
            Console.WriteLine("Order has been removed. Cannot cancel it.");
        }
        public void RejectOrder(bool orderCancellable)
        {
            Console.WriteLine("Order has been removed. Cannot reject it.");
        }
        public void PrepareOrder()
        {
            Console.WriteLine("Order has been removed. Cannot prepare it.");
        }
        public void CancelOrder()
        {
            Console.WriteLine("Order has been removed. Cannot complete it.");
        }

        }
}
