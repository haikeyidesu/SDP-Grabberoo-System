using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal interface PaymentStrategy
    {
        bool processPayment(double amount);
    }
}
