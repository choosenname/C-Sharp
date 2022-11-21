static void DFS(int[,] graph, bool[] visited, int st)
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
static void Main(string[] args)
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
}