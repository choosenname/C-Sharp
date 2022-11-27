using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Processor[] processors = new Processor[25];
            for (int i = 0; i < processors.Length; i++)
            {
                processors[i] = new Processor(random);
                Console.WriteLine(processors[i]);
            }

            Console.WriteLine("-----------СОРТИРОВКА ПО ЦЕНЕ---------");
            Array.Sort(processors);
            foreach (var obj in processors)
                Console.WriteLine(obj);
            
            Console.WriteLine("-----------СОРТИРОВКА---------");
            Array.Sort(processors, new Processor());
            foreach (var obj in processors)
                Console.WriteLine(obj);

            Processor A = (Processor)processors[0].Clone();
            Console.WriteLine("\n----------------\nОбъект {0}\nКлон {1}", processors[0], A);
        }
    }
}
