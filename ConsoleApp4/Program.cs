using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp4
{
    internal class Program
    {
        static string path = @"C:\Users\admin\Desktop\Labsы\input.txt";
        static string path1 = @"C:\Users\admin\Desktop\Labsы\output.txt";

        struct Student : IComparable
        {
            public string Name;
            public int Course;
            public string GroupNumber;
            public TimeSpan RaceResult;

            public Student()
            {
                Name = String.Empty;
                Course = 0;
                GroupNumber = String.Empty;
                RaceResult = TimeSpan.Zero;
            }

            public Student(string name, int course, string groupNumber, TimeSpan raceResult)
            {
                Name = name;
                Course = course;
                GroupNumber = groupNumber;
                RaceResult = raceResult;
            }

            public int CompareTo(Student other)
            {
                return RaceResult.CompareTo(other.RaceResult);
            }

            public int CompareTo(object obj)
            {
                return RaceResult.CompareTo(((Student)obj).RaceResult);
            }

            public override string ToString()
            {
                return $"{Name} учиться в группе {GroupNumber} на {Course} курсе, результат забега: {RaceResult}";
            }
        }

        static void Main()
        {
            ArrayList students = new ArrayList();
            ReadFile(students);

            students.Sort();
            foreach (var i in students)
            {
                Console.WriteLine(i);
            }
            WriteFile(students);
        }

        static void ReadFile(ArrayList students)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                ArrayList arr = new ArrayList();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //Console.WriteLine(i);
                    var a = line.Split(new string[] { ", " }, StringSplitOptions.None);
                    var b = a[3].Split(new char[] { ':' });
                    students.Add(new Student(a[0], Convert.ToInt32(a[1]), a[2], new TimeSpan(Convert.ToInt32(b[0]), Convert.ToInt32(b[1]), Convert.ToInt32(b[2]))));
                }
            }
        }

        static void WriteFile(ArrayList students)
        {
            using (StreamWriter writer = new StreamWriter(path1, false, System.Text.Encoding.UTF8))
            {
                for (int i = 0; i < 3; i++)
                {
                    writer.WriteLine(students[i]);
                }
                for (int i = 3; i < students.Count; i++)
                {
                    if (((Student)students[2]).RaceResult != ((Student)students[i]).RaceResult)
                    {
                        break;
                    }
                    writer.WriteLine(students[i]);
                }
            }
        }
    }
}