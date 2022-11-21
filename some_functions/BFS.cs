static int[] BFS(int[,] arr, int start)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);

    int[] nodes = new int[arr.GetLength(0)];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        nodes[i] = 0;
    }

    int[] path = new int[arr.GetLength(0)];
    int count = 0;

    while (queue.Count != 0)
    {
        int node = queue.Dequeue();
        nodes[node] = 2;
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            if (arr[node, j] == 1 && nodes[j] == 0)
            {
                queue.Enqueue(j);
                nodes[j] = 1;
            }
        }
        path[count++] = node;
    }
    return path;
}