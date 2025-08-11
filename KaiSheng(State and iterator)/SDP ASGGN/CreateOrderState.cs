using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASGGN
{
    internal class CreateOrderState:OrderStates
    {
        private Order order;
        public Order Order { get; set; }

        public CreateOrderState(Order order)
        {
            this.Order = order;
        }

        public void PayOrder(bool payment)
        {
            if (payment == true)
            {   
                Order.State = Order.PendingOrderState;
                Console.WriteLine("Order successfully submitted");
            }
            else
            {
                Console.WriteLine("Please pay first before submitting an order!");
            }
        }
        public void CancelOrder(bool orderCancellable)
        {
            Console.WriteLine("Can't cancel order. Please place one first!");
        }
        public void RejectOrder(bool orderCancellable) 
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
