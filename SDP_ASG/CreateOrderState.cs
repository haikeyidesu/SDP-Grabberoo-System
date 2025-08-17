using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class CreateOrderState:OrderStates
    {
        private Order order;
        public Order Order { get { return order; } set { order = value; } }

        public CreateOrderState(Order order)
        {
            this.Order = order;
        }

        public void PayOrder()
        {
            Order.State = Order.PendingOrderState;
            Console.WriteLine("Order successfully submitted");
        }
        public void CancelOrder()
        {
            Console.WriteLine("Can't cancel order. Please place one first!");
        }
        public void RejectOrder() 
        {
            Console.WriteLine("Cant reject order. No order found.");
        }
        public void PrepareOrder()
        {
            Console.WriteLine("Can't prepare order.Please place an order first");
        }
        public void CompleteOrder()
        {
            Console.WriteLine("Can't complete order. Please place an order first.");
        }
    }
}
