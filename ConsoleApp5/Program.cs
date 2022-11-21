using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dragon dragon = new Dragon("Драгобебр", 200, 5, 1, MythicalCreature.SexEnum.Male);
            Console.WriteLine(dragon);
            for(int i = 0;i< 20;i++)
            {
                Console.WriteLine(dragon.Attack());
                //Thread.Sleep(18);
            }
            Console.ReadLine();
        }
    }
}
