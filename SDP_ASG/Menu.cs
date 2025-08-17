
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class Menu : MenuComponent
    {
        private string name;
        private List<MenuComponent> menuComponents;
        protected DiscountStrategy discountType;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<MenuComponent> MenuComponents
        {
            get { return menuComponents; }
            set { menuComponents = value; }
        }
        public Menu(string name)
        {
            Name = name;
            MenuComponents = new List<MenuComponent>();
            Indent = 0;
        }
        public override void add(MenuComponent mc)
        {
            MenuComponents.Add(mc);
            mc.setIndent(this.Indent + 1);
        }
        public override void remove(MenuComponent mc)
        {
            mc.Indent = this.Indent + 1;
            MenuComponents.Remove(mc);
        }
        public override MenuComponent getChild(int index)
        {
            return MenuComponents[index];
        }
        public override void setIndent(int indent)
        {
            this.Indent = indent;
            foreach (var mc in menuComponents)
            {
                mc.setIndent(indent + 1);
            }
        }

        public override void print()
        {
            string indentString = new string(' ', Indent * 2);
            Console.WriteLine($"{indentString}{Name} Menu:");
        }


        //Kai Sheng ( for iterator)

        public List<MenuComponent> GetChildren()
        {
            return menuComponents;
            
        }

        public Iterator createIterator()
        {
            return new CompositeIterator(menuComponents.GetEnumerator());
        }

        //Strategy
        public void Discount(DiscountStrategy discount)
        {

            discountType = discount;
            foreach (var mc in MenuComponents)
            {
                if (mc is Menu submenu)
                    submenu.Discount(discount);
                else if (mc is MenuItem item)
                    item.SetDiscount(discount);
            }
        }
    }
}
