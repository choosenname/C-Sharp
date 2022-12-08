using SomeFunc;
using System;
using System.IO;

namespace КПиЯП
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayFunc.EnterArr(out int[] arr, 127);
            //ArrayFunc.PrintArr(arr);

            string path = @"C:\Users\admin\Desktop\Бебра.doci";
            string path1 = @"C:\Users\admin\Desktop\+.+";
            //File.Create(path);

            File.WriteAllText(path, ArrayFunc.OutArr(arr));
            string[] str = File.ReadAllText(path).Split(' ');

            try
            {
                File.WriteAllText(path1, "");
                while (true)
                {
                    Console.WriteLine("Введите число k");
                    int index = Convert.ToInt32(Console.ReadLine());

                    if (index < 1 || index > str.Length)
                        File.AppendAllText(path1, Convert.ToString(Convert.ToChar(128)));
                    else
                        File.AppendAllText(path1, str[index - 1]);
                    File.AppendAllText(path1, " ");
                }
            }
            catch (FormatException) { }
            catch (Exception ex) { Console.WriteLine(ex); }

            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine("-------");
            Console.WriteLine(File.ReadAllText(path1));
        }
    }
}
