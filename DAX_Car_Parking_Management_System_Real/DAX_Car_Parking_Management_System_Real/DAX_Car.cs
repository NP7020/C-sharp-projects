using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAX_Car_Parking_Management_System_Real
{
    internal class DAX_Car
    {
        public string carID;

        public string carNumber;

        public string carName;

        public DateTime inTime;

        public DAX_Car(string carID, string carNumber, string carName, DateTime inTime)
        {
            this.carID = carID;
            this.carNumber = carNumber;
            this.carName = carName;
            this.inTime = inTime;
        }
    }
}
