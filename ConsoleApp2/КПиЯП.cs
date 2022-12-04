﻿using System;

namespace ConsoleApp2
{
    internal class КПиЯП
    {
        delegate double Func(double x);

        public static void Main(string[] args)
        {
            /*DoubleDifference @double = new DoubleDifference(3.8, 5.2);
            Console.WriteLine(@double.GetDifference());

            DoubleDifferenceWithX doubleDifference = new DoubleDifferenceWithX(@double.B, 5.97, 3);
            Console.WriteLine(doubleDifference.GetDifference());*/

            Processor processor = new Processor(Processor.ProcessorModels.AMD, 2.34, 12, 783.34);
            Console.WriteLine(processor);

            processor.ShowInfo();

            Motherboard motherboard = new Motherboard(processor, 12);
            Console.WriteLine(motherboard);

            Motherboard[] motherboards = new Motherboard[10];
            motherboards[0] = motherboard;

            for (int i = 0; i < motherboards.Length; i++)
            {
                motherboards[i] = new Motherboard(i);
            }

            MotherboardArray array = new MotherboardArray(motherboards);
            array.ShowArray();

            Console.WriteLine("Материнская плата на процессоре AMD с самым большим количеством оперативной памяти");
            Console.WriteLine(array.MaxMotherBoard());

            Console.WriteLine("----------------");
            Motherboard motherboard1 = (Motherboard)motherboard.Clone();

            Console.WriteLine("----------------");
            Array.Sort(motherboards);
            foreach (var i in motherboards)
                i.ShowInfo();

            Console.WriteLine("----------------");
            Array.Sort(motherboards, new Motherboard());
            foreach (var i in motherboards)
                i.ShowInfo();

        }
    }
}
