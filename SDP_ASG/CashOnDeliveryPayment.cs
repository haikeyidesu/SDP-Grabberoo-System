using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class CashOnDeliveryPayment : PaymentStrategy
    {
        public bool processPayment(double amount)
        {
            Console.WriteLine($"Payment of ${amount:0.00} to be collected on delivery.");
            return true;
        }
    }
}
