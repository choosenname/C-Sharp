using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    internal class LessThenZeroException : ArgumentException
    {
        public LessThenZeroException() : base("Значение не может быть меньше нуля") { }

        public LessThenZeroException(string message) : base(message) { }
    }

    internal class SumIsMoreThen24HourException : ArgumentException
    {
        public SumIsMoreThen24HourException() : base("Сумма всех часов не может превышать 24") { }
        
        public SumIsMoreThen24HourException(string message) : base(message) { }
    }

    internal class MoreThen24HourException : ArgumentException
    {
        public MoreThen24HourException() : base("Проводимое время не может быть больше 24 часов") { }

        public MoreThen24HourException(string message) : base(message) { }
    }

    internal class SumIsNot24HourException : ArgumentException
    {
        public SumIsNot24HourException() : base("Сумма всех часов не равна 24") { }

        public SumIsNot24HourException(string message) : base(message) { }
    }

    internal class StudentNullReferenceException : System.NullReferenceException
    {
        public StudentNullReferenceException() : base() { }

        public StudentNullReferenceException(string message) : base(message) { }
    }

    internal class StudentException : System.Exception
    {
        public StudentException() : base() { }

        public StudentException(string message) : base(message) { }
    }

    internal delegate void ShowExeptionFunc(System.Exception ex);
}
