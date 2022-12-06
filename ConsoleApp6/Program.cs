using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
