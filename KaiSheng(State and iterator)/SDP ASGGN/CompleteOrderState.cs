using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASGGN
{
    internal class CompleteOrderState:OrderStates
    {
        private Order order;
        public Order Order { get; set; }

        public CompleteOrderState(Order order)
        {
            this.Order = order;

            Console.WriteLine("Order is completed. Archiving order in 1 year.");
            order.OrderStatus = "Completed";
            order.State = order.RemovedState; 
        }

        public void PayOrder(bool payment)
        {
            Console.WriteLine("You have already paid for the order.");
        }

        public void CancelOrder(bool orderCancellable)
        {
            Console.WriteLine("Order cannot be cancelled. It is already completed.");
        }

        public void RejectOrder(bool orderCancellable)
        {
            Console.WriteLine("Order cannot be rejected. It is already completed.");
        }

        public void PrepareOrder()
        {
            Console.WriteLine("Order is already completed. No preparation needed.");
        }

        public void CompleteOrder()
        {
            Console.WriteLine("Order is already completed.");
        }
    }
}
