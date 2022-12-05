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
            Console.WriteLine("Введите размер массива");
            OneDimensional arr;
            try
            {
                arr = new OneDimensional(Convert.ToInt32(Console.ReadLine()));
            }
            catch (FormatException ex) { Console.WriteLine(ex); arr = new OneDimensional(9); }
            arr.Show();
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберете действие 1 - Вывести массив, 2 - Найти среднее по модулю, 3 - Отсортировать массив, 4 - Обработать массив, 5 - Выход");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1: { arr.Show(); break; }
                        case 2: { Console.WriteLine(">>>" + arr.Average()); break; }
                        case 3: { arr.Sort(); break; }
                        case 4:
                            {
                                Console.WriteLine("Какое действие вы хотите выполнить (*,/,+,-)");
                                OneDimensional.FuncPrevByNext func = (a, b) => a * b;
                                switch (Console.ReadLine())
                                {
                                    case "*": break;
                                    case "/": func = (a, b) => a / b; break;
                                    case "+": func = (a, b) => a + b; break;
                                    case "-": func = (a, b) => a - b; break;
                                    default: Console.WriteLine("Неверное значение, выполнена функция умножения"); break;
                                }
                                arr.PreviousByNext(func);
                                arr.ShowWithCurrency();
                                break;
                            }
                        case 5: return;
                        default: { Console.WriteLine("Неверное значение, повторите ввод"); break; }
                    }
                }
                catch (FormatException) { Console.WriteLine("Неверное значение, повторите ввод"); }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
        }
    }
}