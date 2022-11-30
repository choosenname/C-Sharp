using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Motherboard : ICloneable, IComparable<Motherboard>, IComparer<Motherboard>, IShowInfo
    {
        internal Processor Processor { get; set; }
        int ram;
        internal int RAM
        {
            get { return ram; }
            set
            {
                try
                {
                    if (value < 0)
                    { throw new Exception("Значение должны быть больше 0 для оперативной памяти"); }
                    else if (value > 100)
                    { throw new Exception("Значение должны быть меньше 100 для оперативной памяти"); }
                    else if (value % 2 != 0)
                    { throw new Exception("Значение должно быть кратно 2 для оперативной памяти"); }
                    else
                    { ram = value; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        internal Motherboard()
        {
            ram = 0;
            Processor = new Processor();
        }
        internal Motherboard(int seed)
        {
            RandomEnter(seed);
        }
        internal Motherboard(Processor.ProcessorModels model, double clockRate, int cache, double cost, int ram)
        {
            Processor = new Processor(model, clockRate, cache, cost);
            RAM = ram;
        }
        internal Motherboard(Processor processor, int ram)
        {
            this.Processor = processor;
            RAM = ram;
        }
        public override string ToString()
        {
            return $"Материнская плата с {ram} ГБ оперативной памяти и c {Processor}";
        }
        internal void RandomEnter(int seed)
        {
            Processor = new Processor(seed);

            Random random = new Random(seed);
            int tmp = random.Next(2, 256);
            if (tmp % 2 != 0)
                tmp++;
            ram = tmp;
        }

        public object Clone()
        {
            return new Motherboard(Processor.Model, Processor.ClockRate, Processor.Cache, Processor.Cost, ram);
        }

        public int CompareTo(Motherboard other)
        {
            return ram - other.RAM;
        }

        public int Compare(Motherboard x, Motherboard y)
        {
            int resolt = x.Processor.Compare(x.Processor, y.Processor);
            if (resolt == 0)
                resolt = x.CompareTo(y);
            return resolt;
        }

        public void ShowInfo()
        {
            Console.WriteLine(ToString());
        }
    }
}
