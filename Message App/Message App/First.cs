using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_App
{
    internal class First
    {
        public static void Main(string[] args)
        {
            Message o = new App();
            while(true)
            {
                Console.WriteLine("enter 1.Send 2.Receive 3.Show All Messages 4.Show Charge 5.exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                if(choice==1)
                {
                    o.Send();
                }
                else if (choice == 2)
                {
                    o.Receive();
                }
                else if (choice == 3)
                {
                    o.ShowAll();
                }
                else if (choice == 4)
                {
                    App p = (App)o;
                    p.ShowCharge();
                }
                else if (choice == 5)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
        }
    }
}
