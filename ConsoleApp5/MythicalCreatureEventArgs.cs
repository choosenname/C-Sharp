using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class MythicalCreatureEventArgs
    {
        public string Message { get; }

        public MythicalCreatureEventArgs(string message)
        {
            Message = message;
        }
    }

    delegate void MythicalCreatureHandler(object obj, MythicalCreatureEventArgs args);
}
