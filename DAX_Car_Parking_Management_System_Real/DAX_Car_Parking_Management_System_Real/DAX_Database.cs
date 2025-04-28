using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAX_Car_Parking_Management_System_Real
{
    internal class DAX_Database
    {
        private static string carDetails = "CAR ID  ==============  CAR NUMBER  ==============  CAR NAME  ==============  CAR IN TIME  ==============  CAR OUT TIME  ==============  TOTAL FEES\n";

        private static string userName = "admin";

        private static string password = "admin";

        public static void save(DAX_Car car, DateTime outTime, double fees = 500.0)
        {
            int num = Convert.ToInt16(car.carID);
            string carNumber = car.carNumber;
            string carName = car.carName;
            DateTime inTime = car.inTime;
            carDetails += $"{num}  ==============  {carNumber}  ==============  {carName}  ==============  {inTime}  ==============  {outTime}  ==============  {fees} RUPEES \n";
        }

        public static void showCarDetails()
        {
            Console.WriteLine("ENTER THE USER NAME :\n");
            string value = Console.ReadLine().ToLower();
            Console.WriteLine("ENTER THE PASSWORD :\n");
            string value2 = Console.ReadLine().ToLower();
            if (userName.Equals(value) && password.Equals(value2))
            {
                Console.WriteLine("LOGIN SUCCESSSFUL.....\n");
                Console.WriteLine("SHOWING CAR DETAILS.....\n");
                string[] array = carDetails.Split(new char[1] { '\n' });
                for (int i = 0; i < array.Length - 1; i++)
                {
                    Console.WriteLine(array[i] + "\n");
                }
            }
            else
            {
                Console.WriteLine("WRONG USER ID AND PASSWORD.....\n");
            }
        }
    }
}
