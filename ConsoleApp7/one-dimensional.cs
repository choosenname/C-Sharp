using SomeFunc;
using System;

namespace ConsoleApp7
{
    internal class OneDimensional
    {
        double[] arr;

        public OneDimensional(int n)
        {
            ArrayFunc.EnterArr(out arr, n);
        }

        public OneDimensional(double[] arr)
        {
            Arr = arr;
        }

        public double[] Arr
        {
            get => arr;
            set
            {
                try
                {
                    if (value == null) throw new ArgumentNullException();
                    arr = value;
                }
                catch (ArgumentNullException ex) { ShowExeption(ex); }
                catch (Exception ex) { ShowExeption(ex); }
            }
        }

        public void Show()
        {
            ArrayFunc.OutArr(arr);
            Console.WriteLine("-----------");
        }

        public double Average()
        {
            double sum = 0;
            for (int i = 0; i < Arr.Length; i++) { sum += Math.Abs(Arr[i]); }

            return sum / Arr.Length;
        }

        public delegate bool Difference(double x, double y);

        public void Sort(Difference difference)
        {
            try
            {
                double average = Average();
                Difference func;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (difference(arr[i], average)) func = (x, y) => x > y;
                    else func = (x, y) => x < y;

                    for (int j = i; j < arr.Length; j++)
                    {
                        if (func(arr[i], arr[j]))
                        {
                            (arr[i], arr[j]) = (arr[j], arr[i]);
                        }
                    }
                }
            }
            catch (NullReferenceException ex) { ShowExeption(ex); Sort((a, b) => a < b); }
            catch (Exception ex) { ShowExeption(ex); }
        }

        public delegate double Func(double a, double b);

        public void PreviousByNext(Func func)
        {
            arr[0] = func(arr[0], arr[arr.Length - 1]);
            for (int i = 1; i < arr.Length; i++)
                arr[i] = func(arr[i], arr[i - 1]);
        }

        public void ShowWithCurrency()
        {
            if (arr is null || arr.Length is 0) return;
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine("{0:C} ", arr[i]);
        }

        public static void ShowExeption(System.Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
