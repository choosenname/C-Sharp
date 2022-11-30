using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
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
