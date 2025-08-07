using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class CreditCardPayment : PaymentStrategy
    {
        private string paymentDetails;
        private double balance;
        public string PaymentDetails
        {
            get { return paymentDetails; }
            set { paymentDetails = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public CreditCardPayment(double balance, string paymentDetails)
        {
            Balance = balance;
            PaymentDetails = paymentDetails;
        }

        public bool processPayment(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Payment of ${amount:0.00} is successful!");
                return true;
            }
            Console.WriteLine($"Payment of ${amount:0.00} is unsuccessful.");
            return false;
        }
    }
}
