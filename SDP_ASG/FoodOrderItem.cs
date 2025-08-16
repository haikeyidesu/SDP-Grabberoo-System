using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class FoodOrderItem : OrderItem
    {
        public MenuItem MenuItem
        {
            get { return this.menuItem; }
            set { this.menuItem = value; }
        }
        public string Name
        {
            get { return this.name; }
        }
        public string Description
        {
            get { return this.description; }
        }
        public double Price
        {
            get { return this.price; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        // TotalPrice is a calculated property that returns the total price of the order item
        public double TotalPrice
        {
            get { return this.totalPrice; }
        }

        public FoodOrderItem(MenuItem menuItem, int quantity)
        {
            this.menuItem = menuItem;
            this.quantity = quantity;
        }
    }
}
