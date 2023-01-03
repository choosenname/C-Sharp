using ConsoleApp2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace КПиЯП
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(ConvertStr("abc#d##c"));

            string path = @"C:\Users\admin\Desktop\Labsы\Students.xml";
            WriteFile(15, path);
            ReadFile(path);
        }

        static void ShowQueue(Queue queue)
        {  
            foreach(var item in queue)
            {
                Console.WriteLine(item);
            }
        }

        static string ConvertStr(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var i in str)
            {
                if (i == '#')
                    stack.Pop();
                else
                    stack.Push(i);
            }

            char[] arr = stack.ToArray();
            Array.Reverse(arr);
            str = new string(arr);

            return str;
        }

        static void WriteFile(int count, string path)
        {
            Random random = new Random();
            Student[] students = new Student[count];

            for (int i = 0; i < count; i++)
            {
                students[i] = new Student(random);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student[]));

            using (FileStream fl = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fl, students);
            }
        }

        static void ReadFile(string path)
        {
            XmlSerializer xmlDeserializer = new XmlSerializer(typeof(Student[]));
            Queue queue1 = new Queue();
            Queue queue2 = new Queue();

            using (FileStream fl = new FileStream(path, FileMode.Open))
            {
                Student[] students = xmlDeserializer.Deserialize(fl) as Student[];

                foreach (var item in students)
                {
                    if (item.SuccStud())
                        queue1.Enqueue(item);
                    else
                        queue2.Enqueue(item);
                }
            }

            ShowQueue(queue1);
            ShowQueue(queue2);
        }
    }
}