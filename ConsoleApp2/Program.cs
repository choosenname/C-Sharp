using System;
using System.Drawing;

namespace КПиЯП
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarPark carPark = new CarPark(new Car[] {
                new Car(4578, "Игорь Брусков", Color.Aqua, true),
                new Car(5236, "аебров", Color.Tan, false),
                new Car(778, "Курсед", Color.Magenta, true) });

            Console.WriteLine("Найти машину с водителем Бебров " + carPark.FindCars(car => car.LastName == "Бебров"));

            Console.WriteLine("Вывести все машины на парковке");
            carPark.ShowCars(car => car.IsOnParking);

            Console.WriteLine("----------");
            carPark[2] = new Car(1488, "Боб", Color.Azure, false);
            Console.WriteLine(carPark[2]);
        }
    }
}
