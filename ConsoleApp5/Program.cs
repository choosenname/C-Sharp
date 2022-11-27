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

            Ogr ogr = new Ogr("игорь Бруско", 350, 300, 25, MythicalCreature.SexEnum.None, 30);
            Console.WriteLine(ogr);

            ArmoredOgr armoredOgr = new ArmoredOgr("Куско", 300, 250, 14, MythicalCreature.SexEnum.Male, 15, 15);
            Console.WriteLine(armoredOgr);


            Console.WriteLine("-------------------------------");
            ArrayMythicalCreature array = new ArrayMythicalCreature();
            array.Add(new MythicalCreature[] { armoredOgr, ogr, wyvern, dragon });
            Console.WriteLine(array);

            Console.WriteLine("Больше всего урона: " + array.MaxDamage());
            Console.WriteLine("Меньше всего здоровья: " + array.MinHealth());

            Console.WriteLine("----------Отсортированный массив------------");
            //array.SortByName();
            Array.Sort(array.ArrayOfMC);
            Console.WriteLine(array);

            int a = ogr.Figth(armoredOgr);
            if (a == 0) Console.WriteLine("Ничья");
            else if(a > 0) Console.WriteLine("Победитель: {0}\nПроигравший: {1}", ogr, armoredOgr);
            else Console.WriteLine("Победитель: {0}\nПроигравший: {1}", armoredOgr, ogr);

            Console.WriteLine("-------------------------------");
            array.Remove(dragon);
            array.Add(new MythicalCreature[] {
                new Ogr("лешка", 250, 300, 30, MythicalCreature.SexEnum.Male, 50),
                new ArmoredOgr("cursed", 300, 400, 25, MythicalCreature.SexEnum.Female, 100, 30),
                new Dragon("draconchik", 1500, 1500, 10, MythicalCreature.SexEnum.None),
                new ArmoredOgr("John Xina", 350, 500, 11, MythicalCreature.SexEnum.None, 75, 50),
                new ArmoredOgr("лепешка", 300, 400, 25, MythicalCreature.SexEnum.Female, 100, 30),});

            ArrayMythicalCreature array1 = new ArrayMythicalCreature();
            array1.Add(new MythicalCreature[] { dragon,
                new ArmoredOgr("Лазупин", 300, 400, 25, MythicalCreature.SexEnum.Female, 100, 30)});

            Console.WriteLine($"{array}\nVS\n{array1}");

            Console.WriteLine("\n\nПобедители:\n{0}", array.Figth(array1) > 0 ? array : array1);

            Console.ReadLine();
        }
    }
}
