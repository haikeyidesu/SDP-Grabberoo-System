using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class StudentDiscount : DiscountStrategy
    {
        public double Discount(double price)
        {
            return price / 100 * 80;
        }
    }
}
