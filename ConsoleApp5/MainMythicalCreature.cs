using System;

namespace ConsoleApp5
{
    internal class MainMythicalCreature
    {
        static void Main(string[] args)
        {
            MythicalCreature.Event += Print;


            Dragon dragon = new Dragon("dttttttt", 5000, 250, 300, SexEnum.Male);

            ArrayMythicalCreature array = new ArrayMythicalCreature
            {
                new MythicalCreature[] {
                new Ogr("лешка", 250, 300, 30, SexEnum.Male, 50),
                new ArmoredOgr("cursed", 300, 200, 25, SexEnum.Female, 100, 30),
                new Dragon("draconchik", 1500, 1500, 10, SexEnum.None),
                new ArmoredOgr("John Xina", 500, 300, 11, SexEnum.None, 75, 50),
                new ArmoredOgr("лепешка", 300, 300, 25, SexEnum.Female, 100, 30) }
            };

            Console.WriteLine(array.FindMax((x, y) => x.Health > y.Health));
            Console.WriteLine(array.MinHealth());

            ArrayMythicalCreature.Event += AnotherPrint;

            Console.WriteLine("-------");

            ArrayMythicalCreature.Func = Show;
            ArrayMythicalCreature.Func(array.ArrayMC);

            Console.WriteLine("-------");

            array.Show((x, y) => Console.WriteLine(x + " " + y));

            Console.WriteLine("-------");

            array.Clear();
            array.Add(dragon);
            array.Show();
            array.Remove(dragon);
            array.Show();

            Console.ReadLine();
        }

        static void Show(object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(i + ". " + arr[i]);
        }

        static void Print(object obj, MythicalCreatureEventArgs args)
        {
            Console.WriteLine(args.Message + " " + obj.GetType().Name);
        }

        static void AnotherPrint(object obj, ArrayMythicalCreatureEventArgs args)
        {
            Console.WriteLine(args.Message + " " + args.Object);
        }
    }
}
