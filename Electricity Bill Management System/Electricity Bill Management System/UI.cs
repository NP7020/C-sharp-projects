using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity_Bill_Management_System
{
    internal class UI
    {
        public void addUser()
        {
            Console.WriteLine("enter the user name");
            string username = Console.ReadLine();
            Console.WriteLine("enter the connection phase as 1 or 2 or 3");
            char phase = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("enter the connection type as D or C or I");
            char type = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("enter the address");
            string address = Console.ReadLine();
     
            User us = new User();
            us.UserName = username;
            us.ConnectionPhase = phase;
            us.ConnectionType = type;
            us.Address = address;

            Db.AddUser(us);
        }
        public void deleteUser()
        {
            Console.WriteLine("enter the user id");
            int userid = Convert.ToInt32(Console.ReadLine());

            User us = new User();
            us.UserID = userid;

            if(Db.HaveUser(us)==true)
            {
                Db.DeleteUser(us);
            }
            else
            {
                Console.WriteLine("Wrong user id");
            }
        }
        public void updateUser()
        {
            Console.WriteLine("enter the user id");
            int userid = Convert.ToInt32(Console.ReadLine());

            User us = new User();
            us.UserID = userid;
            if (Db.HaveUser(us) == true)
            {
                Console.WriteLine("enter the user name");
                string username = Console.ReadLine();
                Console.WriteLine("enter the connection phase as 1 or 2 or 3");
                char phase = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("enter the connection type as D or C or I");
                char type = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("enter the address");
                string address = Console.ReadLine();

                us.UserName = username;
                us.ConnectionPhase = phase;
                us.ConnectionType = type;
                us.Address = address;

                Db.UpdateUser(us);
            }
            else
            {
                Console.WriteLine("Wrong user id");
            }
        }
        public void saveBill()
        {
            Console.WriteLine("enter the user id");
            int userid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter the month");
            string month = Console.ReadLine();

            DateTime date = DateTime.Now;

            Console.WriteLine("enter the no of units");
            int noofunits = Convert.ToInt32(Console.ReadLine());

            
            Bill b = new Bill();
            b.UserID = userid;
            b.Month = month;
            b.date = date ;
            b.NumberOfUnits = noofunits;

            Db.SaveBill(b);
        }
        public void createDatabase()
        {
            Db.CreateDatabase();
        }
        public void showBill()
        {
            Console.WriteLine("enter the user id");
            int userid = Convert.ToInt32(Console.ReadLine());

            User us = new User();
            us.UserID = userid;

            if (Db.HaveUser(us) == true)
            {
                Db.ShowBill(us);
            }
            else
            {
                Console.WriteLine("Wrong user id");
            }
        }
    }
}
