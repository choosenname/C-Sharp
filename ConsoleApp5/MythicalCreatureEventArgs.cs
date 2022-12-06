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
        { this.Message = message; }
    }

    delegate void StudyGroupHandler(object obj, MythicalCreatureEventArgs args);
}
