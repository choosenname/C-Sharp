using System;

namespace КПиЯП
{
    internal class Program
    {
        static void Main(string[] args)
        {

            OneDimensional arr;
            while (true)
            {
                Console.WriteLine("Введите размер массива");
                try
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (n < 1) throw new ArgumentOutOfRangeException("Размер массива не может быть меньше 1");
                    else
                    {
                        arr = new OneDimensional(n);
                        break;
                    }
                }
                catch (Exception ex) { ShowException(ex); }
            }
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
                                bool flag = true;
                                OneDimensional.FuncPrevByNext func = null;
                                Console.WriteLine("Какое действие вы хотите выполнить (*,/,+,-)");
                                switch (Console.ReadLine())
                                {
                                    case "*": func = (a, b) => a * b; break;
                                    case "/": func = (a, b) => a / b; break;
                                    case "+": func = (a, b) => a + b; break;
                                    case "-": func = (a, b) => a - b; break;
                                    default: Console.WriteLine("Неверное значение"); flag = false; break;
                                }

                                if (flag)
                                {
                                    arr.PreviousByNext(func);
                                    arr.ShowWithCurrency();
                                }
                                break;
                            }
                        case 5: return;
                        default: { Console.WriteLine("Неверное значение, повторите ввод"); break; }
                    }
                }
                catch (FormatException ex) { ShowException(ex); }
                catch (Exception ex) { ShowException(ex); }
            }
        }

        static void ShowException(Exception ex) { Console.WriteLine(ex); }
    }
}