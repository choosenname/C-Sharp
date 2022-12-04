using System;

namespace ConsoleApp2
{
    internal class КПиЯП
    {
        delegate double Func(double x);

        public static void Main(string[] args)
        {
            IntervalFunc(Math.Cos);
            Console.WriteLine("-----------");
            IntervalFunc(Math.Cosh);
        }

        static void IntervalFunc(Func f)
        {
            for (double i = 0; i < 3; i += 0.02)
            {
                Console.WriteLine(f(i));
            }
        }
    }
}
