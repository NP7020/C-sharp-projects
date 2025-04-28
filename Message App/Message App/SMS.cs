using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_App
{
    internal class SMS
    {
        public int SMSId
        {
            set;
            get;
        }
        public string From
        {
            set;
            get;
        }
        public string To
        {
            set;
            get;
        }
        public string Content
        {
            set;
            get;
        }
        public DateTime InTime
        {
            set;
            get;
        }
        public bool Read
        {
            set;
            get;
        }
    }
}
