using System;
using System.Collections.Generic;

namespace SomeFunc
{
    static public class GraphFunc
    {
        public static int[] BFS(int[,] arr, int start)
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

        public static void DFS(int[,] graph, bool[] visited, int st)
        {

            Console.Write(st + " ");
            visited[st] = true;
            for (int r = 0; r < graph.GetLength(0); r++)
            {
                if ((graph[st, r] != 0) && (!visited[r]))
                {
                    DFS(graph, visited, r);
                }
            }
        }

    /*static void Main(string[] args)
    {
        int[,] graph = new int[9, 9] {
        {0, 0, 0, 1, 0, 1, 0, 0, 0},
        {0, 0, 1, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 1, 1},
        {0, 0, 0, 0, 1, 0, 0, 0, 0},
        {0, 1, 0, 0, 0, 0, 1, 0, 0},
        {0, 0, 0, 0, 0, 0, 1, 0, 0},
        {0, 0, 1, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 1, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 1, 0, 0, 0} };
        bool[] visited = new bool[graph.GetLength(0)];

        Console.Write("Стартовая вершина: ");
        int start = Convert.ToInt32(Console.ReadLine());

        DFS(graph, visited, start);
        Console.ReadLine();
    }*/
    }
}