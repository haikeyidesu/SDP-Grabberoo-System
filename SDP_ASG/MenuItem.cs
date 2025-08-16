using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal abstract class MenuItem : MenuComponent
    {
        private string name;
        private string description;
        private double price;
        private DiscountStrategy discountType;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }
        public virtual double Price
        {
            get { return price; }
            set { price = value; }
        }

        public void SetDiscount(DiscountStrategy discount)
        {
            discountType = discount;
        }

        public double GetDiscountPrice()
        {
            return discountType != null ? discountType.Discount(price) : price;
        }


        public override void print()
        {
            string indentString = new string(' ', Indent * 2);
            double discountPrice = GetDiscountPrice();
            Console.WriteLine($"{indentString}{Name} - {Description}\n{indentString}Price: ${discountPrice:0.00}");
        }

    }
}
