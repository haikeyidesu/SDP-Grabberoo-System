using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_ASG
{
    internal class Customer
    {
        private string email;
        private string password;
        // Replace arrays with lists
        private List<Command> addOrderCommands;
        private List<Command> removeOrderCommands;
        private Command undoCommand;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Customer()
        {
            addOrderCommands = new List<Command>();
            removeOrderCommands = new List<Command>();
            Command noCommand = new NoCommand();
            undoCommand = noCommand;
        }

        public void SetCommand(int slot, Command placeOrderCommand, Command removeOrderCommand)
        {
            while (addOrderCommands.Count <= slot)
                addOrderCommands.Add(new NoCommand());
            while (removeOrderCommands.Count <= slot)
                removeOrderCommands.Add(new NoCommand());

            addOrderCommands[slot] = placeOrderCommand;
            removeOrderCommands[slot] = removeOrderCommand;
        }

        public void AddOrder(int slot)
        {
            if (slot < addOrderCommands.Count)
            {
                addOrderCommands[slot].execute();
                undoCommand = addOrderCommands[slot];
            }
        }

        public void RemoveOrder(int slot)
        {
            if (slot < removeOrderCommands.Count)
            {
                removeOrderCommands[slot].execute();
                undoCommand = removeOrderCommands[slot];
            }
        }

        public void undoOrder()
        {
            undoCommand.undo();
        }

    }
}
