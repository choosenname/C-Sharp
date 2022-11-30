using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class CarPark
    {
        Car[] cars;

        public Car[] Cars
        {
            get => cars;
            set
            {
                try
                {
                    if (value == null) throw new CarArgumentNullException("Массив машин не должен быть пустым");
                    cars = value;
                }
                catch(CarArgumentNullException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public CarPark(Car[] cars)
        {
            Cars = cars;
        }

        public delegate bool FindCarsFunc(Car car);

        public Car FindCars(FindCarsFunc func)
        {
            try
            {
                if (func == null) throw new CarArgumentNullException("Функция должна содержать определение");
                foreach (Car car in cars)
                {
                    if (func(car)) return car;
                }
            }
            catch (CarArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CarExeption ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void ShowCars(FindCarsFunc func)
        {
            try
            {
                if (func == null) throw new CarArgumentNullException("Функция должна содержать определение");
                foreach (Car car in cars)
                {
                    if (func(car)) Console.WriteLine(car);
                }
            }
            catch (CarArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CarExeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowAllCars() { foreach (Car car in cars) Console.WriteLine(car); }

        public Car this[int index]
        {
            get => cars[index];
            set
            {
                try
                {
                    if (value == null) throw new CarArgumentNullException("Машина не должен быть пустой");
                    cars[index] = value;
                }
                catch (CarArgumentNullException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
