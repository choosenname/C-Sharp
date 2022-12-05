using System;
using SomeFunc;

namespace ConsoleApp7
{
    internal class OneDimensional
    {
        int[] arr;

        public OneDimensional(int n)
        {
            ArrayFunc.EnterArr(out arr, n);
        }

        public OneDimensional(int[] arr)
        {
            Arr = arr;
        }

        public int[] Arr
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

        public int Average()
        {
            int sum = 0;
            for (int i = 0; i < Arr.Length; i++) { sum += Math.Abs(Arr[i]); }

            return sum / Arr.Length;
        }

        public void SortMoreThenAverage()
        {
            int av = Average();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < av) continue;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < av) continue;
                    if (arr[i] > arr[j])
                    {
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                    }
                }
            }
        }

        public void SpecialSort()
        {

        }

        public static void ShowExeption(System.Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
