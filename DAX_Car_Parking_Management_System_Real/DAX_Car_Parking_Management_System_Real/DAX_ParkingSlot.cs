using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAX_Car_Parking_Management_System_Real
{
    internal class DAX_ParkingSlot
    {
        public static int size = 16;

        public static int[] carSpace = new int[size];

        public static DAX_Car[] carObjectSpace;

        public static void setInitial()
        {
            carObjectSpace = new DAX_Car[size];
            for (int i = 0; i < size; i++)
            {
                carSpace[i] = i + 1;
                carObjectSpace[i] = null;
            }
        }

        public void showSlots()
        {
            Console.WriteLine("SHOWING SLOTS.....");
            Console.WriteLine(" ________________________________________________________________________");
            for (int i = 0; i < size; i++)
            {
                Console.Write(" | " + carSpace[i]);
            }
            Console.Write(" |\n");
            Console.WriteLine(" ________________________________________________________________________");
        }

        public static void bookParKingSlot()
        {
            new DAX_ParkingSlot().showSlots();
            Console.WriteLine("\n");
            Console.WriteLine("CHOOSE A FREE SLOT [NON 0 SLOT] :\n");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num >= 1 && num <= 15)
            {
                if (carSpace[num - 1] == 0)
                {
                    Console.WriteLine("SLOT {0} IS ALREADY FILLED......\nCHOOSE ANOTHER.....\n", num);
                    return;
                }
                Console.WriteLine("SLOT {0} IS AVAILABLE.....\n", num);
                Console.WriteLine("ENTER THE CAR ID :\n");
                string carID = Console.ReadLine();
                Console.WriteLine("ENTER THE CAR NUMBER :\n");
                string carNumber = Console.ReadLine();
                Console.WriteLine("ENTER THE CAR NAME :\n");
                string carName = Console.ReadLine();
                Console.WriteLine("SLOT {0} IS BOOKED SUCCESSFULLY.....\n", num);
                DateTime now = DateTime.Now;
                DAX_Car dAX_Car = new DAX_Car(carID, carNumber, carName, now);
                carSpace[num - 1] = 0;
                carObjectSpace[num - 1] = dAX_Car;
            }
            else
            {
                Console.WriteLine("INVALID SLOTS......\n");
            }
        }

        public static void leaveParKingSlot()
        {
            Console.WriteLine("ENTER THE CAR ID :\n");
            string value = Console.ReadLine();
            bool flag = false;
            for (int i = 0; i < carObjectSpace.Length; i++)
            {
                DAX_Car dAX_Car = carObjectSpace[i];
                if (dAX_Car != null && dAX_Car.carID.Equals(value))
                {
                    Console.WriteLine("SLOT {0} IS LEAVED SUCCESSFULLY.....\n", i + 1);
                    carSpace[i] = i + 1;
                    DateTime now = DateTime.Now;
                    int seconds = (now - dAX_Car.inTime).Seconds;
                    double num = new DAX_ParkingSlot().calculateFee(seconds);
                    Console.WriteLine("TOTAL AMOUNT : {0} RUPEES\n", num);
                    DAX_Database.save(dAX_Car, now);
                    carObjectSpace[i] = null;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("WRONG PARKING ID.....\n");
            }
        }

        public static void countSlots()
        {
            int num = 0;
            int num2 = 0;
            Console.WriteLine("COUNTING SLOTS......\n");
            for (int i = 0; i < carSpace.Length; i++)
            {
                if (carSpace[i] == 0)
                {
                    num2++;
                }
                else
                {
                    num++;
                }
            }
            Console.WriteLine("FREE SLOTS : {0}\n", num);
            Console.WriteLine("OCCUPIED SLOTS : {0}\n", num2);
        }

        public static void searchSlots()
        {
            Console.WriteLine("SEARCHING DETAILS.....\n");
            Console.WriteLine("ENTER THE CAR NUMBER YOU WANT TO SEARCH :\n");
            string text = Console.ReadLine();
            bool flag = false;
            DAX_Car[] array = carObjectSpace;
            foreach (DAX_Car dAX_Car in array)
            {
                if (dAX_Car != null)
                {
                    string carNumber = dAX_Car.carNumber;
                    if (text.Equals(carNumber))
                    {
                        Console.WriteLine("SHOWING DETAILS.....\n");
                        Console.WriteLine("CAR ID : {0}\nCAR NUMBER : {1}\nCAR NAME : {2}\nCAR IN TIME : {3}\nCAR STATUS : IN THE PARKING\n", dAX_Car.carID, dAX_Car.carNumber, dAX_Car.carName, dAX_Car.inTime);
                        flag = true;
                        break;
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine("CAR IS NOT IN THE PARKING.....\n");
            }
        }

        public double calculateFee(int seconds)
        {
            double num = 0.0;
            if (seconds <= 10)
            {
                return seconds * 2;
            }
            if (seconds > 10 && seconds <= 20)
            {
                return seconds * 4;
            }
            if (seconds > 20 && seconds <= 30)
            {
                return seconds * 6;
            }
            if (seconds > 30 && seconds <= 40)
            {
                return seconds * 8;
            }
            if (seconds > 40 && seconds <= 50)
            {
                return seconds * 10;
            }
            return seconds * 14;
        }
    }
}
