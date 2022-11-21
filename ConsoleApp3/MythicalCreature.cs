using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class MythicalCreature
    {
        private string name;
        private int weight;
        private int height;
        private bool sex;
        private int age;
        public string Name
        {
            set
            {
                Regex regex = new Regex(@"[A-Z]\w{2,15}");
                try
                {
                    if (!regex.IsMatch(value))
                    {
                        throw new Exception("Введенное имя не подходит");
                    }
                    else
                        name = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            get { return name; }
        }
        public int Weight
        {
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception("Вес не может быть меньше нуля");
                    }
                    else if (value > 10000)
                    {
                        throw new Exception("Вес не может быть больше 10т");
                    }
                    else
                        weight = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            get { return weight; }
        }
        public int Height
        {
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception("Рост не может быть меньше нуля");
                    }
                    else if (value > 5000)
                    {
                        throw new Exception("Рост не может быть больше 50м");
                    }
                    else
                        height = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            get { return height; }
        }
        public bool Sex
        {
            set { sex = value; }
            get { return sex; }
        }
        public int Age
        {
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception("Возраст не может быть меньше нуля");
                    }
                    else if (value > 10000)
                    {
                        throw new Exception("Возраст не может быть больше 10000 лет");
                    }
                    else
                        age = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            get { return age; }
        }
        internal MythicalCreature()
        {
            name = null;
            weight = 0;
            height = 0;
            sex = true;
            age = 0;
        }
        internal MythicalCreature(string name, int weight, int height, bool sex, int age)
        {
            Name = name;
            Weight = weight;
            Height = height;
            Sex = sex;
            Age = age;
        }
        ~MythicalCreature()
        {
            Console.WriteLine($"Класс MythicalCreature с параметрами {this} удален");
        }
        public override string ToString()
        {
            return $"Имя {name}, вес {weight}, рост {height}, пол " + (sex ? "мужской" : "женский") + $", возраст {age}";
        }
        public void EnterObject()
        {
            Console.WriteLine("Введите имя");
            Name = Console.ReadLine();
            
            Console.WriteLine("Введите вес");
            Weight = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите рост");
            Height = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите пол (true - мужчина, false - женщина)");
            Sex = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Введите возраст");
            Age = Convert.ToInt32(Console.ReadLine());
        }
        public void RandEnterObject(int seed)
        {
            Random rnd = new Random(seed);
            Name = "Ber" + rnd.Next('a', 'z');

            Weight = rnd.Next(10, 60);

            Height = rnd.Next(20, 90);

            Sex = Convert.ToBoolean(rnd.Next());

            Age = rnd.Next(23, 76);
        }
    }
}