using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class MenuItem : MenuComponent
    {
        private string name;
        private string description;
        private double price;
        private DiscountStrategy discountType;
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
        public MenuItem(string name, string desc, double price)
        {
            Name = name;
            Description = desc;
            Price = price;
        }

        public void SetDiscount(DiscountStrategy discount)
        {
            discountType = discount;
        }

        public override void print()
        {
            string indentString = new string(' ', Indent * 2);
            double discountPrice = discountType != null ? discountType.Discount(price) : price;
            Console.WriteLine($"{indentString}{Name} - {Description}\n{indentString}Price: ${discountPrice:0.00}");
        }

    }
}
