using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal interface OrderStates
    {
        public void PayOrder();
        public void CancelOrder();
        public void RejectOrder();
        public void PrepareOrder();
        public void CompleteOrder();
    }
}
