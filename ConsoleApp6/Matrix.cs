using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ArrayFunc;

namespace ConsoleApp6
{
    internal class Matrix
    {
        int[,] array;

        public static event Parallelogram.ExceptionHandler ExceptionNotify;

        public int[,] Array
        {
            get => array;
            set
            {
                try
                {
                    if (value.Rank != 2) throw new ArgumentException("Число измерений матрицы должно быть 2");
                    else if (value.GetLength(0) != value.GetLength(1)) throw new ArgumentException("Матрица должна быть квадратичной");
                    array = value;
                }
                catch(ArgumentException ex)
                {
                    ExceptionNotify?.Invoke(ex);
                    array = null;
                }
                catch (Exception ex)
                {
                    ExceptionNotify?.Invoke(ex);
                }
            }
        }

        public Matrix(int[,] array)
        {
            Array = array;
        }

        public Matrix()
        {
            array = null;
        }

        public void EnterArr()
        {
            Random random = new Random();
            int size = random.Next(1, 5);
            ArrayFunc.ArrayFunc.EnterArr(out array, size, size);
        }

        public bool IsOrthonormal()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    for (int k = 0; k < array.GetLength(0); k++)
                    {
                        sum += array[i, k] * array[j, k];
                    }
                    if (i == j)
                    { if (sum != 1) return false; }
                    else
                    { if (sum != 0) return false; }

                    sum = 0;
                }
            }
            return true;
        }
    }
}
