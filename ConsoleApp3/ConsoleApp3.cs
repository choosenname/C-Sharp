using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class ConsoleApp3
    {
        static void Main(string[] args)
        {
            MythicalCreature mythicalCreature = new MythicalCreature();
            mythicalCreature.RandEnterObject(9);
            Console.WriteLine(mythicalCreature);
            mythicalCreature.Weight = -2;
            Console.WriteLine(mythicalCreature);
            
        }
    }
}