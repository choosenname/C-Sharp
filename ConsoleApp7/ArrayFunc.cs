using System;

namespace SomeFunc
{
    static internal class ArrayFunc
    {

        static internal void EnterArr(out int[] arr, int n)
        {
            arr = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(-99, 100);
        }

        static internal void EnterArr(out int[,] arr, int n, int m)
        {
            arr = new int[n, m];
            Random rnd = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = rnd.Next(-99, 100);
        }

        static internal void EnterArr(out double[] arr, int n)
        {
            arr = new double[n];
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(-99, 100) + Math.Round(rnd.NextDouble(), 2);
        }

        static internal void EnterArr(out double[,] arr, int n, int m)
        {
            arr = new double[n, m];
            Random rnd = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = rnd.Next(-99, 100) + Math.Round(rnd.NextDouble(), 2);
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
