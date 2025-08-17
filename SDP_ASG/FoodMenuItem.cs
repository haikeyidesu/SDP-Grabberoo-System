using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class FoodMenuItem : MenuItem
    {
        public FoodMenuItem(string name, string desc, double price) : base(name, desc, price)
        {
        }

        public override void print()
        {
            string indentString = new string(' ', Indent * 2);
            Console.WriteLine($"{indentString}{Name} - {Description}\n{indentString}Price: ${Price:0.00}");
        }
    }
}
