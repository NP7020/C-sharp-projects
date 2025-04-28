using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop
{
    class Cake
    {
        public static int billNumber = 0;
        public int OrderNumber
        {
            set;
            get;
        }
        public int Weight
        {
            set;
            get;
        }
        public string Message
        {
            set;
            get;
        }
        public string CakeType
        {
            set;
            get;
        }
        
        public string Flavour
        {
            set;
            get;
        }
        public bool Cherry
        {
            set;
            get;
        }
        public bool Cream
        {
            set;
            get;
        }
        public bool Candle
        {
            set;
            get;
        }
        public int CandleCount
        {
            set;
            get;
        }
        public int Amount
        {
            set;
            get;
        }
        public DateTime Date
        {
            set;
            get;
        }
    }
}
