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
        protected double price => this.menuItem.Price;
        protected int quantity;
        protected double totalPrice => price * (double)quantity;

        public double Price 
        { 
            get { return price; } 
        }
        public MenuItem MenuItem
        {
            get { return menuItem; }
            set { menuItem = value; }
        }

        // for decorator
        public virtual string getName()
        {
            return name;
        }
        public virtual string getDescription()
        {
            return description;
        }
        public virtual double getCost()
        {
            return totalPrice;
        }
        public virtual int getQuantity()
        {
            return quantity;
        }
                
    }
}
