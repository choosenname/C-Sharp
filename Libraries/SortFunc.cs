namespace SomeFunc
{
    static public class SortFunc
    {
        static void Merge(int[] arr, int first, int middle, int last)
        {
            int n1 = middle - first + 1;
            int n2 = last - middle;

            int[] left = new int[n1];
            int[] right = new int[n2];

            int i = 0, j = 0;
            for (; i < n1; i++)
                left[i] = arr[first + i];

            for (; j < n2; j++)
                right[j] = arr[middle + 1 + j];

            i = 0; j = 0; int k = first;
            for (; i < n1 && j < n2; k++)
                if (left[i] <= right[j])
                    arr[k] = left[i++];
                else
                    arr[k] = right[j++];

            while (i < n1)
                arr[k++] = left[i++];

            while (j < n2)
                arr[k++] = right[j++];
        }

        public static void MergeSort(int[] arr, int first, int last)
        {
            if (first < last)
            {
                int middle = first + (last - first) / 2;

                MergeSort(arr, first, middle);

                MergeSort(arr, middle + 1, last);

                Merge(arr, first, middle, last);
            }
        }

        public static int[] ShelSort(int[] arr)
        {
            int count = 0;
            for (int i = arr.Length; i > 0; i = i / 2)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    for (int k = j; k > -1; k = k - i)
                    {
                        if (arr[k] > arr[k + i])
                        {
                            int tmp = arr[k];
                            arr[k] = arr[k + i];
                            arr[k + i] = tmp;
                            count++;
                        }
                        else
                        {
                            k = 0;
                        }
                    }
                }
            }
            return arr;
        }
    }
}