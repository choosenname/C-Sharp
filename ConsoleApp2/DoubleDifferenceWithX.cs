using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class DoubleDifferenceWithX : DoubleDifference
    {
        double x;
        internal double X
        {
            get { return x; }
            set
            {
                try
                {
                    x = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        internal DoubleDifferenceWithX(double a, double b, double x) : base(a, b)
        {
            X = x;
        }
        internal override double GetDifference() => A * Math.Pow(x, 2) + B;
    }
}
