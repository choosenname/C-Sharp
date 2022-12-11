using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    interface IShowInfo
    {
        void ShowInfo();
    }

    [Serializable]
    public class Processor : ICloneable, IComparable<Processor>, IComparer<Processor>, IShowInfo
    {
        public enum ProcessorModels
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

        public ProcessorModels Model
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
        public double ClockRate
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
        public int Cache
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
        public double Cost
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
        public Processor()
        {
            model = 0;
            clockRate = 0;
            cache = 0;
            cost = 0;
        }
        public Processor(Random random)
        {
            RandomEnter(random);
        }
        public Processor(ProcessorModels model, double clockRate, int cache, double cost)
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
        public void RandomEnter(Random random)
        {
            model = (ProcessorModels)random.Next(Enum.GetNames(typeof(ProcessorModels)).Length);

            clockRate = random.Next(0, 3) + Math.Round(random.NextDouble(), 1);

            int tmp = random.Next(2, 32);
            if (tmp % 2 != 0)
                tmp++;
            cache = tmp;

            cost = random.Next(43, 1000) + Math.Round(random.NextDouble(), 3);
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
        public void ShowInfo()
        {
            Console.WriteLine(ToString());
        }
    }
}