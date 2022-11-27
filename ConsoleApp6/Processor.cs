using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Processor : ICloneable, IComparable<Processor>, IComparer<Processor>
    {
        internal enum ProcessorModels
        {
            AMD,
            Intel,
            IBM,
            Эльбрус
        }
        ProcessorModels model;
        double clockRate;
        int cache;
        double cost;

        internal ProcessorModels Model
        {
            get { return model; }
            set
            {
                try
                {
                    model = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        internal double ClockRate
        {
            get { return clockRate; }
            set
            {
                try
                {
                    if (value < 0)
                    { throw new Exception("Значение должны быть больше 0 для тактовой частоты"); }
                    else if (value > 100)
                    { throw new Exception("Значение должны быть меньше 100 для тактовой частоты"); }
                    else
                    { clockRate = value; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        internal int Cache
        {
            get { return cache; }
            set
            {
                try
                {
                    if (value < 0)
                    { throw new Exception("Значение должны быть больше 0 для кэша"); }
                    else if (value > 100)
                    { throw new Exception("Значение должны быть меньше 100 для кэша"); }
                    else if (value % 2 != 0)
                    { throw new Exception("Значение должно быть кратно 2 для кэша"); }
                    else
                    { cache = value; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        internal double Cost
        {
            get { return cost; }
            set
            {
                try
                {
                    if (value < 0)
                    { throw new Exception("Значение должны быть больше 0 для цены"); }
                    else if (value > 100000)
                    { throw new Exception("Значение должны быть меньше 100000 для цены"); }
                    else
                    { cost = value; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        internal Processor()
        {
            model = 0;
            clockRate = 0;
            cache = 0;
            cost = 0;
        }
        internal Processor(Random random)
        {
            Enter(random);
        }
        internal Processor(ProcessorModels model, double clockRate, int cache, double cost)
        {
            Model = model;
            ClockRate = clockRate;
            Cache = cache;
            Cost = cost;
        }
        public override string ToString()
        {
            return $"Процессор модели {model}, с тактовой частотой {clockRate} ГГц, объемом кэша {cache} МБ и стоимостью {cost:C2}";
        }
        internal void Enter(Random random)
        {
            model = (ProcessorModels)random.Next(Enum.GetNames(typeof(ProcessorModels)).Length);

            clockRate = random.Next(0, 3) + Math.Round(random.NextDouble(), 1);

            int tmp = random.Next(2, 32);
            if (tmp % 2 != 0)
                tmp++;
            cache = tmp;

            cost = random.Next(43, 1000) + Math.Round(random.NextDouble(), 3);
        }
        internal void Enter()
        {
            Console.WriteLine("Введите модель от 0 до 3" + Model);
            model = (ProcessorModels)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите тактовою частоту от 0 до 100");
            clockRate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите размер кэша от 2 до 32 (четное)");
            cache = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите цену от 0 до 100000");
            cost = Convert.ToInt32(Console.ReadLine());
        }

        public object Clone()
        {
            return new Processor(model, clockRate, cache, cost);
        }

        public int CompareTo(Processor other)
        {
            return Math.Sign(cost - other.cost);
        }

        public int Compare(Processor x, Processor y)
        {
            int resolt = x.model.ToString().CompareTo(y.model.ToString());
            if (resolt == 0)
            {
                resolt = x.model.ToString().Length - y.model.ToString().Length;
                if (resolt == 0)
                {
                    resolt = Math.Sign(x.clockRate - y.clockRate);
                    if (resolt == 0)
                        resolt = x.CompareTo(y);
                }
            }
            return resolt;
        }
    }
}