using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class CompleteOrderState:OrderStates
    {
        private Order order;
        public Order Order { get { return order; } set { order = value; } }

        public CompleteOrderState(Order order)
        {
            this.Order = order;
        }
        public void OnEnterState()
        {
            if (Order.State == Order.CompleteOrderState)
            {
                Console.WriteLine("Order is completed. Archiving order in 1 year.");
                Order.State = Order.RemovedState; 
            }
        }

        public void PayOrder()
        {
            Console.WriteLine("You have already paid for the order.");
        }

        public void CancelOrder()
        {
            Console.WriteLine("Order cannot be cancelled. It is already completed.");
        }

        public void RejectOrder()
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
