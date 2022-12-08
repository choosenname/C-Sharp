using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using ClassLibrary1;

namespace ConsoleApp4
{
    internal class A
    {
        static void Main()
        {
            ComplexNumber number = new ComplexNumber(23, 56);
            ComplexNumber number1 = new ComplexNumber(4, 17);

            Console.Write($"({number}) + ({number1}) = ");

            ComplexNumber number2 = number + number1;
            Console.WriteLine(number2.ToString());

            Console.WriteLine(new ComplexNumber(-2, 1) - new ComplexNumber(Math.Sqrt(3), 5));

            Console.WriteLine(new ComplexNumber(1, 3) * new ComplexNumber(4, -2));

            Console.WriteLine(new ComplexNumber(13, 1) / new ComplexNumber(7, -6));
        }
    }
}