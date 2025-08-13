using SDP_ASG;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class CompositeIterator:Iterator
    {
        private Stack<IEnumerator<MenuComponent>> stack = new Stack<IEnumerator<MenuComponent>>();

        public CompositeIterator(IEnumerator<MenuComponent> iterator)
        {
            stack.Push(iterator);
        }

        public bool hasNext()
        {
            while (stack.Count > 0)
            {
                IEnumerator<MenuComponent> iterator = stack.Peek();

                if (iterator.MoveNext())
                {
                    return true;
                }
                else
                {
                    stack.Pop(); 
                }
            }
            return false;
        }

        public MenuComponent next()
        {
            IEnumerator<MenuComponent> iterator = stack.Peek();
            MenuComponent component = iterator.Current;

     
            if (component is Menu menu)
            {
                stack.Push(menu.GetChildren().GetEnumerator());
            }

            return component;
        }
    }
}
