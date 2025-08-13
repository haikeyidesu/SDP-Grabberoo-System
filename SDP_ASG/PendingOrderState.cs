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

        public void PayOrder(bool payment)
        {
            Console.WriteLine("You have already paid !");
        }
        public void CancelOrder(bool orderCancellable)
        {
            if (orderCancellable == true)
            {
                Console.WriteLine("Order cancelled , you will be refunded ");
                order.State = order.RemovedState;
            }
            else
            {
                Console.WriteLine("Order cannot be cancelled. ");
            }
        }
        public void RejectOrder(bool orderCancellable)
        {
            if (orderCancellable == true)
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
            order.OrderStatus= "Preparing";
            order.State = order.PrepareOrderState;
            order.OrderCancellable = false;
        }
        public void CompleteOrder()
        {
            Console.WriteLine("Can't complete order. Please place an order first.");
        }
    }
}
    

