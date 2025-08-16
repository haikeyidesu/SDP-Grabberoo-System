using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class OrderItem
    {
        private MenuItem menuItem;
        private string name => this.menuItem.Name;
        private string description => this.menuItem.Description;
        private double price => this.menuItem.Price;
        private int quantity;
        private double totalPrice => price * (double)quantity;

        public MenuItem MenuItem
        {
            get { return menuItem; }
            set { menuItem = value; }
        }
        public string Name
        {
            get { return name; }
        }
        public string Description
        {
            get { return description; }
        }
        public double Price
        {
            get { return price; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        // TotalPrice is a calculated property that returns the total price of the order item
        public double TotalPrice
        {
            get { return totalPrice; }
        }

        // constructor
        // OrderItem is a menuItem with the added property of quantity
        // name and price properties are inherited from a MenuItem
        public OrderItem(MenuItem menuItem, int quantity)
        {
            this.menuItem = menuItem;
            this.quantity = quantity;
        }
    }
}
