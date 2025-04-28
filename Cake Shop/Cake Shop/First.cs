using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Cake_Shop
{
    class First
    {

        public static void Main(string[] args)
        {
            CakeDesign cd =new CakeUI();
            while(true)
            {
                Console.WriteLine("ENTER YOUR CHOICE :\n1.CREATE CAKE\n2.SHOW ALL BILL INFORMATION\n3.EXIT");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    cd.createCake();
                }
                else if (choice == 2)
                {
                    cd.showAllBill();
                }
                else if (choice == 3)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("INVALID.....");
                }
            }
        }
    }
}
