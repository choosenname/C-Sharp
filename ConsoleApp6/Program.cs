using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
>>>>>>> practice

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
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
=======
            StudyGroup.Event += AlsoPrint;
            StudyGroup.Adding += AnotherPrint;

            StudyGroup.Deducting += AlsoPrint;
            StudyGroup.Deducting += Priiiint;


            int girls, boys;

            Console.WriteLine("Введите начальное количество девушек");
            girls = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите начальное количество юношей");
            boys = Convert.ToInt32(Console.ReadLine());

            StudyGroup group = new StudyGroup(girls < 0 ? Math.Abs(girls) : girls, boys < 0 ? Math.Abs(boys) : boys);


            while (true)
            {
                Console.WriteLine("Выберете действие 1 - Вывести группу, 2 - Отчислить студентов, 3 - Добавить юношей, 4 - Выход");
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1": { Console.WriteLine(group); break; }
                        case "2":
                            {
                                Console.WriteLine("Введите количество девушек для отчисления");
                                girls = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Введите количество юнош для отчисления");
                                boys = Convert.ToInt32(Console.ReadLine());
>>>>>>> practice

                                group.Deduct(girls, boys);
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("Введите количество юнош");
                                group.AddBoys(Convert.ToInt32(Console.ReadLine()));

                                break;
                            }
                        case "4": return;
                        default: { Console.WriteLine("Неверное значение, повторите ввод"); break; }
                    }
                }
                catch (Exception ex) { ShowException(ex); }
            }
        }

        static void ShowException(Exception ex) { Console.WriteLine(ex); }

        static void Priiiint(object obj, StudyGroupEventArgs sg)
        {
            Console.WriteLine(obj);
        }

        static void AnotherPrint(object obj, StudyGroupEventArgs sg)
        {
            Console.WriteLine("{0} {1}", sg.Message, sg.Boys);
        }

        static void AlsoPrint(object obj, StudyGroupEventArgs sg)
        {
            Console.WriteLine("{0}  девушек {1}, юношей {2}", sg.Message, sg.Boys, sg.Girls);
        }
    }
}
