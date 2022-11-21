using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class A
    {
        static void swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

    }
}