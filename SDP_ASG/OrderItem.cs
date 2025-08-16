using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class OrderItem
    {
        private string name;
        private string description;
        private double price;
        private int quantity;
        private double totalPrice => price * quantity;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
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
            Name = menuItem.Name;
            Price = menuItem.Price;
            Quantity = quantity;
        }

        public OrderItem() { }
        public OrderItem(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
