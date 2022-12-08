using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ComplexNumber
    {
        double imaginaryPart;

        public double RealPart { get; set; }

        public double ImaginaryPart
        {
            get => imaginaryPart;
            set
            {
                try
                {
                    if (value == 0) throw new ArgumentException("Мнимая часть не может быть нулевой");
                    imaginaryPart = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public ComplexNumber(double realPart, double imaginaryPart)
        {
            RealPart = realPart;
            ImaginaryPart = imaginaryPart;
        }

        public override string ToString()
        {
            return $"{RealPart} + {ImaginaryPart}i";
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b) => new ComplexNumber(a.RealPart + b.RealPart, a.ImaginaryPart + b.ImaginaryPart);

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b) => new ComplexNumber(a.RealPart - b.RealPart, a.ImaginaryPart - b.ImaginaryPart);

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            double Atmp = (a.RealPart * b.RealPart) - (a.ImaginaryPart * b.ImaginaryPart);
            double Btmp = (a.RealPart * b.ImaginaryPart) + (a.ImaginaryPart * b.RealPart);

            return new ComplexNumber(Atmp, Btmp);
        }

        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            a *= new ComplexNumber(b.RealPart, -b.ImaginaryPart);

            double Btmp = Math.Pow(b.RealPart, 2) + Math.Pow(b.ImaginaryPart, 2);

            return new ComplexNumber(a.RealPart/Btmp, a.ImaginaryPart/Btmp);
        }
    }
}
