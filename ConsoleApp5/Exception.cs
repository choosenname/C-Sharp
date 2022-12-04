using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class InvalidNameException : Exception
    {
        public InvalidNameException() : base("Введенное имя не подходит") { }
    }

    internal class ArgumentLessThenZeroException : ArgumentException
    {
        public ArgumentLessThenZeroException() : base("Значение не может быть меньше нуля") { }

        public ArgumentLessThenZeroException(object obj) : base(String.Format("Значение не может быть меньше нуля ({0})", obj)) { }

        public ArgumentLessThenZeroException(string message) : base(message) { }
    }
    
    internal class ArgumentLessOrZeroException : ArgumentException
    {
        public ArgumentLessOrZeroException() : base("Значение не может быть меньше нуля") { }

        public ArgumentLessOrZeroException(object obj) : base(String.Format("Значение не может быть меньше нуля ({0})", obj)) { }

        public ArgumentLessOrZeroException(string message) : base(message) { }
    }
    
    internal class ArgumentOutOfRangeException : ArgumentException
    {
        public ArgumentOutOfRangeException() : base("Значение вышло за допустимый диапазон") { }

        public ArgumentOutOfRangeException((int, int) range) : base(String.Format("Значение вышло за допустимый диапазон (min - {0} max - {1})", range.Item1, range.Item2)) { }

        public ArgumentOutOfRangeException(string message) : base(message) { }
    }

    internal delegate void ShowExeptionFunc(System.Exception ex);
}
