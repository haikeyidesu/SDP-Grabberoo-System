using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class HolidayDiscount : DiscountStrategy
    {
        public double Discount(double price)
        {
            return price * 0.9;
        }
    }
}
