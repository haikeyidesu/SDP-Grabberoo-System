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

        public override void print()
        {
            string indentString = new string(' ', Indent * 2);
            Console.WriteLine($"{indentString}{Name} - {Description}\n{indentString}Price: ${Price:0.00}");
        }
    }
}
