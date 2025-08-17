using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal abstract class OrderItem
    {
        protected MenuItem menuItem;
        protected string name => menuItem.Name;
        protected string description => menuItem.Description;
        protected double price => menuItem.GetDiscountPrice();
        protected int quantity;
        protected double totalPrice => menuItem.GetDiscountPrice() * (double)quantity;
        //protected OrderItem orderItem;
        protected List<OrderItem> orderList;
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

        // Decorator
        public virtual string getDescription() { return description; }
        public virtual double getTotalPrice() { return totalPrice; }

        //Command
        public void AddItem()
        {
            orderList.Add(this);
            Console.WriteLine($"{Quantity}x {Name} added to order.");
        }

        public void RemoveItem()
        {
            orderList.Remove(this);
            Console.WriteLine($"{Quantity}x {Name} removed from order.");
        }
    }
}
