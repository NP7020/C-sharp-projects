using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop
{
    internal class CakeUI:CakeDesign
    {
       
        public override void createCake()
        {
            Console.WriteLine("ENTER YOUR CHOICE :\n1.STANDARD BIRTHDAY CAKE\n2.CUSTOM CAKE");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice==1)
            {
                StandardCake standardCake = new CakeUI();
                standardCake.prepare();
                Console.WriteLine("PRESS 1 FOR CONTINUE.....");
                int move = Convert.ToInt32(Console.ReadLine());
                if (move == 1)
                {
                    Cake mango =new Cake();
                    mango.Weight = 3;
                    mango.Message = "HAPPY BIRTHDAY";
                    mango.CakeType = "NORMAL CAKE";
                    mango.Flavour = "VANILLA";
                    mango.Cherry = true;
                    mango.Cream = true;
                    mango.Candle = true;
                    mango.CandleCount = 8;
                    mango.Amount = 600;
                    mango.Date = DateTime.Now;
                    mango.OrderNumber = ++Cake.billNumber;


                    bill.Add(mango);
                    showBill();
                    showBill(mango);
                    thankMessage();
                }
                else
                {
                    Console.WriteLine("CANCELLING TRANSACTION.....");
                }

            }
            else if(choice==2)
            {
                CustomCake customCake = new CakeUI();
                customCake.prepare();

                Console.WriteLine("ENTER THE WEIGHT [1 or 2] IN Kg: ");
                int weight = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("ENTER THE MESSAGE : ");
                string message = Console.ReadLine();
                Console.WriteLine("ENTER THE CAKE TYPE :\n1.NORMAL\n2.ICE CAKE\n3.FANTACY");
                int cakeTypeChoice = Convert.ToInt32(Console.ReadLine());
                string[] cakeTypeList= {"NORMAL CAKE", "ICE CAKE", "FANTACY CAKE" };
                string cakeType = cakeTypeList[cakeTypeChoice - 1];
                Console.WriteLine("ENTER THE CAKE FLAVOUR :\n1.VANILLA\n2.CHOCOLATE\n3.PISTA");
                int flavourChoice = Convert.ToInt32(Console.ReadLine());
                string[] cakeFlavourList = { "VANILLA", "CHOCOLATE", "PISTA" };
                string flavour =cakeFlavourList[flavourChoice - 1];
                Console.WriteLine("ENTER 1 FOR CHERRY : ");
                bool cherry =(Convert.ToInt32(Console.ReadLine()) == 1)?true:false;
                Console.WriteLine("ENTER 1 FOR CREAM : ");
                bool cream = (Convert.ToInt32(Console.ReadLine()) == 1) ? true : false;
                Console.WriteLine("ENTER 1 FOR CANDLE : ");
                bool candle = (Convert.ToInt32(Console.ReadLine()) == 1) ? true : false;
                int candleCount=0;
                if(candle==true)
                {
                    Console.WriteLine("ENTER THE NUMBER OF CANDLES : ");
                    candleCount =Convert.ToInt32(Console.ReadLine());
                }
                int amount = calculatePrice(weight, cakeType,flavour,cherry,cream,candle,candleCount);

                Console.WriteLine("PRESS 1 FOR CONTINUE.....");
                int move = Convert.ToInt32(Console.ReadLine());
                if(move==1)
                {
                    DateTime date = DateTime.Now;
                    Cake mango =new Cake();
                    mango.Weight = weight;
                    mango.Message = message;
                    mango.CakeType = cakeType;
                    mango.Flavour = flavour;
                    mango.Cherry = cherry;
                    mango.Cream = cream;
                    mango.Candle = candle;
                    mango.CandleCount = candleCount;
                    mango.Amount = amount;
                    mango.Date = date;
                    mango.OrderNumber = ++Cake.billNumber;

                    bill.Add(mango);
                    showBill();
                    showBill(mango);
                    thankMessage();
                }
                else
                {
                    Console.WriteLine("CANCELLING TRANSACTION.....");
                }

            }
            else
            {
                Console.WriteLine("INVALID......");
            }
        }
        public int calculatePrice(int weight, string cakeType,string flavour,bool cherry,bool cream,bool candle,int candleCount)
        {
            base.calculatePrice(weight ,cakeType,flavour);
            int price = 0;
            if (cakeType.Equals("FANTACY CAKE"))
            {
                price = price + (weight * 200);
            }
            else if(cakeType.Equals("ICE CAKE"))
            {
                price = price + (weight * 150);
            }
            else
            {
                price = price + (weight * 100);
            }
            if (flavour.Equals("PISTA"))
            {
                price = price + (weight * 200);
            }
            else if (flavour.Equals("CHOCOLATE"))
            {
                price = price + (weight * 150);
            }
            else
            {
                price = price + (weight * 100);
            }
            if(cherry==true)
            {
                price = price + 70;
            }
            if(cream==true)
            {
                price = price + 70;
            }
            if(candle==true)
            {
                price = price + (candleCount * 10);
            }
            return price;
        }

        public override void showBill(Cake mango)
        {
            
            Console.WriteLine("==========================");
            Console.WriteLine("ORDER NUMBER : {0}",mango.OrderNumber);
            Console.WriteLine("DATE : {0}", mango.Date);
            Console.WriteLine("WEIGHT : {0} Kg",mango.Weight);
            Console.WriteLine("MESSAGE : {0}", mango.Message);
            Console.WriteLine("CAKE TYPE : {0}",mango.CakeType);
            Console.WriteLine("CAKE FLAVOUR : {0}",mango.Flavour);
            Console.WriteLine("ADDED CHERRY : {0}",mango.Cherry?"Yes":"No");
            Console.WriteLine("ADDED CREAM : {0}",mango.Cream?"Yes":"No");
            Console.WriteLine("WANT CANDLE : {0}",mango.Candle?"Yes\nNUMBER OF CANDLES : "+mango.CandleCount:"No");
            Console.WriteLine("AMOUNT : {0} Rs",mango.Amount);
            Console.WriteLine("==========================");

        }
        public override void thankMessage()
        {
            Console.WriteLine("PLEASE TAKE YOUR CAKE.....");
            Console.WriteLine("THANK YOU......\nVISIT AGAIN.....\n\n\n\n");
        }
        public override void showAllBill()
        {
            base.showAllBill();
            foreach(Cake mango in bill)
            {
                if(mango==null)
                {
                    continue;
                }
                else
                {
                    showBill(mango);
                }
            }
        }
    }
}
