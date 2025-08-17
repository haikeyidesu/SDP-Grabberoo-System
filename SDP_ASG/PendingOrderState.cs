using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class PendingOrderState:OrderStates
    {
        private Order order;
        public Order Order {get { return order; } set { order = value; }}

        public PendingOrderState(Order order)
        {
            this.Order = order;
        }

        public void PayOrder()
        {
            Console.WriteLine("You have already paid !");
        }
        public void CancelOrder()
        {
            if (Order.OrderCancellable == true)
            {
                Console.WriteLine("Order cancelled , you will be refunded ");
                order.State = order.RemovedState;
            }
            else
            {
                Console.WriteLine("Order cannot be cancelled. ");
            }
        }
        public void RejectOrder()
        {
            if (Order.OrderCancellable == true)
            {
                Console.WriteLine("Order rejected ,customer will be refunded ");
                order.State = order.RemovedState;
            }
            else
            {
                Console.WriteLine("Order cannot be rejected. ");
            }
        }
        public void PrepareOrder()
        {
            Console.WriteLine("Order is being prepared.");
            order.State = order.PrepareOrderState;
            order.OrderCancellable = false;
        }
        public void CompleteOrder()
        {
            Console.WriteLine("Can't complete order. Please place an order first.");
        }
    }
}
    

