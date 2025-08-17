using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class Order
    {   
        //states
        private OrderStates state;
        public OrderStates State { get { return state; } set { state = value; } }
        private OrderStates createOrderState;
        public OrderStates CreateOrderState { get { return createOrderState; } set { createOrderState = value; } }
        private OrderStates pendingOrderState;
        public OrderStates PendingOrderState { get { return pendingOrderState; } set { pendingOrderState = value; } }
        private OrderStates prepareOrderState;
        public OrderStates PrepareOrderState { get { return prepareOrderState; } set { prepareOrderState = value; } }
        private OrderStates completeOrderState;
        public OrderStates CompleteOrderState { get { return completeOrderState; } set { completeOrderState = value; } }
        private OrderStates removedState;
        public OrderStates RemovedState { get { return removedState; } set { removedState = value; } }

        //Order attributes
        private DateTime deliveryTime;
        public DateTime DeliveryTime { get { return deliveryTime; } set { deliveryTime = value; } }
        private string address;
        public string Address { get { return address; } set { address = value; } }
        private string orderStatus;
        public string OrderStatus { get { return orderStatus; } set { orderStatus = value; } }
        private string paymentMethod;
        public string PaymentMethod { get { return paymentMethod; } set { paymentMethod = value; } }
        private bool orderCancellable;
        public bool OrderCancellable { get { return orderCancellable; } set { orderCancellable = value; } }
        private DateTime orderDate;
        public DateTime OrderDate { get { return orderDate; } set { orderDate = value; } }
        private List<OrderItem> orderItems = new List<OrderItem>();
        public List<OrderItem> OrderItems { get { return orderItems; } set {  orderItems = value; } }
       

        public Order(DateTime DeliveryTime,string Address,string OrderStatus,string PaymentMethod,bool OrderCancellable)
        { 
            CreateOrderState=new CreateOrderState(this);
            PendingOrderState = new PendingOrderState(this);
            PrepareOrderState = new PrepareOrderState(this);
            CompleteOrderState = new CompleteOrderState(this);
            RemovedState= new RemovedState(this);
            state = CreateOrderState;
        }

        public void PayOrder(bool payment)
        {
            state.PayOrder(payment);
        }
        public void CancelOrder(bool orderCancellable)
        {
            state.CancelOrder(orderCancellable);
        }
        public void RejectOrder(bool orderCancellable)
        {
            state.RejectOrder(orderCancellable);
        }
        public void PrepareOrder()
        {
            state.PrepareOrder();
        }
        public void CompleteOrder()
        {
            state.CompleteOrder();
            if (State is CompleteOrderState completeOrderState)
            {
                completeOrderState.OnEnterState();
            }
        }
    }
}
