using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace КПиЯП
{
    internal class Car
    {
        int number;
        string lastName;

        public Color Color { get; set; }

        public bool IsOnParking { get; set; }

        public int Number
        {
            get => number;
            set
            {
                try
                {
                    if (value > 9999) throw new InvalidArgumentExeption("Номер может состоять только из 4 цифр");
                    number = value;
                }
                catch (InvalidArgumentExeption ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (CarExeption ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                try
                {
                    Regex regex = new Regex(@"\b[А-Я][а-я]{2,31}\b");
                    if (!regex.IsMatch(value)) throw new InvalidArgumentExeption("Фамилия водителя должна начинаться с большой буквы и содержать от 3 до 32 символов");
                    lastName = value;
                }
                catch (InvalidArgumentExeption ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (CarExeption ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Car(int number, string lastName, Color color, bool isOnParking)
        {
            Number = number;
            LastName = lastName;
            Color = color;
            IsOnParking = isOnParking;
        }

        public override string ToString()
        {
            return $"Машина с номером {number}, фамилия водителя {lastName}, с цветом {Color.ToKnownColor()}, {(IsOnParking ? "находиться" : "не находиться")} на парковке";
        }
    }
}
