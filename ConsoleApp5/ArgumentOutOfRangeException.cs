using System;

namespace ConsoleApp5
{
    internal class ArgumentOutOfRangeException : ArgumentException
    {
        public ArgumentOutOfRangeException() : base("Значение вышло за допустимый диапазон") { }

        public ArgumentOutOfRangeException((int, int) range) : base(String.Format("Значение вышло за допустимый диапазон (min - {0} max - {1})", range.Item1, range.Item2)) { }

        public ArgumentOutOfRangeException(string message) : base(message) { }
    }
}
