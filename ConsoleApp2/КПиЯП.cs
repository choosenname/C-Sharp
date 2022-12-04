using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class КПиЯП
    {
        class CandyEventArgs
        {
            public string message;
            public int n;
            public CandyEventArgs(string s, int c)
            {
                message = s;
                n = c;
            }
        }
        delegate void CandyHandler(object obj, CandyEventArgs m);
        class CandyBag
        {
            int amount; // кол-во конфет
            //CandyHandler del;
            public event CandyHandler Adding; //до
            public event CandyHandler Eaten; //после
            public CandyBag(int n)
            {
                amount = n;
            }
            public void Input(int k)
            {
                if (Adding != null) Adding(this, new CandyEventArgs("В мешок добавляется ", k));
                amount += k;
            }
            public void Output(int k)
            {
                if (amount > k)
                {
                    amount -= k;
                    if (Eaten != null) Eaten(this, new CandyEventArgs("Съедено ", k));
                }
                else if (Eaten != null) Eaten(this, new CandyEventArgs("Не хватает конфет", amount));
            }
        }
        static void PrintA(object obj, CandyEventArgs s)
        {
            Console.WriteLine(s.message + s.n);
        }
        static void PrintB(object obj, CandyEventArgs s)
        {
            Console.WriteLine("Сообщение: " + s.message + s.n);
        }
        static void Main()
        {
            CandyBag bag = new CandyBag(100);
            bag.Adding += PrintA;
            bag.Eaten += PrintB;
            bag.Eaten += PrintA;
            bag.Input(100);
            bag.Output(150);
            bag.Output(100);
            Console.ReadKey();
        }

    }
}
