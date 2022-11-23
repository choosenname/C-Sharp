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
            Dragon dragon = new Dragon("Драгобебр", 2000, 2500, 300, MythicalCreature.SexEnum.Male);
            Console.WriteLine(dragon);

            Wyvern wyvern = new Wyvern("Дребр", 500, 250, 45, MythicalCreature.SexEnum.Female, 28);
            Console.WriteLine(wyvern);

            Ogr ogr = new Ogr("игорь", 350, 300, 25, MythicalCreature.SexEnum.None, 30);
            Console.WriteLine(ogr);

            ArmoredOgr armoredOgr = new ArmoredOgr("Бруско", 300, 250, 14, MythicalCreature.SexEnum.Male, 15, 15);
            Console.WriteLine(armoredOgr);

            Console.WriteLine(ogr.Figth(armoredOgr));
            Console.ReadLine();
        }
    }
}
