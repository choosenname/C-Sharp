using System;
using System.Data.SqlTypes;
using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace ConsoleApp1
{
    internal class ConsoleApp1
    {
        static int[] enterMas()
        {
            Console.Write("Введите размер массива: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] mas = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < mas.Length; i++)
                mas[i] = rnd.Next(0, 99);
            outMas(mas);

            return mas;
        }
        static void outMas(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
                Console.Write(mas[i] + " ");
            Console.WriteLine();
        }
        static int MaxNum(int[] mas)
        {
            int max = mas[0], n = 0;

            for (int i = 1; i < mas.Length; i++)
            {
                if (max < mas[i])
                {
                    max = mas[i];
                    n = i;
                }
            }

            return n;
        }
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        static int Sum(int[] mas, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += mas[i];
            return sum;
        }
        static int[] BubbleSort(int[] mas)
        {
            int temp;
            int[] numArr = new int[mas.Length];
            for (int i = 0; i < mas.Length; i++)
                numArr[i] = i;

            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[numArr[i]] <= mas[numArr[j]])
                    {
                        temp = numArr[i];
                        numArr[i] = numArr[j];
                        numArr[j] = temp;
                    }
                }
            }
            return numArr;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите номер задания: ");
                int set = Convert.ToInt32(Console.ReadLine());
                switch (set)
                {
                    case 1:
                        string str = "gfgChild 56chIld fdk.45Children ds00";
                        str = Regex.Replace(str, "child", "children", RegexOptions.IgnoreCase);
                        str = Regex.Replace(str, @"\d", "");
                        Console.WriteLine(str);
                        break;

                    case 2:
                        str = "gfgr prklfg,pre fld fkfprint, pret";

                        foreach (Match match in new Regex(@"\bpr\w+\b").Matches(str))
                            Console.WriteLine(match.Value);
                        break;

                    case 3:
                        char[] cstr = "абвгдежз ий.КЛМНОПРС/ТУФхцчшщъыьэю00 яЯ".ToCharArray();

                        for (int i = 0; i < cstr.Length; i++)
                        {
                            if (Char.IsLetter(cstr[i]))
                            {
                                if (cstr[i] != 'я' && cstr[i] != 'Я')
                                {
                                    cstr[i] += (char)1;
                                }
                                else
                                {
                                    if (Char.IsLower(cstr[i]))
                                        cstr[i] = 'а';
                                    else
                                        cstr[i] = 'А';
                                }
                            }
                        }

                        Console.WriteLine(cstr);
                        break;

                    case 4:
                        str = "Однако вы не можете ограничить строковую переменную, чтобы она принимала только n-символьные строки. Если вы определяете строковую переменную, ей может быть присвоена любая строка.".Substring(0, 80);
                        cstr = "БВГДЖЗЙКЛМНПРСТФХЧЦШЩ".ToCharArray();
                        for (int i = 0; i < cstr.Length; i++)
                        {
                            int count = 0;
                            foreach (Match match in new Regex(@"\b\w{2,}\b").Matches(str))
                            {
                                if (new Regex(cstr[i].ToString(), RegexOptions.IgnoreCase).IsMatch(match.Value))
                                {
                                    count++;
                                }
                            }
                            if (count == 2)
                                Console.Write(cstr[i] + " ");
                        }
                        Console.WriteLine();
                        break;

                    case 5:
                        str = "Однако вы не можете ограничить строковую переменную, чтобы она принимала только n-символьные строки. Если вы определяете строковую переменную, ей может быть присвоена любая строка.".Substring(0, 80);
                        cstr = "БВГДЖЗЙКЛМНПРСТФХЧЦШЩ".ToCharArray();
                        int[] arr = new int[cstr.Length];
                        foreach (Match match in new Regex(@"\b\w{2,}\b").Matches(str))
                        {
                            for (int i = 0; i < cstr.Length; i++)
                            {
                                if (new Regex(cstr[i].ToString(), RegexOptions.IgnoreCase).IsMatch(match.Value))
                                {
                                    arr[i]++;
                                }
                            }
                        }
                        for (int i = 0; i < arr.Length; i++)
                            if (arr[i] == 2)
                                Console.Write(cstr[i] + " ");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}