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
            Student student1 = new Student(3, 3, 12, 6, 4);
        }

        public static void ShowExeption(Exception ex)
        {
            Console.WriteLine($"Исключение: {ex.Message}");
            Console.WriteLine($"Название приложения: {ex.Source}");
            Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            Console.WriteLine($"Метод: {ex.TargetSite}");
        }
    }
}
