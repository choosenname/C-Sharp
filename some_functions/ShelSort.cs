static int[] ShelSort(int[] arr)
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