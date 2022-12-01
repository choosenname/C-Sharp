using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class LessThenZeroException : ArgumentException
    {
        public LessThenZeroException() : base("Значение не может быть меньше нуля") { }
    }

    internal class MoreThen24HourException  : ArgumentException
    {
        public MoreThen24HourException() : base("Сумма всех часов не может превышать 24") { }
    }

    internal class SumIsNot24HourException : ArgumentException
    {
        public SumIsNot24HourException() : base("Сумма всех часов не равна 24") { }
    }
}
