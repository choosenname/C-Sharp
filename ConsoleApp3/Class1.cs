using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            Hashtable catalog = new Hashtable();
            while (true)
            {
                Console.WriteLine("1 - заполнить случайно, 2 - вывести, 3 - добавить диск, 4 - добавить музыку, 5 - поиск по исполнителю, 6 - удалить исполнителя");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        {
                            catalog = GenCD();
                            break;
                        }

                    case 2:
                        {
                            foreach (DictionaryEntry item in catalog)
                            {
                                Console.WriteLine("Исполнитель: " + item.Key);
                                foreach (DictionaryEntry item1 in (Hashtable)item.Value)
                                {
                                    Console.WriteLine(item1.Value + " ---- " + item1.Key);
                                }
                            }
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Сколько дисков добавить");
                            int len = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < len; i++)
                            {
                                Console.WriteLine("Введите исполнителя");
                                var str = Console.ReadLine();
                                catalog.Add(str, EnterMusic());
                            }
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Введите исполнителя");
                            string str = Console.ReadLine();
                            foreach (DictionaryEntry item in catalog)
                            {
                                if ((string)item.Key == str)
                                {
                                    Console.WriteLine("Сколько песен добавить");
                                    int len = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < len; i++)
                                    {
                                        Console.WriteLine("Введите название");
                                        var str1 = Console.ReadLine();

                                        Console.WriteLine("Введите продолжительность песни");
                                        var str2 = Console.ReadLine();

                                        var b = str2.Split(new char[] { ':' });
                                        ((Hashtable)item.Value).Add(new TimeSpan(Convert.ToInt32(b[0]), Convert.ToInt32(b[1]), Convert.ToInt32(b[2])), str1);
                                    }
                                    break;
                                }
                            }
                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine("Введите исполнителя");
                            string str = Console.ReadLine();
                            foreach (DictionaryEntry item in catalog)
                            {
                                if ((string)item.Key == str)
                                {
                                    foreach (DictionaryEntry item1 in (Hashtable)item.Value)
                                    {
                                        Console.WriteLine(item1.Value + " ---- " + item1.Key);
                                    }
                                }
                            }
                            break;
                        }

                    case 6:
                        {
                            Console.WriteLine("Введите исполнителя");
                            string str = Console.ReadLine();
                            catalog.Remove(str);
                            break;
                        }
                }
            }
        }

        static Hashtable EnterMusic()
        {
            Hashtable Music = new Hashtable();
            Console.WriteLine("Сколько песен добавить");
            int len = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("Введите название");
                var str = Console.ReadLine();

                Console.WriteLine("Введите продолжительность песни");
                var str1 = Console.ReadLine();

                var b = str1.Split(new char[] { ':' });
                Music.Add(new TimeSpan(Convert.ToInt32(b[0]), Convert.ToInt32(b[1]), Convert.ToInt32(b[2])), str);
            }
            return Music;
        }

        static Hashtable GenMusic()
        {
            Hashtable Music = new Hashtable();
            Random random = new Random();
            for (int j = 0; j < random.Next(1, 12); j++)
            {
                string str = "";
                for (int i = 0; i < random.Next(2, 12); i++)
                {
                    str += (char)random.Next('a', 'z');
                }
                Music.Add(new TimeSpan(0, random.Next(120), random.Next(60)), str);
            }
            return Music;
        }

        static Hashtable GenCD()
        {
            Hashtable CD = new Hashtable();
            Random random = new Random();
            for (int j = 0; j < random.Next(1, 12); j++)
            {
                string str = "";
                for (int i = 0; i < random.Next(1, 12); i++)
                {
                    str += (char)random.Next('a', 'z');
                }
                CD.Add(str, GenMusic());
            }
            return CD;
        }
    }
}
