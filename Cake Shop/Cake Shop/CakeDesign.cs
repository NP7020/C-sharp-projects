using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop
{
    internal abstract class CakeDesign : StandardCake, CustomCake
    {
        public static List<Cake> bill = new List<Cake>();
        void StandardCake.prepare()
        {
            Console.WriteLine("PREPARING STANDARD BIRTHDAY CAKE.....");
        }
        void CustomCake.prepare()
        {
            Console.WriteLine("PREPARING CUSTOM CAKE......");
        }
        public virtual void showAllBill()
        {
            Console.WriteLine("SHOWING ALL BILL INFORMATION.....");
        }
        public int calculatePrice(int weight, string cakeType, string flavour)
        {
            Console.WriteLine("CALCULATING PRICE FOR {0} Kg  OF {1}-{2}.....", weight, flavour, cakeType);
            return 0;
        }
        public void showBill()
        {
            Console.WriteLine("SHOWING BILL INFORMATION.....");
        }
        public abstract void createCake();
        public abstract void showBill(Cake mango);

        public abstract void thankMessage();

        
    }
}
