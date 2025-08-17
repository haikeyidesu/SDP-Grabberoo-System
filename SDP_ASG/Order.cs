using System;
using System.Collections.Generic;

namespace SDP_ASG
{
    internal class Order
    {
        // --- States ---
        private OrderStates state;
        public OrderStates State { get { return state; } set { state = value; } }
        public OrderStates CreateOrderState { get; private set; }
        public OrderStates PendingOrderState { get; private set; }
        public OrderStates PrepareOrderState { get; private set; }
        public OrderStates CompleteOrderState { get; private set; }
        public OrderStates RemovedState { get; private set; }

        // --- Order attributes ---
        public DateTime DeliveryTime { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public bool OrderCancellable { get; set; }
        public DateTime OrderDate { get; set; }

        // --- Order Items ---
        private List<OrderItem> items = new List<OrderItem>();

        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }

        public bool IsEmpty() => items.Count == 0;

        public double GetTotal()
        {
            double total = 0;
            foreach (var item in items)
            {
                total += item.TotalPrice;
            }
            return total;
        }

        public void PrintItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items in this order.");
                return;
            }

            Console.WriteLine("--- Order Items ---");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Quantity}x {item.MenuItem.Name} - ${item.TotalPrice:0.00}");
            }
            Console.WriteLine($"Total = ${GetTotal():0.00}");
        }

        
        public Order(DateTime deliveryTime, string address, string orderStatus, string paymentMethod, bool orderCancellable)
        {
            CreateOrderState = new CreateOrderState(this);
            PendingOrderState = new PendingOrderState(this);
            PrepareOrderState = new PrepareOrderState(this);
            CompleteOrderState = new CompleteOrderState(this);
            RemovedState = new RemovedState(this);

            state = CreateOrderState;
            DeliveryTime = deliveryTime;
            Address = address;
            PaymentMethod = paymentMethod;
            OrderCancellable = orderCancellable;
            OrderDate = DateTime.Now;
        }

        
        public void PayOrder() { state.PayOrder(); }
        public void CancelOrder() { state.CancelOrder(); }
        public void RejectOrder() { state.RejectOrder(); }
        public void PrepareOrder() { state.PrepareOrder(); }
        public void CompleteOrder()
        {
            state.CompleteOrder();
            if (State is CompleteOrderState completeOrderState)
            {
                completeOrderState.OnEnterState();
            }
        }

        
        public string StateName => state.GetType().Name.Replace("State", "");
    }
}
