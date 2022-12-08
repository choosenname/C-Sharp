using System;

namespace SomeFunc
{
    public static class ArrayFunc
    {
        static Random random = new Random();
        public static void EnterArr(out int[] arr, int n)
        {
            arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(-99, 100);
        }

        public static void EnterArr(out int[,] arr, int n, int m = 1)
        {
            arr = new int[n, m];

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = random.Next(-99, 100);
        }

        public static void EnterArr(out byte[] arr, int n)
        {
            arr = new byte[n];

            random.NextBytes(arr);
        }

        public static void EnterArr(out double[] arr, int n)
        {
            arr = new double[n];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(-99, 100) + Math.Round(random.NextDouble(), 2);
        }

        public static void EnterArr(out double[,] arr, int n, int m = 1)
        {
            arr = new double[n, m];

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = random.Next(-99, 100) + Math.Round(random.NextDouble(), 2);
        }

        public static void PrintArr<T>(T[] arr)
        {
            if (arr is null || arr.Length is 0) return;
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        public static void PrintArr<T>(T[,] arr)
        {
            if (arr is null || arr.Length is 0) return;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
        }

        public static string OutArr<T>(T[] arr)
        {
            string str = null;
            if (arr is null || arr.Length is 0) return null;
            for (int i = 0; i < arr.Length; i++)
                str += arr[i] + " ";
            str = str.Remove(str.Length - 1, 1);
            return str;
        }

        public static string OutArr<T>(T[,] arr)
        {
            string str = null;
            if (arr is null || arr.Length is 0) return null;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    str += arr[i, j] + " ";
                str = str.Remove(str.Length - 1, 1);
                str += "\n";
            }
            str = str.Remove(str.Length - 1, 1);
            return str;
        }
    }
}
