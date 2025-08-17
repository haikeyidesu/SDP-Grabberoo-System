using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class PrepareOrderState:OrderStates
    {
        private Order order;
        public Order Order { get { return order; } set { order = value; } }
        public PrepareOrderState(Order order)
        {
            this.Order = order;
        }

        public void PayOrder()
        {
            Console.WriteLine("You have already paid !");
        }
        public void CancelOrder()
        {
           Console.WriteLine("Order cannot be cancelled. Order is being prepared.");
           
        }
        public void RejectOrder()
        {
            Console.WriteLine("Order cannot be rejected. Order is being prepared.");
     
        }
        public void PrepareOrder()
        {
            Console.WriteLine("Order is being prepared.");
        }
        public void CompleteOrder()
        {
            
            Console.WriteLine("Order is completed.");
            order.State = order.CompleteOrderState;
        }
    }
}
