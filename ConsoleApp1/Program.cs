using System;

namespace КПиЯП
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] str = new string[15];
            Random random = new Random();
            for (int i = 0; i < str.Length; i++)
            {
                string tmp = null;
                for (int j = 0; j < random.Next(3, 17); j++)
                {
                    tmp += (char)random.Next('a', 'z');
                }
                str[i] = tmp + " ";
                Console.WriteLine(str[i]);
            }
        }
    }
}