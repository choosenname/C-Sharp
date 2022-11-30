using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parallelogram.ExceptionNotify += ex => Console.WriteLine($"Исключение: {ex.Message}");
            Parallelogram.ExceptionNotify += ex => Console.WriteLine($"Название приложения: {ex.Source}");
            Parallelogram.ExceptionNotify += ex => Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            Parallelogram.ExceptionNotify += ex => Console.WriteLine($"Метод: {ex.TargetSite}");
            Parallelogram parallelogram = new Parallelogram();

            parallelogram.Square = 0;
            parallelogram.ASide = 3;
            Console.WriteLine(parallelogram.GetHeight());

            Matrix.ExceptionNotify += ex => Console.WriteLine(ex);
            Matrix matrix = new Matrix(new int[3, 3]
            {   {1, 0, 0},
                {0, 1, 0},
                {0, 0, 1}});

            //matrix.EnterArr();
            ArrayFunc.ArrayFunc.OutArr(matrix.Array);
            Console.WriteLine(matrix?.IsOrthonormal());
        }
    }
}