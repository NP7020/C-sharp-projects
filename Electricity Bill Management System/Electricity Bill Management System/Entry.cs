using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity_Bill_Management_System
{
    internal class Entry
    {
        public static void Main(string[] args)
        {
            UI ui = new UI();
            ui.createDatabase();
            while(true)
            {
                Console.WriteLine("enter 1.add user 2.delete user 3.update user 4.save bill 5.show bill 6.exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    ui.addUser();
                }
                else if (choice == 2)
                {
                    ui.deleteUser();
                }
                else if (choice == 3)
                {
                    ui.updateUser();
                }
                else if (choice == 4)
                {
                    ui.saveBill();
                }
                else if (choice == 5)
                {
                    ui.showBill();
                }
                else if (choice == 6)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }
    }
}
