using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_App
{
    internal abstract class Message:ISendable,IReceivable
    {

        void ISendable.Send()
        {
            Console.WriteLine("Sending....");
        }
        void IReceivable.Receive()
        {
            Console.WriteLine("Receiving....");
        }
        public virtual void Send()
        {
            Console.WriteLine("Message sent successfully");
        }
        public virtual void Receive()
        {
            Console.WriteLine("Messages received successfully");
        }

        public abstract void ShowAll();
    }
}
