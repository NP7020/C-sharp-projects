using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_App
{
    internal class App:Message
    {
        List<SMS> mes = new List<SMS>();

        public static int counter = 0;

        static float rate = 0.1f;
        static float defaultcharge=0.30f;
        public override void Send()
        {
            Console.WriteLine("enter the name");
            string name = Console.ReadLine();
            if(name.Length==0)
            {
                Greet();
            }
            else
            {
                Greet(name);
            }
            Console.WriteLine("enter the From id");
            string from = Console.ReadLine();
            Console.WriteLine("enter the To id");
            string to = Console.ReadLine();
            if(from.Equals(to))
            {
                Console.WriteLine("sender and receiver cannot same");
                return;
            }
            Console.WriteLine("enter the Content");
            string content = Console.ReadLine();
            DateTime intime = DateTime.Now;

            SMS m = new SMS();
            m.From = from;
            m.To = to;
            m.Content = content;
            m.InTime = intime;
            m.Read = false;

            Console.WriteLine("enter 1 for ok");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice!=1)
            {
                Console.WriteLine("cancelled");
                return;
            }

            m.SMSId = ++counter;
            mes.Add(m);

            ISendable i =new App();
            i.Send();

            base.Send();

            Console.WriteLine($"message id :{m.SMSId}");
        }
        public override void Receive()
        {
            
            Console.WriteLine("enter your id");
            string to = Console.ReadLine();

            SMS m = new SMS();
            m.To = to;

            bool valid = false;
            int count = 0;
            foreach(SMS m1 in mes)
            {
                if(m1!=null && m1.To==to && m1.Read==false)
                {
                    m = m1;
                    Console.WriteLine("==================================");
                    Console.WriteLine($"Message Id :{m.SMSId}");
                    Console.WriteLine($"From : {m.From}");
                    Console.WriteLine($"To : {m.To}");
                    Console.WriteLine($"Content : {m.Content}");
                    Console.WriteLine($"InTime : {m1.InTime}");
                    m.Read = true;
                    Console.WriteLine($"Read : {m1.Read}");
                    valid = true;
                    Console.WriteLine("==================================");

                }
                else if (m1!= null && m1.To == to && m1.Read == true)
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }
            if (count > 0)
            {
                Console.WriteLine("all messages are open");
                return;
            }
            if (valid==false)
            {
                Console.WriteLine("wrong id");
                return;
            }

            IReceivable i = new App();
            i.Receive();

            base.Receive();
        }
        public override void ShowAll()
        {
            Console.WriteLine("enter your id");
            string to = Console.ReadLine();

            SMS m = new SMS();
            m.To = to;

            bool valid = false;
            foreach (SMS m1 in mes)
            {
                if (m1 != null && m1.To==m.To)
                {
                    m = m1;
                    Console.WriteLine("==================================");
                    Console.WriteLine($"Message Id :{m.SMSId}");
                    Console.WriteLine($"From : {m.From}");
                    Console.WriteLine($"To : {m.To}");
                    Console.WriteLine($"Content : {m.Content}");
                    Console.WriteLine($"InTime : {m.InTime}");
                    m.Read = true;
                    Console.WriteLine($"Read : {m.Read}");
                    valid = true;
                    Console.WriteLine("==================================");

                }
                else
                {
                    continue;
                }
            }
            if(valid==false)
            {
                Console.WriteLine("wrong id");
                return;
            }
        }
        public void Greet()
        {
            Console.WriteLine("welcome user");
        }
        public void Greet(string name)
        {
            Console.WriteLine($"welcome {name}");
        }
        public void Getcharge()
        {
            Console.WriteLine($"charge is : {defaultcharge} rupee");
        }
        public void Getcharge(int o,int s)
        {
            Console.WriteLine($"messages sent : {o}");
            Console.WriteLine($"messages received : {s}");
            Console.WriteLine($"charge is : {(o+s)*rate} rupee");
        }
        public void ShowCharge()
        {
            Console.WriteLine("enter your id");
            string id = Console.ReadLine();
            int lsent = 0;
            int lreceived = 0;
            foreach(SMS m1 in mes)
            {
                if(m1!=null && m1.From.Equals(id))
                {
                    lsent++;
                }
                if(m1!=null && m1.To.Equals(id))
                {
                    lreceived++;
                }
            }
            int t = lsent + lreceived;
            if(t<=4)
            {
                Getcharge();
            }
            else
            {
                Getcharge(lsent,lreceived);
            }
        }
    }
}
