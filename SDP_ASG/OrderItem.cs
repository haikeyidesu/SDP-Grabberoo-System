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
        protected string name => this.menuItem.Name;
        protected string description => this.menuItem.Description;
        protected double price => this.menuItem.GetDiscountPrice();
        protected int quantity;
        protected double totalPrice => menuItem.GetDiscountPrice() * (double)quantity;
        //protected OrderItem orderItem;
        protected List<OrderItem> orderList;

        public MenuItem MenuItem
        {
            get { return menuItem; }
            set { menuItem = value; }
        }
        public virtual string getName() { return name; }
        public virtual double getIndividualPrice() { return price; }
        public virtual int getQuantity() { return quantity; }
        public virtual string getDescription() { return description; }
        public virtual double getTotalPrice() { return totalPrice; }

        //Command
        public void AddItem()
        {
            orderList.Add(this);
            Console.WriteLine($"{this.getQuantity()}x {this.getName()} added to order.");
        }

        public void RemoveItem()
        {
            orderList.Remove(this);
            Console.WriteLine($"{this.getQuantity()}x {this.getName()} removed from order.");
        }
    }
}
