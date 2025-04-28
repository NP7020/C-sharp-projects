using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity_Bill_Management_System
{
    internal class User
    {
        public int UserID
        {
            set;
            get;
        }
        public string UserName
        {
            set;
            get;
        }
        public char ConnectionPhase
        {
            set;
            get;
        }
        public char ConnectionType
        {
            set;
            get;
        }
        public string Address
        {
            set;
            get;
        }
    }
}
