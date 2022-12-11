using System;

namespace ConsoleApp4
{
    internal class MotherboardArray
    {
        internal Motherboard[] Motherboards { get; set; }
        internal MotherboardArray(Motherboard[] Motherboards)
        {
            this.Motherboards = Motherboards;
        }
        internal void ShowArray()
        {
            foreach (var board in Motherboards)
            {
                Console.WriteLine(board);
            }
        }
        internal Motherboard MaxMotherBoard()
        {
            int index = -1, maxRAM = -1;
            for (int i = 0; i < Motherboards.Length; i++)
            {
                if (Motherboards[i].Processor.Model == Processor.ProcessorModels.AMD && Motherboards[i].RAM > maxRAM)
                {
                    maxRAM = Motherboards[i].RAM;
                    index = i;
                }
            }
            if (index == -1) { return null; }
            else { return Motherboards[index]; }
        }
    }
}
