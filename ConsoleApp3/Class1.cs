using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            int[] nums2 = { 1, 1, 0, 0, 4, 5, 0, 10, 1, 0, 19, 120, 120 };

            int first = 0;
            int end = nums2.Length - 1;
            int result = 0;

            for (int i = 0; i < nums2.Length; i++)
            {
                if (nums2[i] == 0)
                {
                    first = i;
                    break;
                }
            }

            for (int i = nums2.Length - 1; i > -1; i--)
            {
                if (nums2[i] == 0)
                {
                    end = i;
                    break;
                }
            }

            for(int i = first; i < end; i++)
            {
                result += nums2[i];
            }

            Console.WriteLine(result);
        }
    }
}
