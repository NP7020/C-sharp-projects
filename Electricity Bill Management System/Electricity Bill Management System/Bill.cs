using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity_Bill_Management_System
{
    internal class Bill
    {
        public int BillNo
        {
            set;
            get;
        }
        public int UserID
        {
            set;
            get;
        }
        public string Month
        {
            set;
            get;
        }
        public DateTime date
        {
            set;
            get;
        }
        public int NumberOfUnits
        {
            set;
            get;
        }
        public int Amount
        {
            set;
            get;
        }
    }
}
