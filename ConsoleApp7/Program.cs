using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OneDimensional arr = new OneDimensional(15);
            Console.WriteLine(">>>" + arr.Average());
            arr.Show();
            arr.Sort((a, b) => a < b);
            arr.Show();
            arr.PreviousByNext((a, b) => a * b);
            arr.ShowWithCurrency();
        }
    }
}
