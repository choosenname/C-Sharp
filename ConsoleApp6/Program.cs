using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hours.ShowExeption = ShowExeption;
            Student.ShowExeption = ShowExeption;
            Students.ShowExeption = ShowExeption;
            Random random = new Random();

            Students students = new Students(new List<Student>()
            {
                new Student(3, 3, 12, 6, 4),
                new Student(-1, 4, 5, 25, 7),
                new Student(10, 4, 7, 4, 8),
                new Student(random),
                new Student(random),
                new Student(random),
                new Student(random),
                new Student(random),
                new Student(random),
                new Student(random),
                new Student(random),
                new Student(random)
            });

            students.Show();
            Console.WriteLine("\nЗависимость среднего балла от приоритета учащегося. \n");
            students.ShowDependence();

        }
        public static void ShowExeption(System.Exception ex)
        {
            Console.WriteLine($"Исключение: {ex.Message}");
            Console.WriteLine($"Название приложения: {ex.Source}");
            Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            Console.WriteLine($"Метод: {ex.TargetSite}");
        }

    }
}
