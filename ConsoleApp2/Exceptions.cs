using System;

namespace КПиЯП
{
    internal class CarExeption : Exception
    {
        public CarExeption(string message) : base(message) { }
    }

    internal class InvalidArgumentExeption : ArgumentException
    {
        public InvalidArgumentExeption(string message) : base(message) { }
    }

    public class CarArgumentNullException : ArgumentNullException
    {
        public CarArgumentNullException(string message) : base(message) { }
    }
}
