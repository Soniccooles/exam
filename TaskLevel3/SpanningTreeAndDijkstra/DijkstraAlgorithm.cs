using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel3.SpanningTreeAndDijkstra
{
    internal class DijkstraAlgorithm
    {
        public static void Dijkstra(int[,] graph, int startVertex)
        {
            int vertices = graph.GetLength(0);
            int[] key = new int[vertices];
            bool[] included = new bool[vertices];
            for (int i = 0; i < vertices; i++)
            {
                key[i] = int.MaxValue;
                included[i] = false;
            }
            key[startVertex] = 0;
            for (int count = 0; count < vertices - 1; count++)
            {
                int u = MinDistance(key, included, vertices);
                included[u] = true;
                for (int v = 0; v < vertices; v++)
                {
                    if (!included[v] && graph[u, v] != 0 && key[u] != int.MaxValue && key[u] + graph[u, v] < key[v])
                    {
                        key[v] = key[u] + graph[u, v];
                    }
                }
            }
            PrintSolution(key, vertices);
        }
        private static int MinDistance(int[] key, bool[] included, int vertices)
        {
            int min = int.MaxValue, minIndex = -1;
            for (int v = 0; v < vertices; v++)
            {
                if (!included[v] && key[v] <= min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        private static void PrintSolution(int[] distances, int vertices)
        {
            Console.WriteLine("Вершина \t Расстояние от источника");
            for (int i = 0; i < vertices; i++)
                Console.WriteLine($"{i} \t\t {distances[i]}");
        }
    }
}
