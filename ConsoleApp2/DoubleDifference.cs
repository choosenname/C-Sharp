using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class DoubleDifference
    {
        double a;
        double b;
        internal double A
        {
            get { return a; }
            set
            {
                try
                {
                    a = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        internal double B
        {
            get { return b; }
            set
            {
                try
                {
                    b = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        internal DoubleDifference(double a, double b)
        {
            A = a;
            B = b;
        }
        internal virtual double GetDifference() => Math.Pow(a, 2) - Math.Pow(b, 2);
    }
}
