using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class CarEventArgs
    {
        public string Message { get; }

        public CarEventArgs(string message)
        {
            Message = message;
        }
    }
}
