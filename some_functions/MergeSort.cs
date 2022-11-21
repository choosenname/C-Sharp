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
static void sort(int[] arr, int first, int last)
{
    if (first < last)
    {
        int middle = first + (last - first) / 2;

        sort(arr, first, middle);

        sort(arr, middle + 1, last);

        Merge(arr, first, middle, last);
    }
}