using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class ArrayMythicalCreatureEventArgs
    {
        public string Message { get; }

        public MythicalCreature Object { get; }

        public ArrayMythicalCreatureEventArgs(string message, MythicalCreature obj)
        {
            Message = message;
            Object = obj;
        }
    }

    delegate void ArrayMythicalCreatureHandler(object obj, ArrayMythicalCreatureEventArgs args);
}
