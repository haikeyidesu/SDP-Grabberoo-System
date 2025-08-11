using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASGGN
{
    internal interface OrderStates
    {
        public void PayOrder(bool payment);
        public void CancelOrder(bool orderCancellable);
        public void RejectOrder(bool orderCancellable);
        public void PrepareOrder();
        public void CompleteOrder();
    }
}
