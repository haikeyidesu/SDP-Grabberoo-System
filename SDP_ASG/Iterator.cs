using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal interface Iterator
    {
        public bool hasNext();
        public MenuComponent next();
    }
}