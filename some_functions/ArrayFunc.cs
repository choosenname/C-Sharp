using System;

namespace SomeFunc
{
    static internal class ArrayFunc
    {
        static Random random = new Random();
        static internal void EnterArr(out int[] arr, int n)
        {
            arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(-99, 100);
        }

        static internal void EnterArr(out int[,] arr, int n, int m)
        {
            arr = new int[n, m];

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = random.Next(-99, 100);
        }

        static internal void EnterArr(out double[] arr, int n)
        {
            arr = new double[n];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(-99, 100) + Math.Round(random.NextDouble(), 2);
        }

        static internal void EnterArr(out double[,] arr, int n, int m)
        {
            arr = new double[n, m];

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = random.Next(-99, 100) + Math.Round(random.NextDouble(), 2);
        }

        static internal void OutArr<T>(T[] arr)
        {
            if (arr is null || arr.Length is 0) return;
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        static internal void OutArr<T>(T[,] arr)
        {
            if (arr is null || arr.Length is 0) return;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
