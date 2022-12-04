using Exception;
using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    internal class Students
    {
        List<Student> students;

        public static ShowExeptionFunc ShowExeption;

        public Students(List<Student> students)
        {
            this.students = students;
        }

        public void Show()
        {
            try
            {
                if (students == null) throw new StudentNullReferenceException();

                foreach (var student in this.students)
                {
                    Console.WriteLine(student);
                }
            }
            catch (StudentNullReferenceException ex)
            {
                ShowExeption(ex);
            }
            catch (System.Exception ex)
            {
                ShowExeption(ex);
            }
        }

        int[] FindDependence()
        {
            int[] dependenceArr = new int[Enum.GetNames(typeof(HourTypeEnum)).Length - 1];
            try
            {
                if (students == null) throw new StudentNullReferenceException();


                foreach (var student in this.students)
                {
                    HourTypeEnum tmp = student.PriorityOccupation().HourType;
                    if (dependenceArr[(int)tmp] == 0)
                        dependenceArr[(int)tmp] = student.AverageScore;
                    else
                    {
                        dependenceArr[(int)tmp] += student.AverageScore;
                        dependenceArr[(int)tmp] /= 2;
                    }

                }
            }
            catch (StudentNullReferenceException ex)
            {
                ShowExeption(ex);
            }
            catch (System.Exception ex)
            {
                ShowExeption(ex);
            }
            return dependenceArr;
        }

        (HourTypeEnum, int) FindMaxPrior(int[] dependenceArr)
        {
            try
            {
                if (dependenceArr == null) throw new StudentNullReferenceException();

                HourTypeEnum type = 0;
                int max = dependenceArr[0];
                for (int i = 1; i < dependenceArr.Length; i++)
                {
                    if (dependenceArr[i] > max)
                    {
                        max = dependenceArr[i];
                        type = (HourTypeEnum)i;
                    }
                }
                return (type, max);
            }
            catch (StudentNullReferenceException ex)
            {
                ShowExeption(ex);
            }
            catch (System.Exception ex)
            {
                ShowExeption(ex);
            }
            return (0, 0);
        }

        public void ShowDependence()
        {
            try
            {
                int[] dependenceArr = FindDependence();

                for (int i = 0; i < dependenceArr.Length; i++)
                {
                    if (dependenceArr[i] != 0)
                        Console.WriteLine("У учеников с приоритетом {0} средний бал {1}", Enum.GetNames(typeof(HourTypeEnum))[i], dependenceArr[i]);
                }

                var touple = FindMaxPrior(dependenceArr);
                if (touple.Item2 == 0) Console.WriteLine("Зависимости нет");
                else Console.WriteLine("У учеников которые больше времени уделяли {0} наибольший средний балл", touple.Item1.ToString());
            }
            catch (StudentNullReferenceException ex)
            {
                ShowExeption(ex);
            }
            catch (System.Exception ex)
            {
                ShowExeption(ex);
            }
        }
    }
}
