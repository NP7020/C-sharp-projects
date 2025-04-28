using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAX_Car_Parking_Management_System_Real
{
    internal class DAX_Entry
    {
        public static void Main(string[] args)
        {
            DAX_ParkingSlot.setInitial();
            Console.WriteLine("WELCOME TO CAR PARKING MANAGEMENT SYSTEM :)\n");
            while (true)
            {
                Console.WriteLine("ENTER YOUR CHOICE TO USE OUR SERVICE:\n1.BOOK PARKING SLOT\n2.LEAVE PARKING SLOT\n3.SHOW SLOTS\n4.SLOT DETAILS\n5.SEARCH CAR DETAILS\n6.SHOW DATABASE\n7.EXIT\n");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        DAX_ParkingSlot.bookParKingSlot();
                        break;
                    case 2:
                        DAX_ParkingSlot.leaveParKingSlot();
                        break;
                    case 3:
                        new DAX_ParkingSlot().showSlots();
                        break;
                    case 4:
                        DAX_ParkingSlot.countSlots();
                        break;
                    case 5:
                        DAX_ParkingSlot.searchSlots();
                        break;
                    case 6:
                        DAX_Database.showCarDetails();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("INVALID CHOICE.....\n");
                        break;
                }
            }
        }
    }
}
