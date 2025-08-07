using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    abstract class MenuComponent
    {
        private int indent;
        public int Indent
        {
            get { return indent; }
            set { indent = value; }
        }
        public virtual void setIndent(int indent)
        {
            this.Indent = indent;
        }

        public virtual void add(MenuComponent mc)
        {
            throw new NotSupportedException();
        }
        public virtual void remove(MenuComponent mc)
        {
            throw new NotSupportedException();
        }
        public virtual MenuComponent getChild(int index)
        {
            throw new NotSupportedException();
        }
        public virtual void print()
        {
            throw new NotSupportedException();
        }
    }
}
